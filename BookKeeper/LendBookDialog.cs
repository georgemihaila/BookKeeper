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
    public partial class LendBookDialog : Form
    {
        public LendBookDialog()
        {
            InitializeComponent();
            LoanDate_DateTimePicker.MinDate = DateTime.Today;
            ReturnDate_DateTimePicker.MinDate = LoanDate_DateTimePicker.Value.AddDays(1);
            ReturnDate_DateTimePicker.MaxDate = LoanDate_DateTimePicker.Value.AddDays(14);
        }

        public LendBookDialog(uint bookID) : this()
        {
            this.BookID = bookID;
        }

        private uint BookID { get; set; }
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
                BookID = BookID,
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
            Save_Buton.Enabled = !(Name_TextBox.Text.Trim() == string.Empty);
        }
        
    }
}
