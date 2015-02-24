namespace Recept2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Тип отображаемых данных в отчете.
    /// </summary>
    public enum PreviewReport
    {
        /// <summary>
        /// Ничего не показываем.
        /// </summary>
        None,
        /// <summary>
        /// Показываем технико-технологическую карту.
        /// </summary>
        FormTtk,
        /// <summary>
        /// Показываем технологическую карту.
        /// </summary>
        FormTK,
        /// <summary>
        /// Показываем список рецептур.
        /// </summary>
        BookList
    }
    
    /// <summary>
    /// Форма показа отчета для печати и экспорта.
    /// </summary>
    public partial class FormPreview : Form
    {
        /// <summary>
        /// Текст отчета.
        /// </summary>
        string myDoc = "";

        /// <summary>
        /// Название отчета (используется для сохранения файла).
        /// </summary>
        string myName = "Отчет";
        
        /// <summary>
        /// Используемый объект для расчета.
        /// </summary>
        DataBase myData;
        
        /// <summary>
        /// Используемый отчет.
        /// </summary>
        PreviewReport myMode = PreviewReport.None;
        
        /// <summary>
        /// Инициализирует данные отчета.
        /// </summary>
        /// <param name="data">Объект данных для отображения в отчете.</param>
        /// <param name="mode">Режим отображения.</param>
        public FormPreview(DataBase data, PreviewReport mode)
        {
            InitializeComponent();
            myData = data;
            myMode = mode;

            SetData();
        }
        
        void SetData()
        {
            switch (myMode)
            {
                case PreviewReport.FormTtk:
                    myDoc = PrintTTK((DataRecept)myData);
                    myName = myData.Name;
                    break;
                case PreviewReport.FormTK:
                    myDoc = PrintTK((DataRecept)myData);
                    myName = myData.Name;
                    break;
                case PreviewReport.BookList:
                    myDoc = PrintBookList();
                    myName = "Перечень ТТК";
                    break;
                default:
                    throw new NotImplementedException("Неизвестный отчет для просмотра");
            }
            webBrowser1.DocumentText = myDoc;
        }

        /// <summary>
        /// Генерация шапки документа
        /// </summary>
        /// <param name="isLeft">Выводить поле согласовано</param>
        /// <param name="isRight">Выводить поле утверждаю</param>
        /// <returns>Строка с шапкой документа.</returns>
        private static StringBuilder makeHeader(bool isLeft, bool isRight)
        {
            StringBuilder ret = new StringBuilder();
            
            ret.Append("<table width=\"100%\"><tr><td align=\"left\" width=\"49%\">");
            if (isLeft)
            {
                ret.Append("&nbsp;СОГЛАСОВАНО:<br>");
                ret.Append("Роспотребнадзор<br>");
                ret.Append("по республике Карелия<br>");
                ret.Append("__________________________");
                ret.Append(" <br>");
                ret.Append("_______________");
            }else{ret.Append("&nbsp;");}
            
            ret.Append("<td align=\"right\" width=\"49%\">");
            if (isRight)
            {
                ret.Append("УТВЕРЖДАЮ:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>");
                ret.Append(DataBook.Book.company + "<br>");
                ret.Append(DataBook.Book.ChiefName + "<br>");
                ret.Append("\"___\" _________________ 200___г.<br>");
                ret.Append(" <br>");
                ret.Append("_______________");
            }else{ret.Append("&nbsp;");}
            
            ret.Append("</tr></table>");
            return ret;
        }
        
        /// <summary>
        /// Генерация окончания документа.
        /// </summary>
        /// <returns>Строка окончания документа.</returns>
        private static StringBuilder makeFooter()
        {
            StringBuilder ret = new StringBuilder();
            // финал документа
            ret.Append("<p>Ответственный разработчик: " + DataBook.Book.developerCompany + " ___________ " + DataBook.Book.developer + "</p>");
            ret.Append("</html>");
            
            return ret;
        }
        
        static StringBuilder makeReceptProperty(DataRecept curRec)
        {
            StringBuilder curElem = new StringBuilder();
            if (!String.IsNullOrEmpty(curRec.extView))
                curElem.Append("<b>Внешний вид:</b> " + TextFormatting(curRec.extView) + "<br>");
            if (!String.IsNullOrEmpty(curRec.color))
                curElem.Append("<b>Цвет:</b> " + TextFormatting(curRec.color) + "<br>");
            if (!String.IsNullOrEmpty(curRec.consistence))
                curElem.Append("<b>Консистенция:</b> " + TextFormatting(curRec.consistence) + "<br>");
            if (!String.IsNullOrEmpty(curRec.taste))
                curElem.Append("<b>Вкус и запах:</b> " + TextFormatting(curRec.taste));
            return curElem;
        }
        
        /// <summary>
        /// Создание технико-технологической карты
        /// </summary>
        /// <returns></returns>
        internal string PrintTTK(DataRecept curRec)
        {
            Hashtable groupRaws = curRec.GroupRaws(true);
            FormCounter cc = new FormCounter();

            StringBuilder ret = new StringBuilder("<html><style>h3{text-align:center;}</style>");
            try{
                curRec.CalcRecept();
            }catch(OverflowException ex)
            {
                ret.Append("<p align=center>Невозможно сосчитать рецептуру:" + ex.Message + ". Проверьте правильность заполнения</p></html>");
                return ret.ToString();
            }

            // шапка
            ret.Append(makeHeader(true,true));
            ret.Append("<p align=center><b><font size=4>ТЕХНИКО-ТЕХНОЛОГИЧЕСКАЯ КАРТА № " + curRec.Id.ToString(CultureInfo.CurrentCulture) +
                       "</font><br><font size=5> на " + curRec.Name + "</font></b>");
            if (!String.IsNullOrEmpty(curRec.normativDoc))
            {
                ret.Append("<br>Изготовлено по " + curRec.normativDoc);
            }
            ret.Append("</p>");

            // область применения
            ret.Append("<h3>" + cc.moveUp() + " Область применения</h3>" +
                       "<p align=justify>" + cc.next() + " Настоящая технико-технологическая карта распространяется на изделие \"" +
                       curRec.Name + "\", вырабатываемое " + DataBook.Book.company + ".");
            if (!String.IsNullOrEmpty(curRec.preview))
            {
                ret.Append("<br>" + cc.next() + " Описание изделия. " + curRec.preview);
            }
            ret.Append("</p>");

            // перечень сырья и гостов
            ret.Append("<h3>" + cc.moveUp() + " Перечень сырья</h3>");
            StringBuilder curElem = new StringBuilder();
            foreach (DataRawStruct curRaw in groupRaws.Keys)
            {
                if (String.IsNullOrEmpty(curRaw.NormativDoc) || !curRaw.InRecept)
                {
                    continue;
                }
                curElem.Append("<tr><td><span>" + curRaw.Name + "</span><td><span>" + curRaw.NormativDoc + "</span></tr>");
            }
            if (curElem.Length > 0)
            {
                ret.Append("<p align=justify>" + cc.next() + " Для приготовления \"" + curRec.Name + "\" используют следующее сырье: <table>");
                ret.Append(curElem);
                ret.Append("</table>или продукты зарубежных фирм, имеющие сертификаты и удостоверения качества РФ.</p>");
            }

            ret.Append("<p align=justify>" + cc.next() + " Сырье, используемое для приготовления \"" + curRec.Name + "\", должно соответствовать требованиям" +
                       " нормативной документации, иметь сертификаты и удостоверения качества.</p>");

            // рецептура
            ret.Append("<h3>" + cc.moveUp() + " Рецептура</h3><p align=justify>Рецептура изделия \"" + curRec.Name +
                       "\"<table width=\"100%\" border><tr><td align=center> Наименование сырья <td align=center>Масса брутто, г<td align=center> Масса нетто, г</tr>");
            decimal brSum = 0, ntSum = 0;

            // пробегаем по вложенным рецептурам
            foreach (DataBase dbase in curRec.Components)
            {
                if (dbase is DataRecept)
                {
                    groupRaws = (dbase as DataRecept).GroupRaws(false);
                    Decimal curbrSum = 0;
                    Decimal curntSum = 0;
                    foreach (DataRawStruct curRaw in groupRaws.Keys)
                    {
                        if (!curRaw.InRecept)
                        {
                            continue;
                        }

                        decimal brutto = (groupRaws[curRaw] as DataRaw).Brutto * Config.Cfg.TotalExit / curRec.CalcExitNetto;
                        decimal netto = (groupRaws[curRaw] as DataRaw).Quantity * Config.Cfg.TotalExit / curRec.CalcExitNetto;
                        ret.Append("<tr><td>" + curRaw.Name + "<td align=center>" +
                                   CommonFunctions.Round(brutto) +
                                   "<td align=center>" + CommonFunctions.Round(netto) + "</tr>");
                        curbrSum += brutto;
                        curntSum += netto;
                    }
                    ret.Append("<tr style=\"background-color: #808080\"><td>Итого " + dbase.Name + "<td align=center>" + CommonFunctions.Round(curbrSum) + "<td align=center>" + CommonFunctions.Round(curntSum) + "</tr>");
                    brSum += curbrSum;
                    ntSum += curntSum;

                }
            }

            // отстатки основной рецептуры
            groupRaws = curRec.GroupRaws(false);
            
            foreach (DataRawStruct curRaw in groupRaws.Keys)
            {
                if (!curRaw.InRecept)
                {
                    continue;
                }

                decimal brutto = (groupRaws[curRaw] as DataRaw).Brutto * Config.Cfg.TotalExit / curRec.CalcExitNetto;
                decimal netto = (groupRaws[curRaw] as DataRaw).Quantity * Config.Cfg.TotalExit / curRec.CalcExitNetto;
                ret.Append("<tr><td>" + curRaw.Name + "<td align=center>" +
                           CommonFunctions.Round(brutto) +
                           "<td align=center>" + CommonFunctions.Round(netto) + "</tr>");
                brSum += brutto;
                ntSum += netto;
            }
            ret.Append("<tr><td>Итого<td align=center>" + CommonFunctions.Round(brSum) + "<td align=center>" + CommonFunctions.Round(ntSum) + "</tr>");
            ret.Append("<tr><td>Выход<td>&nbsp;<td align=center>" + CommonFunctions.Round(Config.Cfg.TotalExit) + "</tr>");
            ret.Append("</table></p>");

            // технологический процесс
            ret.Append("<h3>" + cc.moveUp() + " Технологический процесс</h3>");
            ret.Append("<p align=justify> " + cc.next() + " Подготовка сырья к производству изделия \"" + curRec.Name + "\" производится в соответствии со \"Сборником рецептур блюд и кулинарных изделий для предприятий общественного питания\" (1996 г.).</p>");
            if (!String.IsNullOrEmpty(curRec.process))
            {
                ret.Append("<p align=justify> "+cc.next()+" " + curRec.process + "</p>");
            }

            // оформление подача и т.д.
            if (!String.IsNullOrEmpty(curRec.design) || !String.IsNullOrEmpty(curRec.delivery) ||
                !String.IsNullOrEmpty(curRec.sale) || !String.IsNullOrEmpty(curRec.storage))
            {
                ret.Append("<h3>" + cc.moveUp() + " Оформление, подача, реализация и хранение</h3>");
                if (!String.IsNullOrEmpty(curRec.design))
                    ret.Append("<p align=justify> " + cc.next() + " " + curRec.design + "</p>");
                if (!String.IsNullOrEmpty(curRec.delivery))
                    ret.Append("<p align=justify> " + cc.next() + " " + curRec.delivery + "</p>");
                if (!String.IsNullOrEmpty(curRec.sale))
                    ret.Append("<p align=justify> " + cc.next() + " " + curRec.sale + "</p>");
                if (!String.IsNullOrEmpty(curRec.storage))
                    ret.Append("<p align=justify> " + cc.next() + " " + curRec.storage + "</p>");
            }

            // физ-хим показатели
            ret.Append("<h3>" + cc.moveUp() + " Показатели качества и безопасности</h3>");
            curElem = makeReceptProperty(curRec);
            if (curElem.Length > 0)
            {
                ret.Append("<p align=justify>" + cc.next() + " Органолептические показатели изделия:<br>");
                ret.Append(curElem + "</p>");
            }

            ret.Append("<p align=justify>" + cc.next() + " Физико-химические показатели:<br>");
            if (curRec.CalcWater != 0)
            {
                string waterApp = "";
                if (curRec.waterPlus == curRec.waterMinus)
                {
                    if (curRec.waterPlus != 0)
                        waterApp = " &plusmn;" + curRec.waterPlus;
                }else
                    waterApp = " +" + curRec.waterPlus + " -" + curRec.waterMinus;
                ret.AppendLine("Влажность: " + CommonFunctions.Round(curRec.CalcWater) + "%" + waterApp + "<br>");
            }
            if (curRec.Acidity != 0)
            	ret.AppendLine("Кислотность: " + CommonFunctions.Round(curRec.Acidity) + "Ph<br>");
            if (curRec.CalcProperty.starch != 0)
                ret.AppendLine("Крахмал: " + CommonFunctions.Round(curRec.CalcProperty.starch) + "%<br>");
            if (curRec.CalcProperty.saccharides != 0)
                ret.Append("Моно и дисахариды: " + CommonFunctions.Round(curRec.CalcProperty.saccharides) + "%<br>");
            if (curRec.CalcProperty.acid != 0)
                ret.Append("Жирные кислоты: " + CommonFunctions.Round(curRec.CalcProperty.acid) + "%<br>");
            if (curRec.CalcProperty.ash != 0)
                ret.Append("Зола: " + CommonFunctions.Round(curRec.CalcProperty.ash) + "%<br>");
            if (curRec.CalcProperty.cellulose != 0)
                ret.Append("Целлюлоза: " + CommonFunctions.Round(curRec.CalcProperty.cellulose) + "%<br>");
            if (curRec.CalcProperty.cholesterol != 0)
                ret.Append("Холестерин: " + CommonFunctions.Round(curRec.CalcProperty.cholesterol) + "%<br>");
            if (curRec.CalcProperty.protein != 0)
                ret.Append("Протеины: " + CommonFunctions.Round(curRec.CalcProperty.protein) + "%<br>");

            // макроэлементы
            curElem = new StringBuilder();
            if (curRec.CalcProperty.MineralK != 0)
                curElem.Append("<li>Калий (K): " + CommonFunctions.Round(curRec.CalcProperty.MineralK));
            if (curRec.CalcProperty.MineralCA != 0)
                curElem.Append("<li>Кальций (Ca): " + CommonFunctions.Round(curRec.CalcProperty.MineralCA));
            if (curRec.CalcProperty.MineralMG != 0)
                curElem.Append("<li>Магний (Mg): " + CommonFunctions.Round(curRec.CalcProperty.MineralMG));
            if (curRec.CalcProperty.MineralNA != 0)
                curElem.Append("<li>Натрий (Na): " + CommonFunctions.Round(curRec.CalcProperty.MineralNA));
            if (curRec.CalcProperty.MineralP != 0)
                curElem.Append("<li>Фосфор (P): " + CommonFunctions.Round(curRec.CalcProperty.MineralP));
            if (curElem.Length > 0)
            {
                ret.Append("<div>Макроэлементы, мг<ul>");
                ret.Append(curElem);
                ret.Append("</ul></div>");
            }

            // микроэлементы
            curElem = new StringBuilder();
            if (curRec.CalcProperty.MineralFE != 0)
                curElem.Append("<li>Железо (Fe): " + CommonFunctions.Round(curRec.CalcProperty.MineralFE));
            if (curElem.Length > 0)
            {
                ret.Append("<div>Микроэлементы, мкг<ul>");
                ret.Append(curElem);
                ret.Append("</ul></div>");
            }

            // витамины
            curElem = new StringBuilder();
            if (curRec.CalcProperty.vitaminA != 0)
                curElem.Append("<li>Ретинол (А): " + CommonFunctions.Round(curRec.CalcProperty.vitaminA));
            if (curRec.CalcProperty.VitaminB != 0)
                curElem.Append("<li>Бета-каротин (B): " + CommonFunctions.Round(curRec.CalcProperty.VitaminB));
            if (curRec.CalcProperty.VitaminB1 != 0)
                curElem.Append("<li>Тиамин (B1): " + CommonFunctions.Round(curRec.CalcProperty.VitaminB1));
            if (curRec.CalcProperty.VitaminB2 != 0)
                curElem.Append("<li>Рибофлавин (B2): " + CommonFunctions.Round(curRec.CalcProperty.VitaminB2));
            if (curRec.CalcProperty.VitaminC != 0)
                curElem.Append("<li>Аскорбиновая кислота (C): " + CommonFunctions.Round(curRec.CalcProperty.VitaminC));
            if (curRec.CalcProperty.VitaminPP != 0)
                curElem.Append("<li>Ниацин (PP): " + CommonFunctions.Round(curRec.CalcProperty.VitaminPP));
            if (curElem.Length > 0)
            {
                ret.Append("<div>Витамины<ul>");
                ret.Append(curElem);
                ret.Append("</ul></div>");
            }

            if (curRec.MicroBiology != null)
            {
                ret.Append("<p align=justify>" + cc.next() + " Микробиологические показатели:" + "</p>");
                throw new NotImplementedException("Нарисовать табличку с микробиологией");
            }
            ret.Append("<h3>" + cc.moveUp() + " Пищевая и энергетическая ценность</h3>");
            ret.Append("<p><table width=\"100%\"  border><tr><td align=\"center\"><span>Белки</span><td align=\"center\"><span>Жиры</span><td align=\"center\"><span>Углеводы</span><td align=\"center\"><span>Энергетическая ценность, ккал/кДж</span></tr>");
            ret.Append("<tr><td align=\"center\"><span>" + CommonFunctions.Round((Decimal)curRec.CalcProperty.protein) +"</span>"+
                       "<td align=\"center\"><span>" + CommonFunctions.Round((Decimal)curRec.CalcProperty.fat) + "</span>" +
                       "<td align=\"center\"><span>" + CommonFunctions.Round((Decimal)(curRec.CalcProperty.saccharides + curRec.CalcProperty.starch)) + "</span>" +
                       "<td align=\"center\"><span>" + CommonFunctions.Round((Decimal)curRec.CalcProperty.Caloric) + "/" +
                       CommonFunctions.Round((Decimal)curRec.CalcProperty.Caloric * (Decimal)4.184) + "</span>" + "</tr></table></p>");

            ret.Append(makeFooter());

            // автозамены
            ReplaceSymbols(ret);

            return ret.ToString();
        }
        
        /// <summary>
        /// Форматирование текста.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <returns>Билдер с отформатированным текстом.</returns>
        private static StringBuilder TextFormatting(string text)
        {
            StringBuilder ret = new StringBuilder(text);
            
            // расставляем переносы строк
            ret.Replace("\n", "<br>");
            
            // убираем двойные пробелы
            ret.Replace("  ", " ");
            
            return ret;
        }
        
        /// <summary>
        /// Замена символов в тексте кодами HTML.
        /// </summary>
        /// <param name="ret">билдер с текстом</param>
        private static void ReplaceSymbols(StringBuilder ret)
        {
            if (Config.Cfg.ReplaceGrad)
            {
                ret.Replace("%grad", "<sup>o</sup>");
            }
            ret.Replace("---", "-");
            ret.Replace("--", "-");
        }
        
        /// <summary>
        /// Создание технологической карты.
        /// </summary>
        /// <param name="curRec">текущая рецептура</param>
        /// <param name="useOriginal">флаг использования оригинальных данных</param>
        /// <param name="countVals">перечень значений выхода в шт.</param>
        /// <param name="exitVals">перечень значений выхода в гр.</param>
        /// <returns>HTML документ в виде строки</returns>
        internal string PrintTK(DataRecept curRec)
        {
            if ((Config.Cfg.ReportUseCounts == null || Config.Cfg.ReportUseCounts.Count == 0) &&
                (Config.Cfg.ReportUseExits == null || Config.Cfg.ReportUseExits.Count == 0) &&
              !Config.Cfg.ReportIsShowOriginal)
                if (MessageBox.Show("Не указан выход, хотите настроить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                    this.BtnSettingsClick(null, EventArgs.Empty);
            
            StringBuilder ret = new StringBuilder("<html><style>h3{text-align:center;}</style>");
            try {
                curRec.CalcRecept();
                //Hashtable groupRaws = curRec.GroupRaws(true);
            } catch (OverflowException ex)
            {
                ret.Append("<p align=center>Невозможно сосчитать рецептуру: " + ex.Message + ". Проверьте правильность заполнения</p></html>");
                return ret.ToString();
            }

            // шапка
            ret.Append(makeHeader(false, true));
            ret.Append("<p align=center><b><font size=4>ТЕХНОЛОГИЧЕСКАЯ КАРТА № " + curRec.Id.ToString(CultureInfo.CurrentCulture) +
                       "</font><br><font size=5> на " + curRec.Name + "</font></b>");
            if (!String.IsNullOrEmpty(curRec.normativDoc))
            {
                ret.Append("<br>Изготовлено по " + curRec.normativDoc);
            }
            ret.Append("</p>");
            
            if (!String.IsNullOrEmpty(curRec.preview))
            {
                ret.Append("<h3>Описание изделия</h3><p>" + TextFormatting(curRec.preview) + "</p>");
            }
            
            ret.Append("<h3>Рецептура</h3>");
            
            // Шапка
            ret.Append("<table width=\"100%\" border><thead align=center><td> Наименование сырья");
            int cols = 1;
            if (Config.Cfg.ReportIsShowOriginal)
            {
                ret.Append("<td>" + curRec.TotalExit + " г./" + curRec.CountExit + " шт.");
                cols++;
            }

            for (int i = 0; i < Config.Cfg.ReportUseCounts.Count; i++)
            {
                ret.Append("<td>" + Config.Cfg.ReportUseCounts[i] + " шт.");
                cols++;
            }
            
            for (int i = 0; i < Config.Cfg.ReportUseExits.Count; i++)
            {
                ret.Append("<td>" + Config.Cfg.ReportUseExits[i] + " г.");
                cols++;
            }
            
            ret.Append("</thead>");
            
            // тело
            PrintReceptBody(ret, curRec, cols);
            
            ret.Append("</table>");
            
            ret.Append("<h3>Технология приготовления</h3><p>" + TextFormatting(curRec.process) + "</p>");
            
            StringBuilder curElem = makeReceptProperty(curRec);
            if (curElem.Length > 0)
            {
                ret.Append("<h3>Характеристика изделия</h3>");
                ret.Append("<p>" + curElem + "</p>");
            }
            
            ret.Append(makeFooter());

            // автозамены
            ReplaceSymbols(ret);

            return ret.ToString();
        }
        
        private void PrintReceptBody(StringBuilder ret, DataRecept rec, int cols)
        {
            foreach(DataBase curRaw in rec.Components)
            {
                if (curRaw is DataRecept)
                {
                    ret.Append("<tr><td colspan=" + cols + " align=\"center\">" + curRaw.Name + "</tr>");
                    PrintReceptBody(ret, (DataRecept)curRaw, cols);
                    //ret.Append("<tr><td> Итого:</tr>");
                    continue;
                }
                DataRaw craw = (DataRaw)curRaw;
                ret.Append("<tr><td>" + craw.Name);
                if (!String.IsNullOrEmpty(craw.Comment))
                    ret.Append(" (" + craw.Comment + ")");
                if (Config.Cfg.ReportIsShowOriginal)
                {
                    ret.Append("<td>" + Math.Round(craw.Brutto, Config.Cfg.Precision));
                    if (craw.Brutto != craw.Quantity)
                        ret.Append(" / " + Math.Round(craw.Quantity, Config.Cfg.Precision));
                }

                for (int i = 0; i < Config.Cfg.ReportUseCounts.Count; i++)
                {
                    ret.Append("<td>" + Math.Round(craw.Brutto/rec.CountExit * Config.Cfg.ReportUseCounts[i], Config.Cfg.Precision));
                    if (craw.Brutto != craw.Quantity)
                        ret.Append(" / " +
                                   Math.Round(craw.Quantity/rec.CountExit * Config.Cfg.ReportUseCounts[i], Config.Cfg.Precision));
                }
                
                for (int i = 0; i < Config.Cfg.ReportUseExits.Count; i++)
                {
                    ret.Append("<td>" + Math.Round(craw.Brutto/rec.CalcExitNetto * Config.Cfg.ReportUseExits[i], Config.Cfg.Precision));
                    if (craw.Brutto != craw.Quantity)
                        ret.Append(" / " +
                                   Math.Round(craw.Quantity/rec.CalcExitNetto * Config.Cfg.ReportUseExits[i], Config.Cfg.Precision));
                }
                ret.Append("</tr>");
            }
        }

        /// <summary>
        /// Печать списка рецептур.
        /// </summary>
        /// <returns>HTML документ в виде строки.</returns>
        internal static string PrintBookList()
        {
            FormCounter cc = new FormCounter();
            StringBuilder ret = new StringBuilder("<html><style>h3{text-align:center;}</style>");

            // шапка
            ret.Append(makeHeader(false, true));
            ret.Append("<p align=center><b><font size=4>ПЕРЕЧЕНЬ ТЕХНИКО-ТЕХНОЛОГИЧЕСКИХ КАРТ</font></b>");
            ret.Append("</p><p>");

            foreach (DataRecept curRec in DataBook.Book.Components)
            {
                ret.Append("<p>" + cc.moveUp() + " " + curRec.Name+"</p>");
            }

            ret.Append(makeFooter());

            // автозамены
            ReplaceSymbols(ret);

            return ret.ToString();
        }
        
        #region Обработка кнопок панели
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|" +
                "Документ OpenOffice (*.odt)|*.odt|" +
                "Текстовый документ (*.txt)|*.txt|" +
                "Документ HTML (*.html)|*html";
            dlg.DefaultExt = Config.Cfg.ExportFileType;
            switch(dlg.DefaultExt)
            {
                case "rtf":
                    dlg.FilterIndex = 1;
                    break;
                case "odt":
                    dlg.FilterIndex = 2;
                    break;
                case "txt":
                    dlg.FilterIndex = 3;
                    break;
                case "html":
                    dlg.FilterIndex = 4;
                    break;
            }
            dlg.FileName = myName + "." + Config.Cfg.ExportFileType;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Config.Cfg.ExportFileType = Path.GetExtension(dlg.FileName).Trim('.');
                    bool usePanDoc = true;
                    if (Config.Cfg.ExportFileType.Equals("html"))
                        usePanDoc = false;
                    if (CommonFunctions.SaveToFile(dlg.FileName, myDoc, usePanDoc))
                        MessageBox.Show("Сохранение выполнено успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0);
                    else
                        MessageBox.Show("Сохранение не удалось", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                    #if (DEBUG)
                    MessageBox.Show(ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                    #endif
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
        
        private void BtnReloadClick(object sender, EventArgs e)
        {
            SetData();
        }
        
        void BtnSettingsClick(object sender, EventArgs e)
        {
            FormConfig frm = new FormConfig();
            frm.ShowDialog();
            this.BtnReloadClick(sender, e);
        }
        #endregion
    }
}