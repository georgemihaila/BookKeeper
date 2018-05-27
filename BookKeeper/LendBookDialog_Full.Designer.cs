namespace BookKeeper
{
    partial class LendBookDialog_Full
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LendBookDialog_Full));
            this.Save_Buton = new System.Windows.Forms.Button();
            this.ReturnDate_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoanDate_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Name_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Book_ComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save_Buton
            // 
            this.Save_Buton.Enabled = false;
            this.Save_Buton.Location = new System.Drawing.Point(138, 170);
            this.Save_Buton.Name = "Save_Buton";
            this.Save_Buton.Size = new System.Drawing.Size(75, 23);
            this.Save_Buton.TabIndex = 13;
            this.Save_Buton.Text = "Save";
            this.Save_Buton.UseVisualStyleBackColor = true;
            this.Save_Buton.Click += new System.EventHandler(this.Save_Buton_Click);
            // 
            // ReturnDate_DateTimePicker
            // 
            this.ReturnDate_DateTimePicker.Location = new System.Drawing.Point(12, 130);
            this.ReturnDate_DateTimePicker.Name = "ReturnDate_DateTimePicker";
            this.ReturnDate_DateTimePicker.Size = new System.Drawing.Size(201, 20);
            this.ReturnDate_DateTimePicker.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Return date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Loan date:";
            // 
            // LoanDate_DateTimePicker
            // 
            this.LoanDate_DateTimePicker.CustomFormat = "";
            this.LoanDate_DateTimePicker.Location = new System.Drawing.Point(12, 91);
            this.LoanDate_DateTimePicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.LoanDate_DateTimePicker.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.LoanDate_DateTimePicker.Name = "LoanDate_DateTimePicker";
            this.LoanDate_DateTimePicker.Size = new System.Drawing.Size(201, 20);
            this.LoanDate_DateTimePicker.TabIndex = 9;
            this.LoanDate_DateTimePicker.ValueChanged += new System.EventHandler(this.LoanDate_DateTimePicker_ValueChanged);
            // 
            // Name_TextBox
            // 
            this.Name_TextBox.Location = new System.Drawing.Point(56, 52);
            this.Name_TextBox.Name = "Name_TextBox";
            this.Name_TextBox.Size = new System.Drawing.Size(157, 20);
            this.Name_TextBox.TabIndex = 8;
            this.Name_TextBox.TextChanged += new System.EventHandler(this.Name_TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // Book_ComboBox
            // 
            this.Book_ComboBox.FormattingEnabled = true;
            this.Book_ComboBox.Location = new System.Drawing.Point(12, 25);
            this.Book_ComboBox.Name = "Book_ComboBox";
            this.Book_ComboBox.Size = new System.Drawing.Size(201, 21);
            this.Book_ComboBox.TabIndex = 14;
            this.Book_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Book_ComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Book:";
            // 
            // LendBookDialog_Full
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 205);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Book_ComboBox);
            this.Controls.Add(this.Save_Buton);
            this.Controls.Add(this.ReturnDate_DateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoanDate_DateTimePicker);
            this.Controls.Add(this.Name_TextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LendBookDialog_Full";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lend book";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save_Buton;
        private System.Windows.Forms.DateTimePicker ReturnDate_DateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker LoanDate_DateTimePicker;
        private System.Windows.Forms.TextBox Name_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Book_ComboBox;
        private System.Windows.Forms.Label label4;
    }
}