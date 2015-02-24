using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace Recept2
{
    public class DataTotalLoss: DataBase, ICloneable
    {
        // конструктор
        public DataTotalLoss(DataBase par) : base(par) 
        { 
            BeginUpdate();
            this.Name = "Новые потери"; 
            EndUpdate(false);
            this.IsChanged = false;
        }

        #region для списков (ключ=значение)
        // то, что выбирается в списке
        public String DisplayMember
        {
            get { return this.Quantity.ToString(CultureInfo.CurrentCulture) + "% (" + this.Name + ")"; }
        }

        // то, что возвращается после выбора из списка
        public String ValueMember
        {
            get { return this.Id.ToString(CultureInfo.CurrentCulture); }
        }

        public int TotalLossNum
        {
            get { return Config.DP.GetTotalLossNum(this); }
        }
        #endregion

        public override decimal PercentFilling()
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        internal static DataTotalLoss LoadFromXml(System.Xml.XmlNode props, DataBase par, ReceptVersion curVer)
        {
            DataTotalLoss curRec = new DataTotalLoss(par);
            curRec.BeginUpdate();
            switch (curVer)
            {
                case ReceptVersion.Version0:
                    foreach (XmlNode curNode in props.ChildNodes)
                    {
                        switch (curNode.Name)
                        {
                                case "number": curRec.Id = int.Parse(curNode.InnerText, CultureInfo.CurrentCulture); break;
                                case "name": curRec.Name = curNode.InnerText; break;
                                case "value": curRec.Quantity = Convert.ToDecimal(curNode.InnerText, CultureInfo.CurrentCulture); break;
                                case "comment": curRec.Comment = curNode.InnerText; break;
                        }
                    }
                    break;

                case ReceptVersion.Version1:
                    curRec.Id = int.Parse(props.Attributes["id"].Value, CultureInfo.CurrentCulture);

                    foreach (XmlNode curnode in props.ChildNodes)
                    {
                        switch (curnode.Name)
                        {
                                case "comment": curRec.Comment = curnode.InnerText; break;
                                case "name": curRec.Name = curnode.InnerText; break;
                                case "quantity": curRec.Quantity = Convert.ToDecimal(curnode.InnerText, CultureInfo.CurrentCulture); break;
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException("Not implemented");
            }
            curRec.IsChanged = false;
            curRec.EndUpdate(false);
            DataTotalLoss ret = Config.DP.FindTotalLoss(curRec);
            if (ret == null)
            {
                FormCompare frm = new FormCompare(curRec, Config.DP.FindSimilarTotalLoss(curRec), DataBaseType.TotalLossType);
                frm.ShowDialog();
                ret = (DataTotalLoss)frm.UserRec;
                ret.IsChanged = true;
            }else{
                ret.IsChanged = false;
            }
            return ret;
        }

        public override XmlNode StoreToXml(XmlDocument doc, String nodeName)
        {
            XmlNode root = doc.CreateElement(nodeName);
            XmlAttribute idattr = doc.CreateAttribute("id");
            idattr.Value = this.Id.ToString(CultureInfo.CurrentCulture);
            root.Attributes.Append(idattr);

            XmlNode curNode = root.AppendChild(doc.CreateElement("comment"));
            curNode.InnerText = this.Comment;
            curNode = root.AppendChild(doc.CreateElement("name"));
            curNode.InnerText = this.Name;
            curNode = root.AppendChild(doc.CreateElement("quantity"));
            curNode.InnerText = this.Quantity.ToString(CultureInfo.CurrentCulture);

            return root;
        }

        #region ICloneable Members

        public object Clone()
        {
            DataTotalLoss ret = new DataTotalLoss(this.Parent);
            ret.BeginUpdate();
            ret.Id = this.Id;
            ret.Name = this.Name;
            ret.Quantity = this.Quantity;
            ret.Comment = this.Comment;
            ret.IsChanged = this.IsChanged;
            ret.EndUpdate(false);
            return ret;
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        internal bool EqualVal(object p)
        {
            DataTotalLoss curLoss;
            
            if (p == null || (curLoss = p as DataTotalLoss) == null)
            {
                return false;
            }
            if (!curLoss.Name.Equals(this.Name))
            {
                return false;
            }
            if (!curLoss.Comment.Equals(this.Comment))
            {
                return false;
            }
            if (!curLoss.Quantity.Equals(this.Quantity))
            {
                return false;
            }

            return true;
        }
    }
}
