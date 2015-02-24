// <copyright file="FormConfig.cs" company="SeekerSoft">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>$Author$</author>
// <email>seeker.k@gmail.com</email>
// <date>$LastChangedDate$</date>
// <summary>Содержит описание формы настроек.</summary>

namespace Recept2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Форма работы с настройками программы.
    /// </summary>
    public partial class FormConfig : Form
    {
        /// <summary>
        /// Ключ-строка для БД SQlite.
        /// </summary>
        private string dBtypeSQLite = "БД SQLite";
        
        /// <summary>
        /// Ключ-строка для БД MS Access
        /// </summary>
        private string dBtypeMDB = "БД MS Access";
        
        /// <summary>
        /// Текущая конфигурация системы.
        /// </summary>
        private Config curCfg;
        
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public FormConfig()
        {
            InitializeComponent();
            this.curCfg = (Config)Config.Cfg.Clone();
            this.tbBDName.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbExit.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbPrecision.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbTemplate.TextChanged -= new System.EventHandler(this.tbTextChanged);
            this.tbPandoc.TextChanged -= new System.EventHandler(this.tbTextChanged);
            
            this.tbBDName.Text = curCfg.DBFile;
            this.tbExit.Text = curCfg.TotalExit.ToString(CultureInfo.CurrentCulture);
            this.tbPrecision.Text = curCfg.Precision.ToString(CultureInfo.CurrentCulture);
            this.tbTemplate.Text = curCfg.DefaultFile;
            this.tbPandoc.Text = curCfg.Pandoc;
            this.cbDBType.Items.Clear();
            this.cbDBType.Items.Add(dBtypeSQLite);
            this.cbDBType.Items.Add(dBtypeMDB);
            this.cbDBType.SelectedItem = curCfg.IsSQliteData ? dBtypeSQLite : dBtypeMDB;
            this.panelConfigReport1.LoadData(this.curCfg);
            
            this.tbBDName.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbExit.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbPrecision.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbTemplate.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.tbPandoc.TextChanged += new System.EventHandler(this.tbTextChanged);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panelConfigReport1.StoreData(curCfg);
            Config.Cfg = curCfg;
            Config.Cfg.StoreConfig();
            this.Close();
        }

        private void tbTextChanged(object sender, EventArgs e)
        {
            bool isCorrectValue = true;
            if (tbBDName.Equals(sender))
            {
                if (tbBDName.Text.Length == 0)
                {
                    tbBDName.BackColor = Color.Yellow;
                }else{
                    curCfg.DBFile = tbBDName.Text;
                    tbBDName.BackColor = Color.White;
                }
            }
            if (tbTemplate.Equals(sender))
            {
                if (tbTemplate.Text.Length == 0)
                {
                    tbTemplate.BackColor = Color.Yellow;
                }else{
                    curCfg.DefaultFile = tbTemplate.Text;
                    tbTemplate.BackColor = Color.White;
                }
            }
            if (tbExit.Equals(sender))
            {
                decimal ret = curCfg.TotalExit;
                try
                {
                    ret = Convert.ToDecimal(tbExit.Text, CultureInfo.CurrentCulture);
                    if (ret <= 0)
                    {
                        throw new OverflowException();
                    }
                    tbExit.BackColor = Color.White;
                }
                catch (System.Exception)
                {
                    isCorrectValue = false;
                    tbExit.BackColor = Color.Yellow;
                }
                if (isCorrectValue && curCfg.TotalExit != ret)
                {
                    curCfg.TotalExit = ret;
                }
            }
            if (tbPrecision.Equals(sender))
            {
                int ret = curCfg.Precision;
                try
                {
                    ret = Convert.ToInt32(tbPrecision.Text, CultureInfo.CurrentCulture);
                    if (ret < 0)
                    {
                        throw new OverflowException();
                    }
                    tbPrecision.BackColor = Color.White;
                }
                catch (OverflowException)
                {
                    isCorrectValue = false;
                    tbPrecision.BackColor = Color.Yellow;
                } catch (FormatException) {
					isCorrectValue = false;
					tbPrecision.BackColor = Color.Yellow;
				}
                if (isCorrectValue && curCfg.Precision != ret)
                    curCfg.Precision = ret;
            }
            if (tbPandoc.Equals(sender))
            {
                if (tbPandoc.Text.Length == 0)
                {
                    tbPandoc.BackColor = Color.Yellow;
                }else{
                    curCfg.Pandoc = tbPandoc.Text;
                    tbPandoc.BackColor = Color.White;
                }
            }
        }
        
        private void cbDBTypeChanged(object sender, EventArgs e)
        {
            if (cbDBType.SelectedItem.Equals(dBtypeSQLite))
                curCfg.IsSQliteData = true;
            else{
                if (cbDBType.SelectedItem.Equals(dBtypeMDB))
                    curCfg.IsSQliteData = false;
                else{
                    throw new Exception("Такой тип БД не реализован");
                }
            }
        }

        private void btnBDSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "База данных компонент (*.mdb, *.sqlite)|*.mdb;*.sqlite";
            dlg.FileName = tbBDName.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbBDName.Text = dlg.FileName;
                if (tbBDName.Text.LastIndexOf(".mdb", StringComparison.CurrentCultureIgnoreCase) == tbBDName.Text.Length - 4 &&
                    curCfg.IsSQliteData)
                {
                    cbDBType.SelectedItem = dBtypeMDB;
                }
                if (tbBDName.Text.LastIndexOf(".sqlite", StringComparison.CurrentCultureIgnoreCase) == tbBDName.Text.Length - 7 &&
                    !curCfg.IsSQliteData)
                {
                    cbDBType.SelectedItem = dBtypeSQLite;
                }
            }
        }

        private void btnTemplateSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".rcp2";
            dlg.Filter = "Книга рецептур (*.rcp2)|*.rcp2";
            dlg.FileName = tbTemplate.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbTemplate.Text = dlg.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Config.DeleteConfig();
        }
        
        void BtnPandocSelectClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".exe";
            dlg.Filter = "Выполняемые программы (*.exe)|*.exe";
            dlg.FileName = tbPandoc.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbPandoc.Text = dlg.FileName;
            }
        }
    }
}