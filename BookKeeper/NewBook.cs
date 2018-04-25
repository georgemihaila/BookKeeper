using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookKeeper
{
    public partial class NewBook : UserControl
    {
        public NewBook()
        {
            InitializeComponent();
        }

        private void Title_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Author_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manual_RadioButton_Click(object sender, EventArgs e)
        {
            URL_TextBox.Enabled = false;
        }

        private void FromBookDepository_RadioButton_Click(object sender, EventArgs e)
        {
            URL_TextBox.Enabled = true;
        }

        private void ChooseImage_Button_Click(object sender, EventArgs e)
        {
            ImageFileDialog.ShowDialog();
        }

        private void URL_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Description_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void Quantity_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        public enum ControlStatus { Enabled, Disabled }
        /// <summary>
        /// Enables or disables the controls in the form.
        /// </summary>
        /// <param name="status"></param>
        public void SetControlStatus(ControlStatus status)
        {
            switch(status)
            {
                case ControlStatus.Enabled:
                    Manual_RadioButton.Enabled = FromBookDepository_RadioButton.Enabled = Author_TextBox.Enabled = Category_TextBox.Enabled = Description_TextBox.Enabled = Title_TextBox.Enabled = ChooseImage_Button.Enabled = Quantity_NumericUpDown.Enabled = SaveButton.Enabled = true;
                    if ((bool)FromBookDepository_RadioButton.Checked) URL_TextBox.Enabled = true;
                    break;
                case ControlStatus.Disabled:
                    Manual_RadioButton.Enabled = FromBookDepository_RadioButton.Enabled = Author_TextBox.Enabled = Category_TextBox.Enabled = Description_TextBox.Enabled = Title_TextBox.Enabled = ChooseImage_Button.Enabled = URL_TextBox.Enabled = Quantity_NumericUpDown.Enabled = SaveButton.Enabled = false;
                    break;
                default:
                    throw new InvalidOperationException("Invalid control status provided.");
            }
        }
    }
}
