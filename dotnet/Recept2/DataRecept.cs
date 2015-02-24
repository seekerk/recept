using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Recept2
{
    /// <summary>
    /// структура хранения рецептуры
    /// </summary>
    internal class DataRecept: DataBase
    {
        #region поля структуры
        
        /// <summary>
        /// влажность изделия
        /// </summary>
        decimal _water;
        /// <summary>
        /// влажность изделия
        /// </summary>
        public decimal water
        {
            get { return _water; }
            set {
                decimal oldVal = _water;
                _water = value;
                if (!oldVal.Equals(_water))
                    OnChanged(new DataBaseEventArgs(false, true));
            }
        }

        /// <summary>
        /// отклонение влажности в большую сторону (+)
        /// </summary>
        decimal _waterPlus;
        /// <summary>
        /// отклонение влажности в большую сторону (+)
        /// </summary>
        public decimal waterPlus
        {
            get { return _waterPlus; }
            set {
                decimal oldVal = _waterPlus;
                _waterPlus = value;
                if (!oldVal.Equals(_waterPlus))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// отклонение влажности в меньшую сторону (-)
        /// </summary>
        decimal _waterMinus;
        /// <summary>
        /// отклонение влажности в меньшую сторону (-)
        /// </summary>
        public decimal waterMinus
        {
            get { return _waterMinus; }
            set {
                decimal oldVal = _waterMinus;
                _waterMinus = value;
                if (!oldVal.Equals(_waterMinus))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }
        
        /// <summary>
        /// Кислотность изделия.
        /// </summary>
        private decimal myAcidity;
        
        /// <summary>
        /// Кислотность изделия.
        /// </summary>
        public decimal Acidity
        {
        	get {
        		return this.myAcidity;
        	}
        	
        	set {
        		if (!decimal.Equals(this.Acidity, value))
        		{
        			this.myAcidity = value;
        			OnChanged(new DataBaseEventArgs(false, true));
        		}
        	}
        }

        /// <summary>
        /// норма потерь
        /// </summary>
        DataTotalLoss _totalLoss;
        /// <summary>
        /// норма потерь
        /// </summary>
        public DataTotalLoss totalLoss
        {
            get { return _totalLoss; }
            set {
                DataTotalLoss oldVal = _totalLoss;
                _totalLoss = value;
                if (oldVal == null && _totalLoss != null ||
                    !oldVal.EqualVal(_totalLoss))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        #region Параметры оформления, подачи, хранения и реализации
        string _extView = "";
        /// <summary>
        /// Описание внешнего вида
        /// </summary>
        public string extView
        {
            get { return _extView; }
            set {
                string oldVal = _extView;
                _extView = value;
                if (!oldVal.Equals(_extView))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _color = "";
        /// <summary>
        /// Описание цвета изделия
        /// </summary>
        public string color
        {
            get { return _color; }
            set {
                string oldVal = _color;
                _color = value;
                if (!oldVal.Equals(_color))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _consistence = "";
        /// <summary>
        /// Описание консистенции изделия
        /// </summary>
        public string consistence
        {
            get { return _consistence; }
            set {
                string oldVal = _consistence;
                _consistence = value;
                if (!oldVal.Equals(_consistence))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _taste = "";
        /// <summary>
        /// Описание вкуса и запаха изделия
        /// </summary>
        public string taste
        {
            get { return _taste; }
            set {
                string oldVal = _taste;
                _taste = value;
                if (!oldVal.Equals(_taste))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _design = "";
        /// <summary>
        /// Описание оформления изделия
        /// </summary>
        public string design
        {
            get { return _design; }
            set {
                string oldVal = _design;
                _design = value;
                if (!oldVal.Equals(_design))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _delivery = "";
        /// <summary>
        /// Описание подачи изделия
        /// </summary>
        public string delivery
        {
            get { return _delivery; }
            set {
                string oldVal = _delivery;
                _delivery = value;
                if (!oldVal.Equals(_delivery))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _sale = "";
        /// <summary>
        /// описание реализации изделия
        /// </summary>
        public string sale
        {
            get { return _sale; }
            set {
                string oldVal = _sale;
                _sale = value;
                if (!oldVal.Equals(_sale))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        string _storage = "";
        /// <summary>
        /// Описание хранения изделия
        /// </summary>
        public string storage
        {
            get { return _storage; }
            set {
                string oldVal = _storage;
                _storage = value;
                if (!oldVal.Equals(_storage))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }
        #endregion

        /// <summary>
        /// описание процесса приготовления
        /// </summary>
        string _process;
        /// <summary>
        /// описание процесса приготовления
        /// </summary>
        public string process
        {
            get { return _process; }
            set {
                if (!string.Equals(_process, value))
				{
					_process = value;
                    OnChanged(new DataBaseEventArgs(false, true)); 
				}
			}
        }

        /// <summary>
        /// Выход рецептуры по весу.
        /// </summary>
        decimal myTotalExit;
        
        /// <summary>
        /// Выход рецептуры по весу.
        /// </summary>
        public decimal TotalExit
        {
            get { return myTotalExit; }
            set {
                decimal oldVal = myTotalExit;
                myTotalExit = value;
                if (!oldVal.Equals(myTotalExit))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }
        
        /// <summary>
        /// Выход рецептуры по количеству.
        /// </summary>
        decimal myCountExit = 1;
        
        /// <summary>
        /// Выход рецептуры по количеству.
        /// </summary>
        public decimal CountExit
        {
            get { return myCountExit; }
            set {
                decimal oldVal = myCountExit;
                myCountExit = value;
                if (!oldVal.Equals(myCountExit))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }
        
        #region Параметры расчета
        /// <summary>
        /// Расчет по влажности
        /// </summary>
        bool myIsCalcWater = true;
        /// <summary>
        /// Расчет по влажности
        /// </summary>
        public bool isCalcWater
        {
            get { return myIsCalcWater; }
            set {
                if (myIsCalcWater != value)
                {
                    myIsCalcWater = value;
                    if (myIsCalcWater)
                    {
                        myIsCalcExit = false;
                        myIsSetWater = false;
                    }
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }

        /// <summary>
        /// Расчет по выходу
        /// </summary>
        bool myIsCalcExit = false;
        /// <summary>
        /// Расчет по выходу
        /// </summary>
        public bool isCalcExit
        {
            get { return myIsCalcExit; }
            set {
                if (myIsCalcExit != value)
                {
                    myIsCalcExit = value;
                    if (myIsCalcExit)
                    {
                        myIsCalcWater = false;
                        myIsSetWater = false;
                    }
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }
        
        /// <summary>
        /// расчитать требуемое кол-во воды по выходу и влажности
        /// </summary>
        bool myIsSetWater = false;
        /// <summary>
        /// расчитать требуемое кол-во воды по выходу и влажности
        /// </summary>
        public bool isSetWater
        {
            get { return myIsSetWater; }
            set {
                if (myIsSetWater != value)
                {
                    myIsSetWater = value;
                    if (myIsSetWater)
                    {
                        myIsCalcExit = false;
                        myIsCalcWater = false;
                    }
                    OnChanged(new DataBaseEventArgs(false, true));
                }
            }
        }
        #endregion

        /// <summary>
        /// нормативный документ
        /// </summary>
        string _normativDoc;
        /// <summary>
        /// нормативный документ
        /// </summary>
        public string normativDoc
        {
            get { return _normativDoc; }
            set {
                string oldVal = _normativDoc;
                _normativDoc = value;
                if (!oldVal.Equals(_normativDoc))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// источник данных рецептуры
        /// </summary>
        string _source;
        /// <summary>
        /// источник данных рецептуры
        /// </summary>
        public string source
        {
            get { return _source; }
            set {
                string oldVal = _source;
                _source = value;
                if (!oldVal.Equals(_source))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// краткое предварительное описание
        /// </summary>
        string _preview;
        /// <summary>
        /// краткое предварительное описание
        /// </summary>
        public string preview
        {
            get { return _preview; }
            set {
                string oldVal = _preview;
                _preview = value;
                if (!oldVal.Equals(_preview))
                    OnChanged(new DataBaseEventArgs(false, true)); }
        }

        /// <summary>
        /// Показатели микробиологии.
        /// </summary>
        DataMicroBiology myMicroBiology;
        
        /// <summary>
        /// Показатели микробиологии.
        /// </summary>
        public DataMicroBiology MicroBiology
        {
            get {
                return myMicroBiology;
            }
            
            set {
                myMicroBiology = value;
                OnChanged(new DataBaseEventArgs(false, true));
            }
        }

        #endregion

        #region Расчетные поля структуры
        /// <summary>
        /// Расчетная сумма нетто по компонентам рецептуры.
        /// </summary>
        private decimal myCalcSumNetto;
        
        /// <summary>
        /// Расчетная сумма нетто по компонентам рецептуры.
        /// </summary>
        public decimal CalcSumNetto
        {
            get {
                return myCalcSumNetto;
            }
        }
        
        /// <summary>
        /// Расчетный выход нетто по компонентам рецептуры.
        /// </summary>
        private decimal myCalcExitNetto;
        
        /// <summary>
        /// Расчетный выход нетто по компонентам рецептуры.
        /// </summary>
        public decimal CalcExitNetto
        {
            get {
                return myCalcExitNetto;
            }
        }
        
        /// <summary>
        /// Расчетная влажность.
        /// </summary>
        public decimal CalcWater
        {
        	get {
        		if (this._water != 0)
        			return this._water;
        		if (this.myCalcExitNetto != 0)
        			return (1 - this.myCalcExitSuhie/this.myCalcExitNetto) * 100;
        		return this._water; // если вообще ничего не задано
        	}
        }
        
        /// <summary>
        /// Расчетная сумма по сухому в-ву компонент рецептуры.
        /// </summary>
        private decimal myCalcSumSuhie;
        
        /// <summary>
        /// Расчетная сумма по сухому в-ву компонент рецептуры.
        /// </summary>
        public decimal CalcSumSuhie
        {
            get {
                return myCalcSumSuhie;
            }
        }
        
        /// <summary>
        /// Расчетный выход по сухому в-ву компонент рецептуры.
        /// </summary>
        private decimal myCalcExitSuhie;
        
        /// <summary>
        /// Расчетный выход по сухому в-ву компонент рецептуры.
        /// </summary>
        public decimal CalcExitSuhie
        {
            get {
                return myCalcExitSuhie;
            }
        }
        
        /// <summary>
        /// Расчетные свойства готового изделия.
        /// </summary>
        private DataRawStruct myCalcProperty;

        /// <summary>
        /// Расчетные свойства готового изделия.
        /// </summary>
        public DataRawStruct CalcProperty
        {
            get {
                return myCalcProperty;
            }
        }
        #endregion
        
        public DataRecept(DataBase par): base(par)
        {
            this.BeginUpdate();
            this.Quantity = Config.Cfg.TotalExit;
            this.Name = "Новая рецептура";
            this.EndUpdate(false);
            this.IsChanged = false;
        }

        #region Загрузка из XML-файла
        /// <summary>
        /// загрузка файла в зависимости от версии
        /// </summary>
        /// <param name="root">узел дерева XML</param>
        /// <param name="par">родительский объект</param>
        /// <param name="curVer">версия загружаемого файла</param>
        /// <returns>структура, содержащая данные рецептуры</returns>
        internal static DataRecept LoadFromXml(XmlNode root, DataBase par, ReceptVersion curVer)
        {
            switch (curVer)
            {
                case ReceptVersion.Version0:
                    return LoadFromXmlVer0(root, par, curVer);
                case ReceptVersion.Version1:
                    return LoadFromXmlVer1(root, par, curVer);
                default:
                    throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// загрузка из файла старого формата
        /// </summary>
        /// <param name="curnode"></param>
        /// <param name="par"></param>
        /// <param name="curVer"></param>
        /// <returns></returns>
        private static DataRecept LoadFromXmlVer0(XmlNode curnode, DataBase par, ReceptVersion curVer)
        {
            DataRecept curRec = new DataRecept(par);
            curRec.BeginUpdate();
            XmlNode rootNode = curnode.SelectSingleNode("recept");
            foreach (XmlNode props in rootNode.ChildNodes)
            {
                switch (props.Name)
                {
                        case "name": curRec.Name = props.InnerText; break;
                        case "number": curRec.Id = int.Parse(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "water": curRec._water = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "deflect": {curRec._waterPlus = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture);
                            curRec._waterMinus = curRec._waterPlus; break;}
                        case "description": curRec._design = props.InnerText; break;
                        case "poteri": curRec._totalLoss = DataTotalLoss.LoadFromXml(props, curRec, curVer); break;
                        case "component": curRec.Components.Add(DataRaw.LoadOneFromXml(props, curRec, curVer)); break;
                }
            }
            curRec.IsChanged = false;
            curRec.EndUpdate(false);
            return curRec;
        }
        
        /// <summary>
        /// загрузка файла версии программы "2"
        /// </summary>
        /// <param name="curnode">узел дерева XML</param>
        /// <param name="par">родительский объект</param>
        /// <returns>структуру данных рецептуры</returns>
        private static DataRecept LoadFromXmlVer1(XmlNode curnode, DataBase par, ReceptVersion curVer)
        {
            DataRecept curRec = new DataRecept(par);
            curRec.BeginUpdate();
            curRec.Id = int.Parse(curnode.Attributes["id"].Value, CultureInfo.CurrentCulture);
            foreach (XmlNode props in curnode.ChildNodes)
            {
                switch (props.Name)
                {
                        case "color": curRec._color = props.InnerText; break;
                        case "components": curRec.Components.AddRange(DataRaw.LoadManyFromXml(props, curRec, curVer)); break;
                        case "consistence": curRec._consistence = props.InnerText; break;
                        case "delivery": curRec._delivery = props.InnerText; break;
                        case "design": curRec._design = props.InnerText; break;
                        case "extView": curRec._extView = props.InnerText; break;
                        case "totalLoss": curRec._totalLoss = DataTotalLoss.LoadFromXml(props, curRec, curVer); break;
                        case "process": curRec._process = props.InnerText; break;
                        case "sale": curRec._sale = props.InnerText; break;
                        case "storage": curRec._storage = props.InnerText; break;
                        case "taste": curRec._taste = props.InnerText; break;
                        case "water": curRec._water = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "waterPlus": curRec._waterPlus = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "waterMinus": curRec._waterMinus = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "acidity": curRec.myAcidity = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "name": curRec.Name = props.InnerText; break;
                        case "source": curRec._source = props.InnerText; break;
                        case "normativDoc": curRec._normativDoc = props.InnerText; break;
                        case "preview": curRec._preview = props.InnerText; break;
                        case "quantity": curRec.Quantity = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "totalExit": curRec.myTotalExit = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "countExit": curRec.myCountExit = Convert.ToDecimal(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "microbiology": curRec.myMicroBiology = DataMicroBiology.LoadFromXml(props, curRec, curVer); break;
                        case "isCalcExit": curRec.myIsCalcExit = Convert.ToBoolean(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "isCalcWater": curRec.myIsCalcWater = Convert.ToBoolean(props.InnerText, CultureInfo.CurrentCulture); break;
                        case "isSetWater": curRec.myIsSetWater = Convert.ToBoolean(props.InnerText, CultureInfo.CurrentCulture); break;
                }
            }
            curRec.IsChanged = false;
            curRec.EndUpdate(false);
            return curRec;
        }


        public override XmlNode StoreToXml(XmlDocument doc, String nodeName)
        {
            // TODO: сделать не переписывание а дополнение недостающими элементами
            XmlNode root = doc[nodeName];
            if (root == null)
                root = doc.CreateElement(nodeName);
            
            XmlAttribute idattr = doc.CreateAttribute("id");
            idattr.Value = this.Id.ToString(CultureInfo.CurrentCulture);
            root.Attributes.Append(idattr);
            XmlNode curNode = root.AppendChild(doc.CreateElement("color"));
            curNode.InnerText = _color;
            curNode = root.AppendChild(doc.CreateElement("components"));
            foreach (DataBase curRec in Components)
            {
                XmlNode ret = null;
                if (curRec is DataRecept)
                {
                    ret = curRec.StoreToXml(doc, "recept");
                }else
                    ret = curRec.StoreToXml(doc, "raw");
                if (ret != null)
                {
                    curNode.AppendChild(ret);
                }
            }
            curNode = root.AppendChild(doc.CreateElement("consistence"));
            curNode.InnerText = _consistence;
            curNode = root.AppendChild(doc.CreateElement("delivery"));
            curNode.InnerText = _delivery;
            curNode = root.AppendChild(doc.CreateElement("design"));
            curNode.InnerText = _design;
            curNode = root.AppendChild(doc.CreateElement("extView"));
            curNode.InnerText = _extView;
            if (_totalLoss != null)
            {
                root.AppendChild(_totalLoss.StoreToXml(doc, "totalLoss"));
            }
            curNode = root.AppendChild(doc.CreateElement("process"));
            curNode.InnerText = _process;
            curNode = root.AppendChild(doc.CreateElement("sale"));
            curNode.InnerText = _sale;
            curNode = root.AppendChild(doc.CreateElement("storage"));
            curNode.InnerText = _storage;
            curNode = root.AppendChild(doc.CreateElement("taste"));
            curNode.InnerText = _taste;
            curNode = root.AppendChild(doc.CreateElement("water"));
            curNode.InnerText = _water.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("waterPlus"));
            curNode.InnerText = _waterPlus.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("waterMinus"));
            curNode.InnerText = _waterMinus.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("acidity"));
            curNode.InnerText = this.myAcidity.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("name"));
            curNode.InnerText = this.Name;
            curNode = root.AppendChild(doc.CreateElement("source"));
            curNode.InnerText = _source;
            curNode = root.AppendChild(doc.CreateElement("normativDoc"));
            curNode.InnerText = _normativDoc;
            curNode = root.AppendChild(doc.CreateElement("preview"));
            curNode.InnerText = _preview;
            curNode = root.AppendChild(doc.CreateElement("quantity"));
            curNode.InnerText = this.Quantity.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("totalExit"));
            curNode.InnerText = myTotalExit.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("countExit"));
            curNode.InnerText = myCountExit.ToString(CultureInfo.CurrentCulture);
            if (myMicroBiology != null)
            {
                root.AppendChild(myMicroBiology.StoreToXml(doc, "microbiology"));
            }
            curNode = root.AppendChild(doc.CreateElement("isCalcExit"));
            curNode.InnerText = myIsCalcExit.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("isCalcWater"));
            curNode.InnerText = myIsCalcWater.ToString(CultureInfo.CurrentCulture);
            curNode = root.AppendChild(doc.CreateElement("isSetWater"));
            curNode.InnerText = myIsSetWater.ToString(CultureInfo.CurrentCulture);

            return root;
            //throw new Exception("The method or operation is not implemented.");
        }
        #endregion



        public override decimal PercentFilling()
        {
            decimal totalVals = 0;
            decimal fillVals = 0;

            if (!String.IsNullOrEmpty(this._color)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._consistence)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._delivery)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._design)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._extView)) fillVals++; totalVals++;
            if (this.myMicroBiology != null) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._normativDoc)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._preview)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._process)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._sale)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._source)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._storage)) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this._taste)) fillVals++; totalVals++;
            if (this.myTotalExit != 0) fillVals++; totalVals++;
            if (this.myCountExit != 0) fillVals++; totalVals++;
            if (this._totalLoss != null) fillVals++; totalVals++;
            if (this._water != 0) fillVals++; totalVals++;
            if (this.myAcidity != 0) fillVals++; totalVals++;
            if (!String.IsNullOrEmpty(this.Name)) fillVals++; totalVals++;
            if (this.Id != 0) fillVals++; totalVals++;

            return fillVals * 100 / totalVals;
        }

        /// <summary>
        /// расчет рецептуры
        /// </summary>
        /// <returns>результаты расчета</returns>
        internal void CalcRecept()
        {
            // инициализация
            this.myCalcProperty = new DataRawStruct(null);
            this.myCalcSumNetto = 0;
            this.myCalcSumSuhie = 0;

            // Потери текущего элемента.
            DataRawStruct prLoss;

            // расчет закладки по количеству и сухим веществам
            foreach (DataBase curRec in Components)
            {
                Decimal netto = 0;
                DataRawStruct curRaw = null;

                if (curRec is DataRecept)
                {
                    // расчет вложенной рецептуры
                    DataRecept introRec = (DataRecept)curRec;
                    introRec.CalcRecept();
                    netto = introRec.CalcSumNetto;
                    curRaw = introRec.CalcProperty;
                    prLoss = new DataRawStruct(null);
                    this.myCalcSumSuhie += introRec.CalcSumSuhie;
                }
                else
                {
                    // Расчет компоненты
                    DataRaw dr = (DataRaw)curRec;
                    netto = dr.Quantity;
                    curRaw = dr.RawStruct;
                    // если элемент пустой, то пропускаем его
                    if (curRaw == null)
                        continue;
                    
                    if (dr.Brutto == 0 && netto != 0 && curRaw.Brutto != 0)
                    {
                        dr.Brutto = netto * curRaw.Brutto;
                    }
                    
                    if (dr.Brutto != 0 && netto == 0 && curRaw.Brutto != 0)
                    {
                        netto = dr.Brutto / curRaw.Brutto;
                    }
                    
                    // если не заданы потери, то создаем пустые (без потерь)
                    if (dr.ProcessLoss != null)
                        prLoss = dr.ProcessLoss;
                    else
                        prLoss = new DataRawStruct(null);
                    
                    // добавление сухих веществ
                    this.myCalcSumSuhie += netto * (100 - curRaw.Water) * (100 - prLoss.Brutto) / 10000;
                    
                }
                
                // расчет = сумма (количество, уменьшенное на потерю при термической обработке и умноженное на присутствие
                // исходные данные указаны в % (кроме веса и калорийности)
                this.myCalcSumNetto += netto * (100 - prLoss.Brutto) / 100;
                this.myCalcProperty.Water += curRaw.Water * netto * (100 - prLoss.Water) / 10000;
                this.myCalcProperty.Caloric += curRaw.Caloric * netto * (100 - prLoss.Caloric) / 10000; // калории на 100г., поэтому еще делим и на 100
                this.myCalcProperty.starch += curRaw.starch * netto * (100 - prLoss.starch) / 10000;
                this.myCalcProperty.saccharides += curRaw.saccharides * netto * (100 - prLoss.saccharides) / 10000;
                this.myCalcProperty.cellulose += curRaw.cellulose * netto * (100 - prLoss.cellulose) / 10000;
                this.myCalcProperty.cholesterol += curRaw.cholesterol * netto * (100 - prLoss.cholesterol) / 10000;
                this.myCalcProperty.fat += curRaw.fat * netto * (100 - prLoss.fat) / 10000;
                this.myCalcProperty.acid += curRaw.acid * netto * (100 - prLoss.acid) / 10000;
                this.myCalcProperty.ash += curRaw.ash * netto * (100 - prLoss.ash) / 10000;
                this.myCalcProperty.MineralCA += curRaw.MineralCA * netto * (100 - prLoss.MineralCA) / 10000;
                this.myCalcProperty.MineralFE += curRaw.MineralFE * netto * (100 - prLoss.MineralFE) / 10000;
                this.myCalcProperty.MineralK += curRaw.MineralK * netto * (100 - prLoss.MineralK) / 10000;
                this.myCalcProperty.MineralMG += curRaw.MineralMG * netto * (100 - prLoss.MineralMG) / 10000;
                this.myCalcProperty.MineralNA += curRaw.MineralNA * netto * (100 - prLoss.MineralNA) / 10000;
                this.myCalcProperty.MineralP += curRaw.MineralP * netto * (100 - prLoss.MineralP) / 10000;
                this.myCalcProperty.protein += curRaw.protein * netto * (100 - prLoss.protein) / 10000;
                this.myCalcProperty.vitaminA += curRaw.vitaminA * netto * (100 - prLoss.vitaminA) / 10000;
                this.myCalcProperty.VitaminB += curRaw.VitaminB * netto * (100 - prLoss.VitaminB) / 10000;
                this.myCalcProperty.VitaminB1 += curRaw.VitaminB1 * netto * (100 - prLoss.VitaminB1) / 10000;
                this.myCalcProperty.VitaminB2 += curRaw.VitaminB2 * netto * (100 - prLoss.VitaminB2) / 10000;
                this.myCalcProperty.VitaminC += curRaw.VitaminC * netto * (100 - prLoss.VitaminC) / 10000;
                this.myCalcProperty.VitaminPP += curRaw.VitaminPP * netto * (100 - prLoss.VitaminPP) / 10000;
            }

            // Расчет по выходу
            if (myIsCalcExit && this.myTotalExit > 0)
            {
                if (this._totalLoss != null)
                    this.myCalcExitSuhie = this.myCalcSumSuhie * (100 - this._totalLoss.Quantity) / 100;
                else
                    this.myCalcExitSuhie = this.myCalcSumSuhie;
                
                this.myCalcExitNetto = this.myTotalExit;
            }else
                
                // расчет по воде
                if (myIsCalcWater && this.water > 0)
            {
                if (this._totalLoss != null)
                    this.myCalcExitSuhie = this.myCalcSumSuhie * (100 - this._totalLoss.Quantity) / 100;
                else
                    this.myCalcExitSuhie = this.myCalcSumSuhie;
                
                this.myCalcExitNetto = this.myCalcExitSuhie / (100 - this._water) * 100;
            }else
                
                // расчет воды по выходу и влажности
                if (myIsSetWater && this._water > 0 && this.myTotalExit > 0)
            {
                DataRawStruct waterRaw = Config.DP.GetRawByNum(Config.Cfg.WaterId);
                if (waterRaw == null)
                    throw new InvalidDataException("Не задана вода для расчета в рецептуре");

                if (this._totalLoss != null)
                    this.myCalcExitSuhie = this.myCalcSumSuhie * (100 - this._totalLoss.Quantity) / 100;
                else
                    this.myCalcExitSuhie = this.myCalcSumSuhie;

                this.myCalcExitNetto = this.myTotalExit;
                //decimal waterVal = this.myCalcExitSuhie / (100 - this._water) * 100 - this.myCalcExitNetto;
                throw new NotImplementedException("Дописать расчет воды по выходу и влажности");
            }else
            { // Просто без расчета
                this.myCalcExitNetto = this.myCalcSumNetto;
                this.myCalcExitSuhie = this.myCalcSumSuhie;
            }
            if (this.myCalcExitNetto <= 0)
                throw new OverflowException("Выход у рецептуры меньше или равен нулю");

            // пересчет значений в процентах
            this.myCalcProperty.Water /= this.myCalcExitNetto / 100;
            this.myCalcProperty.Caloric /= this.myCalcExitNetto / 100;
            this.myCalcProperty.starch /= this.myCalcExitNetto / 100;
            this.myCalcProperty.saccharides /= this.myCalcExitNetto / 100;
            this.myCalcProperty.cellulose /= this.myCalcExitNetto / 100;
            this.myCalcProperty.cholesterol /= this.myCalcExitNetto / 100;
            this.myCalcProperty.fat /= this.myCalcExitNetto / 100;
            this.myCalcProperty.acid /= this.myCalcExitNetto / 100;
            this.myCalcProperty.ash /= this.myCalcExitNetto / 100;
            this.myCalcProperty.MineralCA /= this.myCalcExitNetto / 100;
            this.myCalcProperty.MineralFE /= this.myCalcExitNetto / 100;
            this.myCalcProperty.MineralK /= this.myCalcExitNetto / 100;
            this.myCalcProperty.MineralMG /= this.myCalcExitNetto / 100;
            this.myCalcProperty.MineralNA /= this.myCalcExitNetto / 100;
            this.myCalcProperty.MineralP /= this.myCalcExitNetto / 100;
            this.myCalcProperty.protein /= this.myCalcExitNetto / 100;
            this.myCalcProperty.vitaminA /= this.myCalcExitNetto / 100;
            this.myCalcProperty.VitaminB /= this.myCalcExitNetto / 100;
            this.myCalcProperty.VitaminB1 /= this.myCalcExitNetto / 100;
            this.myCalcProperty.VitaminB2 /= this.myCalcExitNetto / 100;
            this.myCalcProperty.VitaminC /= this.myCalcExitNetto / 100;
            this.myCalcProperty.VitaminPP /= this.myCalcExitNetto / 100;
        }

        /// <summary>
        /// группировка сырья с суммированием количества
        /// </summary>
        /// <returns>ключ=DataRawStruct, значение=DataRaw (заполнено quantity и brutto)</returns>
        internal Hashtable GroupRaws(bool isRecursive)
        {
            Hashtable ret = new Hashtable();
            foreach (DataBase dr in this.Components)
            {
                // если это рецептура полуфабриката
                if (dr is DataRecept)
                {
                    if (isRecursive)
                    {
                        Hashtable curRec = (dr as DataRecept).GroupRaws(isRecursive);
                        foreach (DataRawStruct curRaw in curRec.Keys)
                        {
                            if (!ret.ContainsKey(curRaw))
                            {
                                ret[curRaw] = new DataRaw(null);
                            }
                            (ret[curRaw] as DataRaw).Quantity += (curRec[curRaw] as DataRaw).Quantity;
                            (ret[curRaw] as DataRaw).Brutto += (curRec[curRaw] as DataRaw).Brutto;
                        }
                    }
                    continue;
                }

                DataRawStruct rawStr = (dr as DataRaw).RawStruct;

                if (rawStr == null)
                {
                    continue;
                }

                Decimal brutto = (dr as DataRaw).Brutto;
                Decimal netto = (dr as DataRaw).Quantity;
                if (brutto != 0 && netto == 0 && rawStr.Brutto != 0)
                {
                    netto = brutto / rawStr.Brutto;
                }
                if (brutto == 0 && netto != 0 && rawStr.Brutto != 0)
                {
                    brutto = netto * rawStr.Brutto;
                }

                if (!ret.ContainsKey(rawStr))
                {
                    ret[rawStr] = new DataRaw(null);
                }
                (ret[rawStr] as DataRaw).Quantity += netto;
                (ret[rawStr] as DataRaw).Brutto += brutto;
            }
            return ret;
        }

    }
}
