using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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