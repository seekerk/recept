using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class PanelReceptProcess : UserControl
    {
        private DataRecept _data;

        public PanelReceptProcess()
        {
            InitializeComponent();
        }

        internal void LoadData(DataRecept data)
        {
            _data = data;
            lblReceptName.Text = _data.Name;
            rtbProcess.Text = _data.process;
            _data.Changed += new EventHandler<DataBaseEventArgs>(_data_Changed);
        }

        void _data_Changed(object sender, DataBaseEventArgs args)
        {
            if (!lblReceptName.Text.Equals(_data.Name))
            {
                lblReceptName.Text = _data.Name;
            }
            if (!rtbProcess.Text.Equals(_data.process))
            {
                rtbProcess.Text = _data.process;
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void rtbProcess_TextChanged(object sender, EventArgs e)
        {
            _data.process = rtbProcess.Text;
        }
    }
}
