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
    /// Тип элемента наследника DataBase.
    /// </summary>
    public enum DataBaseType
    {
        RawType,
        ProcessLossType,
        TotalLossType,
        MicroBiologyType,
        MicroBiologyIndicatorType
    }



    public sealed class BookTreeViewSort : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            TreeNode nx = x as TreeNode;
            TreeNode ny = y as TreeNode;

            if (nx == null || nx.Tag == null)
            {
                if (ny == null || ny.Tag == null)
                {
                    return 0;
                }
                return -1;
            }
            else
            {
                if (ny == null || ny.Tag == null)
                {
                    return 1;
                }
            }

            return (nx.Tag as DataBase).Id.CompareTo((ny.Tag as DataBase).Id);
        }
    }
}
