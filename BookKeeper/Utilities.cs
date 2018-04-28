using BookKeeper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
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

        public static async Task AddBook(Book book)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            SQLiteCommand command = new SQLiteCommand(string.Format("select Username, Name, RA, Country, Site, PhoneNumber, Email from Users where Username=\"{0}\"", book))
            {
                Connection = connection
            };
            SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
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
    }
}