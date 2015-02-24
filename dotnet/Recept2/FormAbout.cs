using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            label2.Text = "Версия " + Application.ProductVersion;
            webBrowser1.Url = new Uri(CommonFunctions.AbsolutePathFromAnyPath(Application.StartupPath, "version.txt"));
        }

        private void FormAbout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}