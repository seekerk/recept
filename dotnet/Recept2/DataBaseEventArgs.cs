// <copyright file="DataBaseEventArgs.cs" company="SeekerSoft">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>$Author$</author>
// <email>seeker.k@gmail.com</email>
// <date>$LastChangedDate$</date>
// <summary>Содержит описание события обновления данных.</summary>

namespace Recept2
{
    using System;

    //    public delegate void ChangedEventHandler(object sender, DataBaseEventArgs args);
    
    /// <summary>
    /// Класс содержащий информацию о событии обновления данных.
    /// </summary>
    public class DataBaseEventArgs : EventArgs
    {
        /// <summary>
        /// Флаг изменения основных данных.
        /// </summary>
        private bool mainDataChanged = false;
        
        /// <summary>
        /// Флаг изменения основных данных.
        /// </summary>
        public bool IsMainDataChanged
        {
            get
            {
                return mainDataChanged;
            }
        }
        
        /// <summary>
        /// Флаг изменения основных данных.
        /// </summary>
        private bool otherDataChanged = false;
        
        /// <summary>
        /// Флаг изменения основных данных.
        /// </summary>
        public bool IsOtherDataChanged
        {
            get
            {
                return otherDataChanged;
            }
        }
        
        public DataBaseEventArgs(bool changeMainData, bool changeOtherData)
        {
            mainDataChanged = changeMainData;
            otherDataChanged = changeOtherData;
        }
    }
}
