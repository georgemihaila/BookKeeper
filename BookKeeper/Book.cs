using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BookKeeper
{
    public class Book
    {
        /// <summary>
        /// Creates a new instance of the Book class.
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// Creates a new instance of the Book class.
        /// </summary>
        /// <param name="Title">The title of the book.</param>
        /// <param name="Author">The author of the book.</param>
        /// <param name="Description">The description of the book.</param>
        /// <param name="Category">The category of the book.</param>
        /// <param name="QuantityAvailable">The number of available books of this kind.</param>
        /// <param name="Image">The image for the book.</param>
        /// <param name="ID">The book's ID.</param>
        public Book(string Title, string Author, string Description, string Category, UInt32 QuantityAvailable, Bitmap Image, UInt32 ID) : this()
        {
            this.Title = Title;
            this.Author = Author;
            this.Description = Description;
            this.Category = Category;
            this.QuantityAvailable = QuantityAvailable;
            this.Image = Image;
            this.ID = ID;
        }

        /// <summary>
        /// Creates a new instance of the Book class.
        /// </summary>
        /// <param name="Title">The title of the book.</param>
        /// <param name="Author">The author of the book.</param>
        /// <param name="Description">The description of the book.</param>
        /// <param name="Category">The category of the book.</param>
        /// <param name="QuantityAvailable">The number of available books of this kind.</param>
        /// <param name="ImageLocation">The location of the book's image.</param>
        /// <param name="ID">The book's ID.</param>
        public Book(string Title, string Author, string Description, string Category, UInt32 QuantityAvailable, string ImageLocation, UInt32 ID) : this()
        {
            this.Title = Title;
            this.Author = Author;
            this.Description = Description;
            this.Category = Category;
            this.QuantityAvailable = QuantityAvailable;
            this.Image = new Bitmap(ImageLocation);
            this.ID = ID;
        }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        private string _Description = string.Empty;
        /// <summary>
        /// Gets or sets the description of the book.
        /// </summary>
        public string Description
        {
            get
            {
                return _Description.Base64Decode();
            }
            set
            {
                _Description = value.Base64Encode();
            }
        }

        public string Description_Base64 { get { return _Description; } set { _Description = value; } }

        /// <summary>
        /// Gets or sets the category of the book.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the available quantity of the book.
        /// </summary>
        public UInt32 QuantityAvailable { get; set; }

        /// <summary>
        /// Gets or sets the image of the book.
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public UInt32 ID { get; set; }
    }
}
