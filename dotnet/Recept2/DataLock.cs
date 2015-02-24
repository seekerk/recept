using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;

namespace Recept2
{
    public class DataLock
    {
        // структура файла
        // root // корень дерева
        // - users // ветка подключенных пользователей, наборы элементов user()
        // - - [username] // имя пользователя, значение любое
        // - items // ветка заблокированных элементов содержит наборы lockItem(user, item)
        // - - user // имя пользователя [username]
        // - - item // заблокированный элемент



        /// <summary>
        /// Файл блокировки
        /// </summary>
        string lockFile = "";

        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        string userName = Environment.MachineName + "//" + Environment.UserDomainName + "//" + Environment.UserName;

        /// <summary>
        /// создание блокировки файла пользователя
        /// </summary>
        /// <param name="fileToLock">файл пользователя</param>
        public DataLock(string fileToLock)
        {
            lockFile = CommonFunctions.AbsolutePathFromAnyPath(Application.StartupPath, fileToLock) + ".lock";
            FileStream lf = new FileStream(lockFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(lf);
            XmlNode root = doc.DocumentElement;

            bool isExists = false;
            foreach (XmlNode curNode in root["users"].ChildNodes)
            {
                if (curNode.InnerText.Equals(userName))
                {
                    isExists = true;
                }
            }
            if (!isExists)
            {
                XmlNode user = root["users"].AppendChild(doc.CreateElement("user"));
                user.InnerText = userName;
            }
            doc.Save(lf);
            lf.Close();
        }

        /// <summary>
        /// Блокировка элемента
        /// </summary>
        /// <param name="name">идентификатор элемента</param>
        /// <returns>true если заблокирован, иначе false</returns>
        public bool AddLock(string name)
        {
            bool isLocked = false; // блокирован этот элемент или нет
            bool isCanLock = true; // можем заблокировать или нет
            
            FileStream lf = new FileStream(lockFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(lf);
            XmlNode root = doc.DocumentElement;

            // проверяем, заблокирован элемент или нет
            foreach (XmlNode curNode in root["items"].ChildNodes)
            {
                if (curNode["item"].Equals(name)) // если нашли этот элемент в списке заблокированных
                {
                    isLocked = true;
                    if (!curNode["user"].Equals(userName)) // если этот элемент заблокирован другим пользователем
                    {
                        isCanLock = false;
                    }
                    break;
                }
            }

            if (isLocked) // если заблокирован, то выдаем юзеру результат в зависимости от того, кто блокировал
            {
                lf.Close();
                if (isCanLock)
                {
                    return true;
                }else{
                    return false;
                }
            }else{
                XmlNode newNode = root["items"].AppendChild(doc.CreateElement("lockItem"));
                newNode.AppendChild(doc.CreateElement("user"));
                newNode.AppendChild(doc.CreateElement("item"));
                newNode["user"].InnerText = userName;
                newNode["item"].InnerText = name;
                doc.Save(lf);
                lf.Close();
            }
            return true;
        }

        public void RemoveLock(string name)
        {
            FileStream lf = new FileStream(lockFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(lf);
            XmlNode root = doc.DocumentElement;

            // проверяем, заблокирован элемент или нет
            foreach (XmlNode curNode in root["items"].ChildNodes)
            {
                if (curNode["item"].Equals(name) && curNode["user"].Equals(userName)) // если нашли этот элемент в списке заблокированных
                {
                    root["items"].RemoveChild(curNode);
                    break;
                }
            }
            doc.Save(lf);
            lf.Close();
        }

        /// <summary>
        /// удаление блокировок
        /// </summary>
        public void RemoveAllLocks()
        {
            FileStream lf = new FileStream(lockFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(lf);
            XmlNode root = doc.DocumentElement;

            ArrayList delItems = new ArrayList();
            // проверяем, заблокирован элемент или нет
            foreach (XmlNode curNode in root["items"].ChildNodes)
            {
                if (curNode["user"].Equals(userName)) // если нашли этот элемент в списке заблокированных
                {
                    delItems.Add(curNode);
                }
            }

            foreach (XmlNode curNode in delItems)
            {
                root["items"].RemoveChild(curNode);
            }
            doc.Save(lf);
            lf.Close();
        }

        /// <summary>
        /// Освобождение файла
        /// </summary>
        public void ReleaseFile()
        {
            FileStream lf = new FileStream(lockFile, FileMode.Open, FileAccess.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(lf);
            XmlNode root = doc.DocumentElement;

            // удаление текущего пользователя
            foreach (XmlNode curNode in root["users"])
            {
                if (curNode.InnerText.Equals(userName))
                {
                    root["users"].RemoveChild(curNode);
                    break;
                }
            }

            // очистка заблокированных элементов
            ArrayList deleteElems = new ArrayList();
            foreach (XmlNode curNode in root["items"].ChildNodes)
            {
                if (curNode["user"].InnerText.Equals(userName))
                {
                    deleteElems.Add(curNode);
                }
            }
            foreach (XmlNode curNode in deleteElems)
            {
                root["items"].RemoveChild(curNode);
            }
            doc.Save(lf);
            lf.Close();
        }
    }
}
