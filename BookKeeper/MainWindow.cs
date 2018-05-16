using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Utilities;
using System.Reflection;
using System.Threading;
using System.Windows.Threading;

namespace BookKeeper
{
    public partial class MainWindow : Form
    {

        #region Initialization

        public MainWindow()
        {
            InitializeComponent();
            InitializeDirectories();
            SortByAuthor_RadioButton.Tag = Database.SortParameter.Author;
            SortByAuthor_RadioButton.CheckedChanged += Sort_RadioButton_CheckedChanged;
            SortByCategory_RadioButton.Tag = Database.SortParameter.Category;
            SortByCategory_RadioButton.CheckedChanged += Sort_RadioButton_CheckedChanged;
            SortByID_RadioButton.Tag = Database.SortParameter.ID;
            SortByID_RadioButton.CheckedChanged += Sort_RadioButton_CheckedChanged;
            SortByQtyAvailable_RadioButton.Tag = Database.SortParameter.QuantityAvailable;
            SortByQtyAvailable_RadioButton.CheckedChanged += Sort_RadioButton_CheckedChanged;
            SortByTitle_RadioButton.Tag = Database.SortParameter.Title;
            SortByTitle_RadioButton.CheckedChanged += Sort_RadioButton_CheckedChanged;
            SetupAsync();
        }


        #endregion

        #region Variables

        private readonly string[] AppDirectories = { "Data", "Cache" };
        private Random random = new Random();
        private int ThumbnailWidth { get; set; } = 250;
        private int ThumbnailHeight { get; set; } = 150;
        private int ThumbnailSpacing { get; set; } = 20;
        private int previousPerRow = 0;
        private Database.SortParameter _SortParameter = Database.SortParameter.Title;
        private List<Book> Books { get; set; } = new List<Book>();
        private List<BookThumbnail> BookThumbnails = new List<BookThumbnail>();
        private readonly Dispatcher UIDispatcher = Dispatcher.CurrentDispatcher;
        private CancellationToken RefreshCancellationToken { get; set; } = CancellationToken.None;
        private bool RefreshActive { get; set; } = false;
        private CancellationToken SearchCancellationToken { get; set; } = CancellationToken.None;
        private bool SearchActive { get; set; } = false;

        #endregion

        #region Methods

        /// <summary>
        /// Creates the directories required for the application to run properly if they don't exist.
        /// </summary>
        private void InitializeDirectories()
        {
            foreach (string folder in AppDirectories)
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
        }

        private async void SetupAsync()
        {
            await RefreshMainPanelAsync();
        }

        /// <summary>
        /// Refreshes the list of books from the database and updates the main panel asynchronously. The task can be canceled by using the RefreshCancellationToken CancellationToken."
        /// </summary>
        /// <returns></returns>
        private async Task RefreshMainPanelAsync()
        {
            if (Database.Exists)
            {
                try
                {
                    RefreshActive = true;
                    await Task.Run(async () =>
                    {
                        UIDispatcher.Invoke(() =>
                        {
                            StatusLabel.Text = "Ready";
                        });
                        Books = await Database.GetAllBooksAsync(_SortParameter, Database.SortDirection.Asc);
                        int xIndex = 0;
                        int yIndex = 0;
                        int perRow = previousPerRow = 0;
                        UIDispatcher.Invoke(() =>
                        {
                            perRow = previousPerRow = MainPanel.Width / (ThumbnailSpacing + ThumbnailWidth);
                            MainPanel.Controls.Clear();
                        });
                        int currentIndex = 0;
                        foreach (Book book in Books)
                        {
                            BookThumbnail thumbnail = new BookThumbnail(book)
                            {
                                Height = 150,
                                Width = 250,
                                Top = yIndex * (ThumbnailHeight + ThumbnailSpacing),
                                Left = xIndex * (ThumbnailWidth + ThumbnailSpacing)
                            };
                            BookThumbnails.Add(thumbnail);
                            if (++xIndex >= perRow)
                            {
                                xIndex = 0;
                                yIndex++;
                            }
                            UIDispatcher.Invoke(() =>
                            {
                                MainPanel.Controls.Add(thumbnail);
                                StatusLabel.Text = string.Format("Loading \"{2}\" ({0}/{1})...", ++currentIndex, Books.Count, book.Title);
                            });
                        }
                        UIDispatcher.Invoke(() =>
                        {
                            StatusLabel.Text = MainPanel.Controls.Count + " items";
                        });
                    }, RefreshCancellationToken);
                }
                catch
                {
                    MainPanel.Controls.Clear();
                }
                finally
                {
                    RefreshCancellationToken = CancellationToken.None;
                    RefreshActive = false;
                }
            }
            else
            {
                StatusLabel.Text = "Database file does not exist!";
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            ResizeAll();
        }

        private void ResizeAll()
        {
            //MainPanel
            int xIndex = 0;
            int yIndex = 0;
            int perRow = MainPanel.Width / (ThumbnailSpacing + ThumbnailWidth);
            if (previousPerRow == perRow)
                return;
            previousPerRow = perRow;
            foreach (BookThumbnail thumbnail in MainPanel.Controls)
            {
                thumbnail.Top = yIndex * (ThumbnailHeight + ThumbnailSpacing);
                thumbnail.Left = xIndex * (ThumbnailWidth + ThumbnailSpacing);
                if (++xIndex >= perRow)
                {
                    xIndex = 0;
                    yIndex++;
                }
            }
        }

        private async Task SearchAsync(string s)
        {
            try
            {
                SearchActive = true;
                await Task.Run(() =>
                {

                });
            }
            catch
            {
            }
            finally
            {
                RefreshCancellationToken = CancellationToken.None;
                SearchActive = false;
            }
        }
        
        #endregion

        #region Input handling

        #region Menu

        private void NewLoan_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Settings_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Exit_MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {
            (new About()).Show();
        }

        #endregion

        /// <summary>
        /// Updates the title of the window according to the tab the user has navigated to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "BookKeeper - " + (sender as TabControl).SelectedTab.Text;
        }

        private void Search_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Refresh_Button_Click(object sender, EventArgs e)
        {
            await RefreshMainPanelAsync();
        }

        async private void Sort_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RefreshActive)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                RefreshCancellationToken = cancellationTokenSource.Token;
                cancellationTokenSource.Cancel();
            }
            await RefreshMainPanelAsync();
        }

        private void Print_MenuItem_Click(object sender, EventArgs e)
        {

        }

        [LengthCanBeImproved]
        private void NewBook_MenuItem_Click(object sender, EventArgs e)
        {

            ContextMenu contextMenu = new ContextMenu();

            TabPage newBookPage = new TabPage()
            {
                Text = "New book",
                BackColor = Color.White,
                ContextMenu = contextMenu,
                Tag = MainTabControl.Controls.Count
            };

            MenuItem closeThisOneMenuItem = new MenuItem() { Text = "Close this tab" };
            closeThisOneMenuItem.Tag = MainTabControl.Controls.Count;
            closeThisOneMenuItem.Click += (cmiSender, cmiE) =>
            {
                MainTabControl.SelectedIndex = (int)(cmiSender as MenuItem).Tag - 1;
                MainTabControl.Controls.RemoveAt((int)(cmiSender as MenuItem).Tag);
            };
            contextMenu.MenuItems.Add(closeThisOneMenuItem);

            MenuItem closeAllMenuItem = new MenuItem() { Text = "Close all tabs" };
            closeAllMenuItem.Tag = MainTabControl.Controls.Count;
            closeAllMenuItem.Click += (cmiSender, cmiE) =>
            {
                while (MainTabControl.Controls.Count > 2)
                {
                    MainTabControl.Controls.RemoveAt(2);
                }
            };
            contextMenu.MenuItems.Add(closeAllMenuItem);

            NewBook newBookControl = new NewBook();
            newBookPage.Controls.Add(newBookControl);

            MainTabControl.Controls.Add(newBookPage);
            MainTabControl.SelectedIndex = MainTabControl.Controls.Count - 1;
        }

        /// <summary>
        /// Creates a new book loan TabPage, adds it to the main tabcontrol and creates a context menu for it that allows closing and printing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [LengthCanBeImproved]
        private void NewBookLoan_MenuItem_Click(object sender, EventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();

            TabPage newBookLoanPage = new TabPage()
            {
                Text = "New book loan",
                BackColor = Color.White,
                ContextMenu = contextMenu,
                Tag = MainTabControl.Controls.Count
            };

            MenuItem closeThisOneMenuItem = new MenuItem() { Text = "Close this tab" };
            closeThisOneMenuItem.Tag = MainTabControl.Controls.Count;
            closeThisOneMenuItem.Click += (cmiSender, cmiE) =>
            {
                MainTabControl.SelectedIndex = (int)(cmiSender as MenuItem).Tag - 1;
                MainTabControl.Controls.RemoveAt((int)(cmiSender as MenuItem).Tag);
            };
            contextMenu.MenuItems.Add(closeThisOneMenuItem);

            MenuItem closeAllMenuItem = new MenuItem() { Text = "Close all tabs" };
            closeAllMenuItem.Tag = MainTabControl.Controls.Count;
            closeAllMenuItem.Click += (cmiSender, cmiE) =>
            {
                while (MainTabControl.Controls.Count > 2)
                {
                    MainTabControl.Controls.RemoveAt(2);
                }
            };
            contextMenu.MenuItems.Add(closeAllMenuItem);
            /*
            MenuItem closeAllExceptMenuItem = new MenuItem() { Text = "Close all tabs except this one" };
            closeAllExceptMenuItem.Tag = MainTabControl.Controls.Count;
            closeAllExceptMenuItem.Click += (cmiSender, cmiE) =>
            {
                for (int i = 1; i < MainTabControl.Controls.Count; i++)
                {
                    if (i == (int)(cmiSender as MenuItem).Tag) continue;
                    MainTabControl.Controls.RemoveAt(i);
                }
            };
            contextMenu.MenuItems.Add(closeAllExceptMenuItem);*/

            MainTabControl.Controls.Add(newBookLoanPage);
            MainTabControl.SelectedIndex = MainTabControl.Controls.Count - 1;
        }
        #endregion
    }
}