using System;
using System.Windows.Forms;

namespace BookKeeper
{
    public class BookLoan
    {
        /// <summary>
        /// Creates a new instance of the BookLoan class.
        /// </summary>
        public BookLoan()
        {

        }

        /// <summary>
        /// Creates a new instance of the BookLoan class.
        /// </summary>
        /// <param name="LoanerName"></param>
        /// <param name="BookID"></param>
        /// <param name="LoanDate"></param>
        /// <param name="ReturnDate"></param>
        public BookLoan(string LoanerName, uint BookID, DateTime LoanDate, DateTime ReturnDate) : this()
        {
            this.LoanDate = LoanDate;
            this.LoanerName = LoanerName;
            this.BookID = BookID;
            this.ReturnDate = ReturnDate;
        }

        /// <summary>
        /// Gets or sets the loaner name.
        /// </summary>
        public string LoanerName { get; set; }

        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        public uint BookID { get; set; }

        /// <summary>
        /// Gets or sets the loan date.
        /// </summary>
        public DateTime LoanDate { get; set; }

        /// <summary>
        /// Gets or sets the return date.
        /// </summary>
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// Converts a BookLoan item to a ListViewItem.
        /// </summary>
        /// <returns></returns>
        public ListViewItem ToListViewItem()
        {
            ListViewItem listViewItem = new ListViewItem(this.BookID.ToString());
            listViewItem.SubItems.Add(this.LoanerName);
            listViewItem.SubItems.Add(this.LoanDate.ToShortDateString());
            listViewItem.SubItems.Add(this.ReturnDate.ToShortDateString());
            return listViewItem;
        }
    }
}
