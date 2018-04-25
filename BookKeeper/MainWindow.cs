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

namespace BookKeeper
{
    public partial class MainWindow : Form
    {

        #region Initialization

        public MainWindow()
        {
            InitializeComponent();
            InitializeDirectories();
        }


        #endregion

        #region Variables
        
        private readonly string[] AppDirectories = { "Data", "Cache" };
        private Random random = new Random();

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
                while (MainTabControl.Controls.Count > 1)
                {
                    MainTabControl.Controls.RemoveAt(1);
                }
            };
            contextMenu.MenuItems.Add(closeAllMenuItem);

            NewBook newBookControl = new NewBook();
            newBookPage.Controls.Add(newBookControl);

            MainTabControl.Controls.Add(newBookPage);
            MainTabControl.SelectedIndex = MainTabControl.Controls.Count - 1;
        }

        private void Print_MenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Creates a new book loan TabPage, adds it to the main tabcontrol and creates a context menu for it that allows closing and printing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                while (MainTabControl.Controls.Count > 1)
                {
                    MainTabControl.Controls.RemoveAt(1);
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

        /// <summary>
        /// Updates the title of the window according to the tab the user has navigated to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "BookKeeper - " + (sender as TabControl).SelectedTab.Text;
        }

        #endregion

        #endregion

    }
}
