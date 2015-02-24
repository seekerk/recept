using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace Recept2
{
    /// <summary>
    /// Интерфейс с базой данных
    /// </summary>
    public class DPodbc: DataProvider, IDisposable
    {
        #region Переменные класса
        OdbcConnection conn; // соединение
        OdbcDataAdapter adapter; // адаптер БД
        #endregion

        #region Конструктор класса
        public DPodbc()
        {
            // создаем соединение с БД
            try{
                //this.conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                //    CommonFunctions.AbsolutePathFromAnyPath(Application.StartupPath, Config.cfg.dbFile));
                this.conn = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};DBQ=" +
                                               CommonFunctions.AbsolutePathFromAnyPath(Application.StartupPath, Config.Cfg.DBFile));
                //Extended Properties=dBase 5.0 // dbf
                this.adapter = new OdbcDataAdapter();
            } catch (OdbcException pe)
            {
                MessageBox.Show(pe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }
        #endregion

        #region работа с элементами типа DataRawStruct (GetDataRawList)
        protected override SortableBindingList<DataRawStruct> LoadDataRawList(string tableName)
        {
            DataTable comp_table = null;
            String sql = "SELECT * FROM " + tableName + " ORDER BY name ASC";
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.SelectCommand = new OdbcCommand(sql, this.conn);
                DataSet ds = new DataSet("tables");
                ds.Locale = CultureInfo.InvariantCulture;
                this.adapter.Fill(ds);
                comp_table = ds.Tables[0];
            }
            catch (OdbcException pe)
            {
                MessageBox.Show(pe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return null;
            }

            SortableBindingList<DataRawStruct> ret = new SortableBindingList<DataRawStruct>();
            for (int i = 0; i < comp_table.Rows.Count; i++)
            {
                DataRawStruct curRec = new DataRawStruct(null);
                curRec.Brutto = Convert.ToDecimal(comp_table.Rows[i]["brutto"] is DBNull ? 0 : comp_table.Rows[i]["brutto"], CultureInfo.InvariantCulture);
                curRec.Caloric = Convert.ToDecimal(comp_table.Rows[i]["caloric"] is DBNull ? 0 : comp_table.Rows[i]["caloric"], CultureInfo.InvariantCulture);
                curRec.starch = Convert.ToDecimal(comp_table.Rows[i]["starch"] is DBNull ? 0 : comp_table.Rows[i]["starch"], CultureInfo.InvariantCulture);
                curRec.saccharides = Convert.ToDecimal(comp_table.Rows[i]["saccharides"] is DBNull ? 0 : comp_table.Rows[i]["saccharides"], CultureInfo.InvariantCulture);
                curRec.cellulose = Convert.ToDecimal(comp_table.Rows[i]["cellulose"] is DBNull ? 0 : comp_table.Rows[i]["cellulose"], CultureInfo.InvariantCulture);
                curRec.cholesterol = Convert.ToDecimal(comp_table.Rows[i]["cholesterol"] is DBNull ? 0 : comp_table.Rows[i]["cholesterol"], CultureInfo.InvariantCulture);
                curRec.Comment = comp_table.Rows[i]["comment"].ToString();
                curRec.fat = Convert.ToDecimal(comp_table.Rows[i]["fat"] is DBNull ? 0 : comp_table.Rows[i]["fat"], CultureInfo.InvariantCulture);
                curRec.acid = Convert.ToDecimal(comp_table.Rows[i]["acid"] is DBNull ? 0 : comp_table.Rows[i]["acid"], CultureInfo.InvariantCulture);
                curRec.ash = Convert.ToDecimal(comp_table.Rows[i]["ash"] is DBNull ? 0 : comp_table.Rows[i]["ash"], CultureInfo.InvariantCulture);
                curRec.Id = Convert.ToInt32(comp_table.Rows[i]["id"], CultureInfo.InvariantCulture);
                curRec.MineralCA = Convert.ToDecimal(comp_table.Rows[i]["mineralCa"] is DBNull ? 0 : comp_table.Rows[i]["mineralCa"], CultureInfo.InvariantCulture);
                curRec.MineralFE = Convert.ToDecimal(comp_table.Rows[i]["mineralFe"] is DBNull ? 0 : comp_table.Rows[i]["mineralFe"], CultureInfo.InvariantCulture);
                curRec.MineralK = Convert.ToDecimal(comp_table.Rows[i]["mineralK"] is DBNull ? 0 : comp_table.Rows[i]["mineralK"], CultureInfo.InvariantCulture);
                curRec.MineralMG = Convert.ToDecimal(comp_table.Rows[i]["mineralMg"] is DBNull ? 0 : comp_table.Rows[i]["mineralMg"], CultureInfo.InvariantCulture);
                curRec.MineralNA = Convert.ToDecimal(comp_table.Rows[i]["mineralNa"] is DBNull ? 0 : comp_table.Rows[i]["mineralNa"], CultureInfo.InvariantCulture);
                curRec.MineralP = Convert.ToDecimal(comp_table.Rows[i]["mineralP"] is DBNull ? 0 : comp_table.Rows[i]["mineralP"], CultureInfo.InvariantCulture);
                curRec.Name = comp_table.Rows[i]["name"].ToString();
                curRec.NormativDoc = comp_table.Rows[i]["normativDoc"].ToString();
                curRec.protein = Convert.ToDecimal(comp_table.Rows[i]["protein"] is DBNull ? 0 : comp_table.Rows[i]["protein"], CultureInfo.InvariantCulture);
                curRec.vitaminA = Convert.ToDecimal(comp_table.Rows[i]["vitaminA"] is DBNull ? 0 : comp_table.Rows[i]["vitaminA"], CultureInfo.InvariantCulture);
                curRec.VitaminB = Convert.ToDecimal(comp_table.Rows[i]["vitaminB"] is DBNull ? 0 : comp_table.Rows[i]["vitaminB"], CultureInfo.InvariantCulture);
                curRec.VitaminB1 = Convert.ToDecimal(comp_table.Rows[i]["vitaminB1"] is DBNull ? 0 : comp_table.Rows[i]["vitaminB1"], CultureInfo.InvariantCulture);
                curRec.VitaminB2 = Convert.ToDecimal(comp_table.Rows[i]["vitaminB2"] is DBNull ? 0 : comp_table.Rows[i]["vitaminB2"], CultureInfo.InvariantCulture);
                curRec.VitaminC = Convert.ToDecimal(comp_table.Rows[i]["vitaminC"] is DBNull ? 0 : comp_table.Rows[i]["vitaminC"], CultureInfo.InvariantCulture);
                curRec.VitaminPP = Convert.ToDecimal(comp_table.Rows[i]["vitaminPP"] is DBNull ? 0 : comp_table.Rows[i]["vitaminPP"], CultureInfo.InvariantCulture);
                curRec.Water = Convert.ToDecimal(comp_table.Rows[i]["water"] is DBNull ? 0 : comp_table.Rows[i]["water"], CultureInfo.InvariantCulture);
                if (comp_table.Columns.Contains("inSostav"))
                {
                    curRec.InSostav = Convert.ToBoolean(comp_table.Rows[i]["inSostav"] is DBNull ? true : comp_table.Rows[i]["inSostav"], CultureInfo.InvariantCulture);
                }

                if (comp_table.Columns.Contains("inRecept"))
                {
                    curRec.InRecept = Convert.ToBoolean(comp_table.Rows[i]["inRecept"] is DBNull ? true : comp_table.Rows[i]["inRecept"], CultureInfo.InvariantCulture);
                }
                
                curRec.IsChanged = false;
                ret.Add(curRec);
            }

            return ret;
        }

        /// <summary>
        /// Добавление записи в таблицу
        /// </summary>
        /// <param name="curRec">запись которая добавляется</param>
        /// <param name="tableName">имя таблицы</param>
        protected override void AddDataRawStruct(DataRawStruct curRec, string tableName)
        {
            string sqlStr = "INSERT INTO " + tableName + " (name, water, caloric, fat, acid, ash, cholesterol, protein, starch, saccharides, cellulose, vitaminA, vitaminB, vitaminB1, vitaminB2, vitaminPP, vitaminC, mineralK, mineralNa, mineralCa, mineralMg, mineralP, mineralFe, comment, normativDoc, brutto, inSostav, inRecept) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                "?, ?, ?, ?, ?, ?, ?, ?)";
            OdbcCommand cmd = new OdbcCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            cmd.Parameters.AddWithValue("@water", curRec.Water.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@caloric", curRec.Caloric.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@fat", curRec.fat.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@acid", curRec.acid.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@ash", curRec.ash.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@cholesterol", curRec.cholesterol.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@protein", curRec.protein.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@starch", curRec.starch.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@saccharides", curRec.saccharides.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@cellulose", curRec.cellulose.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminA", curRec.vitaminA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB", curRec.VitaminB.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB1", curRec.VitaminB1.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB2", curRec.VitaminB2.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminPP", curRec.VitaminPP.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminC", curRec.VitaminC.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralK", curRec.MineralK.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralNa", curRec.MineralNA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralCa", curRec.MineralCA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralMg", curRec.MineralMG.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralP", curRec.MineralP.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralFe", curRec.MineralFE.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@comment", curRec.Comment);
            cmd.Parameters.AddWithValue("@normativDoc", curRec.NormativDoc);
            cmd.Parameters.AddWithValue("@brutto", curRec.Brutto.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@inSostav", curRec.InSostav);
            cmd.Parameters.AddWithValue("@inRecept", curRec.InRecept);
            int ret = 0;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.InsertCommand = cmd;
                ret = this.adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Обновление записи неудачно:\n " + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return;
            }
            if (ret != 1)
            {
                MessageBox.Show("Во время обновления произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            curRec.IsChanged = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Обновление записи в таблице
        /// </summary>
        /// <param name="curRec">запись</param>
        /// <param name="tableName">имя таблицы</param>
        protected override void UpdateDataRawStruct(DataRawStruct curRec, string tableName)
        {
            string sqlStr = "UPDATE " + tableName + " SET name=?, water=?, caloric=?, fat=?, acid=?, ash=?, cholesterol=?, protein=?, starch=?, saccharides=?, cellulose=?, vitaminA=?, vitaminB=?, vitaminB1=?, vitaminB2=?, vitaminPP=?, vitaminC=?, mineralK=?, mineralNa=?, mineralCa=?, mineralMg=?, mineralP=?, mineralFe=?, comment=?, normativDoc=?, brutto=?, inSostav=?, inRecept=? WHERE id=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            cmd.Parameters.AddWithValue("@water", curRec.Water.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@caloric", curRec.Caloric.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@fat", curRec.fat.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@acid", curRec.acid.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@ash", curRec.ash.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@cholesterol", curRec.cholesterol.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@protein", curRec.protein.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@starch", curRec.starch.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@saccharides", curRec.saccharides.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@cellulose", curRec.cellulose.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminA", curRec.vitaminA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB", curRec.VitaminB.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB1", curRec.VitaminB1.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB2", curRec.VitaminB2.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminPP", curRec.VitaminPP.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminC", curRec.VitaminC.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralK", curRec.MineralK.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralNa", curRec.MineralNA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralCa", curRec.MineralCA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralMg", curRec.MineralMG.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralP", curRec.MineralP.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralFe", curRec.MineralFE.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@comment", curRec.Comment);
            cmd.Parameters.AddWithValue("@normativDoc", curRec.NormativDoc);
            cmd.Parameters.AddWithValue("@brutto", curRec.Brutto.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@inSostav", curRec.InSostav);
            cmd.Parameters.AddWithValue("@inRecept", curRec.InRecept);
            cmd.Parameters.AddWithValue("@id", curRec.Id.ToString(CultureInfo.InvariantCulture));
            //throw new Exception("The method or operation is not implemented.");
            int ret = 0;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.UpdateCommand = cmd;
                ret = this.adapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Обновление записи неудачно:\n " + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return;
            }
            if (ret != 1)
            {
                MessageBox.Show("Во время обновления произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            curRec.IsChanged = false;
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        /// <param name="curRec">запись</param>
        /// <param name="tableName">имя таблицы</param>
        protected override void DeleteRecord(DataBase curRec, string tableName)
        {
            string sqlStr = "DELETE FROM " + tableName + " WHERE id=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@id", curRec.Id.ToString(CultureInfo.InvariantCulture));

            int ret = 0;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.DeleteCommand = cmd;
                ret = this.adapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Удаление записи неудачно:\n " + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return;
            }
            if (ret != 1)
            {
                MessageBox.Show("Во время удаления произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            curRec.IsChanged = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Поиск записи о компоненте пользователя в БД
        /// </summary>
        /// <param name="curRaw">компонента пользователя</param>
        /// <returns>найденная запись если есть</returns>
        protected override int FindDataRawStruct(DataRawStruct curRec, string tableName)
        {
            string sqlStr = "SELECT id FROM " + tableName + " WHERE name=? AND water=? AND caloric=? AND fat=? AND acid=? AND ash=? AND cholesterol=? AND protein=? AND starch=? AND saccharides=? AND cellulose=? AND vitaminA=? AND vitaminB=? AND vitaminB1=? AND vitaminB2=? AND vitaminPP=? AND vitaminC=? AND mineralK=? AND mineralNa=? AND mineralCa=? AND mineralMg=? AND mineralP=? AND mineralFe=? AND normativDoc=? AND brutto=? AND inSostav=? AND inRecept=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            cmd.Parameters.AddWithValue("@water", curRec.Water.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@caloric", curRec.Caloric.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@fat", curRec.fat.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@acid", curRec.acid.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@ash", curRec.ash.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@cholesterol", curRec.cholesterol.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@protein", curRec.protein.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@starch", curRec.starch.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@saccharides", curRec.saccharides.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@cellulose", curRec.cellulose.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminA", curRec.vitaminA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB", curRec.VitaminB.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB1", curRec.VitaminB1.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminB2", curRec.VitaminB2.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminPP", curRec.VitaminPP.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@vitaminC", curRec.VitaminC.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralK", curRec.MineralK.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralNa", curRec.MineralNA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralCa", curRec.MineralCA.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralMg", curRec.MineralMG.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralP", curRec.MineralP.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@mineralFe", curRec.MineralFE.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@normativDoc", curRec.NormativDoc);
            cmd.Parameters.AddWithValue("@brutto", curRec.Brutto.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@inSostav", curRec.InSostav);
            cmd.Parameters.AddWithValue("@inRecept", curRec.InRecept);
            //throw new Exception("The method or operation is not implemented.");

            DataTable comp_table = null;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.SelectCommand = cmd;
                DataSet ds = new DataSet("tables");
                ds.Locale = CultureInfo.InvariantCulture;
                this.adapter.Fill(ds);
                comp_table = ds.Tables[0];
            }
            catch (OdbcException pe)
            {
                MessageBox.Show(pe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return -1;
            }

            if (comp_table.Rows.Count == 0)
            {
                return -1;
            }
            return Convert.ToInt32(comp_table.Rows[0][0], CultureInfo.InvariantCulture);

            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Поиск записи о компоненте пользователя в БД
        /// </summary>
        /// <param name="curRaw">компонента пользователя</param>
        /// <returns>найденная запись если есть</returns>
        protected override int FindSimilarDataRawStruct(DataRawStruct curRec, string tableName)
        {
            string sqlStr = "SELECT id FROM " + tableName + " WHERE name=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            //throw new Exception("The method or operation is not implemented.");

            DataTable comp_table = null;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.SelectCommand = cmd;
                DataSet ds = new DataSet("tables");
                ds.Locale = CultureInfo.InvariantCulture;
                this.adapter.Fill(ds);
                comp_table = ds.Tables[0];
            }
            catch (OdbcException pe)
            {
                MessageBox.Show(pe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return -1;
            }

            if (comp_table.Rows.Count == 0)
            {
                return -1;
            }
            return Convert.ToInt32(comp_table.Rows[0][0], CultureInfo.InvariantCulture);
        }
        #endregion

        #region Работа с элементами типа DataTotalLoss
        /// <summary>
        /// получение таблицы потерь
        /// </summary>
        /// <returns>Массив записей потерь</returns>
        protected override SortableBindingList<DataTotalLoss> LoadTotalLossList()
        {
            DataTable totalLossTable = null;

            String sql = "SELECT * FROM totalLoss ORDER BY number ASC";
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.SelectCommand = new OdbcCommand(sql, this.conn);
                DataSet ds = new DataSet("Loss");
                ds.Locale = CultureInfo.InvariantCulture;
                this.adapter.Fill(ds);
                totalLossTable = ds.Tables[0];
            }
            catch (OdbcException pe)
            {
                MessageBox.Show(pe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return null;
            }

            SortableBindingList<DataTotalLoss> ret = new SortableBindingList<DataTotalLoss>();
            for (int i = 0; i < totalLossTable.Rows.Count; i++)
            {
                DataTotalLoss curData = new DataTotalLoss(null);
                curData.Id = Convert.ToInt32(totalLossTable.Rows[i]["id"], CultureInfo.InvariantCulture);
                curData.Name = totalLossTable.Rows[i]["name"].ToString();
                curData.Quantity = Convert.ToDecimal(totalLossTable.Rows[i]["number"], CultureInfo.InvariantCulture);
                curData.Comment = totalLossTable.Rows[i]["comment"].ToString();
                curData.IsChanged = false;
                ret.Add(curData);
            }
            return ret;
        }

        /// <summary>
        /// Добавление потерь в БД
        /// </summary>
        /// <param name="currentRecord">добавляемая запись</param>
        internal override void AddTotalLossStruct(DataTotalLoss curRec)
        {
            string sqlStr = "INSERT INTO totalLoss (name, comment, [number]) VALUES (?, ?, ?)";
            OdbcCommand cmd = new OdbcCommand(sqlStr, this.conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            cmd.Parameters.AddWithValue("@comment", curRec.Comment);
            cmd.Parameters.AddWithValue("@number", curRec.Quantity.ToString(CultureInfo.InvariantCulture));

            int ret = 0;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.InsertCommand = cmd;
                ret = this.adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Обновление записи неудачно:\n " + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return;
            }
            if (ret != 1)
            {
                MessageBox.Show("Во время обновления произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            curRec.IsChanged = false;
            SendTotalLossChanged();
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Обновление потерь в БД
        /// </summary>
        /// <param name="curRec">обновляемая запись</param>
        internal override void UpdateTotalLossStruct(DataTotalLoss curRec)
        {
            string sqlStr = "UPDATE totalLoss SET name=?, comment=?, [number]=? WHERE id=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, this.conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            cmd.Parameters.AddWithValue("@comment", curRec.Comment);
            cmd.Parameters.AddWithValue("@number", curRec.Quantity.ToString(CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@id", curRec.Id.ToString(CultureInfo.InvariantCulture));

            int ret = 0;
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.UpdateCommand = cmd;
                ret = this.adapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Обновление записи неудачно:\n " + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return;
            }
            if (ret != 1)
            {
                MessageBox.Show("Во время обновления произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            curRec.IsChanged = false;
            SendTotalLossChanged();
            //throw new Exception("The method or operation is not implemented.");
        }

        internal override DataTotalLoss FindTotalLoss(DataTotalLoss curRec)
        {
            // шаг 1. Берем компоненту с таким ID
            DataTotalLoss ret = this.GetTotalLoss(curRec.Id);
            if (ret.EqualVal(curRec))
            {
                return ret;
            }

            // шаг 2. Ищем такую компоненту в БД без учета ID
            string sqlStr = "SELECT id FROM totalLoss WHERE name=? AND comment=? AND [number]=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, this.conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);
            cmd.Parameters.AddWithValue("@comment", curRec.Comment);
            cmd.Parameters.AddWithValue("@number", curRec.Quantity.ToString(CultureInfo.InvariantCulture));

            DataTable totalLossTable;

            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.SelectCommand = cmd;
                DataSet ds = new DataSet("Loss");
                ds.Locale = CultureInfo.InvariantCulture;
                this.adapter.Fill(ds);
                totalLossTable = ds.Tables[0];
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return null;
            }
            if (totalLossTable.Rows.Count == 0)
            {
                return null;
            }
            return this.GetTotalLoss(Convert.ToInt32(totalLossTable.Rows[0][0], CultureInfo.InvariantCulture));
            //throw new Exception("The method or operation is not implemented.");
        }

        internal override DataTotalLoss FindSimilarTotalLoss(DataTotalLoss curRec)
        {
            string sqlStr = "SELECT id FROM totalLoss WHERE name=?";
            OdbcCommand cmd = new OdbcCommand(sqlStr, this.conn);
            cmd.Parameters.AddWithValue("@name", curRec.Name);

            DataTable totalLossTable;

            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.adapter.SelectCommand = cmd;
                DataSet ds = new DataSet("Loss");
                ds.Locale = CultureInfo.InvariantCulture;
                this.adapter.Fill(ds);
                totalLossTable = ds.Tables[0];
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return null;
            }
            if (totalLossTable.Rows.Count == 0)
            {
                return null;
            }
            return this.GetTotalLoss(Convert.ToInt32(totalLossTable.Rows[0][0], CultureInfo.InvariantCulture));
            //throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region Функции проверки/модификации структуры БД
        internal override void TestDataBase()
        {
            // TODO: дореализовать по аналогии с sqlite
            //throw new Exception("The method or operation is not implemented.");
        }
        #endregion
        
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                this.conn.Close();
                this.adapter.Dispose();
                this.conn.Dispose();
            }
        }
    }
}
