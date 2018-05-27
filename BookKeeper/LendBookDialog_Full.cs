using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookKeeper
{
    public partial class LendBookDialog_Full : Form
    {
        public LendBookDialog_Full()
        {
            InitializeComponent();
            LoanDate_DateTimePicker.MinDate = DateTime.Today;
            ReturnDate_DateTimePicker.MinDate = LoanDate_DateTimePicker.Value.AddDays(1);
            ReturnDate_DateTimePicker.MaxDate = LoanDate_DateTimePicker.Value.AddDays(14);
        }

        public LendBookDialog_Full(List<Book> Books) : this()
        {
            this.Books = Books;
        }

        private List<Book> _Books = new List<Book>();
        private List<Book> Books
        {
            get
            {
                return _Books;
            }
            set
            {
                _Books = value;
                Book_ComboBox.Items.Clear();
                foreach (var x in _Books)
                {
                    Book_ComboBox.Items.Add(x.Title);
                }
            }
        }
        private BookLoan _LoanerDetails = new BookLoan();

        private void LoanDate_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ReturnDate_DateTimePicker.MinDate = LoanDate_DateTimePicker.Value.AddDays(1);
            ReturnDate_DateTimePicker.MaxDate = LoanDate_DateTimePicker.Value.AddDays(14);
        }

        private void Save_Buton_Click(object sender, EventArgs e)
        {
            Save?.Invoke(this, _LoanerDetails = new BookLoan()
            {
                BookID = Books.Where(o => o.Title == Book_ComboBox.Items[Book_ComboBox.SelectedIndex].ToString()).ToList()[0].ID,
                LoanerName = Name_TextBox.Text.Trim(),
                ReturnDate = ReturnDate_DateTimePicker.Value,
                LoanDate = LoanDate_DateTimePicker.Value
            });
            this.Close();
        }

        public event EventHandler<BookLoan> Save;
        protected virtual void OnSave(BookLoan e) => Save?.Invoke(this, e);

        private void Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Save_Buton.Enabled = (!(Name_TextBox.Text.Trim() == string.Empty)) && (Book_ComboBox.SelectedIndex >= 0);
        }

        private void Book_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save_Buton.Enabled = (!(Name_TextBox.Text.Trim() == string.Empty)) && (Book_ComboBox.SelectedIndex >= 0);
        }
    }
}
