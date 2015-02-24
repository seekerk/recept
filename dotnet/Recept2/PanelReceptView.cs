using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class PanelReceptView : UserControl
    {
    	/// <summary>
    	/// данные текущей рецептуры
    	/// </summary>
        private DataRecept _data = null;
        /// <summary>
        /// текущий режим просмотра
        /// </summary>
        ViewMode _mode = ViewMode.None;
        
        public PanelReceptView()
        {
            InitializeComponent();
        }

        internal void LoadData(DataRecept dataRecept)
        {
            _data = dataRecept;
            lblReceptName.Text = _data.Name;
            _mode = ViewMode.None;
            _data.Changed += new EventHandler<DataBaseEventArgs>(_data_Changed);
            //throw new Exception("The method or operation is not implemented.");
        }

        void _data_Changed(object sender, DataBaseEventArgs args)
        {
            if (!lblReceptName.Text.Equals(_data.Name))
            {
                lblReceptName.Text = _data.Name;
            }
            switch (_mode)
            {
            	case ViewMode.ReceptView: 
            		if (!richTextBox1.Text.Equals(_data.extView))
            		richTextBox1.Text = _data.extView; 
            		break;
                case ViewMode.ReceptColor: 
            		if (!richTextBox1.Text.Equals(_data.color))
            		richTextBox1.Text = _data.color; 
            		break;
                case ViewMode.ReceptConsistence: 
            		if (!richTextBox1.Text.Equals(_data.consistence))
            		richTextBox1.Text = _data.consistence; 
            		break;
                case ViewMode.ReceptTaste: 
            		if (!richTextBox1.Text.Equals(_data.taste))
            		richTextBox1.Text = _data.taste; 
            		break;
                case ViewMode.ReceptDesign: 
            		if (!richTextBox1.Text.Equals(_data.design))
            		richTextBox1.Text = _data.design; 
            		break;
                case ViewMode.ReceptDelivery: 
            		if (!richTextBox1.Text.Equals(_data.delivery))
            		richTextBox1.Text = _data.delivery; 
            		break;
                case ViewMode.ReceptSale: 
            		if (!richTextBox1.Text.Equals(_data.sale))
            		richTextBox1.Text = _data.sale; 
            		break;
                case ViewMode.ReceptStorage: 
            		if (!richTextBox1.Text.Equals(_data.storage))
            		richTextBox1.Text = _data.storage; 
            		break;
               	case ViewMode.ReceptProcess: 
            		if (!richTextBox1.Text.Equals(_data.process))
            		richTextBox1.Text = _data.process; 
            		break;
              	case ViewMode.ReceptFactors: 
            		throw new NotImplementedException("Убрать цепочку приводящую к этому вызову");
            	case ViewMode.None: 
            		break;
                default:
                    throw new NotImplementedException("The method or operation is not implemented.");
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        public void setMode(ViewMode mode)
        {
            richTextBox1.TextChanged -= new EventHandler(this.richTextBox1_TextChanged);
            _mode = mode;
            switch (mode)
            {
                case ViewMode.ReceptView: 
            		richTextBox1.Text = _data.extView; 
            		labelName.Text = "Описание внешнего вида изделия"; 
            		break;
                case ViewMode.ReceptColor: 
            		richTextBox1.Text = _data.color; 
            		labelName.Text = "Описание цвета изделия"; 
            		break;
                case ViewMode.ReceptConsistence: 
            		richTextBox1.Text = _data.consistence; 
            		labelName.Text = "Описание консистенции изделия"; 
            		break;
                case ViewMode.ReceptTaste: 
            		richTextBox1.Text = _data.taste; 
            		labelName.Text = "Описание вкуса и запаха изделия"; 
            		break;
                case ViewMode.ReceptDesign: 
            		richTextBox1.Text = _data.design; 
            		labelName.Text = "Описание оформления изделия"; 
            		break;
                case ViewMode.ReceptDelivery: 
            		richTextBox1.Text = _data.delivery; 
            		labelName.Text = "Описание подачи изделия"; 
            		break;
                case ViewMode.ReceptSale: 
            		richTextBox1.Text = _data.sale; 
            		labelName.Text = "Описание реализации изделия"; 
            		break;
                case ViewMode.ReceptStorage: 
            		richTextBox1.Text = _data.storage; 
            		labelName.Text = "Описание хранения изделия"; 
            		break;
               case ViewMode.ReceptProcess: 
            		richTextBox1.Text = _data.process; 
            		labelName.Text = "Описание процесса приготовления"; 
            		break;
            	case ViewMode.ReceptFactors:
            		throw new NotImplementedException("Не реализовано");
                case ViewMode.None: break;
				default:
                    throw new Exception("The method or operation is not implemented.");
            }
            richTextBox1.TextChanged += new EventHandler(this.richTextBox1_TextChanged);
            //throw new Exception("The method or operation is not implemented.");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case ViewMode.ReceptView: _data.extView = richTextBox1.Text; break;
                case ViewMode.ReceptColor: _data.color = richTextBox1.Text; break;
                case ViewMode.ReceptConsistence: _data.consistence = richTextBox1.Text; break;
                case ViewMode.ReceptTaste: _data.taste = richTextBox1.Text; break;
                case ViewMode.ReceptDesign: _data.design = richTextBox1.Text; break;
                case ViewMode.ReceptDelivery: _data.delivery = richTextBox1.Text; break;
                case ViewMode.ReceptSale: _data.sale = richTextBox1.Text; break;
                case ViewMode.ReceptStorage: _data.storage = richTextBox1.Text; break;
               	case ViewMode.ReceptProcess: _data.process = richTextBox1.Text; break;
               	case ViewMode.ReceptFactors: throw new NotImplementedException("Не реализовано");
              	case ViewMode.None: break;
                default:
                    throw new Exception("The method or operation is not implemented.");
            }
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
