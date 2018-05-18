using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookKeeper
{
    public partial class BookThumbnail : UserControl
    {
        [NotWorkingCorrectly]
        public BookThumbnail()
        {
            InitializeComponent();
            Details_Button.Click += (sender, e) => DetailsButtonClicked(sender, (Book)this);
            DetailsButton_InitialX = 107;
            Details_Button.Left = -135;
        }

        public BookThumbnail(string title, string author, string category, string description, uint quantity) : this()
        {
            Title = title;
            Author = author;
            Description = description;
            QuantityAvailable = quantity;
            Category = category;
        }

        public BookThumbnail(Book book) : this()
        {
            Title = book.Title;
            Author = book.Author;
            Description = book.Description;
            QuantityAvailable = book.QuantityAvailable;
            Thumbnail = book.Image;
            ID = book.ID;
            Category = book.Category;
        }

        private int DetailsButton_InitialX { get; set; } = 0;


        /// <summary>
        /// Gets or sets the category of the book thumbnail.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets the book ID.
        /// </summary>
        public uint ID { get; private set; }

        /// <summary>
        /// Gets or sets the title field of the control.
        /// </summary>
        public string Title
        {
            get
            {
                return Title_Label.Text;
            }
            set
            {
                Title_Label.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the author field of the control.
        /// </summary>
        public string Author
        {
            get
            {
                return Author_Label.Text;
            }
            set
            {
                Author_Label.Text = value;
            }
        }
        private uint _QuantityAvailable = 0;
        /// <summary>
        /// Gets or sets the quantity available field of the control.
        /// </summary>
        public uint QuantityAvailable
        {
            get
            {
                return _QuantityAvailable;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("The available quantity can't be smaller than 0.");
                _QuantityAvailable = value;
                QuantityAvailable_Label.Text = "Available: " + _QuantityAvailable;
                QuantityAvailable_Label.ForeColor = (_QuantityAvailable == 0) ? Color.Red : Color.Black;
            }
        }


        private string _Description = string.Empty;
        /// <summary>
        /// Gets or sets the description field of the control.
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                Description_Label.Text = _Description = value;
            }
        }

        private Bitmap _ThumbnailBitmap = new Bitmap(1, 1);
        /// <summary>
        /// Gets or sets the thumbnail of the control.
        /// </summary>
        public Bitmap Thumbnail
        {
            get
            {
                return _ThumbnailBitmap;
            }
            set
            {
                Thumbnail_PictureBox.Image = value;
                _ThumbnailBitmap = value;
            }
        }

        /// <summary>
        /// Event called when the user clicks the details button.
        /// </summary>
        public event EventHandler<Book> DetailsButtonClicked;
        protected virtual void OnDetailsButtonClicked(Book e) => DetailsButtonClicked?.Invoke(this, e);

        private void BookThumbnail_Click(object sender, EventArgs e)
        {

        }

        private void OnMouseOver()
        {
            this.BackColor = (QuantityAvailable > 0) ? Color.Green : Color.Red;
            QuantityAvailable_Label.ForeColor = (QuantityAvailable > 0) ? Color.Black : Color.White;
            Details_Button.Left = 107;
            Description_Label.Text = String.Empty;
            QuantityAvailable_Label.Text = String.Empty;
        }

        private void OnMouseLeave()
        {
            this.BackColor = Color.White;
            QuantityAvailable_Label.ForeColor = (QuantityAvailable > 0) ? Color.Black : Color.Red;
            Details_Button.Left = -135;
            Description_Label.Text = Description;
            QuantityAvailable_Label.Text = "Available: " + QuantityAvailable;
        }

        private void BookThumbnail_MouseEnter(object sender, EventArgs e)
        {
            OnMouseOver();
        }

        private void BookThumbnail_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave();
        }

        private void Element_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave();
        }

        private void Element_MouseEnter(object sender, EventArgs e)
        {
            OnMouseOver();
        }

        public static explicit operator Book(BookThumbnail thumbnail)
        {
            return new Book()
            {
                Author = thumbnail.Author,
                Description = thumbnail.Description,
                Category = thumbnail.Category,
                ID = thumbnail.ID,
                Image = thumbnail.Thumbnail,
                QuantityAvailable = thumbnail.QuantityAvailable,
                Title = thumbnail.Title
            };
        }
    }
}
