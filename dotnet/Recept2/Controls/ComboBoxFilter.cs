using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Recept2.Controls
{
    class ComboBoxFilter : ComboBox
    {
        public ComboBoxFilter() : base()
        {
            this.KeyDown += new KeyEventHandler(MyComboBox_KeyDown);
            this.TextChanged += new EventHandler(MyComboBox_TextChanged);
        }

        void MyComboBox_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Text);
            //throw new Exception("The method or operation is not implemented.");
        }

        void MyComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.DroppedDown)
                this.DroppedDown = true;
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
