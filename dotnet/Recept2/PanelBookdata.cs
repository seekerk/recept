namespace Recept2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    public partial class PanelBookdata : UserControl
    {
        public PanelBookdata()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            this.tbBookName.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbCompanyName.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbChiefName.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbDeveloperName.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbDeveloperCompany.TextChanged -= new System.EventHandler(this.tbTextChanged);

            DataBook data = DataBook.Book;
            tbBookName.Text = data.Name;
            tbCompanyName.Text = data.company;
            tbChiefName.Text = data.ChiefName;
            tbChiefPost.Text = data.ChiefPost;
            tbDeveloperName.Text = data.developer;
            tbDeveloperCompany.Text = data.developerCompany;

            this.tbBookName.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbCompanyName.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbChiefName.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbDeveloperName.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbDeveloperCompany.TextChanged += new System.EventHandler(this.tbTextChanged);
        }

        private void tbTextChanged(object sender, EventArgs e)
        {
            TextBox tbCur = (TextBox)sender;

            if (tbCur.Equals(tbBookName))
            {
                DataBook.Book.Name = tbBookName.Text;
            }

            if (tbCur.Equals(tbCompanyName))
            {
                DataBook.Book.company = tbCompanyName.Text;
            }

            if (tbCur.Equals(tbChiefName))
            {
                DataBook.Book.ChiefName = tbChiefName.Text;
            }

            if (tbCur.Equals(tbChiefPost))
            {
                DataBook.Book.ChiefPost = tbChiefPost.Text;
            }

            if (tbCur.Equals(tbDeveloperName))
            {
                DataBook.Book.developer = tbDeveloperName.Text;
            }
            
            if (tbCur.Equals(tbDeveloperCompany))
            {
                DataBook.Book.developerCompany = tbDeveloperCompany.Text;
            }
        }
    }
}
