// <copyright file="SortableBindingList.cs" company="SeekerSoft">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>$Author$</author>
// <email>seeker.k@gmail.com</email>
// <date>$LastChangedDate$</date>
// <summary>Содержит описание события обновления БД.</summary>

namespace Recept2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.XPath;

    public class SortableBindingList<T>: BindingList<DataBase>
    {
        public void Sort(IComparer<DataBase> cmp)
        {
            (Items as List<DataBase>).Sort(cmp);
        }
        
        public void AddRange(ICollection<DataBase> collect)
        {
            foreach(DataBase db in collect)
            {
                this.Add(db);
            }
        }
        
        public object[] ToArray()
        {
            DataBase[] arr = new DataBase[this.Count];
            this.CopyTo(arr, 0);
            return arr as object[];
        }
        
    }
}