namespace BookKeeper
{
    partial class BookDetailsDialog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tumbnail_PicureBox = new System.Windows.Forms.PictureBox();
            this.Title_Label = new System.Windows.Forms.Label();
            this.Author_Label = new System.Windows.Forms.Label();
            this.LendBook_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LentTo_ListView = new System.Windows.Forms.ListView();
            this.CurrentLyLentTo_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoanDate_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnDate_ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description_Label = new System.Windows.Forms.TextBox();
            this.Return_Buton = new System.Windows.Forms.Button();
            this.QuantityAvailable_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tumbnail_PicureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Tumbnail_PicureBox
            // 
            this.Tumbnail_PicureBox.Location = new System.Drawing.Point(3, 3);
            this.Tumbnail_PicureBox.Name = "Tumbnail_PicureBox";
            this.Tumbnail_PicureBox.Size = new System.Drawing.Size(109, 159);
            this.Tumbnail_PicureBox.TabIndex = 0;
            this.Tumbnail_PicureBox.TabStop = false;
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.Location = new System.Drawing.Point(118, 3);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(32, 13);
            this.Title_Label.TabIndex = 1;
            this.Title_Label.Text = "Title";
            // 
            // Author_Label
            // 
            this.Author_Label.AutoSize = true;
            this.Author_Label.Location = new System.Drawing.Point(118, 25);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(38, 13);
            this.Author_Label.TabIndex = 2;
            this.Author_Label.Text = "Author";
            // 
            // LendBook_Button
            // 
            this.LendBook_Button.Location = new System.Drawing.Point(3, 168);
            this.LendBook_Button.Name = "LendBook_Button";
            this.LendBook_Button.Size = new System.Drawing.Size(109, 23);
            this.LendBook_Button.TabIndex = 4;
            this.LendBook_Button.Text = "Lend";
            this.LendBook_Button.UseVisualStyleBackColor = true;
            this.LendBook_Button.Click += new System.EventHandler(this.LendBook_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Currently lent to:";
            // 
            // LentTo_ListView
            // 
            this.LentTo_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CurrentLyLentTo_ColumnHeader,
            this.LoanDate_ColumnHeader,
            this.ReturnDate_ColumnHeader});
            this.LentTo_ListView.FullRowSelect = true;
            this.LentTo_ListView.GridLines = true;
            this.LentTo_ListView.Location = new System.Drawing.Point(3, 245);
            this.LentTo_ListView.MultiSelect = false;
            this.LentTo_ListView.Name = "LentTo_ListView";
            this.LentTo_ListView.Size = new System.Drawing.Size(381, 143);
            this.LentTo_ListView.TabIndex = 6;
            this.LentTo_ListView.UseCompatibleStateImageBehavior = false;
            this.LentTo_ListView.View = System.Windows.Forms.View.Details;
            // 
            // CurrentLyLentTo_ColumnHeader
            // 
            this.CurrentLyLentTo_ColumnHeader.Text = "Name";
            this.CurrentLyLentTo_ColumnHeader.Width = 104;
            // 
            // LoanDate_ColumnHeader
            // 
            this.LoanDate_ColumnHeader.Text = "Loan date";
            this.LoanDate_ColumnHeader.Width = 97;
            // 
            // ReturnDate_ColumnHeader
            // 
            this.ReturnDate_ColumnHeader.Text = "Return date";
            this.ReturnDate_ColumnHeader.Width = 115;
            // 
            // Description_Label
            // 
            this.Description_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Description_Label.Location = new System.Drawing.Point(121, 41);
            this.Description_Label.Multiline = true;
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.ReadOnly = true;
            this.Description_Label.Size = new System.Drawing.Size(263, 121);
            this.Description_Label.TabIndex = 7;
            // 
            // Return_Buton
            // 
            this.Return_Buton.Location = new System.Drawing.Point(3, 197);
            this.Return_Buton.Name = "Return_Buton";
            this.Return_Buton.Size = new System.Drawing.Size(109, 23);
            this.Return_Buton.TabIndex = 8;
            this.Return_Buton.Text = "Return";
            this.Return_Buton.UseVisualStyleBackColor = true;
            this.Return_Buton.Click += new System.EventHandler(this.Return_Buton_Click);
            // 
            // QuantityAvailable_Label
            // 
            this.QuantityAvailable_Label.AutoSize = true;
            this.QuantityAvailable_Label.Location = new System.Drawing.Point(121, 168);
            this.QuantityAvailable_Label.Name = "QuantityAvailable_Label";
            this.QuantityAvailable_Label.Size = new System.Drawing.Size(56, 13);
            this.QuantityAvailable_Label.TabIndex = 9;
            this.QuantityAvailable_Label.Text = "Available: ";
            // 
            // BookDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QuantityAvailable_Label);
            this.Controls.Add(this.Return_Buton);
            this.Controls.Add(this.Description_Label);
            this.Controls.Add(this.LentTo_ListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LendBook_Button);
            this.Controls.Add(this.Author_Label);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.Tumbnail_PicureBox);
            this.Name = "BookDetailsDialog";
            this.Size = new System.Drawing.Size(729, 391);
            ((System.ComponentModel.ISupportInitialize)(this.Tumbnail_PicureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Tumbnail_PicureBox;
        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Label Author_Label;
        private System.Windows.Forms.Button LendBook_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LentTo_ListView;
        private System.Windows.Forms.ColumnHeader CurrentLyLentTo_ColumnHeader;
        private System.Windows.Forms.ColumnHeader LoanDate_ColumnHeader;
        private System.Windows.Forms.ColumnHeader ReturnDate_ColumnHeader;
        private System.Windows.Forms.TextBox Description_Label;
        private System.Windows.Forms.Button Return_Buton;
        private System.Windows.Forms.Label QuantityAvailable_Label;
    }
}
