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
    public partial class BookThumbnail : UserControl
    {
        public BookThumbnail()
        {
            InitializeComponent();
        }

        private void BookThumbnail_Click(object sender, EventArgs e)
        {
          
        }

        private void BookThumbnail_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void BookThumbnail_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        
    }
}
