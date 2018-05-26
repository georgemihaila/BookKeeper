namespace BookKeeper
{
    partial class BookThumbnail
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
            this.Thumbnail_PictureBox = new System.Windows.Forms.PictureBox();
            this.Title_Label = new System.Windows.Forms.Label();
            this.Author_Label = new System.Windows.Forms.Label();
            this.Description_Label = new System.Windows.Forms.Label();
            this.QuantityAvailable_Label = new System.Windows.Forms.Label();
            this.Details_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Thumbnail_PictureBox
            // 
            this.Thumbnail_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Thumbnail_PictureBox.Location = new System.Drawing.Point(3, 3);
            this.Thumbnail_PictureBox.Name = "Thumbnail_PictureBox";
            this.Thumbnail_PictureBox.Size = new System.Drawing.Size(100, 144);
            this.Thumbnail_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Thumbnail_PictureBox.TabIndex = 0;
            this.Thumbnail_PictureBox.TabStop = false;
            this.Thumbnail_PictureBox.Click += new System.EventHandler(this.BookThumbnail_Click);
            this.Thumbnail_PictureBox.MouseEnter += new System.EventHandler(this.Element_MouseEnter);
            this.Thumbnail_PictureBox.MouseLeave += new System.EventHandler(this.Element_MouseLeave);
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.Location = new System.Drawing.Point(106, 3);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(0, 13);
            this.Title_Label.TabIndex = 1;
            this.Title_Label.Click += new System.EventHandler(this.BookThumbnail_Click);
            this.Title_Label.MouseEnter += new System.EventHandler(this.Element_MouseEnter);
            this.Title_Label.MouseLeave += new System.EventHandler(this.Element_MouseLeave);
            // 
            // Author_Label
            // 
            this.Author_Label.AutoSize = true;
            this.Author_Label.Location = new System.Drawing.Point(109, 16);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(0, 13);
            this.Author_Label.TabIndex = 2;
            this.Author_Label.Click += new System.EventHandler(this.BookThumbnail_Click);
            this.Author_Label.MouseEnter += new System.EventHandler(this.Element_MouseEnter);
            this.Author_Label.MouseHover += new System.EventHandler(this.Element_MouseLeave);
            // 
            // Description_Label
            // 
            this.Description_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Description_Label.Location = new System.Drawing.Point(109, 43);
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.Size = new System.Drawing.Size(138, 77);
            this.Description_Label.TabIndex = 3;
            this.Description_Label.Click += new System.EventHandler(this.BookThumbnail_Click);
            this.Description_Label.MouseEnter += new System.EventHandler(this.Element_MouseEnter);
            this.Description_Label.MouseLeave += new System.EventHandler(this.Element_MouseLeave);
            // 
            // QuantityAvailable_Label
            // 
            this.QuantityAvailable_Label.AutoSize = true;
            this.QuantityAvailable_Label.Location = new System.Drawing.Point(109, 120);
            this.QuantityAvailable_Label.Name = "QuantityAvailable_Label";
            this.QuantityAvailable_Label.Size = new System.Drawing.Size(0, 13);
            this.QuantityAvailable_Label.TabIndex = 4;
            this.QuantityAvailable_Label.Click += new System.EventHandler(this.BookThumbnail_Click);
            this.QuantityAvailable_Label.MouseEnter += new System.EventHandler(this.Element_MouseEnter);
            this.QuantityAvailable_Label.MouseLeave += new System.EventHandler(this.Element_MouseLeave);
            // 
            // Details_Button
            // 
            this.Details_Button.BackColor = System.Drawing.Color.White;
            this.Details_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Details_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Details_Button.Location = new System.Drawing.Point(-135, 70);
            this.Details_Button.Name = "Details_Button";
            this.Details_Button.Size = new System.Drawing.Size(135, 23);
            this.Details_Button.TabIndex = 5;
            this.Details_Button.Text = "Details";
            this.Details_Button.UseVisualStyleBackColor = false;
            // 
            // BookThumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Details_Button);
            this.Controls.Add(this.QuantityAvailable_Label);
            this.Controls.Add(this.Description_Label);
            this.Controls.Add(this.Author_Label);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.Thumbnail_PictureBox);
            this.Name = "BookThumbnail";
            this.Size = new System.Drawing.Size(250, 150);
            this.Click += new System.EventHandler(this.BookThumbnail_Click);
            this.MouseEnter += new System.EventHandler(this.BookThumbnail_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BookThumbnail_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Thumbnail_PictureBox;
        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Label Author_Label;
        private System.Windows.Forms.Label Description_Label;
        private System.Windows.Forms.Label QuantityAvailable_Label;
        private System.Windows.Forms.Button Details_Button;
    }
}
