using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace BookKeeper
{
    public partial class BookDetailsDialog : UserControl
    {
        public BookDetailsDialog()
        {
            InitializeComponent();
            LentTo_ListView.SelectedIndexChanged += LentTo_ListView_SelectedIndexChanged;
        }

        private void LentTo_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Return_Buton.Enabled = (LentTo_ListView.SelectedIndices.Count == 1);
        }

        public BookDetailsDialog(Book book, List<BookLoan> loans) : this()
        {
            _Book = book;
            Loans = loans;
            Title_Label.Text = book.Title;
            Author_Label.Text = book.Author;
            Description_Label.Text = book.Description;
            Tumbnail_PicureBox.Image = book.Image;
            QuantityAvailable_Label.Text = "Quanity available: " + (QuantityAvailable = book.QuantityAvailable);
        }

        public event EventHandler<BookLoan> BookLent;
        protected virtual void OnBookLent(BookLoan e) => BookLent?.Invoke(this, e);

        private Book _Book { get; set; }

        private List<BookLoan> _Loans = new List<BookLoan>();
        private List<BookLoan> Loans
        {
            get
            {
                return _Loans;
            }
            set
            {
                LentTo_ListView.Items.Clear();
                foreach (BookLoan x in value)
                {
                    ListViewItem item = new ListViewItem(x.LoanerName);
                    item.SubItems.Add(x.LoanDate.ToShortDateString());
                    item.SubItems.Add(x.ReturnDate.ToShortDateString());
                    LentTo_ListView.Items.Add(item);
                }
                _Loans = value;
            }
        }

        private uint _QuantityAvailable = 0;
        private uint QuantityAvailable
        {
            get
            {
                return _QuantityAvailable;
            }
            set
            {
                LendBook_Button.Enabled = (value > 0);
                QuantityAvailable_Label.Text = "Quantity available:" + value;
                _QuantityAvailable = value;
            }
        }

        private void LendBook_Button_Click(object sender, EventArgs e)
        {
            LendBookDialog lendBookDialog = new LendBookDialog(_Book.ID);
            lendBookDialog.Text = "Lend \"" + _Book.Title + "\"";
            lendBookDialog.FormClosing += LendBookDialog_FormClosing;
            lendBookDialog.Save += LendBookDialog_Save;
            lendBookDialog.StartPosition = FormStartPosition.CenterScreen;
            lendBookDialog.TopMost = true;
            lendBookDialog.Show();
            LendBook_Button.Enabled = false;
        }

        async private void LendBookDialog_Save(object sender, BookLoan e)
        {
            try
            {
                await Database.AddBookLoanAsync(e);
                ListViewItem item = new ListViewItem(e.LoanerName);
                item.SubItems.Add(e.LoanDate.ToShortDateString());
                item.SubItems.Add(e.ReturnDate.ToShortDateString());
                LentTo_ListView.Items.Add(item);
                this.QuantityAvailable--;
                BookLent?.Invoke(this, e);
            }
            finally
            {
                LendBook_Button.Enabled = true;
            }
        }

        private void LendBookDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            LendBook_Button.Enabled = true;
        }

        private void Return_Buton_Click(object sender, EventArgs e)
        {

        }
    }
}
