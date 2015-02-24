using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Recept2
{
    public partial class PanelBrowse : UserControl
    {
        public PanelBrowse()
        {
            InitializeComponent();
            tvBook.TreeViewNodeSorter = new BookTreeViewSort();
        }

        /// <summary>
        /// Загрузка текущей книги рецептур в дерево
        /// </summary>
        public void LoadData()
        {
            tvBook.Nodes.Clear();
            DataBook curData = DataBook.Book;
            TreeNode rootNode = new TreeNode(curData.Name);
            rootNode.Tag = curData;
            tvBook.Nodes.Add(rootNode);
            foreach (DataRecept rcp in curData.Components)
            {
                LoadRecepts(rootNode.Nodes, rcp);
            }
            tvBook.ExpandAll();
            tvBook.Sort();
            curData.Changed += new EventHandler<DataBaseEventArgs>(curData_Changed);

            currentMode = ViewMode.BookCommon;
            LoadList(ViewMode.BookCommon);
            lbPages.DisplayMember = "ModeKey";
            lbPages.ValueMember = "ModeValue";
        }

        /// <summary>
        /// Загрузка дерева рецептур
        /// </summary>
        /// <param name="root">текущие листья узла</param>
        /// <param name="curRec">рецептура</param>
        private void LoadRecepts(TreeNodeCollection root, DataRecept curRec)
        {
            TreeNode curnode = new TreeNode(curRec.Name + " (" + CommonFunctions.Round(curRec.PercentFilling()) + "%)");
            curnode.Tag = curRec;
            root.Add(curnode);
            foreach (DataBase rec in curRec.Components)
            {
                if (rec is DataRecept)
                {
                    LoadRecepts(curnode.Nodes, rec as DataRecept);
                }
            }
        }

        void curData_Changed(object sender, DataBaseEventArgs e)
        {
            foreach (TreeNode curNode in tvBook.Nodes)
            {
                UpdateTreeNode(curNode, e.IsMainDataChanged);
            }
            if (e.IsMainDataChanged)
            {
                TreeNode selectedNode = tvBook.SelectedNode;
                tvBook.Sort();
                if (selectedNode != null)
                {
                    tvBook.SelectedNode = selectedNode;
                }
            }
        }

        private void UpdateTreeNode(TreeNode root, bool isMainDataChanged)
        {
            DataBase curData = (DataBase)root.Tag;
            
            // удаляем узел, если его нет у родителя
            if (curData.Parent != null && !curData.Parent.Contains(curData))
            {
                root.Remove();
                return;
            }

            string newName = curData.Name + " (" + CommonFunctions.Round(curData.PercentFilling()) + "%)";
            // обновляем имя узла если изменилось
            if (!root.Text.Equals(newName))
            {
                root.Text = newName;
            }

            if (isMainDataChanged)
            {
                // добавляем новые узлы для книги
                if (curData is DataBook)
                {
                    foreach (DataBase curChild in ((DataBook)curData).Components)
                    {
                        bool isFound = false;
                        foreach (TreeNode node in root.Nodes)
                        {
                            if (((DataBase)node.Tag).Equals(curChild))
                            {
                                isFound = true;
                                break;
                            }
                        }
                        if (!isFound)
                        {
                            TreeNode newNode = null;
                            if (curChild.Name == "")
                            {
                                newNode = new TreeNode("(без названия)");
                                newNode.NodeFont = new Font(newNode.NodeFont, FontStyle.Italic);
                            }
                            else
                                newNode = new TreeNode(curChild.Name + " (" + CommonFunctions.Round(curChild.PercentFilling()) + "%)");
                            newNode.Tag = curChild;
                            root.Nodes.Add(newNode);
                        }
                    }
                }

                if (curData is DataRecept)
                {
                    foreach (DataBase curChild in ((DataRecept)curData).Components)
                    {
                        if (!(curChild is DataRecept || curChild is DataBook))
                        {
                            continue;
                        }
                        bool isFound = false;
                        foreach (TreeNode node in root.Nodes)
                        {
                            if (((DataBase)node.Tag).Equals(curChild))
                            {
                                isFound = true;
                                break;
                            }
                        }
                        if (!isFound)
                        {
                            TreeNode newNode = null;
                            if (curChild.Name == "")
                            {
                                newNode = new TreeNode("(без названия)");
                                newNode.NodeFont = new Font(newNode.NodeFont, FontStyle.Italic);
                            }
                            else
                                newNode = new TreeNode(curChild.Name + " (" + CommonFunctions.Round(curChild.PercentFilling()) + "%)");
                            newNode.Tag = curChild;
                            root.Nodes.Add(newNode);
                        }
                    }
                }
            }

            // рекурсия по нижестоящим узлам
            if (root.Nodes != null)
            {
                foreach (TreeNode curNode in root.Nodes)
                {
                    UpdateTreeNode(curNode, isMainDataChanged);
                }
            }
        }

        private void tvBook_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ((FormMain)this.FindForm()).SetView(e.Node.Tag);
        }

        private ViewMode currentListMode = ViewMode.None;
        private ViewMode currentMode = ViewMode.None;
        
        /// <summary>
        /// Загрузка списка форм
        /// </summary>
        /// <param name="viewMode">Режим просмотра</param>
        internal void LoadList(ViewMode viewMode)
        {
            switch (viewMode)
            {
                case ViewMode.BookCommon:
                    if (currentListMode != ViewMode.BookCommon)
                    {
                        currentListMode = ViewMode.BookCommon;
                        lbPages.Items.Clear();
                        lbPages.Items.AddRange(ViewModeStruct.GetListBook());
                    }
                    currentMode = ViewMode.BookCommon;
                    lbPages.SelectedIndex = 0;
                    break;
                case ViewMode.ReceptCommon:
                    if (currentListMode != ViewMode.ReceptCommon)
                    {
                        currentListMode = ViewMode.ReceptCommon;
                        lbPages.Items.Clear();
                        lbPages.Items.AddRange(ViewModeStruct.GetListRecept());
                    }
                    currentMode = ViewMode.ReceptCommon;
                    lbPages.SelectedIndex = 0;
                    break;
                default:
                    throw new NotImplementedException("The method or operation is not implemented.");
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void lbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMode != ((ViewModeStruct)lbPages.SelectedItem).ModeValue)
            {
                ((FormMain)this.FindForm()).SetView(((ViewModeStruct)lbPages.SelectedItem).ModeValue);
                currentMode = ((ViewModeStruct)lbPages.SelectedItem).ModeValue;
            }
        }

        internal DataRecept GetSelectedRecept()
        {
            if (tvBook.SelectedNode != null && tvBook.SelectedNode.Tag is DataRecept)
            {
                return (DataRecept)tvBook.SelectedNode.Tag;
            }else{
                return null;
            }
        }

        internal void SelectTreeNode(DataRecept newRecept)
        {
            SelectTreeNode(newRecept, tvBook.Nodes);
        }
        internal void SelectTreeNode(DataRecept newRecept, TreeNodeCollection nodes)
        {
            foreach (TreeNode curNode in nodes)
            {
                if (newRecept.Equals(curNode.Tag))
                {
                    tvBook.SelectedNode = curNode;
                    return;
                }
                if (curNode.Nodes.Count > 0)
                {
                    SelectTreeNode(newRecept, curNode.Nodes);
                }
            }
        }
    }
}
