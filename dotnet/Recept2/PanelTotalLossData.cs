using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class PanelTotalLossData : UserControl
    {
        internal DataTotalLoss _data;

        public PanelTotalLossData()
        {
            InitializeComponent();
        }

        internal void SetData(DataTotalLoss p)
        {
            _data = p;
            tbNum.Text = _data.Id.ToString(CultureInfo.CurrentCulture);
            tbName.Text = _data.Name;
            tbQuantity.Text = _data.Quantity.ToString(CultureInfo.CurrentCulture);
            tbComment.Text = _data.Comment;
            //throw new Exception("The method or operation is not implemented.");
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (!_data.Name.Equals(tbName.Text))
            {
                _data.Name = tbName.Text;
                ((FormDB)this.ParentForm).IsDataChanged = true;
            }
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal ret = Convert.ToDecimal(tbQuantity.Text, CultureInfo.CurrentCulture);
                if (ret != _data.Quantity)
                {
                    _data.Quantity = ret;
                    ((FormDB)this.ParentForm).IsDataChanged = true;
                }
                tbQuantity.BackColor = Color.White;
            }
            catch (System.Exception)
            {
                tbQuantity.BackColor = Color.Yellow;
            }
        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {
            if (!_data.Comment.Equals(tbComment.Text))
            {
                _data.Comment = tbComment.Text;
                ((FormDB)this.ParentForm).IsDataChanged = true;
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            ((FormDB)this.ParentForm).SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((FormDB)this.ParentForm).CancelChanges();
        }
    }
}
