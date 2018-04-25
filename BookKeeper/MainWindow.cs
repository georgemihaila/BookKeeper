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

        #endregion

        #region Methods

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

        private void Exit_MenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewBook_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewBookLoan_MenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion


    }
}
