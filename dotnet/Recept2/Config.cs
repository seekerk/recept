using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Recept2
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using System.Security;
	using System.Security.AccessControl;
	using System.Text;
	using System.Windows.Forms;
	using System.Xml;
	using Microsoft.Win32;

	/// <summary>
	/// Настройки конфигурации программы.
	/// </summary>
	public class Config : ICloneable
	{
		/// <summary>
		/// Шаблон книги рецептур для создания новой книги.
		/// </summary>
		private string myDefaultFile = "default.rcp2";

		/// <summary>
		/// Шаблон книги рецептур для создания новой книги.
		/// </summary>
		/// <value>Имя файла шаблона книги рецептур.</value>
		public string DefaultFile {
			get { return this.myDefaultFile; }

			set {
				if (!this.myDefaultFile.Equals (value)) {
					this.myDefaultFile = value;
					this.OnChanged ();
				}
			}
		}

		private Collection<string> myLastOpenPaths;

		public Collection<string> LastOpenPaths {
			get {
				if (this.myLastOpenPaths == null)
					this.myLastOpenPaths = new Collection<string> ();
				return this.myLastOpenPaths;
			}
		}

		/// <summary>
		/// Объем расчетного выхода.
		/// </summary>
		private decimal myTotalExit = 1000;

		/// <summary>
		/// Объем расчетного выхода.
		/// </summary>
		public decimal TotalExit {
			get { return this.myTotalExit; }

			set {
				if (!this.myTotalExit.Equals (value)) {
					this.myTotalExit = value;
					this.OnChanged ();
				}
			}
		}

		/// <summary>
		/// Точность отображения чисел с плавающей точкой.
		/// </summary>
		private int myPrecision = 2;

		/// <summary>
		/// Точность отображения чисел с плавающей точкой.
		/// </summary>
		public int Precision {
			get { return this.myPrecision; }

			set {
				if (!this.myPrecision.Equals (value)) {
					this.myPrecision = value;
					this.OnChanged ();
				}
			}
		}

		/// <summary>
		/// Заменять %grad символом градуса.
		/// </summary>
		private bool myReplaceGrad = true;

		/// <summary>
		/// Заменять %grad символом градуса.
		/// </summary>
		public bool ReplaceGrad {
			get { return this.myReplaceGrad; }

			set {
				if (!this.myReplaceGrad.Equals (value)) {
					this.myReplaceGrad = value;
					this.OnChanged ();
				}
			}
		}

		/// <summary>
		/// Строка запуска программы pandoc для конвертирования текстов.
		/// </summary>
		private string myPandoc = "pandoc";

		/// <summary>
		/// Строка запуска программы pandoc для конвертирования текстов.
		/// </summary>
		public string Pandoc {
			get { return this.myPandoc; }

			set {
				if (!this.myPandoc.Equals (value)) {
					this.myPandoc = value;
					this.OnChanged ();
				}
			}
		}

		/// <summary>
		/// Формат экспортируемого файла.
		/// </summary>
		private string myExportFileType = "html";

		/// <summary>
		/// Формат экспортируемого файла.
		/// </summary>
		public string ExportFileType {
			get { return this.myExportFileType; }

			set {
				if (!this.myExportFileType.Equals (value)) {
					this.myExportFileType = value;
					this.OnChanged ();
				}
			}
		}

		private int myWaterId;

		public int WaterId {
			get { return this.myWaterId; }

			set {
				if (!this.myWaterId.Equals (value)) {
					this.myWaterId = value;
					this.OnChanged ();
				}
			}
		}

		/// <summary>
		/// Показывать оригинальную рецептуру в отчете.
		/// </summary>
		private bool myReportIsShowOriginal;

		/// <summary>
		/// Показывать оригинальную рецептуру в отчете.
		/// </summary>
		public bool ReportIsShowOriginal {
			get { return this.myReportIsShowOriginal; }

			set {
				if (!this.myReportIsShowOriginal.Equals (value)) {
					this.myReportIsShowOriginal = value;
					this.OnChanged ();
				}
			}
		}

		private BindingList<decimal> myReportUseExits;

		public BindingList<decimal> ReportUseExits {
			get {
				if (this.myReportUseExits == null) {
					this.myReportUseExits = new BindingList<decimal> ();
					this.myReportUseExits.ListChanged += new ListChangedEventHandler (Config_ListChanged);
				}
				return this.myReportUseExits;
			}
		}

		void Config_ListChanged (object sender, ListChangedEventArgs e)
		{
			this.OnChanged ();
		}

		/// <summary>
		/// Используемые в отчете величины в шт.
		/// </summary>
		private BindingList<decimal> myReportUseCounts;

		/// <summary>
		/// Используемые в отчете величины в шт.
		/// </summary>
		public BindingList<decimal> ReportUseCounts {
			get {
				if (this.myReportUseCounts == null) {
					this.myReportUseCounts = new BindingList<decimal> ();
					this.myReportUseCounts.ListChanged += new ListChangedEventHandler (Config_ListChanged);
				}
				return this.myReportUseCounts;
			}
		}

		/// <summary>
		/// Отображать настройку формирования отчета перед каждым вызовом или нет.
		/// </summary>
		private bool myReportShowConfig;
		//TODO: сделать загрузку/сохранение

		/// <summary>
		/// Отображать настройку формирования отчета перед каждым вызовом или нет.
		/// </summary>
		public bool ReportShowConfig {
			get { return myReportShowConfig; }

			set {
				if (!this.myReportShowConfig.Equals (value)) {
					this.myReportShowConfig = value;
					this.OnChanged ();
				}
			}
		}

		#region Настройки БД
		/// <summary>
		/// база данных с компонентами.
		/// </summary>
		private string myDbFile = "components.mdb";

		/// <summary>
		/// база данных с компонентами.
		/// </summary>
		public String DBFile {
			get { return myDbFile; }
			set {
				myDbFile = value;
				OnChanged ();
			}
		}

		/// <summary>
		/// тип БД (true = SQlite, false = MS Access (по умолч)).
		/// </summary>
		private bool myIsSQliteData;

		/// <summary>
		/// тип БД (true = SQlite, false = MS Access (по умолч)).
		/// </summary>
		public bool IsSQliteData {
			get { return myIsSQliteData; }
			set {
				myIsSQliteData = value;
				OnChanged ();
			}
		}


		private static DataProvider pDP;
		/// <summary>
		/// интерфейс базы данных.
		/// </summary>
		public static DataProvider DP {
			get {
				if (pDP == null) {
					if (Config.Cfg.IsSQliteData)
						pDP = new DPsqlite ();
					else
						pDP = new DPodbc ();
				}
				return pDP;
			}
		}
		//            set{
		//                DataProvider oldDp = _dp;
		//                _dp = value;
		//                oldDp.Update();
		//            }
		#endregion

		#region Настройки импорта
		bool myImportDoSame;
		// TODO: сделать загрузку/сохранение
		public bool ImportDoSame {
			get { return myImportDoSame; }
			set {
				myImportDoSame = value;
				OnChanged ();
			}
		}

		bool myImportHideEqual = true;
		// TODO: сделать загрузку/сохранение
		public bool ImportHideEqual {
			get { return myImportHideEqual; }
			set {
				myImportHideEqual = value;
				OnChanged ();
			}
		}
		#endregion

		#region Доступ к конфигу проги
		/// <summary>
		/// Конфиг программы.
		/// </summary>
		private static Config pCfg;

		/// <summary>
		/// Конфиг программы.
		/// </summary>
		public static Config Cfg {
			get {
				if (pCfg == null)
					pCfg = new Config (true);
				return pCfg;
			}
			set {
				Config oldCfg = pCfg;
				pCfg = value;
				oldCfg.OnChanged ();
			}
		}
		#endregion

		#region Конструктор класса
		/// <summary>
		/// Инициализация параметров конфигурации.
		/// </summary>
		/// <param name="tryLoad">Попробовать загрузить конфиг.</param>
		public Config (Boolean tryLoad)
		{
			if (tryLoad) {
				try {
					RegistryKey hklm = Registry.LocalMachine.OpenSubKey ("Software");
					RegistryKey hksoft = hklm.OpenSubKey ("SeekerSoft");
					if (hksoft != null) {
						RegistryKey hkrecept = hksoft.OpenSubKey ("Recept2");
						if (hkrecept != null) {
							this.LoadRegConfig (hkrecept);
							hkrecept.Close ();
						}
						
						hksoft.Close ();
					}
					
					RegistryKey hkcu = Registry.CurrentUser.OpenSubKey ("Software");
					hksoft = hkcu.OpenSubKey ("SeekerSoft");
					if (hksoft != null) {
						RegistryKey hkrecept = hksoft.OpenSubKey ("Recept2");
						if (hkrecept != null) {
							this.LoadRegConfig (hkrecept);
							hkrecept.Close ();
						}
						
						hksoft.Close ();
					}
					
					hkcu.Close ();
				} catch (SecurityException) {
					this.LoadFileConfig ();
				} catch (ObjectDisposedException) {
					this.LoadFileConfig ();
				}
			}
		}
		#endregion

		#region Загрузка конфига (по умолчанию при первом запросе)
		private void LoadRegConfig (RegistryKey hkrecept)
		{
			if (hkrecept != null) {
				myDefaultFile = hkrecept.GetValue ("DefaultFile", myDefaultFile).ToString ();
				myDbFile = hkrecept.GetValue ("DBFile", myDbFile).ToString ();
				string dbType = hkrecept.GetValue ("DBType", "SQLite").ToString ();
				if (String.IsNullOrEmpty (dbType))
					dbType = "MSAccess";
				switch (dbType) {
				case "SQLite":
					myIsSQliteData = true;
					//_dp = new DPsqlite();
					break;
				case "MSAccess":
					myIsSQliteData = false;
					//_dp = new DPodbc();
					break;
				default:
					throw new InvalidDataException ("Непонятный тип БД в настройках");
				}
				myTotalExit = Convert.ToDecimal (hkrecept.GetValue ("TotalExit", myTotalExit), CultureInfo.CurrentCulture);
				myPrecision = int.Parse (hkrecept.GetValue ("Precision", myPrecision).ToString (), CultureInfo.CurrentCulture);
				myReplaceGrad = Convert.ToBoolean (hkrecept.GetValue ("ReplaceGrad", myReplaceGrad), CultureInfo.CurrentCulture);
				myPandoc = hkrecept.GetValue ("Pandoc", myPandoc).ToString ();
				myImportHideEqual = Convert.ToBoolean (hkrecept.GetValue ("ImportHideEqual", myImportHideEqual), CultureInfo.CurrentCulture);
				myImportDoSame = Convert.ToBoolean (hkrecept.GetValue ("ImportDoSame", myImportDoSame), CultureInfo.CurrentCulture);
				myWaterId = int.Parse (hkrecept.GetValue ("WaterID", myWaterId).ToString (), CultureInfo.CurrentCulture);
				
				RegistryKey hkReport = hkrecept.OpenSubKey ("Report");
				if (hkReport != null) {
					myReportIsShowOriginal = Convert.ToBoolean (hkReport.GetValue ("IsShowOriginal", myReportIsShowOriginal), CultureInfo.CurrentCulture);
					StringToBindingList (ReportUseCounts, hkReport.GetValue ("UseCounts", string.Empty).ToString ());
					StringToBindingList (ReportUseExits, hkReport.GetValue ("UseExits", string.Empty).ToString ());
					hkReport.Close ();
				}
			}
		}

		public static void StringToBindingList (BindingList<decimal> dest, string source)
		{
			dest.Clear ();
			if (String.IsNullOrEmpty(source))
				return;
			
			string[] vals = source.Split (new char[] {
				' ',
				'|',
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			
			foreach (string val in vals) {
				dest.Add (Convert.ToDecimal (val, CultureInfo.CurrentCulture));
			}
		}

		public static string BindingListToString (BindingList<decimal> src)
		{
			StringBuilder ret = new StringBuilder ();
			
			foreach (decimal val in src) {
				if (ret.Length != 0) {
					ret.Append (";");
				}
				ret.Append (val.ToString (CultureInfo.CurrentCulture));
			}
			
			return ret.ToString ();
		}

		/// <summary>
		/// загрузка конфига из файла
		/// </summary>
		private void LoadFileConfig ()
		{
			string cfgFile = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "/Recept2/config";
			XmlDocument doc = new XmlDocument ();
			try {
				doc.Load (cfgFile);
				XmlNode root = doc.DocumentElement;
				foreach (XmlNode curNode in root.ChildNodes) {
					switch (curNode.Name) {
					case "DefaultFile":
						myDefaultFile = curNode.InnerText;
						break;
					case "DBFile":
						myDbFile = curNode.InnerText;
						break;
					case "DBType":
						myIsSQliteData = curNode.InnerText.Equals ("SQLite") ? true : false;
						break;
					case "TotalExit":
						myTotalExit = Convert.ToDecimal (curNode.InnerText, CultureInfo.CurrentCulture);
						break;
					case "Precision":
						myPrecision = Convert.ToInt32 (curNode.InnerText, CultureInfo.CurrentCulture);
						break;
					case "ReplaceGrad":
						myReplaceGrad = Convert.ToBoolean (curNode.InnerText, CultureInfo.CurrentCulture);
						break;
					case "Pandoc":
						myPandoc = curNode.InnerText;
						break;
					case "ImportHideEqual":
						myImportHideEqual = Convert.ToBoolean (curNode.InnerText, CultureInfo.CurrentCulture);
						break;
					case "ImportDoSame":
						myImportDoSame = Convert.ToBoolean (curNode.InnerText, CultureInfo.CurrentCulture);
						break;
					case "WaterID":
						myWaterId = int.Parse (curNode.InnerText, CultureInfo.CurrentCulture);
						break;
					case "Report":
						foreach (XmlNode repNode in curNode.ChildNodes) {
							switch (repNode.Name) {
							case "IsShowOriginal":
								myReportIsShowOriginal = Convert.ToBoolean (repNode.InnerText, CultureInfo.CurrentCulture);
								break;
							case "UseCounts":
								StringToBindingList (ReportUseCounts, repNode.InnerText);
								break;
							case "UseExits":
								StringToBindingList (ReportUseExits, repNode.InnerText);
								break;
							}
						}

						break;
					case "LastOpenPath":
						foreach (XmlNode repNode in curNode.ChildNodes) {
							switch (repNode.Name) {
							case "file1":
							case "file2":
							case "file3":
							case "file4":
								myLastOpenPaths.Add (repNode.InnerText);
								break;
							}
						}

						break;
					}
				}
			} catch (XmlException) {
			} catch (DirectoryNotFoundException) {
			}
			//MessageBox.Show(appdata);
		}
		#endregion

		#region Сохранение конфига
		/// <summary>
		/// Сохранение настроек пользователя
		/// </summary>
		public void StoreConfig ()
		{
			try {
				StoreRegConfig ();
			} catch (IOException) {
				try {
					StoreFileConfig ();
				} catch (IOException) {
					MessageBox.Show("Не удалось выполнить сохранение настроек программы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0);
				}
			}
		}

		/// <summary>
		/// Сохранение конфига в реестре
		/// </summary>
		/// <exception cref="System.Secyrity.SecurityException"></exception>
		void StoreRegConfig ()
		{
			RegistryKey hkcu = null;
			RegistryKey hksoft = null;
			RegistryKey hkrecept = null;
			RegistryKey hkReport = null;
			try {
				hkcu = Registry.CurrentUser.OpenSubKey ("Software");
				hksoft = hkcu.OpenSubKey ("SeekerSoft");
				if (hksoft == null) {
					hksoft = hkcu.CreateSubKey ("SeekerSoft");
				}
				hkrecept = hksoft.OpenSubKey ("Recept2", true);
				if (hkrecept == null) {
					hkrecept = hksoft.CreateSubKey ("Recept2", RegistryKeyPermissionCheck.ReadWriteSubTree);
				}
				hkrecept.SetValue ("DefaultFile", myDefaultFile, RegistryValueKind.String);
				hkrecept.SetValue ("DBFile", myDbFile, RegistryValueKind.String);
				hkrecept.SetValue ("DBType", myIsSQliteData ? "SQLite" : "MSAccess", RegistryValueKind.String);
				hkrecept.SetValue ("TotalExit", myTotalExit.ToString (CultureInfo.CurrentCulture), RegistryValueKind.String);
				hkrecept.SetValue ("Precision", myPrecision.ToString (CultureInfo.CurrentCulture), RegistryValueKind.String);
				hkrecept.SetValue ("ReplaceGrad", myReplaceGrad.ToString (), RegistryValueKind.String);
				hkrecept.SetValue ("Pandoc", myPandoc, RegistryValueKind.String);
				hkrecept.SetValue ("ImportHideEqual", myImportHideEqual.ToString (), RegistryValueKind.String);
				hkrecept.SetValue ("ImportDoSame", myImportDoSame.ToString (), RegistryValueKind.String);
				hkrecept.SetValue ("WaterID", myWaterId.ToString (CultureInfo.CurrentCulture), RegistryValueKind.String);
				
				hkReport = hkrecept.OpenSubKey ("Report", true);
				if (hkReport == null) {
					hkReport = hkrecept.CreateSubKey ("Report", RegistryKeyPermissionCheck.ReadWriteSubTree);
				}
				hkReport.SetValue ("IsShowOriginal", myReportIsShowOriginal.ToString (), RegistryValueKind.String);
				hkReport.SetValue ("UseCounts", BindingListToString (myReportUseCounts), RegistryValueKind.String);
				hkReport.SetValue ("UseExits", BindingListToString (myReportUseExits), RegistryValueKind.String);
			} catch (UnauthorizedAccessException ex) {
				throw new IOException ("Не удалось записать конфиг в реестр", ex);
			} finally {
				if (hkReport != null)
					hkReport.Close ();
				if (hkrecept != null)
					hkrecept.Close ();
				if (hksoft != null)
					hksoft.Close ();
				if (hkcu != null)
					hkcu.Close ();
			}
		}

		/// <summary>
		/// Функция сохранения настроек в файл 
		/// </summary>
		void StoreFileConfig ()
		{
			//MessageBox.Show("DefaultFile");
			string cfgFile = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "/Recept2/config";
			XmlDocument doc = new XmlDocument ();
			try {
				doc.Load (cfgFile);
			} catch (XmlException) {
				doc.InsertBefore (doc.CreateXmlDeclaration ("1.0", "utf-8", null), null);
				doc.AppendChild (doc.CreateElement ("config"));
			}
			catch(IOException)
			{
				if (!Directory.Exists(Path.GetDirectoryName(cfgFile)))
					Directory.CreateDirectory(Path.GetDirectoryName(cfgFile));
				doc.InsertBefore (doc.CreateXmlDeclaration ("1.0", "utf-8", null), null);
				doc.AppendChild (doc.CreateElement ("config"));
			}
			
			XmlNode root = doc.DocumentElement;
			//MessageBox.Show("DefaultFile");
			//XmlNode curNode;
			if (root["DefaultFile"] == null)
				root.AppendChild (doc.CreateElement ("DefaultFile"));
			root["DefaultFile"].InnerText = myDefaultFile;
			
			if (root["DBFile"] == null)
				root.AppendChild (doc.CreateElement ("DBFile"));
			root["DBFile"].InnerText = myDbFile;
			
			if (root["DBType"] == null)
				root.AppendChild (doc.CreateElement ("DBType"));
			root["DBType"].InnerText = myIsSQliteData ? "SQLite" : "MSAccess";
			
			if (root["TotalExit"] == null)
				root.AppendChild (doc.CreateElement ("TotalExit"));
			root["TotalExit"].InnerText = myTotalExit.ToString (CultureInfo.CurrentCulture);
			
			if (root["Precision"] == null)
				root.AppendChild (doc.CreateElement ("Precision"));
			root["Precision"].InnerText = myPrecision.ToString (CultureInfo.CurrentCulture);
			
			if (root["ReplaceGrad"] == null)
				root.AppendChild (doc.CreateElement ("ReplaceGrad"));
			root["ReplaceGrad"].InnerText = myReplaceGrad.ToString ();
			
			if (root["Pandoc"] == null)
				root.AppendChild (doc.CreateElement ("Pandoc"));
			root["Pandoc"].InnerText = myPandoc;
			
			if (root["ImportHideEqual"] == null)
				root.AppendChild (doc.CreateElement ("ImportHideEqual"));
			root["ImportHideEqual"].InnerText = myImportHideEqual.ToString ();
			
			if (root["ImportDoSame"] == null)
				root.AppendChild (doc.CreateElement ("ImportDoSame"));
			root["ImportDoSame"].InnerText = myImportDoSame.ToString ();
			
			if (root["WaterID"] == null)
				root.AppendChild (doc.CreateElement ("WaterID"));
			root["WaterID"].InnerText = myWaterId.ToString (CultureInfo.CurrentCulture);
			
			if (root["Report"] == null)
				root.AppendChild (doc.CreateNode (XmlNodeType.Element, "Report", ""));
			XmlNode nodeReport = root["Report"];
			
			if (nodeReport["IsShowOriginal"] == null)
				nodeReport.AppendChild (doc.CreateElement ("IsShowOriginal"));
			nodeReport["IsShowOriginal"].InnerText = myReportIsShowOriginal.ToString ();
			
			if (nodeReport["UseCounts"] == null)
				nodeReport.AppendChild (doc.CreateElement ("UseCounts"));
			nodeReport["UseCounts"].InnerText = BindingListToString (myReportUseCounts);
			
			if (nodeReport["UseExits"] == null)
				nodeReport.AppendChild (doc.CreateElement ("UseExits"));
			nodeReport["UseExits"].InnerText = BindingListToString (myReportUseExits);
			
			doc.Save (cfgFile);
		}
		#endregion

		/// <summary>
		/// Удаление конфига из реестра.
		/// </summary>
		public static void DeleteConfig ()
		{
			try {
				RegistryKey hkcu = Registry.CurrentUser.OpenSubKey ("Software");
				RegistryKey hksoft = hkcu.OpenSubKey ("SeekerSoft", true);
				if (hksoft == null) {
					return;
				}
				
				RegistryKey hkrecept = hksoft.OpenSubKey ("Recept2", true);
				if (hkrecept == null) {
					return;
				}
				
				hkrecept.Close ();
				hksoft.DeleteSubKeyTree ("Recept2");
				hksoft.Close ();
				hkcu.Close ();
			} catch (SecurityException e) {
				MessageBox.Show (e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
			} catch (ObjectDisposedException e) {
				MessageBox.Show (e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
			}
		}

		#region Событие измение настроек пользователя
		public event EventHandler Changed;
		protected virtual void OnChanged ()
		{
			if (Changed != null) {
				Changed (this, EventArgs.Empty);
			}
		}
		#endregion

		#region ICloneable Members

		public object Clone ()
		{
			Config ret = new Config (false);
			ret.myDbFile = myDbFile;
			ret.myDefaultFile = myDefaultFile;
			ret.myExportFileType = myExportFileType;
			ret.myImportDoSame = myImportDoSame;
			ret.myImportHideEqual = myImportHideEqual;
			ret.myIsSQliteData = myIsSQliteData;
			ret.myPandoc = myPandoc;
			ret.myPrecision = myPrecision;
			ret.myTotalExit = myTotalExit;
			ret.myReplaceGrad = myReplaceGrad;
			ret.myWaterId = myWaterId;
			ret.myReportIsShowOriginal = myReportIsShowOriginal;
			ret.myReportUseCounts = new BindingList<decimal> ();
			ret.myReportUseCounts.ListChanged += new ListChangedEventHandler (Config_ListChanged);
			foreach (decimal dec in myReportUseCounts)
				ret.myReportUseCounts.Add (dec);
			ret.myReportUseExits = new BindingList<decimal> ();
			ret.myReportUseExits.ListChanged += new ListChangedEventHandler (Config_ListChanged);
			foreach (decimal dec in myReportUseExits)
				ret.myReportUseExits.Add (dec);
			return ret;
		}
		
		#endregion
	}
}
