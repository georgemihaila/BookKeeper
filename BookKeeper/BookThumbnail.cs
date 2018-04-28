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
        public BookThumbnail()
        {
            InitializeComponent();
        }

        public BookThumbnail(string title, string author, string description, uint quantity)
        {
            InitializeComponent();
            Title = title;
            Author = author;
            Description = description;
            QuantityAvailable = quantity;
        }

        public BookThumbnail(Book book)
        {
            InitializeComponent();
            Title = book.Title;
            Author = book.Author;
            Description = book.Description;
            QuantityAvailable = book.QuantityAvailable;
        }

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

        /// <summary>
        /// Gets or sets the description field of the control.
        /// </summary>
        public string Description
        {
            get
            {
                return Description_Label.Text;
            }
            set
            {
                Description_Label.Text = value;
            }
        }

        private Bitmap _ThumbnailBitmap = new Bitmap(1, 1);
        /// <summary>
        /// Gets or sets the thumbnail of the control.
        /// </summary>
        public Bitmap Thumbnai
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

        private void BookThumbnail_Click(object sender, EventArgs e)
        {
            Thumbnail_PictureBox.Image = new Bitmap(0,0);
        }

        private void BookThumbnail_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = (QuantityAvailable > 0) ? Color.Green : Color.Red;
        }

        private void BookThumbnail_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        
    }
}
