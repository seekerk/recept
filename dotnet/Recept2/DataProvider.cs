// <copyright file="DataProvider.cs" company="SeekerSoft">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>$Author$</author>
// <email>seeker.k@gmail.com</email>
// <date>$LastChangedDate$</date>
// <summary>Содержит описание класса работы с БД.</summary>

namespace Recept2
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Windows.Forms;
	using System.Xml;

	public struct RecordProperty
	{
		public string Name;

		public object UsedValue;

		public TypeCode ObjectType;
	}

	/// <summary>
	/// Интерфейс с базой данных
	/// </summary>
	public abstract class DataProvider
	{
		#region хеши таблиц
		private Hashtable myTotalLossHash;
		protected Hashtable TotalLossHash {
			get {
				if (myTotalLossHash == null) {
					myTotalLossHash = new Hashtable ();
					foreach (DataTotalLoss curdp in TotalLossList) {
						myTotalLossHash.Add (curdp.Id, curdp);
					}
				}
				
				return myTotalLossHash;
			}
		}

		private SortableBindingList<DataTotalLoss> myTotalLossList;
		public SortableBindingList<DataTotalLoss> TotalLossList {
			get {
				if (myTotalLossList == null)
					myTotalLossList = LoadTotalLossList ();
				return myTotalLossList;
			}
		}

		private Hashtable myRawHash;
		protected Hashtable RawHash {
			get {
				if (myRawHash == null) {
					myRawHash = new Hashtable ();
					foreach (DataRawStruct dr in RawList) {
						myRawHash.Add (dr.Id, dr);
					}
				}
				return myRawHash;
			}
		}

		private SortableBindingList<DataRawStruct> myRawList;
		public SortableBindingList<DataRawStruct> RawList {
			get {
				if (myRawList == null) {
					myRawList = LoadDataRawList ("comps");
				}
				return myRawList;
			}
		}
		//set {m_rawList = value;}

		private Hashtable myProcessLossHash;
		protected Hashtable ProcessLossHash {
			get {
				if (myProcessLossHash == null) {
					myProcessLossHash = new Hashtable ();
					foreach (DataRawStruct dr in ProcessLossList) {
						myProcessLossHash.Add (dr.Id, dr);
					}
				}
				return myProcessLossHash;
			}
		}

		private SortableBindingList<DataRawStruct> myProcessLossList;
		public SortableBindingList<DataRawStruct> ProcessLossList {
			get {
				if (myProcessLossList == null)
					myProcessLossList = LoadDataRawList ("processLoss");
				return myProcessLossList;
			}
		}
		//set {m_processLossList = value;}

		/// <summary>
		/// Хеш-таблица для микробиологии.
		/// </summary>
		private Hashtable myMicroBiologyHash;

		/// <summary>
		/// Хеш-таблица для микробиологии.
		/// </summary>
		protected Hashtable MicroBiologyHash {
			get {
				if (this.myMicroBiologyHash == null) {
					this.myMicroBiologyHash = new Hashtable ();
					foreach (DataMicroBiology dr in this.MicroBiologyList) {
						this.myMicroBiologyHash.Add (dr.Id, dr);
					}
				}
				return this.myMicroBiologyHash;
			}
		}

		/// <summary>
		/// Список микробиологий.
		/// </summary>
		private SortableBindingList<DataMicroBiology> myMicroBiologyList;

		/// <summary>
		/// Список микробиологий.
		/// </summary>
		public SortableBindingList<DataMicroBiology> MicroBiologyList {
			get {
				if (this.myMicroBiologyList == null)
					this.myMicroBiologyList = LoadMicroBiologyList (DataProvider.MicroBiologyTable);
				return this.myMicroBiologyList;
			}
		}
		//set {m_processLossList = value;}

		/// <summary>
		/// Хеш-таблица для показателей микробиологии.
		/// </summary>
		private Hashtable myMicroBiologyIndicatorHash;

		/// <summary>
		/// Хеш-таблица для микробиологии.
		/// </summary>
		protected Hashtable MicroBiologyIndicatorHash {
			get {
				if (this.myMicroBiologyIndicatorHash == null) {
					this.myMicroBiologyIndicatorHash = new Hashtable ();
					foreach (DataMicroBiologyIndicator dr in this.MicroBiologyIndicatorList) {
						this.myMicroBiologyIndicatorHash.Add (dr.Id, dr);
					}
				}
				return this.myMicroBiologyIndicatorHash;
			}
		}

		/// <summary>
		/// Список микробиологий.
		/// </summary>
		private SortableBindingList<DataMicroBiologyIndicator> myMicroBiologyIndicatorList;

		/// <summary>
		/// Список микробиологий.
		/// </summary>
		public SortableBindingList<DataMicroBiologyIndicator> MicroBiologyIndicatorList {
			get {
				if (this.myMicroBiologyIndicatorList == null)
					this.myMicroBiologyIndicatorList = LoadMicroBiologyIndicatorList (DataProvider.MicroBiologyIndicatorTable);
				return this.myMicroBiologyIndicatorList;
			}
		}
		//set {m_processLossList = value;}
		#endregion

		/// <summary>
		/// Флаг режима работы провайдера (по умолчанию доступа к БД нет).
		/// </summary>
		public static bool IsReadOnly = true;

		public static string DataTotalLossTable = "totalLoss";

		public static string DataRawTable = "comps";

		public static string ProcessLossTable = "processLoss";

		public static string MicroBiologyTable = "microBiology";

		public static string MicroBiologyIndicatorTable = "mbIndicator";

		#region Событие изменения данных (модификация бд и т.п.)
		/// <summary>
		/// Событие изменения данных таблицы.
		/// </summary>
		public event EventHandler<DataProviderEventArgs> Changed;

		/// <summary>
		/// Параметр события изменения данных.
		/// </summary>
		protected DataProviderEventArgs evargs = new DataProviderEventArgs ();

		protected virtual void OnChanged (DataProviderEventArgs args)
		{
			if (args.ProcessLossChanged) {
				myProcessLossList = null;
				myProcessLossHash = null;
			}
			if (args.RawChanged) {
				myRawHash = null;
				myRawList = null;
			}
			if (args.TotalLossChanged) {
				myTotalLossList = null;
				myTotalLossHash = null;
			}
			if (Changed != null) {
				Changed (this, args);
			}
		}

		protected void SendTotalLossChanged ()
		{
			evargs.TotalLossChanged = true;
			evargs.RawChanged = false;
			evargs.ProcessLossChanged = false;
			evargs.MicroBiologyChanged = false;
			OnChanged (evargs);
			//throw new Exception("The method or operation is not implemented.");
		}

		protected void SendRawChanged ()
		{
			evargs.RawChanged = true;
			evargs.TotalLossChanged = false;
			evargs.ProcessLossChanged = false;
			evargs.MicroBiologyChanged = false;
			OnChanged (evargs);
		}

		protected void SendProcessLossChanged ()
		{
			evargs.RawChanged = false;
			evargs.TotalLossChanged = false;
			evargs.ProcessLossChanged = true;
			evargs.MicroBiologyChanged = false;
			OnChanged (evargs);
		}

		protected void SendMicroBiologyChanged ()
		{
			evargs.RawChanged = false;
			evargs.TotalLossChanged = false;
			evargs.ProcessLossChanged = false;
			evargs.MicroBiologyChanged = true;
			OnChanged (evargs);
		}

		/// <summary>
		/// Изменение настроек проги
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void cfg_Changed (object sender, EventArgs e)
		{
			Config.Cfg.Changed -= new EventHandler (cfg_Changed);
			Config.Cfg.Changed += new EventHandler (cfg_Changed);
			evargs.TotalLossChanged = true;
			myTotalLossHash = null;
			myTotalLossList = null;
			evargs.ProcessLossChanged = true;
			myProcessLossHash = null;
			myProcessLossList = null;
			evargs.RawChanged = true;
			myRawHash = null;
			myRawList = null;
			OnChanged (evargs);
		}

		internal void Update ()
		{
			evargs.TotalLossChanged = true;
			evargs.RawChanged = true;
			evargs.ProcessLossChanged = true;
			OnChanged (evargs);
			//throw new Exception("The method or operation is not implemented.");
		}
		#endregion

		#region Конструктор класса
		protected DataProvider ()
		{
			Config.Cfg.Changed += new EventHandler (cfg_Changed);
			this.TestDataBase ();
		}

		internal abstract void TestDataBase ();
		#endregion

		#region Методы удаления записей из БД
		protected abstract void DeleteRecord (DataBase curRec, string tableName);

		internal void DeleteRaw (DataRawStruct curRec)
		{
			DeleteRecord (curRec, DataProvider.DataRawTable);
			SendRawChanged ();
		}

		internal void DeleteProcessLoss (DataRawStruct curRec)
		{
			DeleteRecord (curRec, DataProvider.ProcessLossTable);
			SendProcessLossChanged ();
		}

		internal void DeleteTotalLoss (DataTotalLoss curRec)
		{
			DeleteRecord (curRec, DataProvider.DataTotalLossTable);
			SendTotalLossChanged ();
		}

		internal void DeleteMicroBiology (DataTotalLoss curRec)
		{
			DeleteRecord (curRec, DataProvider.MicroBiologyTable);
			SendMicroBiologyChanged ();
		}
		#endregion

		#region интерфейс к БД для работы с элементами DataTotalLoss
		protected abstract SortableBindingList<DataTotalLoss> LoadTotalLossList ();

		internal abstract void AddTotalLossStruct (DataTotalLoss curRec);

		internal abstract void UpdateTotalLossStruct (DataTotalLoss curRec);

		internal abstract DataTotalLoss FindTotalLoss (DataTotalLoss curRec);

		internal abstract DataTotalLoss FindSimilarTotalLoss (DataTotalLoss curRec);
		#endregion

		#region методы работы с элементами DataTotalLoss

		/// <summary>
		/// получение потери по номеру
		/// </summary>
		/// <param name="p">номер id</param>
		/// <returns>структура потери</returns>
		internal DataTotalLoss GetTotalLoss (int p)
		{
			return (DataTotalLoss)TotalLossHash[p];
			//throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// Получение порядкового номера потери по списку.
		/// </summary>
		/// <param name="totalLoss">Структура потерь.</param>
		/// <returns>Порядковый номер.</returns>
		internal int GetTotalLossNum (DataTotalLoss totalLoss)
		{
			for (int i = 0; i < TotalLossList.Count; i++) {
				if (TotalLossList[i].Id == totalLoss.Id) {
					return i;
				}
			}
			return -1;
		}
		#endregion

		//////////////////////////////////////////////////////////////////////////

		#region интерфейс к БД для работы с элементами DataRawStruct
		protected abstract SortableBindingList<DataRawStruct> LoadDataRawList (string tableName);

		protected abstract void AddDataRawStruct (DataRawStruct curRec, string tableName);

		protected abstract void UpdateDataRawStruct (DataRawStruct curRec, string tableName);

		/// <summary>
		/// Поиск записи о компоненте пользователя в БД
		/// </summary>
		/// <param name="curRaw">компонента пользователя</param>
		/// <returns>найденная запись если есть</returns>
		protected abstract int FindDataRawStruct (DataRawStruct curRec, string tableName);

		/// <summary>
		/// Поиск записи о компоненте пользователя в БД
		/// </summary>
		/// <param name="curRaw">компонента пользователя</param>
		/// <returns>найденная запись если есть</returns>
		protected abstract int FindSimilarDataRawStruct (DataRawStruct curRec, string tableName);
		#endregion

		#region методы работы с элементами DataRawStruct
//		internal DataRawStruct[] GetRawList()
//		{
//			if (RawList == null)
//			{
//				RawList = GetDataRawList("comps");
//			}
//
//			return RawList;
//		}

//		internal DataRawStruct[] GetProcessLossList()
//		{
//			if (ProcessLossList != null)
//			{
//				return ProcessLossList;
//			}
//
//			ProcessLossList = GetDataRawList("processLoss");
//			return ProcessLossList;
//		}

		/// <summary>
		/// получение компоненты по номеру
		/// </summary>
		/// <param name="p">номер id</param>
		/// <returns>структура компоненты</returns>
		internal DataRawStruct GetRawByNum (int p)
		{
			return (DataRawStruct)RawHash[p];
		}

		internal DataRawStruct GetProcessLossByNum (int p)
		{
			return (DataRawStruct)ProcessLossHash[p];
		}

		/// <summary>
		/// Получение порядкового номера по списку компонент
		/// </summary>
		/// <param name="dataRawStruct">структура компоненты</param>
		/// <returns>порядковый номер</returns>
		internal int GetRawNum (DataRawStruct dataRawStruct)
		{
			for (int i = 0; i < RawList.Count; i++) {
				if ((RawList[i] as DataRawStruct).Id == dataRawStruct.Id) {
					return i;
				}
			}
			return -1;
			//throw new Exception("The method or operation is not implemented.");
		}

		internal void AddRaw (DataRawStruct curRec)
		{
			AddDataRawStruct (curRec, "comps");
			SendRawChanged ();
		}

		internal void AddProcessLoss (DataRawStruct curRec)
		{
			AddDataRawStruct (curRec, "processLoss");
			SendProcessLossChanged ();
		}

		internal void UpdateRaw (DataRawStruct curRec)
		{
			UpdateDataRawStruct (curRec, "comps");
			SendRawChanged ();
		}

		internal void UpdateProcessLoss (DataRawStruct curRec)
		{
			UpdateDataRawStruct (curRec, "processLoss");
			SendProcessLossChanged ();
		}

		/// <summary>
		/// Поиск записи о компоненте пользователя в БД
		/// </summary>
		/// <param name="curRaw">компонента пользователя</param>
		/// <returns>найденная запись если есть</returns>
		internal DataRawStruct FindRaw (DataRawStruct curRec)
		{
			if (curRec == null) {
				return null;
			}
			// шаг 1. Берем компоненту с таким ID
			DataRawStruct ret = this.GetRawByNum (curRec.Id);
			if (ret != null && curRec.EqualVal (ret)) {
				return ret;
			}
			
			// шаг 2. Ищем такую компоненту в БД без учета ID
			return this.GetRawByNum (FindDataRawStruct (curRec, "comps"));
		}

		internal DataRawStruct FindProcessLoss (DataRawStruct curRec)
		{
			if (curRec == null) {
				return null;
			}
			// шаг 1. Берем компоненту с таким ID
			DataRawStruct ret = this.GetProcessLossByNum (curRec.Id);
			if (ret != null && curRec.EqualVal (ret)) {
				return ret;
			}
			
			// шаг 2. Ищем такую компоненту в БД без учета ID
			return this.GetProcessLossByNum (FindDataRawStruct (curRec, "processLoss"));
		}

		internal DataRawStruct FindSimilarRaw (DataRawStruct curRec)
		{
			if (curRec == null) {
				return null;
			}
			return this.GetRawByNum (FindSimilarDataRawStruct (curRec, "comps"));
		}

		internal DataRawStruct FindSimilarProcessLoss (DataRawStruct curRec)
		{
			if (curRec == null) {
				return null;
			}
			return this.GetProcessLossByNum (FindSimilarDataRawStruct (curRec, "processLoss"));
		}
		#endregion
		
		#region методы работы с Микробиологией
		protected SortableBindingList<DataMicroBiology> LoadMicroBiologyList (string tableName)
		{
			throw new NotImplementedException();
		}
		
		protected SortableBindingList<DataMicroBiologyIndicator> LoadMicroBiologyIndicatorList (string tableName)
		{
			throw new NotImplementedException();
		}
		
		internal void UpdateMicroBiologyStruct(DataMicroBiology curRec)
		{
			throw new NotImplementedException();
		}
		
		internal void UpdateMicroBiologyIndicatorStruct(DataMicroBiologyIndicator curRec)
		{
			throw new NotImplementedException();
		}
		
		internal void AddMicroBiologyStruct(DataMicroBiology curRec)
		{
			throw new NotImplementedException();
		}
		
		internal void AddMicroBiologyIndicatorStruct(DataMicroBiologyIndicator curRec)
		{
			throw new NotImplementedException();
		}
		
		internal DataMicroBiology FindMicroBiology(DataMicroBiology curRec)
		{
			throw new NotImplementedException();
		}
		
		internal DataMicroBiology FindMicroBiologyIndicator(DataMicroBiologyIndicator curRec)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
