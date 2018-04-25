using System;
using System.Data;
using System.IO;

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
    public static class Exceptions
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
}