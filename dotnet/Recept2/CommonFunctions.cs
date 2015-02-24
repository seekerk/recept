// <copyright file="CommonFunctions.cs" company="SeekerSoft">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Kirill Kulakov</author>
// <email>seeker.k@gmail.com</email>
// <date>2008-05-24</date>
// <summary>Contains assembly information.</summary>

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
    /// Варианты отображения форм главного окна
    /// </summary>
    public enum ViewMode
    {
        /// <summary>
        /// Ничего не отображается
        /// </summary>
        None,
        
        /// <summary>
        /// Общая форма книги рецептур
        /// </summary>
        BookCommon,
        
        /// <summary>
        /// Общая форма рецептуры (состав)
        /// </summary>
        ReceptCommon,
        
        /// <summary>
        /// Описание процесса приготовления рецептуры
        /// </summary>
        ReceptProcess,
        
        /// <summary>
        /// Описание внешнего вида рецептуры
        /// </summary>
        ReceptView,
        
        /// <summary>
        /// Описание физ. хим. показателей
        /// </summary>
        ReceptFactors,
        
        /// <summary>
        /// Описание цвета изделия
        /// </summary>
        ReceptColor,
        
        /// <summary>
        /// Описание консистенции изделия
        /// </summary>
        ReceptConsistence,
        
        /// <summary>
        /// Описание вкуса и запаха изделия
        /// </summary>
        ReceptTaste,
        
        /// <summary>
        /// Описание оформления изделия
        /// </summary>
        ReceptDesign,
        
        /// <summary>
        /// Описание подачи изделия
        /// </summary>
        ReceptDelivery,
        
        /// <summary>
        /// Описание реализации изделия
        /// </summary>
        ReceptSale,
        
        /// <summary>
        /// Описание хранения изделия
        /// </summary>
        ReceptStorage
    }



    /// <summary>
    /// Общие функции, которые не вошли в другие классы
    /// </summary>
    public static class CommonFunctions
    {
        /// <summary>
        /// Получение полного пути из произвольного
        /// </summary>
        /// <param name="basePath">Начальный путь</param>
        /// <param name="fname">Путь до файла</param>
        /// <returns>Полный путь</returns>
        public static string AbsolutePathFromAnyPath(string basePath, string fname)
        {
            string filename = Environment.ExpandEnvironmentVariables(fname);
            char cd = Path.DirectorySeparatorChar;
            
            // правим путь для винды
            if (Environment.OSVersion.Platform == PlatformID.Win32Windows)
            {
                if (filename.Length > 0 && filename.Substring(1, 2) != ":" + cd + cd && filename.Substring(0, 1) != "%")
                {
                    filename = basePath + cd + filename;
                }
                
                string exp = @"\\[^\\]*?\\\.\.(?=\\)";
                System.Text.RegularExpressions.Regex rr = new System.Text.RegularExpressions.Regex(exp);
                System.Text.RegularExpressions.Regex tt = new System.Text.RegularExpressions.Regex(@"\\\.(?=\\)");
                System.Text.RegularExpressions.Match m;
                System.Text.RegularExpressions.Match n;
                do
                {
                    m = rr.Match(filename);
                    n = tt.Match(filename);
                    if (n.Success)
                    {
                        filename = filename.Remove(n.Index, n.Length);
                    }
                    else
                    {
                        if (m.Success)
                        {
                            filename = filename.Remove(m.Index, m.Length);
                        }
                        else
                        {
                            break;
                        }
                    }
                } while (true);
            }
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                if (!Path.IsPathRooted(filename))
                    filename = basePath + cd + filename;
                filename = Path.GetFullPath(filename);
            }
            return filename;
        }

        /// <summary>
        /// сохранение хтмл файла в выбранном формате
        /// </summary>
        /// <param name="fname">абсолютный путь до файла</param>
        /// <param name="html">html документ для сохранения</param>
        /// <param name="expType">формат выходного файла</param>
        /// <returns>true если успешно, иначе false</returns>
        public static bool SaveToFile(string fname, string html, bool usePandoc)
        {
            //  создаем временный файлик
            string tempfile;
            int i = 0;
            if (usePandoc)
            {
                do {
                    tempfile = Path.GetTempPath() + "Recept2" + i.ToString(CultureInfo.CurrentCulture) + ".html";
                    i++;
                } while (System.IO.File.Exists(tempfile));
            }else{
                tempfile = fname;
            }
            
            // записываем туда данные
            StreamWriter wr = new StreamWriter(new FileStream(tempfile.ToString(), FileMode.OpenOrCreate & FileMode.Truncate));
            wr.WriteLine(html.Replace("\n", "\r\n"));
            wr.Close();

            if (usePandoc)
            {
                //MessageBox.Show(Config.cfg.pandoc);
                // запуск конвертера
                //MessageBox.Show(Config.cfg.exportFileType);
                Process prs = Process.Start(Config.Cfg.Pandoc, "-f html -s \"" + tempfile + "\" -t " + Config.Cfg.ExportFileType + " -o \"" + fname + "\"");
                prs.WaitForExit();
                if (prs.ExitCode > 0)
                    return false;

                // удаляем лишнюю каку
                if (File.Exists(tempfile.ToString()))
                {
                    try
                    {
                        File.Delete(tempfile.ToString());
                    }
                    catch (IOException) {}
                }
            }
            
            // проверяем результат
            if (File.Exists(fname.ToString()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Округление числа с точностью от Config.cfg.precision до первого значащего символа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Round(decimal num)
        {
            int prec = Config.Cfg.Precision;
            if (num == 0 || num.ToString(CultureInfo.CurrentCulture).Length < prec + 4)
            {
                return num.ToString(CultureInfo.CurrentCulture);
            }
            decimal ret = Math.Round(num, prec);
            while (ret == 0 && ret != num)
            {
                prec++;
                ret = Math.Round(num, prec);
            }
            return ret.ToString(CultureInfo.CurrentCulture);
        }
    }
}
