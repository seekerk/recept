namespace Recept2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Collections;
    using System.Xml;
    using System.Xml.XPath;
    using System.Windows.Forms;

    /// <summary>
    /// Базовый класс для иерархии структур.
    /// </summary>
    public abstract class DataBase
    {
        #region Общие поля
        /// <summary>
        /// Порядковый номер.
        /// </summary>
        int myId;
        
        /// <summary>
        /// Порядковый номер.
        /// </summary>
        public int Id
        {
            get { return myId; }
            set {
                int oldVal = myId;
                myId = value;
                if (!oldVal.Equals(myId))
                    OnChanged(new DataBaseEventArgs(true, false));
            }
        }
        
        /// <summary>
        /// название
        /// </summary>
        string myName = "Новый элемент";
        
        /// <summary>
        /// название
        /// </summary>
        public String Name
        {
            get { return myName; }
            set {
                string oldVal = myName;
                myName = value;
                if (!oldVal.Equals(myName))
                    OnChanged(new DataBaseEventArgs(true, false));
            }
        }
        
        /// <summary>
        /// количество
        /// </summary>
        decimal m_quantity = 0;
        
        /// <summary>
        /// количество
        /// </summary>
        public decimal Quantity
        {
            get { return m_quantity; }
            set {
                decimal oldVal = m_quantity;
                m_quantity = value;
                if (!oldVal.Equals(m_quantity))
                    OnChanged(new DataBaseEventArgs(false, true));
            }
        }
        
        /// <summary>
        /// комментарий
        /// </summary>
        string m_comment = "";
        
        /// <summary>
        /// комментарий
        /// </summary>
        public String Comment
        {
            get { return m_comment; }
            set {
                string oldVal = m_comment;
                m_comment = value;
                if (!oldVal.Equals(m_comment))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }
        
        #region Состав (вложенное сырье и другие рецептуры)
        /// <summary>
        /// Состав (м.б. как сырье, так и другая рецептура).
        /// </summary>
        private SortableBindingList<DataBase> myComponents;

        /// <summary>
        /// Состав (м.б. как сырье, так и другая рецептура).
        /// </summary>
        public SortableBindingList<DataBase> Components
        {
            get
            {
                if (myComponents == null)
                {
                    myComponents = new SortableBindingList<DataBase>();
                    myComponents.ListChanged += new ListChangedEventHandler(myComponents_ListChanged);
                }
                return myComponents;
            }
        }
        
        void myComponents_ListChanged(object sender, EventArgs e)
        {
            OnChanged(new DataBaseEventArgs(true, false));
        }
        
        public bool Contains(DataBase child)
        {
            if (myComponents == null)
            {
                return false;
            }
            foreach (DataBase curval in myComponents)
            {
                if (curval.Equals(child) || curval.Contains(child))
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Поиск и удаление компоненты в дереве
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public bool DeleteComponent(DataBase comp)
        {
            if (myComponents == null)
            {
                return false;
            }
            foreach (DataBase curval in myComponents)
            {
                if (curval.Equals(comp))
                {
                    myComponents.Remove(comp);
                    return true;
                }
                if (curval.DeleteComponent(comp))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        
        /// <summary>
        /// флаг блокировки обновлений при больших изменениях
        /// </summary>
        bool onUpdate;
        
        public void BeginUpdate()
        {
            onUpdate = true;
        }
        
        public void EndUpdate(bool startUpdate)
        {
            onUpdate = false;
            if (startUpdate)
                OnChanged(new DataBaseEventArgs(true, true));
        }
        
        #endregion
        
        /// <summary>
        /// родительский объект
        /// </summary>
        DataBase myParent;
        
        public DataBase Parent
        {
            get {return myParent;}
            set {myParent = value;}
        }
        
        /// <summary>
        /// флаг изменений после загрузки
        /// </summary>
        bool m_isChanged;
        /// <summary>
        /// флаг изменений после загрузки
        /// </summary>
        public bool IsChanged {
            get { return m_isChanged; }
            set { m_isChanged = value; }
        }
        
        /// <summary>
        /// Расчет заполненности объекта данных
        /// </summary>
        /// <returns>% заполнения объекта</returns>
        public abstract decimal PercentFilling();
        
        /// <summary>
        /// Сохранение объекта в XML-документа
        /// </summary>
        /// <param name="doc">Объект документа в который сохраняется</param>
        /// <param name="nodeName">Узел для сохранения</param>
        /// <returns>Дерево XML</returns>
        public abstract XmlNode StoreToXml(XmlDocument doc, String nodeName);
        
        protected DataBase(DataBase par)
        {
            myParent = par;
        }
        
        protected DataBase()
        {
        }
        
        /// <summary>
        /// запуск события обновления
        /// </summary>
        public void Update(DataBaseEventArgs args)
        {
            OnChanged(args);
        }
        
        /// <summary>
        /// событие изменения полей класса или подчиненных полей
        /// </summary>
        //public event ChangedEventHandler Changed;
        public event EventHandler<DataBaseEventArgs> Changed;
        
        protected virtual void OnChanged(DataBaseEventArgs args)
        {
            if (!onUpdate)
            {
                m_isChanged = true;
                if (Changed != null)
                {
                    Changed(this, args);
                }
                if (myParent != null)
                {
                    myParent.Update(args);
                }
            }
        }
    }
}
