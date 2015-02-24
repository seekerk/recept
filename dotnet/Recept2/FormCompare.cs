using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class FormCompare : Form
    {
        /// <summary>
        /// результат сравнения пользователя
        /// </summary>
        private DataBase myUserRec;

        /// <summary>
        /// результат сравнения пользователя
        /// </summary>
        internal DataBase UserRec
        {
            get { return myUserRec; }
        }

        /// <summary>
        /// Запись из файла
        /// </summary>
        private DataBase myCurRec;

        /// <summary>
        /// Запись из БД
        /// </summary>
        private DataBase myBaseRec;

        private DataBaseType myType;

        internal FormCompare(DataBase curRec, DataBase baseRec, DataBaseType type)
        {
            InitializeComponent();
            myCurRec = curRec;
            myBaseRec = baseRec;
            myType = type;

            if (myBaseRec == null)
            {
                myUserRec = myCurRec;
            }
            else
            {
                myUserRec = myBaseRec;
            }

            cbSelElem.Items.Clear();
            cbSelElem.DisplayMember = "DisplayMember";
            cbSelElem.ValueMember = "ValueMember";

            switch (myType)
            {
                case DataBaseType.RawType:
                    cbSelElem.Items.AddRange(Config.DP.RawList.ToArray());
                    this.Text = "Устранение несоответствий для Компонент";
                    break;
                case DataBaseType.ProcessLossType:
                    cbSelElem.Items.AddRange(Config.DP.ProcessLossList.ToArray());
                    this.Text = "Устранение несоответствий для Потерь горячей обработки";
                    break;
                case DataBaseType.TotalLossType:
                    cbSelElem.Items.AddRange(Config.DP.TotalLossList.ToArray());
                    this.Text = "Устранение несоответствий для Потерь холодной обработки";
                    break;
                case DataBaseType.MicroBiologyType:
                    cbSelElem.Items.AddRange(Config.DP.MicroBiologyList.ToArray());
                    this.Text = "Устранение несоответствий для Показателей микробиологии";
                    break;
                case DataBaseType.MicroBiologyIndicatorType:
                    cbSelElem.Items.AddRange(Config.DP.MicroBiologyIndicatorList.ToArray());
                    this.Text = "Устранение несоответствий для элементов микробиологии";
                    break;
                default:
                    throw new NotImplementedException("Не реализовано");
            }

            cbDoSame.Checked = Config.Cfg.ImportDoSame;
            cbHideEqual.Checked = Config.Cfg.ImportHideEqual;

            LoadData();
        }

        void LoadData()
        {
            dgv.Rows.Clear();
            // если нет записи в БД, то по умолчанию запись пользователя, иначе - запись из БД
            if (myBaseRec == null)
            {
                btnSetToDB.Enabled = false;
                btnSetToFile.Enabled = false;
                btnUpdate.Enabled = false;
            }else{
                btnSetToDB.Enabled = true;
                btnSetToFile.Enabled = true;
                btnUpdate.Enabled = true;
            }

            switch (myType)
            {
                case DataBaseType.RawType:
                case DataBaseType.ProcessLossType:
                    FillDataRawStruct();
                    break;
                case DataBaseType.TotalLossType:
                    FillTotalLossStruct();
                    break;
                case DataBaseType.MicroBiologyType:
                    FillMicroBiologyStruct();
                    break;
                case DataBaseType.MicroBiologyIndicatorType:
                    FillMicroBiologyIndicatorStruct();
                    break;
                default:
                    throw new NotImplementedException("Не реализовано");
            }

            cbSelElem.SelectedItem = myBaseRec;
        }

        void FillTableRecord(bool hideEqual, string rowName, object baseObj, object curObj, object usrObj)
        {
            int curRow = 0;

            if (!hideEqual || !curObj.Equals(baseObj))
            {
                curRow = dgv.Rows.Add();
                dgv["colName", curRow].Value = rowName;
                dgv["colBase", curRow].Value = baseObj;
                dgv["colFile", curRow].Value = curObj;
                dgv["colValue", curRow].Value = usrObj;
                dgv.Rows[curRow].Tag = dgv["colName", curRow].Value;
                if (!dgv["colFile", curRow].Value.Equals(dgv["colBase", curRow].Value))
                    dgv.Rows[curRow].DefaultCellStyle.BackColor = Color.Yellow;
                else
                    dgv.Rows[curRow].DefaultCellStyle.ForeColor = Color.LightGray;
            }
        }

        void FillTotalLossStruct()
        {
            FillTableRecord(false, "Наименование", (myBaseRec == null ? null : myBaseRec.Name),
                myCurRec == null ? null : myCurRec.Name, myUserRec == null ? null : myUserRec.Name);
            FillTableRecord(cbHideEqual.Checked, "Значение", (myBaseRec == null ? 0 : myBaseRec.Quantity),
                myCurRec == null ? 0 : myCurRec.Quantity, myUserRec == null ? 0 : myUserRec.Quantity);
            FillTableRecord(cbHideEqual.Checked, "Комментарий", (myBaseRec == null ? null : myBaseRec.Comment),
                myCurRec == null ? null : myCurRec.Comment, myUserRec == null ? null : myUserRec.Comment);
        }

        void FillDataRawStruct()
        {
            DataRawStruct br = (DataRawStruct)myBaseRec;
            DataRawStruct cr = (DataRawStruct)myCurRec;
            DataRawStruct ur = (DataRawStruct)myUserRec;
            FillTableRecord(false, "Наименование", br == null? null : br.Name,
                cr == null ? null : cr.Name, ur == null ? null : ur.Name);
            FillTableRecord(cbHideEqual.Checked, "Влажность", br == null ? 0 : br.Water,
                cr == null ? 0 : cr.Water, ur == null ? 0 : ur.Water);
            FillTableRecord(cbHideEqual.Checked, "Калорийность", br == null ? 0 : br.Caloric,
                cr == null ? 0 : cr.Caloric, ur == null ? 0 : ur.Caloric);
            FillTableRecord(cbHideEqual.Checked, "Жирность", br == null ? 0 : br.fat,
                cr == null ? 0 : cr.fat, ur == null ? 0 : ur.fat);
            FillTableRecord(cbHideEqual.Checked, "Холестерин", br == null ? 0 : br.cholesterol,
                cr == null ? 0 : cr.cholesterol, ur == null ? 0 : ur.cholesterol);
            FillTableRecord(cbHideEqual.Checked, "Белки", br == null ? 0 : br.protein,
                cr == null ? 0 : cr.protein, ur == null ? 0 : ur.protein);
            FillTableRecord(cbHideEqual.Checked, "Крахмал", br == null ? 0 : br.starch,
                cr == null ? 0 : cr.starch, ur == null ? 0 : ur.starch);
            FillTableRecord(cbHideEqual.Checked, "Моно и дисахариды", br == null ? 0 : br.saccharides,
                cr == null ? 0 : cr.saccharides, ur == null ? 0 : ur.saccharides);
            FillTableRecord(cbHideEqual.Checked, "Органические кислоты", br == null ? 0 : br.acid,
                cr == null ? 0 : cr.acid, ur == null ? 0 : ur.acid);
            FillTableRecord(cbHideEqual.Checked, "Зола", br == null ? 0 : br.ash,
                cr == null ? 0 : cr.ash, ur == null ? 0 : ur.ash);
            FillTableRecord(cbHideEqual.Checked, "Клетчатка", br == null ? 0 : br.cellulose,
                cr == null ? 0 : cr.cellulose, ur == null ? 0 : ur.cellulose);
            FillTableRecord(cbHideEqual.Checked, "Витамин A", br == null ? 0 : br.vitaminA,
                cr == null ? 0 : cr.vitaminA, ur == null ? 0 : ur.vitaminA);
            FillTableRecord(cbHideEqual.Checked, "Витамин B", br == null ? 0 : br.VitaminB,
                cr == null ? 0 : cr.VitaminB, ur == null ? 0 : ur.VitaminB);
            FillTableRecord(cbHideEqual.Checked, "Витамин B1", br == null ? 0 : br.VitaminB1,
                cr == null ? 0 : cr.VitaminB1, ur == null ? 0 : ur.VitaminB1);
            FillTableRecord(cbHideEqual.Checked, "Витамин B2", br == null ? 0 : br.VitaminB2,
                cr == null ? 0 : cr.VitaminB2, ur == null ? 0 : ur.VitaminB2);
            FillTableRecord(cbHideEqual.Checked, "Витамин C", br == null ? 0 : br.VitaminC,
                cr == null ? 0 : cr.VitaminC, ur == null ? 0 : ur.VitaminC);
            FillTableRecord(cbHideEqual.Checked, "Минерал K", br == null ? 0 : br.MineralK,
                cr == null ? 0 : cr.MineralK, ur == null ? 0 : ur.MineralK);
            FillTableRecord(cbHideEqual.Checked, "Минерал Na", br == null ? 0 : br.MineralNA,
                cr == null ? 0 : cr.MineralNA, ur == null ? 0 : ur.MineralNA);
            FillTableRecord(cbHideEqual.Checked, "Минерал Ca", br == null ? 0 : br.MineralCA,
                cr == null ? 0 : cr.MineralCA, ur == null ? 0 : ur.MineralCA);
            FillTableRecord(cbHideEqual.Checked, "Минерал Mg", br == null ? 0 : br.MineralMG,
                cr == null ? 0 : cr.MineralMG, ur == null ? 0 : ur.MineralMG);
            FillTableRecord(cbHideEqual.Checked, "Минерал P", br == null ? 0 : br.MineralP,
                cr == null ? 0 : cr.MineralP, ur == null ? 0 : ur.MineralP);
            FillTableRecord(cbHideEqual.Checked, "Минерал Fe", br == null ? 0 : br.MineralFE,
                cr == null ? 0 : cr.MineralFE, ur == null ? 0 : ur.MineralFE);
            FillTableRecord(cbHideEqual.Checked, "Нормативный документ", br == null ? null : br.NormativDoc,
                cr == null ? null : cr.NormativDoc, ur == null ? null : ur.NormativDoc);
            FillTableRecord(cbHideEqual.Checked, "Брутто/Нетто", br == null ? 0 : br.Brutto,
                cr == null ? 0 : cr.Brutto, ur == null ? 0 : ur.Brutto);
            FillTableRecord(cbHideEqual.Checked, "Отображение в списке состава", br == null ? true : br.InSostav,
                cr == null ? true : cr.InSostav, ur == null ? true : ur.InSostav);
            FillTableRecord(cbHideEqual.Checked, "Отображение элемента в рецептуре", br == null ? true : br.InRecept,
                cr == null ? true : cr.InRecept, ur == null ? true : ur.InRecept);
            FillTableRecord(cbHideEqual.Checked, "Комментарий", br == null ? null : br.Comment,
                cr == null ? null : cr.Comment, ur == null ? null : ur.Comment);
        }

		void FillMicroBiologyStruct()
		{
			throw new NotImplementedException();
		}
		
		void FillMicroBiologyIndicatorStruct()
		{
			throw new NotImplementedException();
		}
		
        private void btnSetToDB_Click(object sender, EventArgs e)
        {
            myUserRec = myBaseRec;
            Close();
        }

        private void btnSetToFile_Click(object sender, EventArgs e)
        {
            myUserRec = myCurRec;
            myUserRec.Id = myBaseRec.Id;
            switch (myType)
            {
                case DataBaseType.RawType:
                    Config.DP.UpdateRaw(myUserRec as DataRawStruct);
                    break;
                case DataBaseType.ProcessLossType:
                    Config.DP.UpdateProcessLoss(myUserRec as DataRawStruct);
                    break;
                case DataBaseType.TotalLossType:
                    Config.DP.UpdateTotalLossStruct(myUserRec as DataTotalLoss);
                    break;
                case DataBaseType.MicroBiologyType:
                    Config.DP.UpdateMicroBiologyStruct(myUserRec as DataMicroBiology);
                    break;
                case DataBaseType.MicroBiologyIndicatorType:
                    Config.DP.UpdateMicroBiologyIndicatorStruct(myUserRec as DataMicroBiologyIndicator);
                    break;
                default:
                    throw new NotImplementedException("Не реализовано");
            }
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            GetValues();
            switch (myType)
            {
                case DataBaseType.RawType:
                    Config.DP.AddRaw(myUserRec as DataRawStruct);
                    myUserRec = Config.DP.FindRaw(myUserRec as DataRawStruct);
                    break;
                case DataBaseType.ProcessLossType:
                    Config.DP.AddProcessLoss(myUserRec as DataRawStruct);
                    myUserRec = Config.DP.FindProcessLoss(myUserRec as DataRawStruct);
                    break;
                case DataBaseType.TotalLossType:
                    Config.DP.AddTotalLossStruct(myUserRec as DataTotalLoss);
                    myUserRec = Config.DP.FindTotalLoss(myUserRec as DataTotalLoss);
                    break;
                case DataBaseType.MicroBiologyType:
                    Config.DP.AddMicroBiologyStruct(myUserRec as DataMicroBiology);
                    myUserRec = Config.DP.FindMicroBiology(myUserRec as DataMicroBiology);
                    break;
                case DataBaseType.MicroBiologyIndicatorType:
                    Config.DP.AddMicroBiologyIndicatorStruct(myUserRec as DataMicroBiologyIndicator);
                    myUserRec = Config.DP.FindMicroBiologyIndicator(myUserRec as DataMicroBiologyIndicator);
                    break;
                default:
                    throw new NotImplementedException("Не реализовано");
            }
            Close();
        }

        /// <summary>
        /// Загрузка значений из формы
        /// </summary>
        private void GetValues()
        {
            myUserRec = myCurRec;
        }

        private void cbSelElem_SelectedIndexChanged(object sender, EventArgs e)
        {
            myBaseRec = ((DataBase)cbSelElem.SelectedItem);
            LoadData();
        }
        
        void CbHideEqualCheckedChanged(object sender, EventArgs e)
        {
        	Config.Cfg.ImportHideEqual = cbHideEqual.Checked;
        	LoadData();
        }
        
        void CbDoSameCheckedChanged(object sender, EventArgs e)
        {
        	Config.Cfg.ImportDoSame = cbDoSame.Checked;
        }
    }
}