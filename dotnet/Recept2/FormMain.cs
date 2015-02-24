using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Recept2
{
    public partial class FormMain : Form
    {
        private static FormMain myFm;
        public static FormMain MainForm
        {
            get {return myFm;}
        }

        #region конструкторы
        public FormMain()
        {
            InitializeComponent();
            LoadData();
        }

        public FormMain(string _file)
        {
            DataBook.Book = new DataBook(_file, null);
            InitializeComponent();
            LoadData();
        }

        // загрузка данных в контролы формы
        private void LoadData()
        {
            panelBrouse1.LoadData();
            panelBookdata1.LoadData();
            FormMain.myFm = this;

            // настройка просмотра
            SetView(ViewMode.BookCommon);
            DataBook.Book.IsChanged = false;
            DataBook.Book.SetFormName();
            
            // загрузка последних открытых документов
            Collection<string> paths = Config.Cfg.LastOpenPaths;
            foreach (string path in paths)
            {
            	ToolStripMenuItem curItem = new ToolStripMenuItem(path);
            	curItem.Click += new EventHandler(curItem_Click);
            	tsmiLastOpen.DropDownItems.Add(curItem);
            }
        }

        void curItem_Click(object sender, EventArgs e)
        {
        	throw new NotImplementedException();
        }
        #endregion

        #region Установка режима просмотра
        internal void SetView(Object data)
        {
            DataRecept dr;
            if ((dr = data as DataRecept) != null)
            {
                panelReceptData1.LoadData(dr);
                panelReceptProcess1.LoadData(dr);
                panelReceptView1.LoadData(dr);
                panelReceptFactor1.LoadData(dr);
                SetView(ViewMode.ReceptCommon);
                panelBrouse1.LoadList(ViewMode.ReceptCommon);
            }
            else
            {
                SetView(ViewMode.BookCommon);
                panelBrouse1.LoadList(ViewMode.BookCommon);
            }
        }

        internal void SetView(ViewMode mode)
        {
            
            // отображение панели книги
            if (mode.Equals(ViewMode.BookCommon))
            {
                panelBookdata1.Visible = true;
                panelBookdata1.Dock = DockStyle.Fill;
                tsmiReportTTk.Enabled = false;
                tsmiReportTk.Enabled = false;
            }
            else
            {
                panelBookdata1.Visible = false;
                tsmiReportTTk.Enabled = true;
                tsmiReportTk.Enabled = true;
            }

            // отображение панели рецептуры
            if (mode.Equals(ViewMode.ReceptCommon))
            {
                panelReceptData1.Visible = true;
                panelReceptData1.Dock = DockStyle.Fill;
                tsmiRecept.Visible = true;
                tsRecept.Visible = true;
            }
            else
            {
                panelReceptData1.Visible = false;
                tsmiRecept.Visible = false;
                tsRecept.Visible = false;
            }

            // TODO: когда сделаем микробиологию, отключить здесь и зацепить в следующем if
            if (mode.Equals(ViewMode.ReceptView) || mode.Equals(ViewMode.ReceptProcess) ||
                mode.Equals(ViewMode.ReceptColor) || mode.Equals(ViewMode.ReceptConsistence) ||
                mode.Equals(ViewMode.ReceptDelivery) || mode.Equals(ViewMode.ReceptDesign) ||
                mode.Equals(ViewMode.ReceptFactors) || mode.Equals(ViewMode.ReceptSale) ||
                mode.Equals(ViewMode.ReceptStorage) || mode.Equals(ViewMode.ReceptTaste) ||
                mode.Equals(ViewMode.ReceptView))
            {
                panelReceptView1.Visible = true;
                panelReceptView1.setMode(mode);
                panelReceptView1.Dock = DockStyle.Fill;
            }
            else
            {
                panelReceptView1.Visible = false;
            }

            // пока что до сюда не доходит. Откомментить когда будет сделано
            if (mode.Equals(ViewMode.ReceptFactors))
            {
                //                panelReceptFactor1.Visible = true;
                //                panelReceptFactor1.Dock = DockStyle.Fill;
            }
            else
                panelReceptFactor1.Visible = false;
        }
        #endregion

        #region Меню файл
        private void tsmiNewBook_Click(object sender, EventArgs e)
        {
            if (DataBook.Book.IsChanged)
            {
                DialogResult res = MessageBox.Show("Текущая книга изменена, хотите сохранить изменения?", "Предупреждение",
                                                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0);
                if (res == DialogResult.Yes)
                    tsmiSave_Click(sender, e);
                if (res == DialogResult.Cancel)
                    return;
            }
            DataBook.Book = new DataBook(null);
            LoadData();
        }

        private void tsmiOpenBook_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "rcp2";
            dlg.Filter = "Книга рецептур (*.rcp2)|*.rcp2";
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() == DialogResult.OK && dlg.FileName != null)
            {
                SetView(ViewMode.None);
                DataBook.Book = new DataBook(dlg.FileName, null);
                LoadData();
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (DataBook.Book.filename == null || DataBook.Book.filename.Equals(""))
            {
                tsmiSaveAs_Click(sender, e);
            }
            else
            {
                DataBook.Book.StoreToFile();
            }
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "rcp2";
            dlg.Filter = "Книга рецептур (*.rcp2)|*.rcp2";
            if (DataBook.Book.filename == null ||  DataBook.Book.filename.Equals(""))
            {
                dlg.FileName =  "Новая книга рецептур.rcp2";
            }else{
                dlg.FileName = DataBook.Book.filename;
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataBook.Book.filename = dlg.FileName;
                DataBook.Book.StoreToFile();
            }
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            FormConfig frm = new FormConfig();
            frm.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Меню книга
        private void tsmiAddRecept_Click(object sender, EventArgs e)
        {
            DataRecept newRecept = new DataRecept(DataBook.Book);
            DataBook.Book.Components.Add(newRecept);
            panelBrouse1.SelectTreeNode(newRecept);
        }

        private void tsmiDeleteRecept_Click(object sender, EventArgs e)
        {
            DataRecept i = panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                DataBook.Book.Components.Remove(i);
            }
            else
            {
                MessageBox.Show("Выберите рецептуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void tsmiClearBook_Click(object sender, EventArgs e)
        {
            DataBook.Book.Components.Clear();
        }

        private void tsmiReceptSortAsc_Click(object sender, EventArgs e)
        {
            DataBook.Book.BeginUpdate();
            DataBook.Book.Components.Sort(new DataBaseComparer(SortOptions.SortAsc));
            DataBook.Book.RenumberRecepts();
            DataBook.Book.EndUpdate(true);
        }

        private void tsmiReceptSortDesc_Click(object sender, EventArgs e)
        {
            DataBook.Book.BeginUpdate();
            DataBook.Book.Components.Sort(new DataBaseComparer(SortOptions.SortDesc));
            DataBook.Book.RenumberRecepts();
            DataBook.Book.EndUpdate(true);
        }
        #endregion

        #region Меню отчеты

        /// <summary>
        /// Обработка вызова функции печати отчета ТТК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReportTTk_Click(object sender, EventArgs e)
        {
            DataRecept i = this.panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                FormPreview frm = new FormPreview(i, PreviewReport.FormTtk);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Выберите рецептуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void TsmiReportTkClick(object sender, EventArgs e)
        {
            DataRecept i = panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                FormPreview frm = new FormPreview(i, PreviewReport.FormTK);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Выберите рецептуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }
        
        private void tsmiReportBookList_Click(object sender, EventArgs e)
        {
            FormPreview frm = new FormPreview(DataBook.Book, PreviewReport.BookList);
            frm.Show();
        }
        #endregion

        #region Меню рецептуры
        private void tsmiAddReceptRaw_Click(object sender, EventArgs e)
        {
            DataRecept i = panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                i.Components.Add(new DataRaw(i));
            }
            else
            {
                MessageBox.Show("Выберите рецептуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void tsmiDeleteReceptRaw_Click(object sender, EventArgs e)
        {
            DataRecept i = panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                DataBase delRaw = panelReceptData1.GetSelectedComponent();
                if (!i.DeleteComponent(delRaw))
                {
                    MessageBox.Show("Выберите компоненту для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                }
            }
            else
            {
                MessageBox.Show("Выберите рецептуру для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void tsmiAddSubRecept_Click(object sender, EventArgs e)
        {
            DataRecept i = panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                i.Components.Add(new DataRecept(i));
            }
            else
            {
                MessageBox.Show("Выберите рецептуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void tsmiClearRecept_Click(object sender, EventArgs e)
        {
            DataRecept i = panelBrouse1.GetSelectedRecept();
            if (i != null)
            {
                i.Components.Clear();
            }else{
                MessageBox.Show("Выберите рецептуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
        }
        #endregion

        #region Меню номенклатур
        private void tsmiRawList_Click(object sender, EventArgs e)
        {
            FormDB frm = new FormDB(DataBaseType.RawType, false);
            frm.Show();
        }

        private void tsmiRawAdd_Click(object sender, EventArgs e)
        {
            FormDB frm = new FormDB(DataBaseType.RawType, true);
            frm.Show();
        }

        private void tsmiTotalLossList_Click(object sender, EventArgs e)
        {
            FormDB frm = new FormDB(DataBaseType.TotalLossType, false);
            frm.Show();
        }

        private void tsmiTotalLossAdd_Click(object sender, EventArgs e)
        {
            FormDB frm = new FormDB(DataBaseType.TotalLossType, true);
            frm.Show();
        }

        private void tsmiProcessLossList_Click(object sender, EventArgs e)
        {
            FormDB frm = new FormDB(DataBaseType.ProcessLossType, false);
            frm.Show();
        }

        private void tsmiProcessLossAdd_Click(object sender, EventArgs e)
        {
            FormDB frm = new FormDB(DataBaseType.ProcessLossType, true);
            frm.Show();
        }

        private void tsmiRefreshDB_Click(object sender, EventArgs e)
        {
            Config.DP.Update();
        }
        #endregion

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DataBook.Book.IsChanged)
            {
                DialogResult res = MessageBox.Show("Книга рецептур не сохранена. Сохранить?", "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0);
                if (res == DialogResult.Yes)
                {
                    tsmiSave_Click(sender, e);
                }
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        #region Меню справка
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog();
        }

        private void tsmiRegister_Click(object sender, EventArgs e)
        {
            FormReg frm = new FormReg();
            //frm.Parent = this;
            frm.ShowDialog();
        }

        #endregion
        private void tsmiImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "rcp";
            dlg.Filter = "Рабочая рецептура (*.rcp)|*.rcp";
            dlg.Multiselect = false;
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK && !dlg.FileName.Equals(""))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(CommonFunctions.AbsolutePathFromAnyPath(Application.StartupPath, dlg.FileName));
                    XmlNode root = doc.DocumentElement;

                    DataRecept rcp = DataRecept.LoadFromXml(root, DataBook.Book, ReceptVersion.Version0);
                    if (rcp != null)
                    {
                        DataBook.Book.Components.Add(rcp);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Невозможно импортировать файл:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                }
            }
        }

    }
}