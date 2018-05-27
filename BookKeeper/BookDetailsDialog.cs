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
            Return_Button.Enabled = (LentTo_ListView.SelectedIndices.Count == 1);
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

        public event EventHandler<BookLoan> BookReturned;
        protected virtual void OnBookReturned(BookLoan e) => BookReturned?.Invoke(this, e);

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

        async private void Return_Buton_Click(object sender, EventArgs e)
        {
            try
            {
                Return_Button.Enabled = false;
                List<BookLoan> selectedBookLoans = Loans.Where(o => o.GetHashCode() == Loans[LentTo_ListView.SelectedIndices[0]].GetHashCode()).ToList();
                if (selectedBookLoans.Count == 1)
                {
                    await Database.RemoveBookLoanAsync(selectedBookLoans[0]);
                    Loans.Remove(selectedBookLoans[0]);
                    QuantityAvailable++;
                    LentTo_ListView.Items.Clear();
                    foreach (BookLoan x in Loans)
                    {
                        ListViewItem item = new ListViewItem(x.LoanerName);
                        item.SubItems.Add(x.LoanDate.ToShortDateString());
                        item.SubItems.Add(x.ReturnDate.ToShortDateString());
                        LentTo_ListView.Items.Add(item);
                    }
                    BookReturned?.Invoke(this, selectedBookLoans[0]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select an item from the list first", "Error");
            }
            finally
            {
                Return_Button.Enabled = true;
            }
        }

        private ListSortDirection BookLoans_SortDirection { get; set; } = ListSortDirection.Descending;
        private int BookLoans_LastColumnIndex { get; set; } = 0;

        private void LentTo_ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == BookLoans_LastColumnIndex) BookLoans_SortDirection = (BookLoans_SortDirection == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            BookLoans_LastColumnIndex = e.Column;
            switch (e.Column)
            {
                case 0:
                    Loans = (BookLoans_SortDirection == ListSortDirection.Ascending) ? Loans.OrderBy(o => o.LoanerName).ToList() : Loans.OrderByDescending(o => o.LoanerName).ToList();
                    break;
                case 1:
                    Loans = (BookLoans_SortDirection == ListSortDirection.Ascending) ? Loans.OrderBy(o => o.LoanDate).ToList() : Loans.OrderByDescending(o => o.LoanDate).ToList();
                    break;
                case 2:
                    Loans = (BookLoans_SortDirection == ListSortDirection.Ascending) ? Loans.OrderBy(o => o.ReturnDate).ToList() : Loans.OrderByDescending(o => o.ReturnDate).ToList();
                    break;
            }
            LentTo_ListView.Items.Clear();
            foreach (var x in Loans)
            {
                ListViewItem item = new ListViewItem(x.LoanerName);
                item.SubItems.Add(x.LoanDate.ToShortDateString());
                item.SubItems.Add(x.ReturnDate.ToShortDateString());
                LentTo_ListView.Items.Add(item);
            }
        }
    }
}
