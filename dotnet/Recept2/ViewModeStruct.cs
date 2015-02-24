// <copyright file="VieModeStruct.cs" company="SeekerSoft">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Kirill Kulakov</author>
// <email>seeker.k@gmail.com</email>
// <date>2008-05-24</date>
// <summary>Описание структуры хранения вариантов отображения панелей</summary>

namespace Recept2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Globalization;
    using System.Text;
    using System.Windows;
    using System.Windows.Forms;
    /// <summary>
    /// Класс-структура хранения отображения панелей
    /// </summary>
    public struct ViewModeStruct
    {
        /// <summary>
        /// Режим просмотра
        /// </summary>
        private ViewMode mode;
        
        /// <summary>
        /// Название режима в списке
        /// </summary>
        private string name;
        
        /// <summary>
        /// Заполнение полей структуры
        /// </summary>
        /// <param name="nmode">Режим просмотра</param>
        /// <param name="nname">Название режима</param>
        public ViewModeStruct(ViewMode nmode, string nname)
        {
            this.mode = nmode;
            this.name = nname;
        }
        
        /// <summary>
        /// Gets ключ элемента списка
        /// </summary>
        public string ModeKey
        {
            get { return this.name; }
        }
        
        /// <summary>
        /// Gets то, что возвращается после выбора из списка
        /// </summary>
        public ViewMode ModeValue
        {
            get { return this.mode; }
        }
        
        /// <summary>
        /// Получение списка элементов для книги
        /// </summary>
        /// <returns>Массив экземпляров ViewModeStruct</returns>
        public static object[] GetListBook()
        {
            ArrayList ret = new ArrayList();
            ret.Add(new ViewModeStruct(ViewMode.BookCommon, "Общие сведения"));
            return ret.ToArray();
        }
        
        /// <summary>
        /// Получение списка элементов для рецептуры
        /// </summary>
        /// <returns>Массив экземпляров ViewModeStruct</returns>
        public static object[] GetListRecept()
        {
            ArrayList ret = new ArrayList();
            ret.Add(new ViewModeStruct(ViewMode.ReceptCommon, "Состав"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptProcess, "Описание процесса"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptView, "Внешний вид"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptColor, "Цвет изделия"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptConsistence, "Консистенция"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptTaste, "Вкус и запах"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptDesign, "Оформление"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptDelivery, "Подача"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptSale, "Реализация"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptStorage, "Хранение"));
            ret.Add(new ViewModeStruct(ViewMode.ReceptFactors, "Показатели м/б"));
            return ret.ToArray();
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ViewModeStruct))
                return false;
            
            return Equals((ViewModeStruct)obj);
        }
        
        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.mode.GetHashCode();
        }
        
        public bool Equals(ViewModeStruct str)
        {
            return this.name.Equals(str.name) && this.mode.Equals(str.mode);
        }
        
        public static bool operator == (ViewModeStruct str1, ViewModeStruct str2)
        {
            return str1.Equals(str2);
        }
        
        public static bool operator != (ViewModeStruct str1, ViewModeStruct str2)
        {
            return !str1.Equals(str2);
        }
        
    }
}
