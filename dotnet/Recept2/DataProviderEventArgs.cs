// <copyright file="DataProviderEventArgs.cs" company="SeekerSoft">
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
    using System.Data;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Параметры события изменения бд.
    /// </summary>
    public class DataProviderEventArgs : EventArgs
    {
        /// <summary>
        /// Флаг изменения данных о общих потерях.
        /// </summary>
        private bool myTotalLossChanged;

        /// <summary>
        /// Флаг изменения данных о общих потерях.
        /// </summary>
        /// <value>Истина если данные об общих потерях изменены.</value>
        public bool TotalLossChanged
        {
            get {return this.myTotalLossChanged;}
            set {this.myTotalLossChanged = value;}
        }
        
        /// <summary>
        /// Флаг изменения данных о потерях при обработке.
        /// </summary>
        private bool myProcessLossChanged;
        
        /// <summary>
        /// Флаг изменения данных о потерях при обработке.
        /// </summary>
        public bool ProcessLossChanged
        {
            get {return myProcessLossChanged;}
            set {myProcessLossChanged = value;}
        }
        
        /// <summary>
        /// Флаг изменения данных о сырье.
        /// </summary>
        private bool myRawChanged;

        /// <summary>
        /// Флаг изменения данных о сырье.
        /// </summary>
        public bool RawChanged
        {
            get {return myRawChanged;}
            set {myRawChanged = value;}
        }
        
        /// <summary>
        /// Флаг изменения данных о микробиологии.
        /// </summary>
        private bool myMicroBiologyChanged;

        /// <summary>
        /// Флаг изменения данных о микробиологии.
        /// </summary>
        public bool MicroBiologyChanged
        {
            get {return this.myMicroBiologyChanged;}
            set {this.myMicroBiologyChanged = value;}
        }
        
        /// <summary>
        /// Флаг изменения данных о микробиологии.
        /// </summary>
        private bool myMicroBiologyIndicatorChanged;

        /// <summary>
        /// Флаг изменения данных о микробиологии.
        /// </summary>
        public bool MicroBiologyIndicatorChanged
        {
            get {return this.myMicroBiologyIndicatorChanged;}
            set {this.myMicroBiologyIndicatorChanged = value;}
        }
        
        public DataProviderEventArgs()
        {
        }
        
        public DataProviderEventArgs(DataBaseType currentType)
        {
            myTotalLossChanged = (currentType == DataBaseType.TotalLossType ? true : false);
            myRawChanged = (currentType == DataBaseType.RawType ? true : false);
            myProcessLossChanged = (currentType == DataBaseType.ProcessLossType ? true : false);
            this.myMicroBiologyChanged = (currentType == DataBaseType.MicroBiologyType ? true : false);
            this.myMicroBiologyIndicatorChanged = (currentType == DataBaseType.MicroBiologyIndicatorType ? true : false);
        }
    }
}
