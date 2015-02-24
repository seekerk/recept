using System.ComponentModel;
namespace Recept2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// перечень версий файлов
    /// </summary>
    public enum ReceptVersion {
        Version0 = 0, // файл рецептур программы версии 1
        Version1 = 1, // файл версии 1 книги рецептур программы версии 2
        CurrentVersion = 1 // текущая версия файла, с которой работает программа
    }

    /// <summary>
    /// книга рецептур
    /// </summary>
    internal class DataBook : DataBase
    {
        #region Свойства книги рецептур
        /// <summary>
        /// Название фирмы заказчика
        /// </summary>
        string _company = "Новая Фирма";
        /// <summary>
        /// Название фирмы
        /// </summary>
        public string company
        {
            get { return _company; }
            set {
                if (String.IsNullOrEmpty(_company) || !_company.Equals(value))
                {
                    _company = value;
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }

        /// <summary>
        /// ФИО начальника фирмы-заказчика
        /// </summary>
        string m_chiefName = "И.И.Иванов"; // директор предприятия, которое утверждает
        /// <summary>
        /// ФИО начальника фирмы-заказчика
        /// </summary>
        public string ChiefName
        {
            get { return m_chiefName; }
            set {
                if (String.IsNullOrEmpty(m_chiefName) || !m_chiefName.Equals(value))
                {
                    m_chiefName = value;
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }
        
        /// <summary>
        /// Должность начальника фирмы-заказчика
        /// </summary>
        string m_chiefPost = "Директор";
        /// <summary>
        /// Должность начальника фирмы-заказчика
        /// </summary>
        public string ChiefPost
        {
            get {return m_chiefPost;}
            set {
                if (String.IsNullOrEmpty(m_chiefPost) || !m_chiefPost.Equals(value))
                {
                    m_chiefPost = value;
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }

        /// <summary>
        /// Разработчик рецептур книги
        /// </summary>
        string _developer = "Л.И.Кулакова";
        /// <summary>
        /// Разработчик рецептур книги
        /// </summary>
        public string developer
        {
            get { return _developer; }
            set {
                if (String.IsNullOrEmpty(_developer) || !_developer.Equals(value))
                {
                    _developer = value;
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }
        
        /// <summary>
        /// Компания разработчика
        /// </summary>
        string _developerCompany = "ООО \"Центр НПТ\"";
        /// <summary>
        /// Компания разработчика
        /// </summary>
        public string developerCompany
        {
            get { return _developerCompany; }
            set {
                if (String.IsNullOrEmpty(_developerCompany) || !_developerCompany.Equals(value))
                    _developerCompany = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// Версия формата книги
        /// </summary>
        private ReceptVersion myVersion = ReceptVersion.CurrentVersion;
        
        /*        /// <summary>
        /// Версия формата книги
        /// </summary>
        public ReceptVersion version {
            get { return myVersion; }
        }
         */
        /// <summary>
        /// ассоциированный с книгой файл
        /// </summary>
        string _filename = "";
        
        /// <summary>
        /// ассоциированный с книгой файл
        /// </summary>
        public string filename{
            get { return _filename; }
            set { _filename = value; SetFormName(); }
        }
        #endregion

        /// <summary>
        /// Текущая книга рецептур.
        /// </summary>
        private static DataBook pBook;

        /// <summary>
        /// Текущая книга рецептур.
        /// </summary>
        public static DataBook Book {
            get { if (pBook == null)
                {
                    pBook = new DataBook(null);
                }
                return pBook; }
            set { pBook = value; }
        }

        #region Конструкторы
        /// <summary>
        /// создание книги рецептур из шаблона
        /// </summary>
        public DataBook(DataBase par) : base(par)
        {
            this.BeginUpdate();
            this.Name = "Новая книга рецептур";
            this.EndUpdate(false);
            LoadFromFile(Config.Cfg.DefaultFile, false);
        }

        /// <summary>
        /// создание книги рецептур из файла
        /// </summary>
        /// <param name="_file">файл с книгой рецептур</param>
        public DataBook(string _file, DataBase par) : base(par)
        {
            BeginUpdate();
            this.Name = "Новая книга рецептур";
            this.filename = _file;
            EndUpdate(false);
            LoadFromFile(filename, true);
        }

        void DataBook_Changed(object sender, DataBaseEventArgs e)
        {
            //isChanged = true;
            SetFormName();
            //throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        /// <summary>
        /// Расчет процента заполненности структуры
        /// </summary>
        /// <returns>Процент заполненности структуры</returns>
        public override decimal PercentFilling()
        {
            decimal totalItems = 0;
            decimal filledItems = 0;

            if (!String.IsNullOrEmpty(this.m_chiefName)) filledItems++; totalItems++;
            if (!String.IsNullOrEmpty(this.m_chiefPost)) filledItems++; totalItems++;
            if (!String.IsNullOrEmpty(this._company)) filledItems++; totalItems++;
            if (!String.IsNullOrEmpty(this._developer)) filledItems++; totalItems++;
            if (!String.IsNullOrEmpty(this._developerCompany)) filledItems++; totalItems++;
            if (!String.IsNullOrEmpty(this.Name)) filledItems++; totalItems++;

            return filledItems * 100 / totalItems;
        }

        /// <summary>
        /// Установка названия формы с отметкой об изменении текущей книги рецептур
        /// </summary>
        public void SetFormName()
        {
            string sfname = String.IsNullOrEmpty(this.filename) ? string.Empty : " (" + System.IO.Path.GetFileName(this.filename) + ")";
            string schanged = this.IsChanged ? "*" : string.Empty;
            if (FormMain.MainForm != null)
                FormMain.MainForm.Text = this.Name + sfname + schanged;
        }

        /// <summary>
        /// перенумерация рецептур в книге
        /// </summary>
        public void RenumberRecepts()
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if ((Components[i] as DataBase).Id != i + 1)
                {
                    (Components[i] as DataBase).Id = i + 1;
                }
            }
        }

        /// <summary>
        /// загрузка книги из файла
        /// </summary>
        private void LoadFromFile(string file, bool isVerbose)
        {
            this.BeginUpdate();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(CommonFunctions.AbsolutePathFromAnyPath(Application.StartupPath, file));
                XmlNode root = doc.DocumentElement;
                if (root.Attributes.Count > 0)
                {
                    int curVer = int.Parse(root.Attributes["version"].Value, CultureInfo.CurrentCulture);
                    if (curVer == 0) myVersion = ReceptVersion.Version0;
                    if (curVer == 1) myVersion = ReceptVersion.Version1;
                }else{
                    myVersion = ReceptVersion.CurrentVersion; // нет версии (rcp)
                }

                foreach (XmlNode rootProps in root.ChildNodes)
                {
                    switch (rootProps.Name)
                    {
                        case "chief":
                            m_chiefName = rootProps.InnerText;
                            break;
                        case "chiefPost":
                            m_chiefPost = rootProps.InnerText;
                            break;
                        case "company":
                            _company = rootProps.InnerText;
                            break;
                        case "developer":
                            _developer = rootProps.InnerText;
                            break;
                        case "developerCompany":
                            _developerCompany = rootProps.InnerText;
                            break;
                        case "recepts":
                            foreach (XmlNode curNode in rootProps.ChildNodes)
                            {
                                Components.Add(DataRecept.LoadFromXml(curNode, this, myVersion));
                            }
                            break;
                        case "name":
                            Name = rootProps.InnerText;
                            break;
                    }
                }
            }
            catch (XmlException ex)
            {
                if (isVerbose) MessageBox.Show("Ошибка: " + ex.Message + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            catch (FileNotFoundException ex)
            {
                if (isVerbose) MessageBox.Show("Ошибка: " + ex.Message + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }

            // сортировка элементов
            Components.Sort(new DataBaseComparer());
            //Array.Sort(Components, new IfDataBaseNumSort());
            RenumberRecepts();
            EndUpdate(false);

            this.Changed += new EventHandler<DataBaseEventArgs>(DataBook_Changed);
            this.IsChanged = false;
        }

        /// <summary>
        /// Сохранение в файл XML
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public override XmlNode StoreToXml(XmlDocument doc, String nodeName)
        {
            XmlNode root = doc.CreateElement(nodeName);
            root.Attributes.Append(doc.CreateAttribute("version"));
            root.Attributes["version"].InnerText = ((int)ReceptVersion.CurrentVersion).ToString(CultureInfo.CurrentCulture);

            XmlNode curNode = root.AppendChild(doc.CreateElement("chief"));
            curNode.InnerText = m_chiefName;
            curNode = root.AppendChild(doc.CreateElement("chiefPost"));
            curNode.InnerText = m_chiefPost;
            curNode = root.AppendChild(doc.CreateElement("company"));
            curNode.InnerText = _company;
            curNode = root.AppendChild(doc.CreateElement("developer"));
            curNode.InnerText = _developer;
            curNode = root.AppendChild(doc.CreateElement("developerCompany"));
            curNode.InnerText = _developer;
            curNode = root.AppendChild(doc.CreateElement("recepts"));
            foreach (DataRecept curRec in Components)
            {
                curNode.AppendChild(curRec.StoreToXml(doc, "recept"));
            }
            curNode = root.AppendChild(doc.CreateElement("name"));
            curNode.InnerText = this.Name;

            return root;
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// сохранение книги в файл
        /// </summary>
        public void StoreToFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.InsertBefore(doc.CreateXmlDeclaration("1.0", "utf-8", null), null);
            doc.AppendChild(StoreToXml(doc, "book"));

            try
            {
                if (File.Exists(filename))
                    File.Copy(filename, filename + ".bak", true);
                doc.Save(filename);
            }
            catch (IOException e)
            {
                MessageBox.Show("Рецептура не сохранена.\n" + e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            IsChanged = false;
            this.SetFormName();
        }
    }
}
