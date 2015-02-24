using System.ComponentModel;
namespace Recept2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.XPath;
    

    
    /// <summary>
    /// Описание микробиологических показателей изделия.
    /// </summary>
    public class DataMicroBiology : DataBase
    {
        private BindingList<DataMicroBiologyIndicator> myComponents;

        /// <summary>
        /// Состав (м.б. как сырье, так и другая рецептура).
        /// </summary>
        public new BindingList<DataMicroBiologyIndicator> Components
        {
            get
            {
                if (myComponents == null)
                {
                    myComponents = new BindingList<DataMicroBiologyIndicator>();
                    myComponents.ListChanged += new ListChangedEventHandler(myComponents_ListChanged);
                }
                return myComponents;
            }
        }

        void myComponents_ListChanged(object sender, EventArgs e)
        {
            OnChanged(new DataBaseEventArgs(true, false));
        }

        #region для списков (ключ=значение)
        // то, что выбирается в списке
        public String DisplayMember
        {
            get { return this.Name; }
        }
        
        /// <summary>
        /// то, что возвращается после выбора из списка
        /// </summary>
        public String ValueMember
        {
            get { return this.Id.ToString(CultureInfo.CurrentCulture); }
        }
        #endregion
        
        public DataMicroBiology(DataBase parent): base(parent)
        {
            BeginUpdate();
            this.Name = "Новый микробиологический показатель";
            EndUpdate(false);
            this.IsChanged = false;
        }
        
        public DataMicroBiology(): base()
        {
            BeginUpdate();
            this.Name = "Новый микробиологический показатель";
            EndUpdate(false);
            this.IsChanged = false;
        }
        
        public override XmlNode StoreToXml(XmlDocument doc, string nodeName)
        {
            XmlNode root = doc.CreateElement(nodeName);
            XmlAttribute idattr = doc.CreateAttribute("id");
            idattr.Value = this.Id.ToString(CultureInfo.CurrentCulture);
            root.Attributes.Append(idattr);

            XmlNode curNode = root.AppendChild(doc.CreateElement("comment"));
            curNode.InnerText = this.Comment;
            curNode = root.AppendChild(doc.CreateElement("name"));
            curNode.InnerText = this.Name;

            XmlNode mbNode = root.AppendChild(doc.CreateElement("items"));
            foreach(DataMicroBiologyIndicator mbItem in this.myComponents)
            {
                mbNode.AppendChild(mbItem.StoreToXml(doc, "item"));
            }
            
            return root;
        }
        
        internal static DataMicroBiology LoadFromXml(XmlNode root, DataBase par, ReceptVersion curVer)
        {
            switch (curVer)
            {
                case ReceptVersion.Version0:
                    throw new NotImplementedException("The method or operation is not implemented.");
                case ReceptVersion.Version1:
                    return LoadFromXmlVer1(root, par, curVer);
                default:
                    throw new NotImplementedException("The method or operation is not implemented.");
            }

        }
        
        private static DataMicroBiology LoadFromXmlVer1(XmlNode root, DataBase par, ReceptVersion curVer)
        {
            DataMicroBiology ret = new DataMicroBiology(par);
            ret.BeginUpdate();
            ret.Id = int.Parse(root.Attributes["id"].Value, CultureInfo.CurrentCulture);
            foreach(XmlNode curNode in root.ChildNodes)
            {
                switch(curNode.Name)
                {
                    case "name":
                        ret.Name = curNode.InnerText;
                        break;
                    case "comment":
                        ret.Comment = curNode.InnerText;
                        break;
                    case "items":
                        foreach(XmlNode itemNode in curNode.ChildNodes)
                            ret.Components.Add(DataMicroBiologyIndicator.LoadFromXml(itemNode, ret, curVer));
                        break;
                }
            }
            ret.EndUpdate(false);
            ret.IsChanged = false;
            return ret;
        }
        
        public static BindingList<RecordProperty> ItemsMicroBiology(DataMicroBiology curRec)
        {
            BindingList<RecordProperty> ret = new BindingList<RecordProperty>();
            RecordProperty np = new RecordProperty();
            np.Name = "name";
            np.ObjectType = TypeCode.String;
			
			return ret;
        }
        
        public override decimal PercentFilling()
        {
            throw new NotImplementedException();
        }
    }
}
