using System.ComponentModel;
using System.Globalization;

namespace Recept2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    ///  структура хранения сырья в рецетуре
    /// </summary>
    internal class DataRaw: DataBase
    {
        private DataRawStruct myRawStruct;
        public DataRawStruct RawStruct {
            get { return myRawStruct; }
            set
            {
                DataRawStruct oldVal = myRawStruct;
                myRawStruct = value;
                if (oldVal == null && myRawStruct != null ||
                    !oldVal.EqualVal(myRawStruct))
                {
                    OnChanged(new DataBaseEventArgs(true, false));
                }
            }
        }
        
        public new string Name
        {
            get 
            {
                if (myRawStruct != null)
                    return myRawStruct.Name;
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        private DataRawStruct myProcessLoss;
        public DataRawStruct ProcessLoss {
            get { return myProcessLoss; }
            set
            {
                DataRawStruct oldVal = myProcessLoss;
                myProcessLoss = value;
                if (oldVal == null && myProcessLoss != null ||
                    !oldVal.EqualVal(myProcessLoss))
                {
                    OnChanged(new DataBaseEventArgs(true, false));
                }
            }
        }

        private decimal myBrutto = 0;
        public decimal Brutto {
            get { return myBrutto; }
            set {
                decimal oldVal = myBrutto;
                myBrutto = value;
                if (!oldVal.Equals(myBrutto))
                {
                    OnChanged(new DataBaseEventArgs(true, false));
                }
            }
        }

        public DataRaw(DataBase par): base(par)
        {
            this.BeginUpdate();
            this.Name = "Новая компонента";
            this.EndUpdate(false);
        }

        public override decimal PercentFilling()
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        //public override bool Contains(DataBase child)
        //{
        //    return false;
        //    //throw new Exception("The method or operation is not implemented.");
        //}

        public static DataRaw LoadOneFromXml(XmlNode root, DataBase par, ReceptVersion curVer)
        {
            DataRaw ret = new DataRaw(par);
            ret.BeginUpdate();
            switch (curVer)
            {
                case ReceptVersion.Version0:
                    foreach (XmlNode props in root.ChildNodes)
                    {
                        switch (props.Name)
                        {
                                case "name": ret.Name = props.InnerText; break;
                                case "number": ret.RawStruct.Id = int.Parse(props.InnerText, CultureInfo.CurrentCulture); break;
                                case "water": ret.RawStruct.Water = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                                case "gir": ret.RawStruct.fat = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                                case "belki": ret.RawStruct.protein = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                                case "sahar": ret.RawStruct.saccharides = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                                case "kkal": ret.RawStruct.Caloric = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                                case "comment": ret.Comment = props.InnerText; break;
                                case "value": ret.Quantity = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        }
                    }
                    break;
                case ReceptVersion.Version1:
                    throw new NotImplementedException("not implemented");
                default:
                    throw new NotImplementedException("not implemented");
            }
            ret.EndUpdate(false);
            ret.IsChanged = false;
            return ret;
        }

        /// <summary>
        /// загрузка данных по сырью из xml файла
        /// </summary>
        /// <param name="root">узел со списком компонент</param>
        /// <param name="par">родительская структура</param>
        /// <returns></returns>
        public static BindingList<DataBase> LoadManyFromXml(XmlNode root, DataBase par, ReceptVersion curVer)
        {
            BindingList<DataBase> ret = new BindingList<DataBase>();

            switch (curVer)
            {
                case ReceptVersion.Version0:
                    throw new NotImplementedException("not implemented");
                    
                case ReceptVersion.Version1:
                    foreach (XmlNode curNode in root.ChildNodes)
                    {
                        if (curNode.Name.Equals("recept"))
                        {
                            ret.Add(DataRecept.LoadFromXml(curNode, par, curVer));
                        }
                        else // это лист с сырьем
                        {
                            DataRaw curRaw = new DataRaw(par);
                            curRaw.BeginUpdate();
                            foreach (XmlNode curRawNode in curNode.ChildNodes)
                            {
                                switch (curRawNode.Name)
                                {
                                        case "quantity": curRaw.Quantity = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                                        case "comment": curRaw.Comment = curRawNode.InnerText; break;
                                        case "brutto": curRaw.myBrutto = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                                        case "rawStruct": curRaw.myRawStruct = DataRawStruct.LoadFromXml(curRawNode, curRaw, DataBaseType.RawType); break;
                                        case "processLoss": curRaw.myProcessLoss = DataRawStruct.LoadFromXml(curRawNode, curRaw, DataBaseType.ProcessLossType); break;
                                }
                            }
                            curRaw.EndUpdate(false);
                            curRaw.IsChanged = false;
                            ret.Add(curRaw);
                        }
                    }
                    break;
                    
                default:
                    throw new NotImplementedException("not implemented");
            }
            return ret;
        }

        public override XmlNode StoreToXml(XmlDocument doc, String nodeName)
        {
            XmlNode root = doc.CreateElement(nodeName);

            XmlNode curNode = root.AppendChild(doc.CreateElement("quantity"));
            curNode.InnerText = this.Quantity.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("comment"));
            curNode.InnerText = this.Comment;
            curNode = root.AppendChild(doc.CreateElement("brutto"));
            curNode.InnerText = myBrutto.ToString(CultureInfo.CurrentCulture);
            if (RawStruct != null)
            {
                root.AppendChild(RawStruct.StoreToXml(doc, "rawStruct"));
            }
            if (ProcessLoss != null)
            {
                root.AppendChild(ProcessLoss.StoreToXml(doc, "processLoss"));
            }

            return root;
        }
    }

    /// <summary>
    /// структура данных сырья
    /// </summary>
    public class DataRawStruct: DataBase, ICloneable
    {
        #region поля структуры
        /// <summary>
        /// влажность
        /// </summary>
        decimal myWater = 0;
        public decimal Water {
            get { return myWater; }
            set { myWater = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// калории
        /// </summary>
        decimal myCaloric = 0;
        public decimal Caloric {
            get { return myCaloric; }
            set { myCaloric = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }
        
        /// <summary>
        /// жирность
        /// </summary>
        decimal _fat = 0;
        public decimal fat {
            get { return _fat; }
            set { _fat = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// холестерин
        /// </summary>
        decimal _cholesterol = 0;
        public decimal cholesterol {
            get { return _cholesterol; }
            set { _cholesterol = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// белки
        /// </summary>
        decimal _protein = 0;
        public decimal protein
        {
            get { return _protein; }
            set { _protein = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// крахмал (углеводы)
        /// </summary>
        decimal _starch = 0;
        public decimal starch
        {
            get { return _starch; }
            set { _starch = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// моно и дисахариды (углеводы)
        /// </summary>
        decimal _saccharides = 0;
        public decimal saccharides
        {
            get { return _saccharides; }
            set { _saccharides = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// органические кислоты
        /// </summary>
        decimal _acid = 0;
        public decimal acid
        {
            get { return _acid; }
            set { _acid = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// Зола
        /// </summary>
        decimal _ash = 0;
        public decimal ash
        {
            get { return _ash; }
            set { _ash = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// клетчатка
        /// </summary>
        decimal _cellulose = 0;
        public decimal cellulose
        {
            get { return _cellulose; }
            set { _cellulose = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal _vitaminA = 0;
        public decimal vitaminA
        {
            get { return _vitaminA; }
            set { _vitaminA = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal _vitaminB = 0;
        public decimal VitaminB
        {
            get { return _vitaminB; }
            set { _vitaminB = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal _vitaminB1 = 0;
        public decimal VitaminB1
        {
            get { return _vitaminB1; }
            set { _vitaminB1 = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal _vitaminB2 = 0;
        public decimal VitaminB2
        {
            get { return _vitaminB2; }
            set { _vitaminB2 = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal _vitaminPP = 0;
        public decimal VitaminPP
        {
            get { return _vitaminPP; }
            set { _vitaminPP = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal m_vitaminC = 0;
        public decimal VitaminC
        {
            get { return m_vitaminC; }
            set { m_vitaminC = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal m_mineralK = 0;
        public decimal MineralK
        {
            get { return m_mineralK; }
            set { m_mineralK = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal m_mineralNA = 0;
        public decimal MineralNA
        {
            get { return m_mineralNA; }
            set { m_mineralNA = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal m_mineralCA = 0;
        public decimal MineralCA
        {
            get { return m_mineralCA; }
            set { m_mineralCA = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal m_mineralMG = 0;
        public decimal MineralMG
        {
            get { return m_mineralMG; }
            set { m_mineralMG = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        decimal m_mineralP = 0;
        public decimal MineralP
        {
            get { return m_mineralP; }
            set { m_mineralP = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }
        
        decimal m_mineralFE = 0;
        public decimal MineralFE
        {
            get { return m_mineralFE; }
            set { m_mineralFE = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// Нормативный документ
        /// </summary>
        String m_normativDoc = "";
        public string NormativDoc
        {
            get { return m_normativDoc; }
            set { m_normativDoc = value; OnChanged(new DataBaseEventArgs(true, false)); }
        }

        /// <summary>
        /// коэффициент отношения брутто к нетто
        /// </summary>
        decimal pBrutto = 0;
        public decimal Brutto
        {
            get { return pBrutto; }
            set { pBrutto = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// Отображение в списке состава
        /// </summary>
        bool pInSostav = true;
        public bool InSostav
        {
            get { return pInSostav; }
            set { pInSostav = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// Отображение элемента в рецептуре
        /// </summary>
        bool pInRecept = true;
        public bool InRecept
        {
            get { return pInRecept; }
            set { pInRecept = value; OnChanged(new DataBaseEventArgs(false, true)); }
        }

        #endregion

        public DataRawStruct(DataBase par): base(par){}

        public override decimal PercentFilling()
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        //public override bool Contains(DataBase child)
        //{
        //    return false;
        //    //throw new Exception("The method or operation is not implemented.");
        //}

        #region Методы для формирования списка (ключ=значение) в комбобоксах
        // то, что выбирается в списке
        public String DisplayMember
        {
            get { return this.Name + " (" + this.Water.ToString(CultureInfo.CurrentCulture) + "%)"; }
        }

        // то, что возвращается после выбора из списка
        public String ValueMember
        {
            get { return this.Id.ToString(CultureInfo.CurrentCulture); }
        }

        public string raw_num
        {
            get { return Config.DP.GetRawNum(this).ToString(CultureInfo.CurrentCulture); }
        }
        #endregion

        #region Загрузка/сохранение в XML
        public static DataRawStruct LoadFromXml(XmlNode root, DataBase par, DataBaseType curType)
        {
            DataRawStruct curRaw = new DataRawStruct(par);
            curRaw.BeginUpdate();
            curRaw.Id = int.Parse(root.Attributes["id"].Value, CultureInfo.CurrentCulture);
            foreach (XmlNode curRawNode in root.ChildNodes)
            {
                switch (curRawNode.Name)
                {
                    case "brutto":
                        curRaw.pBrutto = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture);
                        break;
                    case "caloric":
                        curRaw.myCaloric = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture);
                        break;
                    case "starch":
                        curRaw._starch = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture);
                        break;
                    case "saccharides":
                        curRaw._saccharides = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture);
                        break;
                        case "cellulose": curRaw._cellulose = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "cholesterol": curRaw._cholesterol = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "comment": curRaw.Comment = curRawNode.InnerText.ToString(); break;
                        case "fat": curRaw._fat = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "acid": curRaw._acid = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "ash": curRaw._ash = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "mineralCa": curRaw.m_mineralCA = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "mineralFe": curRaw.m_mineralFE = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "mineralK": curRaw.m_mineralK = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "mineralMg": curRaw.m_mineralMG = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "mineralNa": curRaw.m_mineralNA = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "mineralP": curRaw.m_mineralP = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "normativDoc": curRaw.m_normativDoc = curRawNode.InnerText.ToString(); break;
                        case "protein": curRaw._protein = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "vitaminA": curRaw._vitaminA = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "vitaminB": curRaw._vitaminB = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "vitaminB1": curRaw._vitaminB1 = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "vitaminB2": curRaw._vitaminB2 = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "vitaminC": curRaw.m_vitaminC = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "vitaminPP": curRaw._vitaminPP = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "water": curRaw.myWater = Convert.ToDecimal(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "name": curRaw.Name = curRawNode.InnerText; break;
                        case "inRecept": curRaw.pInRecept = Convert.ToBoolean(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        case "inSostav": curRaw.pInSostav = Convert.ToBoolean(curRawNode.InnerText, CultureInfo.CurrentCulture); break;
                        //case "quantity": curRaw._quantity = Convert.ToDecimal(curRawNode.InnerText); break;
                }
            }
            curRaw.EndUpdate(false);
            curRaw.IsChanged = false;

            // ищем эту или похожую компоненту в БД
            DataRawStruct ret;
            switch (curType)
            {
                case DataBaseType.RawType:
                    ret = Config.DP.FindRaw(curRaw);
                    if (ret == null)
                    {
                        FormCompare frm = new FormCompare(curRaw, Config.DP.FindSimilarRaw(curRaw), curType);
                        frm.ShowDialog();
                        ret = (DataRawStruct)frm.UserRec;
                    }
                    break;
                case DataBaseType.ProcessLossType:
                    ret = Config.DP.FindProcessLoss(curRaw);
                    if (ret == null)
                    {
                        FormCompare frm = new FormCompare(curRaw, Config.DP.FindSimilarProcessLoss(curRaw), curType);
                        frm.ShowDialog();
                        ret = (DataRawStruct)frm.UserRec;
                    }
                    break;
                default:
                    throw new NotImplementedException("Не реализовано");
            }
            
            //ret.Add(curRaw);
            return ret;
        }

        public override XmlNode StoreToXml(XmlDocument doc, string nodeName)
        {
            XmlNode root = doc.CreateElement(nodeName);
            XmlAttribute idattr = doc.CreateAttribute("id");
            idattr.Value = Id.ToString(CultureInfo.CurrentCulture);
            root.Attributes.Append(idattr);

            XmlNode curNode = root.AppendChild(doc.CreateElement("brutto"));
            curNode.InnerText = pBrutto.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("caloric"));
            curNode.InnerText = myCaloric.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("starch"));
            curNode.InnerText = _starch.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("saccharides"));
            curNode.InnerText = _saccharides.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("cellulose"));
            curNode.InnerText = _cellulose.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("cholesterol"));
            curNode.InnerText = _cholesterol.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("comment"));
            curNode.InnerText = this.Comment;
            curNode = root.AppendChild(doc.CreateElement("fat"));
            curNode.InnerText = _fat.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("acid"));
            curNode.InnerText = _acid.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("ash"));
            curNode.InnerText = _ash.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("mineralCa"));
            curNode.InnerText = m_mineralCA.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("mineralFe"));
            curNode.InnerText = m_mineralFE.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("mineralK"));
            curNode.InnerText = m_mineralK.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("mineralMg"));
            curNode.InnerText = m_mineralMG.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("mineralNa"));
            curNode.InnerText = m_mineralNA.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("mineralP"));
            curNode.InnerText = m_mineralP.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("normativDoc"));
            curNode.InnerText = m_normativDoc;
            curNode = root.AppendChild(doc.CreateElement("protein"));
            curNode.InnerText = _protein.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("vitaminA"));
            curNode.InnerText = _vitaminA.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("vitaminB"));
            curNode.InnerText = _vitaminB.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("vitaminB1"));
            curNode.InnerText = _vitaminB1.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("vitaminB2"));
            curNode.InnerText = _vitaminB2.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("vitaminC"));
            curNode.InnerText = m_vitaminC.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("vitaminPP"));
            curNode.InnerText = _vitaminPP.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("water"));
            curNode.InnerText = myWater.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("name"));
            curNode.InnerText = this.Name;
            curNode = root.AppendChild(doc.CreateElement("inRecept"));
            curNode.InnerText = pInRecept.ToString();
            curNode = root.AppendChild(doc.CreateElement("inSostav"));
            curNode.InnerText = pInSostav.ToString();
            //curNode = root.AppendChild(doc.CreateElement("quantity"));
            //curNode.InnerText = _quantity.ToString();

            return root;
        }

        #endregion


        #region ICloneable Members

        public object Clone()
        {
            DataRawStruct ret = new DataRawStruct(this.Parent);
            ret.BeginUpdate();
            ret.pBrutto = pBrutto;
            ret.myCaloric = myCaloric;
            ret._starch = _starch;
            ret._saccharides = _saccharides;
            ret._cellulose = _cellulose;
            ret._cholesterol = _cholesterol;
            ret._fat = _fat;
            ret._acid = _acid;
            ret._ash = _ash;
            ret.m_mineralCA = m_mineralCA;
            ret.m_mineralFE = m_mineralFE;
            ret.m_mineralK = m_mineralK;
            ret.m_mineralMG = m_mineralMG;
            ret.m_mineralNA = m_mineralNA;
            ret.m_mineralP = m_mineralP;
            ret.m_normativDoc = m_normativDoc;
            ret._protein = _protein;
            ret._vitaminA = _vitaminA;
            ret._vitaminB = _vitaminB;
            ret._vitaminB1 = _vitaminB1;
            ret._vitaminB2 = _vitaminB2;
            ret.m_vitaminC = m_vitaminC;
            ret._vitaminPP = _vitaminPP;
            ret.myWater = myWater;
            ret.Id = this.Id;
            ret.Comment = this.Comment;
            ret.Name = this.Name;
            ret.Quantity = this.Quantity;
            ret.pInSostav = pInSostav;
            ret.pInRecept = pInRecept;

            return ret;
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        internal bool EqualVal(object p)
        {
            DataRawStruct ret;
            if (p == null || (ret = p as DataRawStruct) == null)
            {
                return false;
            }

            if (ret.pBrutto != pBrutto ||
                ret.myCaloric != myCaloric ||
                ret._starch != _starch ||
                ret._saccharides != _saccharides ||
                ret._cellulose != _cellulose ||
                ret._cholesterol != _cholesterol ||
                ret._fat != _fat ||
                ret._acid != _acid ||
                ret._ash != _ash ||
                ret.m_mineralCA != m_mineralCA ||
                ret.m_mineralFE != m_mineralFE ||
                ret.m_mineralK != m_mineralK ||
                ret.m_mineralMG != m_mineralMG ||
                ret.m_mineralNA != m_mineralNA ||
                ret.m_mineralP != m_mineralP ||
                !ret.m_normativDoc.Equals(m_normativDoc) ||
                ret._protein != _protein ||
                ret._vitaminA != _vitaminA ||
                ret._vitaminB != _vitaminB ||
                ret._vitaminB1 != _vitaminB1 ||
                ret._vitaminB2 != _vitaminB2 ||
                ret.m_vitaminC != m_vitaminC ||
                ret._vitaminPP != _vitaminPP ||
                ret.myWater != myWater ||
                ret.pInRecept != pInRecept ||
                ret.pInSostav != pInSostav ||
                !ret.Comment.Equals(this.Comment) ||
                !ret.Name.Equals(this.Name) ||
                !ret.Quantity.Equals(this.Quantity))
            {
                return false;
            }

            return true;
        }
    }
}
