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
    /// Варианты сортировок.
    /// </summary>
    public enum SortOptions {
        /// <summary>
        /// Сортировать по номеру.
        /// </summary>
        SortNum,
        
        /// <summary>
        /// Сортировать по названию по возрастанию.
        /// </summary>
        SortAsc,
        
        /// <summary>
        /// Сортировать по названию по убыванию.
        /// </summary>
        SortDesc
    }

    /// <summary>
    /// Описание методов сортировки элементов типа DataBase.
    /// </summary>
    public class DataBaseComparer : IComparer<DataBase>
    {
        private SortOptions mySortOption = SortOptions.SortNum;
        
        public DataBaseComparer()
        {
            
        }
        
        public DataBaseComparer(SortOptions opt)
        {
            mySortOption = opt;
        }
        
        //int IComparer.Compare(object x, object y)
        public int Compare(DataBase x, DataBase y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                return -1;
            }else{
                if (y == null)
                {
                    return 1;
                }
            }
            
            DataBase nx = x; // as DataBase;
            DataBase ny = y; // as DataBase;
            
            switch(mySortOption){
                case SortOptions.SortNum:
                    if (nx.Id == 0 && ny.Id != 0)
                        return -1;
                    if (nx.Id != 0 && ny.Id == 0)
                        return 1;
                    
                    return nx.Id.CompareTo(ny.Id);
                case SortOptions.SortAsc:
                    return string.Compare(nx.Name, ny.Name, StringComparison.CurrentCultureIgnoreCase);
                case SortOptions.SortDesc:
                    return string.Compare(ny.Name, nx.Name, StringComparison.CurrentCultureIgnoreCase);
                default:
                    throw new NotImplementedException("Неизвестный тип сравнения");
            }
        }
    }
}
