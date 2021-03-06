﻿using System.Windows.Forms;

namespace BookKeeper
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewLoan_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewBookLoan_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewBook_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTxtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.Dashboard_TabPage = new System.Windows.Forms.TabPage();
            this.ClearSearch_Button = new System.Windows.Forms.Button();
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Search_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Loans_TabPage = new System.Windows.Forms.TabPage();
            this.Popularity_PictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearLoansSearchBox_Button = new System.Windows.Forms.Button();
            this.LoansSearch_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LendBook_Button = new System.Windows.Forms.Button();
            this.ReturnBook_Button = new System.Windows.Forms.Button();
            this.Loans_ListView = new System.Windows.Forms.ListView();
            this.BookID_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoanerName_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoanDate_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnDate_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusLabel = new System.Windows.Forms.Label();
            this.BookPreview_BookThumbnail = new BookKeeper.BookThumbnail();
            this.MainMenuStrip.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.Dashboard_TabPage.SuspendLayout();
            this.Loans_TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Popularity_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(854, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewLoan_MenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.Exit_MenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // NewLoan_MenuItem
            // 
            this.NewLoan_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewBookLoan_MenuItem,
            this.NewBook_MenuItem});
            this.NewLoan_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewLoan_MenuItem.Image")));
            this.NewLoan_MenuItem.Name = "NewLoan_MenuItem";
            this.NewLoan_MenuItem.Size = new System.Drawing.Size(133, 22);
            this.NewLoan_MenuItem.Text = "New";
            this.NewLoan_MenuItem.Click += new System.EventHandler(this.NewLoan_MenuItem_Click);
            // 
            // NewBookLoan_MenuItem
            // 
            this.NewBookLoan_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewBookLoan_MenuItem.Image")));
            this.NewBookLoan_MenuItem.Name = "NewBookLoan_MenuItem";
            this.NewBookLoan_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.NewBookLoan_MenuItem.Size = new System.Drawing.Size(176, 22);
            this.NewBookLoan_MenuItem.Text = "Book loan...";
            this.NewBookLoan_MenuItem.Click += new System.EventHandler(this.NewBookLoan_MenuItem_Click);
            // 
            // NewBook_MenuItem
            // 
            this.NewBook_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewBook_MenuItem.Image")));
            this.NewBook_MenuItem.Name = "NewBook_MenuItem";
            this.NewBook_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.NewBook_MenuItem.Size = new System.Drawing.Size(176, 22);
            this.NewBook_MenuItem.Text = "Book...";
            this.NewBook_MenuItem.Click += new System.EventHandler(this.NewBook_MenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loansToolStripMenuItem,
            this.booksToolStripMenuItem});
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // loansToolStripMenuItem
            // 
            this.loansToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totxtToolStripMenuItem});
            this.loansToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loansToolStripMenuItem.Image")));
            this.loansToolStripMenuItem.Name = "loansToolStripMenuItem";
            this.loansToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.loansToolStripMenuItem.Text = "Loans";
            // 
            // totxtToolStripMenuItem
            // 
            this.totxtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("totxtToolStripMenuItem.Image")));
            this.totxtToolStripMenuItem.Name = "totxtToolStripMenuItem";
            this.totxtToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.totxtToolStripMenuItem.Text = "To .txt";
            this.totxtToolStripMenuItem.Click += new System.EventHandler(this.totxtToolStripMenuItem_Click);
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toTxtToolStripMenuItem1});
            this.booksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("booksToolStripMenuItem.Image")));
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.booksToolStripMenuItem.Text = "Books";
            // 
            // toTxtToolStripMenuItem1
            // 
            this.toTxtToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toTxtToolStripMenuItem1.Image")));
            this.toTxtToolStripMenuItem1.Name = "toTxtToolStripMenuItem1";
            this.toTxtToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.toTxtToolStripMenuItem1.Text = "To .txt";
            this.toTxtToolStripMenuItem1.Click += new System.EventHandler(this.toTxtToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // Exit_MenuItem
            // 
            this.Exit_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Exit_MenuItem.Image")));
            this.Exit_MenuItem.Name = "Exit_MenuItem";
            this.Exit_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Exit_MenuItem.Size = new System.Drawing.Size(133, 22);
            this.Exit_MenuItem.Text = "Exit";
            this.Exit_MenuItem.Click += new System.EventHandler(this.Exit_MenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About_MenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("About_MenuItem.Image")));
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.Size = new System.Drawing.Size(173, 22);
            this.About_MenuItem.Text = "About BookKeeper";
            this.About_MenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.Dashboard_TabPage);
            this.MainTabControl.Controls.Add(this.Loans_TabPage);
            this.MainTabControl.Location = new System.Drawing.Point(0, 27);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(854, 622);
            this.MainTabControl.TabIndex = 1;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // Dashboard_TabPage
            // 
            this.Dashboard_TabPage.Controls.Add(this.ClearSearch_Button);
            this.Dashboard_TabPage.Controls.Add(this.Refresh_Button);
            this.Dashboard_TabPage.Controls.Add(this.MainPanel);
            this.Dashboard_TabPage.Controls.Add(this.label2);
            this.Dashboard_TabPage.Controls.Add(this.Search_TextBox);
            this.Dashboard_TabPage.Controls.Add(this.label1);
            this.Dashboard_TabPage.Location = new System.Drawing.Point(4, 22);
            this.Dashboard_TabPage.Name = "Dashboard_TabPage";
            this.Dashboard_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Dashboard_TabPage.Size = new System.Drawing.Size(846, 596);
            this.Dashboard_TabPage.TabIndex = 0;
            this.Dashboard_TabPage.Text = "Dashboard";
            this.Dashboard_TabPage.UseVisualStyleBackColor = true;
            // 
            // ClearSearch_Button
            // 
            this.ClearSearch_Button.BackColor = System.Drawing.Color.Transparent;
            this.ClearSearch_Button.FlatAppearance.BorderSize = 0;
            this.ClearSearch_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearSearch_Button.Location = new System.Drawing.Point(223, 27);
            this.ClearSearch_Button.Name = "ClearSearch_Button";
            this.ClearSearch_Button.Size = new System.Drawing.Size(24, 23);
            this.ClearSearch_Button.TabIndex = 11;
            this.ClearSearch_Button.TabStop = false;
            this.ClearSearch_Button.Text = "x";
            this.ClearSearch_Button.UseVisualStyleBackColor = false;
            this.ClearSearch_Button.Click += new System.EventHandler(this.ClearSearch_Button_Click);
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh_Button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh_Button.Image = ((System.Drawing.Image)(resources.GetObject("Refresh_Button.Image")));
            this.Refresh_Button.Location = new System.Drawing.Point(808, 42);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(32, 23);
            this.Refresh_Button.TabIndex = 4;
            this.Refresh_Button.UseVisualStyleBackColor = true;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Location = new System.Drawing.Point(3, 68);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(840, 525);
            this.MainPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Books";
            // 
            // Search_TextBox
            // 
            this.Search_TextBox.Location = new System.Drawing.Point(11, 29);
            this.Search_TextBox.Name = "Search_TextBox";
            this.Search_TextBox.Size = new System.Drawing.Size(206, 20);
            this.Search_TextBox.TabIndex = 1;
            this.Search_TextBox.TextChanged += new System.EventHandler(this.Search_TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // Loans_TabPage
            // 
            this.Loans_TabPage.Controls.Add(this.Popularity_PictureBox);
            this.Loans_TabPage.Controls.Add(this.label3);
            this.Loans_TabPage.Controls.Add(this.ClearLoansSearchBox_Button);
            this.Loans_TabPage.Controls.Add(this.LoansSearch_TextBox);
            this.Loans_TabPage.Controls.Add(this.label4);
            this.Loans_TabPage.Controls.Add(this.LendBook_Button);
            this.Loans_TabPage.Controls.Add(this.ReturnBook_Button);
            this.Loans_TabPage.Controls.Add(this.BookPreview_BookThumbnail);
            this.Loans_TabPage.Controls.Add(this.Loans_ListView);
            this.Loans_TabPage.Location = new System.Drawing.Point(4, 22);
            this.Loans_TabPage.Name = "Loans_TabPage";
            this.Loans_TabPage.Size = new System.Drawing.Size(846, 596);
            this.Loans_TabPage.TabIndex = 1;
            this.Loans_TabPage.Text = "Loans";
            this.Loans_TabPage.UseVisualStyleBackColor = true;
            // 
            // Popularity_PictureBox
            // 
            this.Popularity_PictureBox.Location = new System.Drawing.Point(11, 275);
            this.Popularity_PictureBox.Name = "Popularity_PictureBox";
            this.Popularity_PictureBox.Size = new System.Drawing.Size(498, 318);
            this.Popularity_PictureBox.TabIndex = 14;
            this.Popularity_PictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Most popular books:";
            // 
            // ClearLoansSearchBox_Button
            // 
            this.ClearLoansSearchBox_Button.BackColor = System.Drawing.Color.Transparent;
            this.ClearLoansSearchBox_Button.FlatAppearance.BorderSize = 0;
            this.ClearLoansSearchBox_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearLoansSearchBox_Button.Location = new System.Drawing.Point(223, 26);
            this.ClearLoansSearchBox_Button.Name = "ClearLoansSearchBox_Button";
            this.ClearLoansSearchBox_Button.Size = new System.Drawing.Size(24, 23);
            this.ClearLoansSearchBox_Button.TabIndex = 12;
            this.ClearLoansSearchBox_Button.TabStop = false;
            this.ClearLoansSearchBox_Button.Text = "x";
            this.ClearLoansSearchBox_Button.UseVisualStyleBackColor = false;
            this.ClearLoansSearchBox_Button.Click += new System.EventHandler(this.ClearLoansSearchBox_Button_Click);
            // 
            // LoansSearch_TextBox
            // 
            this.LoansSearch_TextBox.Location = new System.Drawing.Point(11, 29);
            this.LoansSearch_TextBox.Name = "LoansSearch_TextBox";
            this.LoansSearch_TextBox.Size = new System.Drawing.Size(206, 20);
            this.LoansSearch_TextBox.TabIndex = 5;
            this.LoansSearch_TextBox.TextChanged += new System.EventHandler(this.LoansSearch_TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Search";
            // 
            // LendBook_Button
            // 
            this.LendBook_Button.BackColor = System.Drawing.Color.YellowGreen;
            this.LendBook_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LendBook_Button.ForeColor = System.Drawing.Color.White;
            this.LendBook_Button.Location = new System.Drawing.Point(593, 169);
            this.LendBook_Button.Name = "LendBook_Button";
            this.LendBook_Button.Size = new System.Drawing.Size(75, 23);
            this.LendBook_Button.TabIndex = 3;
            this.LendBook_Button.Text = "Lend";
            this.LendBook_Button.UseVisualStyleBackColor = false;
            this.LendBook_Button.Click += new System.EventHandler(this.LendBook_Button_Click);
            // 
            // ReturnBook_Button
            // 
            this.ReturnBook_Button.BackColor = System.Drawing.Color.YellowGreen;
            this.ReturnBook_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnBook_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBook_Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReturnBook_Button.Location = new System.Drawing.Point(512, 169);
            this.ReturnBook_Button.Name = "ReturnBook_Button";
            this.ReturnBook_Button.Size = new System.Drawing.Size(75, 23);
            this.ReturnBook_Button.TabIndex = 2;
            this.ReturnBook_Button.Text = "Return";
            this.ReturnBook_Button.UseVisualStyleBackColor = false;
            this.ReturnBook_Button.Click += new System.EventHandler(this.ReturnBook_Button_Click);
            // 
            // Loans_ListView
            // 
            this.Loans_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BookID_ColumnHeader,
            this.LoanerName_ColumnHeader,
            this.LoanDate_ColumnHeader,
            this.ReturnDate_ColumnHeader});
            this.Loans_ListView.FullRowSelect = true;
            this.Loans_ListView.GridLines = true;
            this.Loans_ListView.Location = new System.Drawing.Point(11, 55);
            this.Loans_ListView.Name = "Loans_ListView";
            this.Loans_ListView.Size = new System.Drawing.Size(498, 201);
            this.Loans_ListView.TabIndex = 0;
            this.Loans_ListView.UseCompatibleStateImageBehavior = false;
            this.Loans_ListView.View = System.Windows.Forms.View.Details;
            this.Loans_ListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Loans_ListView_ColumnClick);
            this.Loans_ListView.SelectedIndexChanged += new System.EventHandler(this.Loans_ListView_SelectedIndexChanged);
            // 
            // BookID_ColumnHeader
            // 
            this.BookID_ColumnHeader.Text = "Book ID";
            this.BookID_ColumnHeader.Width = 65;
            // 
            // LoanerName_ColumnHeader
            // 
            this.LoanerName_ColumnHeader.Text = "Loaner name";
            this.LoanerName_ColumnHeader.Width = 75;
            // 
            // LoanDate_ColumnHeader
            // 
            this.LoanDate_ColumnHeader.Text = "Loan date";
            this.LoanDate_ColumnHeader.Width = 78;
            // 
            // ReturnDate_ColumnHeader
            // 
            this.ReturnDate_ColumnHeader.Text = "Return date";
            this.ReturnDate_ColumnHeader.Width = 89;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 648);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 13);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Ready";
            // 
            // BookPreview_BookThumbnail
            // 
            this.BookPreview_BookThumbnail.Author = "";
            this.BookPreview_BookThumbnail.BackColor = System.Drawing.Color.White;
            this.BookPreview_BookThumbnail.Category = null;
            this.BookPreview_BookThumbnail.Description = "";
            this.BookPreview_BookThumbnail.ID = ((uint)(0u));
            this.BookPreview_BookThumbnail.Location = new System.Drawing.Point(512, 13);
            this.BookPreview_BookThumbnail.Name = "BookPreview_BookThumbnail";
            this.BookPreview_BookThumbnail.QuantityAvailable = ((uint)(0u));
            this.BookPreview_BookThumbnail.Size = new System.Drawing.Size(326, 150);
            this.BookPreview_BookThumbnail.TabIndex = 1;
            this.BookPreview_BookThumbnail.Thumbnail = ((System.Drawing.Bitmap)(resources.GetObject("BookPreview_BookThumbnail.Thumbnail")));
            this.BookPreview_BookThumbnail.Title = "";
            this.BookPreview_BookThumbnail.DetailsButtonClicked += new System.EventHandler<BookKeeper.Book>(this.Thumbnail_DetailsButtonClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 661);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookKeeper - Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.Dashboard_TabPage.ResumeLayout(false);
            this.Dashboard_TabPage.PerformLayout();
            this.Loans_TabPage.ResumeLayout(false);
            this.Loans_TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Popularity_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.MenuStrip MainMenuStrip;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewLoan_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewBookLoan_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewBook_MenuItem;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage Dashboard_TabPage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox Search_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Refresh_Button;
        private System.Windows.Forms.TabPage Loans_TabPage;
        private System.Windows.Forms.Button ClearSearch_Button;
        private ListView Loans_ListView;
        private ColumnHeader BookID_ColumnHeader;
        private ColumnHeader LoanerName_ColumnHeader;
        private ColumnHeader LoanDate_ColumnHeader;
        private ColumnHeader ReturnDate_ColumnHeader;
        private BookThumbnail BookPreview_BookThumbnail;
        private Button ReturnBook_Button;
        private Button LendBook_Button;
        private TextBox LoansSearch_TextBox;
        private Label label4;
        private Button ClearLoansSearchBox_Button;
        private PictureBox Popularity_PictureBox;
        private Label label3;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem loansToolStripMenuItem;
        private ToolStripMenuItem totxtToolStripMenuItem;
        private ToolStripMenuItem booksToolStripMenuItem;
        private ToolStripMenuItem toTxtToolStripMenuItem1;
    }
}

