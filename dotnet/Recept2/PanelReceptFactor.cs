using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class PanelReceptFactor : UserControl
    {
        DataRecept _data;

        public PanelReceptFactor()
        {
            InitializeComponent();
        }
        internal void LoadData(DataRecept data)
        {
            _data = data;
            lblReceptName.Text = _data.Name;
            //rtbFactor.Text = _data.MicroBiology;
            _data.Changed += new EventHandler<DataBaseEventArgs>(_data_Changed);
        }

        void _data_Changed(object sender, DataBaseEventArgs args)
        {
            if (!lblReceptName.Text.Equals(_data.Name))
            {
                lblReceptName.Text = _data.Name;
            }
            if (!rtbFactor.Text.Equals(_data.MicroBiology))
            {
                //rtbFactor.Text = _data.MicroBiology;
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void rtbFactor_TextChanged(object sender, EventArgs e)
        {
           // _data.MicroBiology = rtbFactor.Text;
        }
    }
}
