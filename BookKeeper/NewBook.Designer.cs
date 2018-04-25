namespace BookKeeper
{
    partial class NewBook
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
            this.Manual_RadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.FromBookDepository_RadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Title_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.URL_TextBox = new System.Windows.Forms.TextBox();
            this.Author_TextBox = new System.Windows.Forms.TextBox();
            this.Description_TextBox = new System.Windows.Forms.TextBox();
            this.Category_TextBox = new System.Windows.Forms.TextBox();
            this.Image_PictureBox = new System.Windows.Forms.PictureBox();
            this.ChooseImage_Button = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.Quantity_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Image_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Manual_RadioButton
            // 
            this.Manual_RadioButton.AutoSize = true;
            this.Manual_RadioButton.Checked = true;
            this.Manual_RadioButton.Location = new System.Drawing.Point(3, 3);
            this.Manual_RadioButton.Name = "Manual_RadioButton";
            this.Manual_RadioButton.Size = new System.Drawing.Size(60, 17);
            this.Manual_RadioButton.TabIndex = 0;
            this.Manual_RadioButton.TabStop = true;
            this.Manual_RadioButton.Text = "Manual";
            this.Manual_RadioButton.UseVisualStyleBackColor = true;
            this.Manual_RadioButton.Click += new System.EventHandler(this.Manual_RadioButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(-15, -15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FromBookDepository_RadioButton
            // 
            this.FromBookDepository_RadioButton.AutoSize = true;
            this.FromBookDepository_RadioButton.Location = new System.Drawing.Point(69, 3);
            this.FromBookDepository_RadioButton.Name = "FromBookDepository_RadioButton";
            this.FromBookDepository_RadioButton.Size = new System.Drawing.Size(129, 17);
            this.FromBookDepository_RadioButton.TabIndex = 2;
            this.FromBookDepository_RadioButton.TabStop = true;
            this.FromBookDepository_RadioButton.Text = "From Book Depository";
            this.FromBookDepository_RadioButton.UseVisualStyleBackColor = true;
            this.FromBookDepository_RadioButton.Click += new System.EventHandler(this.FromBookDepository_RadioButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // Title_TextBox
            // 
            this.Title_TextBox.Location = new System.Drawing.Point(168, 65);
            this.Title_TextBox.Name = "Title_TextBox";
            this.Title_TextBox.Size = new System.Drawing.Size(287, 20);
            this.Title_TextBox.TabIndex = 5;
            this.Title_TextBox.TextChanged += new System.EventHandler(this.Title_TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Category:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Image:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "URL:";
            // 
            // URL_TextBox
            // 
            this.URL_TextBox.Enabled = false;
            this.URL_TextBox.Location = new System.Drawing.Point(168, 39);
            this.URL_TextBox.Name = "URL_TextBox";
            this.URL_TextBox.Size = new System.Drawing.Size(287, 20);
            this.URL_TextBox.TabIndex = 10;
            this.URL_TextBox.TextChanged += new System.EventHandler(this.URL_TextBox_TextChanged);
            // 
            // Author_TextBox
            // 
            this.Author_TextBox.Location = new System.Drawing.Point(168, 91);
            this.Author_TextBox.Name = "Author_TextBox";
            this.Author_TextBox.Size = new System.Drawing.Size(287, 20);
            this.Author_TextBox.TabIndex = 11;
            this.Author_TextBox.TextChanged += new System.EventHandler(this.Author_TextBox_TextChanged);
            // 
            // Description_TextBox
            // 
            this.Description_TextBox.AcceptsReturn = true;
            this.Description_TextBox.Location = new System.Drawing.Point(168, 143);
            this.Description_TextBox.Multiline = true;
            this.Description_TextBox.Name = "Description_TextBox";
            this.Description_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description_TextBox.Size = new System.Drawing.Size(287, 123);
            this.Description_TextBox.TabIndex = 12;
            this.Description_TextBox.TextChanged += new System.EventHandler(this.Description_TextBox_TextChanged);
            // 
            // Category_TextBox
            // 
            this.Category_TextBox.Location = new System.Drawing.Point(168, 117);
            this.Category_TextBox.Name = "Category_TextBox";
            this.Category_TextBox.Size = new System.Drawing.Size(287, 20);
            this.Category_TextBox.TabIndex = 13;
            this.Category_TextBox.TextChanged += new System.EventHandler(this.Category_TextBox_TextChanged);
            // 
            // Image_PictureBox
            // 
            this.Image_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image_PictureBox.Location = new System.Drawing.Point(6, 42);
            this.Image_PictureBox.Name = "Image_PictureBox";
            this.Image_PictureBox.Size = new System.Drawing.Size(87, 108);
            this.Image_PictureBox.TabIndex = 14;
            this.Image_PictureBox.TabStop = false;
            // 
            // ChooseImage_Button
            // 
            this.ChooseImage_Button.Location = new System.Drawing.Point(6, 156);
            this.ChooseImage_Button.Name = "ChooseImage_Button";
            this.ChooseImage_Button.Size = new System.Drawing.Size(87, 23);
            this.ChooseImage_Button.TabIndex = 15;
            this.ChooseImage_Button.Text = "Choose image";
            this.ChooseImage_Button.UseVisualStyleBackColor = true;
            this.ChooseImage_Button.Click += new System.EventHandler(this.ChooseImage_Button_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(380, 272);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ImageFileDialog
            // 
            this.ImageFileDialog.Filter = "Image files|*.jpg *.png *.jpeg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Quantity:";
            // 
            // Quantity_NumericUpDown
            // 
            this.Quantity_NumericUpDown.Location = new System.Drawing.Point(168, 272);
            this.Quantity_NumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Quantity_NumericUpDown.Name = "Quantity_NumericUpDown";
            this.Quantity_NumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.Quantity_NumericUpDown.TabIndex = 18;
            this.Quantity_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity_NumericUpDown.ThousandsSeparator = true;
            this.Quantity_NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quantity_NumericUpDown.ValueChanged += new System.EventHandler(this.Quantity_NumericUpDown_ValueChanged);
            // 
            // NewBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Quantity_NumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ChooseImage_Button);
            this.Controls.Add(this.Image_PictureBox);
            this.Controls.Add(this.Category_TextBox);
            this.Controls.Add(this.Description_TextBox);
            this.Controls.Add(this.Author_TextBox);
            this.Controls.Add(this.URL_TextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Title_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FromBookDepository_RadioButton);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Manual_RadioButton);
            this.Name = "NewBook";
            this.Size = new System.Drawing.Size(477, 329);
            ((System.ComponentModel.ISupportInitialize)(this.Image_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Manual_RadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton FromBookDepository_RadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Title_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox URL_TextBox;
        private System.Windows.Forms.TextBox Author_TextBox;
        private System.Windows.Forms.TextBox Description_TextBox;
        private System.Windows.Forms.TextBox Category_TextBox;
        private System.Windows.Forms.PictureBox Image_PictureBox;
        private System.Windows.Forms.Button ChooseImage_Button;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.OpenFileDialog ImageFileDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Quantity_NumericUpDown;
    }
}
