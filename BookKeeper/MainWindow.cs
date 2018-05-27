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
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace BookKeeper
{
    public partial class MainWindow : Form
    {

        #region Initialization

        public MainWindow()
        {
            InitializeComponent();
            InitializeDirectories();
            MenuItem closeThisOneMenuItem = new MenuItem() { Text = "Close this tab", Enabled = false };
            closeThisOneMenuItem.Click += (cmiSender, cmiE) =>
            {
                MainTabControl.Controls.RemoveAt(SelectedTabIndex);
            };
            MainContextMenu.MenuItems.Add(closeThisOneMenuItem);
            MenuItem closeAllMenuItem = new MenuItem() { Text = "Close all tabs", Enabled = false };
            closeAllMenuItem.Tag = MainTabControl.Controls.Count;
            closeAllMenuItem.Click += (cmiSender, cmiE) =>
            {
                while (MainTabControl.Controls.Count > 2)
                {
                    MainTabControl.Controls.RemoveAt(2);
                }
            };
            MainContextMenu.MenuItems.Add(closeAllMenuItem);
            MainTabControl.ContextMenu = MainContextMenu;
            SetupAsync();
        }


        #endregion

        #region Properties

        private readonly string[] AppDirectories = { "Data", "Cache", "Reports" };
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
        private List<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
        private ListSortDirection BookLoans_SortDirection { get; set; } = ListSortDirection.Descending;
        private int BookLoans_LastColumnIndex { get; set; } = 0;
        private ContextMenu MainContextMenu { get; set; } = new ContextMenu();
        private int SelectedTabIndex { get { return MainTabControl.SelectedIndex; } }
        private enum MainPanelRefreshMode { FromDatabase, Deserialization };

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
            await RefreshMainPanelAsync((File.Exists("Data/books.bin")) ? MainPanelRefreshMode.Deserialization : MainPanelRefreshMode.FromDatabase);
            await RefreshLoansListViewAsync();
            await RefreshPopularityChartAsync();
        }

        private Task RefreshPopularityChartAsync()
        {
            Bitmap bitmap = new Bitmap(Popularity_PictureBox.Width, Popularity_PictureBox.Height);
            //Use a tuple for analysing the popularity of each book.
            Tuple<Book, int>[] popularities = new Tuple<Book, int>[Books.Count];
            for (int i = 0; i < popularities.Count(); i++)
            {
                popularities[i] = new Tuple<Book, int>(Books[i], BookLoans.Where(o=>o.BookID == Books[i].ID).ToList().Count);
            }
            popularities = popularities.Where(o => o.Item2 > 0).ToArray();
            popularities = popularities.OrderByDescending(o => o.Item2).ToArray();
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    bitmap.SetPixel(x, y, Color.LightCyan);
                }
            }
            int maxPopularity = popularities[0].Item2;
            int spacing = 1;
            int barThickness = bitmap.Width / (popularities.Length * spacing);
            Color barColor = Color.Green;
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 0; i < popularities.Length; i++)
            {
                if (popularities[i].Item2 == 0) continue; //Avoid DivideByZero exceptions
                for (int y = bitmap.Height - 1; y >= bitmap.Height - bitmap.Height * ((double)popularities[i].Item2 / (double)maxPopularity); y--)
                {
                    for (int x = i * (spacing + barThickness); x < i * (spacing + barThickness) + barThickness; x++)
                    {
                        if (x >= bitmap.Width) break;
                        bitmap.SetPixel(x, y, barColor);
                    }
                }
                //graphics.DrawString(popularities[i].Item1.ID.ToString(), new Font("Tahoma", 5), Brushes.Black, new PointF(i * (spacing + barThickness), bitmap.Height - bitmap.Height * ((float)popularities[i].Item2 / (float)maxPopularity)));
                //At the top of the bar
                //DrawRotatedTextAt(graphics, 270, popularities[i].Item1.Title, i * (spacing + barThickness), (int)(bitmap.Height - bitmap.Height * ((float)popularities[i].Item2 / (float)maxPopularity)), new Font("Tahoma", 8), Brushes.Black);
                string text = ((popularities[i].Item1.Title.Length >= 17) ? popularities[i].Item1.Title.Substring(0, 17) + "..." : popularities[i].Item1.Title) + " (" + popularities[i].Item2+ " loans)";
                DrawRotatedTextAt(graphics, 270, text, i * (spacing + barThickness), bitmap.Height - 1, new Font("Tahoma", 8), Brushes.Black);
            }
            Popularity_PictureBox.Image = bitmap;
            return Task.CompletedTask;
        }

        private void DrawRotatedTextAt(Graphics gr, float angle,
    string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
        }

        private async Task RefreshLoansListViewAsync()
        {
            BookLoans = await Database.GetAllBookLoansAsync();
            Loans_ListView.Items.Clear();
            foreach (var bookLoan in BookLoans)
            {
                Loans_ListView.Items.Add(bookLoan.ToListViewItem());
            }
            if (Loans_ListView.Items.Count > 0)
                Loans_ListView.Items[0].Selected = true;
        }

        /// <summary>
        /// Refreshes the list of books from the database and updates the main panel asynchronously. The task can be canceled by using the RefreshCancellationToken CancellationToken."
        /// </summary>
        /// <returns></returns>
        private async Task RefreshMainPanelAsync(MainPanelRefreshMode refreshMode = MainPanelRefreshMode.FromDatabase)
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
                        Books = (refreshMode == MainPanelRefreshMode.FromDatabase) ? await Database.GetAllBooksAsync(_SortParameter, Database.SortDirection.Asc) : DeserializeBooks();
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
                            thumbnail.DetailsButtonClicked += Thumbnail_DetailsButtonClicked;
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

        private void Thumbnail_DetailsButtonClicked(object sender, Book e)
        {
            string title = (e.Title.Length >= 20) ? e.Title.Substring(0, 17) + "..." : e.Title;
            for (int i = 0; i < MainTabControl.Controls.Count; i++)
            {
                if (MainTabControl.Controls[i].Text == title)
                {
                    MainTabControl.SelectedIndex = i;
                    return;
                }
            }
            TabPage tabPage = new TabPage();
            tabPage.Text = title;
            BookDetailsDialog detailsDialog = new BookDetailsDialog(e, BookLoans.Where(o => o.BookID == e.ID).ToList());
            detailsDialog.BookLent += async(se, ev) =>
            {
                await RefreshLoansListViewAsync();
                await RefreshPopularityChartAsync();
            };
            detailsDialog.BookReturned += async (se, ev) =>
            {
                await RefreshLoansListViewAsync();
                await RefreshPopularityChartAsync();
            };
            tabPage.Controls.Add(detailsDialog);
            detailsDialog.Anchor = tabPage.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            MainTabControl.Controls.Add(tabPage);
            MainTabControl.SelectedIndex = MainTabControl.Controls.Count - 1;
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
                SearchCancellationToken = CancellationToken.None;
                await Task.Run(async () =>
                {
                    bool numerical = false;
                    if (uint.TryParse(s, out uint demoUint)) numerical = true;
                    s = s.FormatForSearch();
                    List<BookThumbnail> currentBookThumbnails = (numerical) ? BookThumbnails.Where(o => o.QuantityAvailable == Convert.ToUInt32(s) || o.ID.ToString().Contains(s)).ToList() : BookThumbnails.Where(o => o.Title.FormatForSearch().Contains(s) || o.Author.FormatForSearch().Contains(s) || o.Description.FormatForSearch().Contains(s)).ToList();
                    // if (currentBookThumbnails.Count == BookThumbnails.Count) return;
                    await UIDispatcher.InvokeAsync(() => { MainPanel.Controls.Clear(); }, DispatcherPriority.Render, SearchCancellationToken);
                    int xIndex = 0;
                    int yIndex = 0;
                    int perRow = previousPerRow = 0;
                    await UIDispatcher.InvokeAsync(() =>
                    {
                        perRow = previousPerRow = MainPanel.Width / (ThumbnailSpacing + ThumbnailWidth);
                    }, DispatcherPriority.Render, SearchCancellationToken);
                    foreach (BookThumbnail thumbnail in currentBookThumbnails)
                    {
                        await UIDispatcher.InvokeAsync(() =>
                        {
                            MainPanel.Controls.Add(thumbnail);
                            thumbnail.Top = yIndex * (ThumbnailHeight + ThumbnailSpacing);
                            thumbnail.Left = xIndex * (ThumbnailWidth + ThumbnailSpacing);
                        }, DispatcherPriority.Render, SearchCancellationToken);
                        if (++xIndex >= perRow)
                        {
                            xIndex = 0;
                            yIndex++;
                        }
                    }
                    await UIDispatcher.InvokeAsync(() => { StatusLabel.Text = MainPanel.Controls.Count + " item" + ((MainPanel.Controls.Count != 1) ? "s" : string.Empty); }, DispatcherPriority.Render, SearchCancellationToken);
                }, SearchCancellationToken);
            }
            catch
            {

            }
            finally
            {
                SearchCancellationToken = CancellationToken.None;
                SearchActive = false;
            }
        }

        #endregion

        #region Input handling

        #region Menu

        private void NewLoan_MenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void Print_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Settings_MenuItem_Click(object sender, EventArgs e)
        {

        }


        private void totxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("Reports/loans.txt");
            foreach (BookLoan loan in BookLoans)
            {
                streamWriter.Write(string.Format("Book ID: {0}\r\nLent to {1}\r\nFrom {2}\r\nTo {3}\r\n\r\n", loan.BookID, loan.LoanerName, loan.LoanDate.ToShortDateString(), loan.ReturnDate.ToShortDateString()));
            }
            streamWriter.Close();
            if (MessageBox.Show("Loans successfully exported to Reports/loans.txt\nDo you want to open the report now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(Application.StartupPath + "\\Reports\\loans.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't find " + Application.StartupPath + "\\Reports\\loans.txt");
                }
            }
        }

        private void toTxtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("Reports/books.txt");
            foreach (Book book in Books)
            {
                streamWriter.Write(string.Format("{0} - {1}\r\nAvailable: {2}\r\n\r\n", book.Author, book.Title, book.QuantityAvailable));
            }
            streamWriter.Close();
            if (MessageBox.Show("Books successfully exported to Reports/books.txt\nDo you want to open the report now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(Application.StartupPath + "\\Reports\\books.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't find " + Application.StartupPath + "\\Reports\\books.txt");
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
#if DEBUG
            return;
#endif
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            SerializeBooks();
        }

        private void Exit_MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            About_MenuItem.Enabled = false;
            about.FormClosed += (a, b) => { About_MenuItem.Enabled = true; };
            about.Show();
        }

        #endregion

        /// <summary>
        /// Updates the title of the window according to the tab the user has navigated to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "BookKeeper - " + MainTabControl.SelectedTab.Text;
            if (SelectedTabIndex < 2 && (MainTabControl.Controls.Count == 2))
            {
                foreach (MenuItem menuItem in MainContextMenu.MenuItems)
                {
                    menuItem.Enabled = false;
                }
            }
            else if (SelectedTabIndex < 2)
            {
                MainContextMenu.MenuItems[0].Enabled = false;
            }
            else
            {
                foreach (MenuItem menuItem in MainContextMenu.MenuItems)
                {
                    menuItem.Enabled = true;
                }
            }
            if (SelectedTabIndex == 0)
            {
                StatusLabel.Text = MainPanel.Controls.Count + " item" + ((MainPanel.Controls.Count != 1) ? "s" : string.Empty);
            }
            else if (SelectedTabIndex == 1)
            {
                StatusLabel.Text = Loans_ListView.Items.Count + " item" + ((Loans_ListView.Items.Count != 1) ? "s" : string.Empty);
            }
            else
            {
                StatusLabel.Text = string.Empty;
            }
        }

        private void Loans_ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == BookLoans_LastColumnIndex) BookLoans_SortDirection = (BookLoans_SortDirection == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            BookLoans_LastColumnIndex = e.Column;
            if (LoansSearch_TextBox.Text.Trim() == string.Empty)
            {
                foreach (BookLoan x in BookLoans)
                {
                    Loans_ListView.Items.Add(x.ToListViewItem());
                }
            }
            Loans_ListView.Items.Clear();
            List<BookLoan> items = new List<BookLoan>();
            foreach (BookLoan x in BookLoans)
            {
                string query = x.BookID + x.LoanDate.ToShortDateString() + x.LoanerName + x.ReturnDate.ToShortDateString();
                if (query.FormatForSearch().Contains(LoansSearch_TextBox.Text.FormatForSearch()))
                {
                    items.Add(x);
                }
            }
            switch (e.Column)
            {
                case 0:
                    items = (BookLoans_SortDirection == ListSortDirection.Ascending) ? items.OrderBy(o => o.BookID).ToList() : items.OrderByDescending(o => o.BookID).ToList();
                    break;
                case 1:
                    items = (BookLoans_SortDirection == ListSortDirection.Ascending) ? items.OrderBy(o => o.LoanerName).ToList() : items.OrderByDescending(o => o.LoanerName).ToList();
                    break;
                case 2:
                    items = (BookLoans_SortDirection == ListSortDirection.Ascending) ? items.OrderBy(o => o.LoanDate).ToList() : items.OrderByDescending(o => o.LoanDate).ToList();
                    break;
                case 3:
                    items = (BookLoans_SortDirection == ListSortDirection.Ascending) ? items.OrderBy(o => o.ReturnDate).ToList() : items.OrderByDescending(o => o.ReturnDate).ToList();
                    break;
            }
            Loans_ListView.Items.Clear();
            foreach (var x in items)
            {
                Loans_ListView.Items.Add(x.ToListViewItem());
            }
            StatusLabel.Text = Loans_ListView.Items.Count + " item" + ((Loans_ListView.Items.Count != 1) ? "s" : string.Empty);
        }

        async private void Search_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchActive)
            {
                CancellationTokenSource sourceTokenSource = new CancellationTokenSource();
                SearchCancellationToken = sourceTokenSource.Token;
                sourceTokenSource.Cancel();
            }
            await SearchAsync(Search_TextBox.Text);
        }

        private async void Refresh_Button_Click(object sender, EventArgs e)
        {
            await RefreshMainPanelAsync();
        }

        private void ClearSearch_Button_Click(object sender, EventArgs e)
        {
            Search_TextBox.Text = string.Empty;
        }

        private void NewBook_MenuItem_Click(object sender, EventArgs e)
        {
            TabPage newBookPage = new TabPage()
            {
                Text = "New book",
                BackColor = Color.White,
                Tag = MainTabControl.Controls.Count
            };
            BookAddDialog newBookControl = new BookAddDialog();
            newBookPage.Controls.Add(newBookControl);
            MainTabControl.Controls.Add(newBookPage);
            MainTabControl.SelectedIndex = MainTabControl.Controls.Count - 1;
        }
        
        private void NewBookLoan_MenuItem_Click(object sender, EventArgs e)
        {
            NewBookLoan_MenuItem.Enabled = false;
            LendBookDialog_Full lendBookDialog_Full = new LendBookDialog_Full(Books);
            lendBookDialog_Full.Save += async(a, b) =>
            {
                await Database.AddBookLoanAsync(b);
                await RefreshLoansListViewAsync();
                await RefreshMainPanelAsync(MainPanelRefreshMode.FromDatabase);
                await RefreshPopularityChartAsync();
                NewBookLoan_MenuItem.Enabled = true;
            };
            lendBookDialog_Full.Show();
        }

        private void SerializeBooks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = File.Create("Data/books.bin"))
            {
                formatter.Serialize(fileStream, Books);
            }
        }

        private List<Book> DeserializeBooks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("Data/books.bin"))
            {
                using (FileStream fileStream = File.OpenRead("Data/books.bin"))
                {
                    return (List<Book>)formatter.Deserialize(fileStream);
                }
            }
            else
            {
                throw new FileNotFoundException("\"Data/books.bin\" does not exist!");
            }
        }

        private void Loans_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loans_ListView.SelectedIndices.Count == 0) return;
            List<Book> selectedBooks = Books.Where(o => o.ID == BookLoans[Loans_ListView.SelectedIndices[0]].BookID).ToList();
            if (selectedBooks.Count == 1)
            {
                var selectedBook = selectedBooks[0];
                BookPreview_BookThumbnail.Title = selectedBook.Title;
                BookPreview_BookThumbnail.ID = selectedBook.ID;
                BookPreview_BookThumbnail.Description = selectedBook.Description;
                BookPreview_BookThumbnail.QuantityAvailable = selectedBook.QuantityAvailable;
                BookPreview_BookThumbnail.Thumbnail = selectedBook.Image;
                ReturnBook_Button.Enabled = BookLoans.Where(o => o.BookID == selectedBook.ID).ToList().Count > 0;
                LendBook_Button.Enabled = selectedBook.QuantityAvailable > 0;
            }
        }

        //TODO:return book
        async private void ReturnBook_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnBook_Button.Enabled = false;
                List<BookLoan> selectedBookLoans = BookLoans.Where(o => o.GetHashCode() == BookLoans[Loans_ListView.SelectedIndices[0]].GetHashCode()).ToList();
                if (selectedBookLoans.Count == 1)
                {
                    await Database.RemoveBookLoanAsync(selectedBookLoans[0]);
                    await RefreshLoansListViewAsync();
                    await RefreshMainPanelAsync(MainPanelRefreshMode.FromDatabase);
                    await RefreshPopularityChartAsync();
                }
            }
            catch (Exception)
            {
               MessageBox.Show("Select an item from the list first", "Error");
            }
            finally
            {
                ReturnBook_Button.Enabled = true;
            }
        }

        private void LendBook_Button_Click(object sender, EventArgs e)
        {
            try
            {
                List<Book> selectedBooks = Books.Where(o => o.ID == BookLoans[Loans_ListView.SelectedIndices[0]].BookID).ToList();
                if (selectedBooks.Count == 1)
                {
                    var selectedBook = selectedBooks[0];
                    LendBookDialog lendBookDialog = new LendBookDialog(selectedBook.ID);
                    lendBookDialog.Text = "Lend \"" + selectedBook.Title + "\"";
                    lendBookDialog.FormClosing += LendBookDialog_FormClosing;
                    lendBookDialog.Save += LendBookDialog_Save;
                    lendBookDialog.StartPosition = FormStartPosition.CenterScreen;
                    lendBookDialog.TopMost = true;
                    lendBookDialog.Show();
                    LendBook_Button.Enabled = false;
                }
            }
            catch (Exception)
            {
               MessageBox.Show("Select an item from the list first", "Error");
            }
        }

        async private void LendBookDialog_Save(object sender, BookLoan e)
        {
            LendBook_Button.Enabled = false;
            try
            {
                await Database.AddBookLoanAsync(e);
                await RefreshMainPanelAsync(MainPanelRefreshMode.FromDatabase);
                await RefreshLoansListViewAsync();
                await RefreshPopularityChartAsync();
            }
            finally
            {
                LendBook_Button.Enabled = true;
            }
        }

        private void LendBookDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            LendBook_Button.Enabled = true;
        }

        private void LoansSearch_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (LoansSearch_TextBox.Text.Trim() == string.Empty)
            {
                foreach (BookLoan x in BookLoans)
                {
                    Loans_ListView.Items.Add(x.ToListViewItem());
                }
            }
            Loans_ListView.Items.Clear();
            foreach (BookLoan x in BookLoans)
            {
                string query = x.BookID + x.LoanDate.ToShortDateString() + x.LoanerName + x.ReturnDate.ToShortDateString();
                if (query.FormatForSearch().Contains(LoansSearch_TextBox.Text.FormatForSearch()))
                {
                    Loans_ListView.Items.Add(x.ToListViewItem());
                }
            }
            StatusLabel.Text = Loans_ListView.Items.Count + " item" + ((Loans_ListView.Items.Count != 1) ? "s" : string.Empty);
        }

        private void ClearLoansSearchBox_Button_Click(object sender, EventArgs e)
        {
            LoansSearch_TextBox.Text = string.Empty;
        }

        #endregion
    }
}