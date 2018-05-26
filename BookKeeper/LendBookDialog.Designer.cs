namespace BookKeeper
{
    partial class LendBookDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LendBookDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.Name_TextBox = new System.Windows.Forms.TextBox();
            this.Name_ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.LoanDate_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReturnDate_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Save_Buton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Name_ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // Name_TextBox
            // 
            this.Name_TextBox.Location = new System.Drawing.Point(56, 6);
            this.Name_TextBox.Name = "Name_TextBox";
            this.Name_TextBox.Size = new System.Drawing.Size(157, 20);
            this.Name_TextBox.TabIndex = 1;
            this.Name_TextBox.TextChanged += new System.EventHandler(this.Name_TextBox_TextChanged);
            // 
            // Name_ErrorProvider
            // 
            this.Name_ErrorProvider.ContainerControl = this;
            // 
            // LoanDate_DateTimePicker
            // 
            this.LoanDate_DateTimePicker.CustomFormat = "";
            this.LoanDate_DateTimePicker.Location = new System.Drawing.Point(12, 45);
            this.LoanDate_DateTimePicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.LoanDate_DateTimePicker.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.LoanDate_DateTimePicker.Name = "LoanDate_DateTimePicker";
            this.LoanDate_DateTimePicker.Size = new System.Drawing.Size(201, 20);
            this.LoanDate_DateTimePicker.TabIndex = 2;
            this.LoanDate_DateTimePicker.ValueChanged += new System.EventHandler(this.LoanDate_DateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loan date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Return date:";
            // 
            // ReturnDate_DateTimePicker
            // 
            this.ReturnDate_DateTimePicker.Location = new System.Drawing.Point(12, 84);
            this.ReturnDate_DateTimePicker.Name = "ReturnDate_DateTimePicker";
            this.ReturnDate_DateTimePicker.Size = new System.Drawing.Size(201, 20);
            this.ReturnDate_DateTimePicker.TabIndex = 5;
            // 
            // Save_Buton
            // 
            this.Save_Buton.Enabled = false;
            this.Save_Buton.Location = new System.Drawing.Point(138, 110);
            this.Save_Buton.Name = "Save_Buton";
            this.Save_Buton.Size = new System.Drawing.Size(75, 23);
            this.Save_Buton.TabIndex = 6;
            this.Save_Buton.Text = "Save";
            this.Save_Buton.UseVisualStyleBackColor = true;
            this.Save_Buton.Click += new System.EventHandler(this.Save_Buton_Click);
            // 
            // LendBookDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 144);
            this.Controls.Add(this.Save_Buton);
            this.Controls.Add(this.ReturnDate_DateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoanDate_DateTimePicker);
            this.Controls.Add(this.Name_TextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LendBookDialog";
            this.Text = "Lend book";
            ((System.ComponentModel.ISupportInitialize)(this.Name_ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Name_TextBox;
        private System.Windows.Forms.ErrorProvider Name_ErrorProvider;
        private System.Windows.Forms.DateTimePicker LoanDate_DateTimePicker;
        private System.Windows.Forms.DateTimePicker ReturnDate_DateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save_Buton;
    }
}