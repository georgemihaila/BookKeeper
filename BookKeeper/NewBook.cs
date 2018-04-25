using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using System.Net;

namespace BookKeeper
{
    public partial class NewBook : UserControl
    {
        public NewBook()
        {
            InitializeComponent();
        }

        public Book CurrentBook { get; set; } = new Book();
        Random random = new Random();

        private void Title_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Author_TextBox_TextChanged(object sender, EventArgs e)
        {

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
            CurrentBook = new Book()
            {
                Title = Title_TextBox.Text,
                Author = Author_TextBox.Text,
                Category = Category_TextBox.Text,
                Description = Description_TextBox.Text,
                ID = (uint)random.Next(1000, 10000),
                Image = new Bitmap(Image_PictureBox.Image),
                QuantityAvailable = (uint)Quantity_NumericUpDown.Value
            };
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
                    Author_TextBox.Enabled = Category_TextBox.Enabled = Description_TextBox.Enabled = Title_TextBox.Enabled = ChooseImage_Button.Enabled = Quantity_NumericUpDown.Enabled = SaveButton.Enabled = GetBookDepositoryDetails_Button.Enabled = URL_TextBox.Enabled = true;
                    break;
                case ControlStatus.Disabled:
                    Author_TextBox.Enabled = Category_TextBox.Enabled = Description_TextBox.Enabled = Title_TextBox.Enabled = ChooseImage_Button.Enabled = URL_TextBox.Enabled = Quantity_NumericUpDown.Enabled = SaveButton.Enabled = GetBookDepositoryDetails_Button.Enabled = false;
                    break;
                default:
                    throw new InvalidOperationException("Invalid control status provided.");
            }
        }

        async private void GetBookDepositoryDetails_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //Get HTML
                string html = string.Empty;
                SetControlStatus(ControlStatus.Disabled);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL_TextBox.Text);
                var response = await httpWebRequest.GetResponseAsync();
                var responseStream = response.GetResponseStream();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                {
                    html = reader.ReadToEnd();
                    reader.Close();
                }

                //Create HTML document
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);

                //Parse HTML document

                //Get title
                var h1 = document.DocumentNode.Descendants().Where(node => node.Name == "h1").ToArray();
                Title_TextBox.Text = h1[0].InnerHtml.FromHTMLToPlainText();
                //Get author(s)
                var span = document.DocumentNode.Descendants().Where(node => node.Name == "span" && node.OuterHtml.Contains("itemprop=\"author\" itemtype=\"http://schema.org/Person\"")).ToArray();
                Author_TextBox.Text = string.Empty;
                for (int i = 0; i < span.Length; i++)
                {
                    string s1 = span[i].OuterHtml;
                    s1 = s1.Substring(s1.IndexOf("itemscope=\"") + "itemscope=\"".Length, s1.Length - "itemscope=\"".Length - s1.IndexOf("itemscope=\""));
                    Author_TextBox.Text += s1.Substring(0, s1.IndexOf("\"")).FromHTMLToPlainText();
                    if (i != span.Length - 1)
                        Author_TextBox.Text += ", ";
                }

                //Get description
                var descriptionNode =
   document.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", "item-excerpt trunc")).ToArray();
                string description = descriptionNode[0].InnerHtml;
                while (description.Contains("  "))
                    description = description.Replace("  ", String.Empty);
                while (description.StartsWith(" ")) description = description.Remove(0, 1);
                /*if (description.Contains("<"))
                    description = description.Substring(0, description.IndexOf("<"));*/
                Description_TextBox.Text = description.FromHTMLToPlainText();

                //Get image url.
                var imageNode =
   document.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", "item-img-content")).ToArray();
                string imageURL = imageNode[0].OuterHtml;
                imageURL = imageURL.Substring(imageURL.IndexOf("src=\"") + "src=\"".Length, imageURL.Length - "src=\"".Length - imageURL.IndexOf("src=\""));
                imageURL = imageURL.Substring(0, imageURL.IndexOf("\""));
                Image_PictureBox.ImageLocation = imageURL;

                //Get category
                //[NotWorkingCorrectly]
                HtmlAgilityPack.HtmlNode[] categoryNode =
   document.DocumentNode.Descendants().Where(node => node.Name == "ol").ToArray();
                Category_TextBox.Text = "Unknown";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ex.Log();
            }
            finally
            {
                SetControlStatus(ControlStatus.Enabled);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewBook_Load(object sender, EventArgs e)
        {

        }

        private void Image_PictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            CurrentBook = new Book()
            {
                Title = Title_TextBox.Text,
                Author = Author_TextBox.Text,
                Category = Category_TextBox.Text,
                Description = Description_TextBox.Text,
                ID = (uint)random.Next(1000, 10000),
                Image = new Bitmap(Image_PictureBox.Image),
                QuantityAvailable = (uint)Quantity_NumericUpDown.Value
            };
        }
    }
}
