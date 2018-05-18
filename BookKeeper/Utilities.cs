using BookKeeper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    /// <summary>
    /// A class for handling database queries.
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// Gets the location of the database file.
        /// </summary>
        public static string Location { get { return "BookKeeperDatabase.db"; } }

        public static bool Exists { get { return File.Exists(Location); } }

        private static string ConnectionString { get { return string.Format("DataSource={0};Version=3;", Location); } }

        public static async Task AddBookAsync(Book book)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            SQLiteCommand command = new SQLiteCommand()
            {
                Connection = connection
            };
            command.CommandText = string.Format("insert into Books values (\"{0}\", \"{1}\", \"{2}\", \"{3}\", {4}, @img, {5});", book.Title, book.Author, book.Description, book.Category, book.QuantityAvailable, book.ID);
            command.Prepare();
            byte[] imageBytes = book.Image.ToByteArray();
            command.Parameters.Add("@img", DbType.Binary, imageBytes.Length);
            command.Parameters["@img"].Value = imageBytes;
            await command.ExecuteNonQueryAsync();
        }

        public enum SortParameter { Title, Author, Description, Category, QuantityAvailable, ID };
        public enum SortDirection { Asc, Desc };

        /// <summary>
        /// Retrieves all the books from the database asynchronously.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Book>> GetAllBooksAsync()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            SQLiteCommand command = new SQLiteCommand(string.Format("select * from books;"))
            {
                Connection = connection
            };
            SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            List<Book> Books = new List<Book>();
            while (await reader.ReadAsync())
            {
                Books.Add(new Book()
                {
                    Title = reader[0].ToString().Replace("\n", string.Empty),
                    Author = reader[1].ToString(),
                    Description = reader[2].ToString(),
                    Category = reader[3].ToString(),
                    QuantityAvailable = Convert.ToUInt32(reader[4].ToString()),
                    ID = Convert.ToUInt32(reader[6].ToString())
                });
            }
            return Books;
        }

        /// <summary>
        /// Retrieves all the books from the database asynchronously.
        /// </summary>
        /// <param name="SortBy">The parameter by which to sort the data.</param>
        /// <param name="SortDirection">The direction of the sorting.</param>
        /// <returns></returns>
        public static async Task<List<Book>> GetAllBooksAsync(SortParameter SortBy, SortDirection SortDirection = SortDirection.Asc)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            SQLiteCommand command = new SQLiteCommand(string.Format("select * from books order by {0} {1};", SortBy.ToString(), SortDirection.ToString()))
            {
                Connection = connection
            };
            SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            List<Book> Books = new List<Book>();
            while (await reader.ReadAsync())
            {
                Book book = new Book()
                {
                    Title = reader[0].ToString().Replace("\n", string.Empty),
                    Author = reader[1].ToString(),
                    Description = reader[2].ToString(),
                    Category = reader[3].ToString(),
                    QuantityAvailable = Convert.ToUInt32(reader[4].ToString()),
                    ID = Convert.ToUInt32(reader[6].ToString())
                };
                if (!File.Exists("Cache/" + book.ID + ".jpg"))
                    File.WriteAllBytes("Cache/" + book.ID + ".jpg", (byte[])reader[5]);
                book.Image = new System.Drawing.Bitmap("Cache/" + book.ID + ".jpg");
                Books.Add(book);
            }
            return Books;
        }

        /// <summary>
        /// Adds a book loan to the database asynchronously.
        /// </summary>
        /// <param name="bookLoan"></param>
        /// <returns></returns>
        public static async Task AddBookLoanAsync(BookLoan bookLoan)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            SQLiteCommand command = new SQLiteCommand(string.Format("insert into Loans values (\"{0}\", \"{1}\", \"{2}\", {3});", bookLoan.LoanerName, bookLoan.LoanDate.Ticks.ToString(), bookLoan.ReturnDate.Ticks.ToString(),bookLoan.BookID))
            {
                Connection = connection
            };
            SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Retrieves all the book loans from the databse asynchronously.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<BookLoan>> GetAllBookLoansAsync()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            SQLiteCommand command = new SQLiteCommand(string.Format("select * from Loans;"))
            {
                Connection = connection
            };
            SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            List<BookLoan> Loans = new List<BookLoan>();
            while (await reader.ReadAsync())
            {
                BookLoan bookLoan = new BookLoan()
                {
                    LoanerName = reader[0].ToString(),
                    LoanDate = new DateTime(Convert.ToInt64(reader[1].ToString())),
                    ReturnDate = new DateTime(Convert.ToInt64(reader[2].ToString())),
                    BookID = Convert.ToUInt32(reader[3].ToString())
                };
                Loans.Add(bookLoan);
            }
            return Loans;
        }
    }

    /// <summary>
    /// A class for handling exceptions.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Logs an exception to the Cache/exceptions.log file.
        /// </summary>
        /// <param name="e"></param>
        public static void Log(this Exception e)
        {
            File.AppendAllText("Cache/exceptions.log", string.Format("{0}{2}{2}{1}{2}{2}", DateTime.Now.ToString(), e.ToString(), Environment.NewLine));
        }
    }

    /// <summary>
    /// A class for managing strings.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Converts HTML code to plaintext.
        /// Source: https://stackoverflow.com/questions/286813/how-do-you-convert-html-to-plain-text
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string FromHTMLToPlainText(this string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        /// <summary>
        /// Formats a string in order for it to be used in a search query.
        /// The method returns the input string in uppercase, without any special characters and without any double, leading or ending spaces.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <returns></returns>
        public static string FormatForSearch(this string s)
        {
            s = s.ToUpper();
            while (s.Contains("  ")) s = s.Replace("  ", " ");
            while (s.EndsWith(" ")) s = s.Remove(s.Length - 1, 1);
            while (s.StartsWith(" ")) s = s.Remove(0, 1);
            s = new string(s.Where(c => Char.IsLetter(c) || c == ' ' || Char.IsNumber(c)).ToArray());
            return s;
        }
    }

    /// <summary>
    /// A class for managing images.
    /// </summary>
    public static class ImageHelper
    {
        public static byte[] ToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
    }
}