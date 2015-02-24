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
    public partial class PanelRawData : UserControl
    {
        internal DataRawStruct _data;
        internal DataBaseType _recType;
        public PanelRawData()
        {
            InitializeComponent();
        }

        internal void SetData(DataRawStruct p, DataBaseType RecType)
        {
            _recType = RecType;
            // меняем фейс
            switch (_recType)
            {
                case DataBaseType.ProcessLossType:
                    label1.Text = "Потери при тепловой обработке";
                    label4.Text = "Потеря массы";
                    cboxInRecept.Visible = false;
                    cboxInSostav.Visible = false;
                    break;
                case DataBaseType.RawType:
                    label1.Text = "Сырье";
                    label4.Text = "Брутто/Нетто";
                    cboxInRecept.Visible = true;
                    cboxInSostav.Visible = true;
                    break;
                default:
                    throw new Exception("Не реализовано");
            }

            // меняем данные
            if (p != null)
            {
                this.tbBrutto.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbCaloric.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbStarch.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbSaccharides.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbCellulose.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbCholesterol.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbComment.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbFat.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbAcid.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbAsh.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbMinCa.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbMinFe.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbMinK.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbMinMg.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbMinNa.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbMinP.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbName.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbNormativ.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbNum.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbProtein.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbVitA.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbVitB.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbVitB1.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbVitB2.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbVitC.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbVitPP.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.tbWater.TextChanged -= new System.EventHandler(this.tbTextChanged);
                this.cboxInRecept.CheckedChanged -= new System.EventHandler(this.cboxCheckedChanged);
                this.cboxInSostav.CheckedChanged -= new System.EventHandler(this.cboxCheckedChanged);

                _data = p;
                tbBrutto.Text = p.Brutto.ToString(CultureInfo.CurrentCulture);
                tbCaloric.Text = p.Caloric.ToString(CultureInfo.CurrentCulture);
                tbStarch.Text = p.starch.ToString(CultureInfo.CurrentCulture);
                tbSaccharides.Text = p.saccharides.ToString(CultureInfo.CurrentCulture);
                tbCellulose.Text = p.cellulose.ToString(CultureInfo.CurrentCulture);
                tbCholesterol.Text = p.cholesterol.ToString(CultureInfo.CurrentCulture);
                tbComment.Text = p.Comment;
                tbFat.Text = p.fat.ToString(CultureInfo.CurrentCulture);
                tbAcid.Text = p.acid.ToString(CultureInfo.CurrentCulture);
                tbAsh.Text = p.ash.ToString(CultureInfo.CurrentCulture);
                tbMinCa.Text = p.MineralCA.ToString(CultureInfo.CurrentCulture);
                tbMinFe.Text = p.MineralFE.ToString(CultureInfo.CurrentCulture);
                tbMinK.Text = p.MineralK.ToString(CultureInfo.CurrentCulture);
                tbMinMg.Text = p.MineralMG.ToString(CultureInfo.CurrentCulture);
                tbMinNa.Text = p.MineralNA.ToString(CultureInfo.CurrentCulture);
                tbMinP.Text = p.MineralP.ToString(CultureInfo.CurrentCulture);
                tbName.Text = p.Name;
                tbNormativ.Text = p.NormativDoc;
                tbNum.Text = p.Id.ToString(CultureInfo.CurrentCulture);
                tbProtein.Text = p.protein.ToString(CultureInfo.CurrentCulture);
                tbVitA.Text = p.vitaminA.ToString(CultureInfo.CurrentCulture);
                tbVitB.Text = p.VitaminB.ToString(CultureInfo.CurrentCulture);
                tbVitB1.Text = p.VitaminB1.ToString(CultureInfo.CurrentCulture);
                tbVitB2.Text = p.VitaminB2.ToString(CultureInfo.CurrentCulture);
                tbVitC.Text = p.VitaminC.ToString(CultureInfo.CurrentCulture);
                tbVitPP.Text = p.VitaminPP.ToString(CultureInfo.CurrentCulture);
                tbWater.Text = p.Water.ToString(CultureInfo.CurrentCulture);
                cboxInRecept.Checked = p.InRecept;
                cboxInSostav.Checked = p.InSostav;

                this.tbBrutto.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbCaloric.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbStarch.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbSaccharides.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbCellulose.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbCholesterol.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbComment.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbFat.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbAcid.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbAsh.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbMinCa.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbMinFe.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbMinK.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbMinMg.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbMinNa.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbMinP.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbName.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbNormativ.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbNum.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbProtein.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbVitA.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbVitB.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbVitB1.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbVitB2.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbVitC.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbVitPP.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.tbWater.TextChanged += new System.EventHandler(this.tbTextChanged);
                this.cboxInRecept.CheckedChanged += new System.EventHandler(this.cboxCheckedChanged);
                this.cboxInSostav.CheckedChanged += new System.EventHandler(this.cboxCheckedChanged);
            }
        }

        private void tbTextChanged(object sender, EventArgs e)
        {
            if (_data == null)
            {
                return;
            }
            TextBox tb = (TextBox)sender;
            decimal ret;
            try
            {
                if (tb.Equals(tbBrutto))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret <= 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.Brutto != ret) _data.Brutto = ret;
                }
                if (tb.Equals(tbCaloric))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                        if (_data.Caloric != ret) _data.Caloric = ret;
                }
                if (tb.Equals(tbStarch))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                        if (_data.starch != ret) _data.starch = ret;
                }
                if (tb.Equals(tbSaccharides))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                    if (_data.saccharides != ret) _data.saccharides = ret;
                }
                if (tb.Equals(tbCellulose))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                        if (_data.cellulose != ret) _data.cellulose = ret;
                }
                if (tb.Equals(tbCholesterol))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                        if (_data.cholesterol != ret) _data.cholesterol = ret;
                }
                if (tb.Equals(tbComment))
                {
                        if (!_data.Comment.Equals(tb.Text))
                            _data.Comment = tb.Text;
                }
                if (tb.Equals(tbFat))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                        if (_data.fat != ret) _data.fat = ret;
                }
                if (tb.Equals(tbAcid))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                    if (_data.acid != ret) _data.acid = ret;
                }
                if (tb.Equals(tbAsh))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                    if (_data.ash != ret) _data.ash = ret;
                }
                if (tb.Equals(tbMinCa))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                        if (_data.MineralCA != ret) _data.MineralCA = ret;
                }
                if (tb.Equals(tbMinFe))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                        if (_data.MineralFE != ret) _data.MineralFE = ret;
                }
                if (tb.Equals(tbMinK))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                        {
                            throw new OverflowException();
                        }
                        if (_data.MineralK != ret) _data.MineralK = ret;
                }
                if (tb.Equals(tbMinMg))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                        {
                            throw new OverflowException();
                        }
                        if (_data.MineralMG != ret) _data.MineralMG = ret;
                }
                if (tb.Equals(tbMinNa))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                        {
                            throw new OverflowException();
                        }
                        if (_data.MineralNA != ret) _data.MineralNA = ret;
                }
                if (tb.Equals(tbMinP))
                {
                        ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                        if (ret < 0 && _recType == DataBaseType.RawType)
                        {
                            throw new OverflowException();
                        }
                        if (_data.MineralP != ret) _data.MineralP = ret;
                }
                if (tb.Equals(tbName))
                {
                    if (tb.Text.Length == 0)
                    {
                        throw new OverflowException();
                    }
                        if (!_data.Name.Equals(tb.Text)) _data.Name = tb.Text;
                }
                if (tb.Equals(tbNormativ))
                {
                    if (!_data.NormativDoc.Equals(tb.Text)) _data.NormativDoc = tb.Text;
                }
                if (tb.Equals(tbNum))
                {
                    int rnum = int.Parse(tb.Text, CultureInfo.CurrentCulture);
                    if (rnum < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    _data.Id = rnum;
                }
                if (tb.Equals(tbProtein))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType || ret > 100)
                    {
                        throw new OverflowException();
                    }
                    if (_data.protein != ret) _data.protein = ret;
                }
                if (tb.Equals(tbVitA))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.vitaminA != ret) _data.vitaminA = ret;
                }
                if (tb.Equals(tbVitB))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.VitaminB != ret) _data.VitaminB = ret;
                }
                if (tb.Equals(tbVitB1))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.VitaminB1 != ret) _data.VitaminB1 = ret;
                }
                if (tb.Equals(tbVitB2))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.VitaminB2 != ret) _data.VitaminB2 = ret;
                }
                if (tb.Equals(tbVitC))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.VitaminC != ret) _data.VitaminC = ret;
                }
                if (tb.Equals(tbVitPP))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType)
                    {
                        throw new OverflowException();
                    }
                    if (_data.VitaminPP != ret) _data.VitaminPP = ret;
                }
                if (tb.Equals(tbWater))
                {
                    ret = Convert.ToDecimal(tb.Text, CultureInfo.CurrentCulture);
                    if (ret < 0 && _recType == DataBaseType.RawType || ret > 100 || ret < -100)
                    {
                        throw new OverflowException();
                    }
                    if (_data.Water != ret) _data.Water = ret;
                }
                tb.BackColor = Color.White;
                if (_data.IsChanged)
                {
                    ((FormDB)this.ParentForm).IsDataChanged = true;
                }
            }
            catch (System.Exception)
            {
                tb.BackColor = Color.Yellow;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((FormDB)this.ParentForm).SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((FormDB)this.ParentForm).CancelChanges();
        }

        /// <summary>
        /// обработка изменения комобобоксов
        /// </summary>
        /// <param name="sender">комбобокс</param>
        /// <param name="e">событие</param>
        private void cboxCheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Equals(cboxInRecept))
            {
                if (cb.Checked != _data.InRecept)
                    _data.InRecept = cboxInRecept.Checked;
            }
            if (cb.Equals(cboxInSostav))
            {
                if (cb.Checked != _data.InSostav)
                {
                    _data.InSostav = cb.Checked;
                }
            }
            if (_data.IsChanged)
            {
                ((FormDB)this.ParentForm).IsDataChanged = true;
            }
        }
    }
}
