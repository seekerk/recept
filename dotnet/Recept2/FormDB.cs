
namespace Recept2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Форма работы с записями из БД
    /// </summary>
    public partial class FormDB : Form
    {
        /// <summary>
        /// Тип записи списка.
        /// </summary>
        private DataBaseType myRecType;
        
        /// <summary>
        /// Текущая запись является новой или нет.
        /// </summary>
        private bool myIsNew = false;

        /// <summary>
        /// Флаг изменения данных текущей записи.
        /// </summary>
        private bool myIsDataChanged;

        /// <summary>
        /// Флаг изменения данных текущей записи.
        /// </summary>
        /// <value>Истина если данные изменены</value>
        public bool IsDataChanged {
            get
            {
                return myIsDataChanged;
            }
            set
            {
                myIsDataChanged = value;
                SetFormName();
            }
        }

        /// <summary>
        /// Текущая запись.
        /// </summary>
        internal DataBase currentRecord;

        public FormDB(DataBaseType recType, bool isNew)
        {
            this.myRecType = recType;
            this.myIsNew = isNew;

            this.InitializeComponent();

            // значения для любого варианта
            this.listBox1.ValueMember = "ValueMember";
            this.listBox1.DisplayMember = "DisplayMember";
            this.panelTotalLossData1.Visible = false;
            this.panelRawData1.Visible = false;

            switch (this.myRecType)
            {
                case DataBaseType.TotalLossType:
                    this.listBox1.Items.AddRange(Config.DP.TotalLossList.ToArray());
                    this.panelTotalLossData1.Visible = true;
                    this.panelTotalLossData1.Dock = DockStyle.Fill;
                    if (isNew)
                    {
                        currentRecord = new DataTotalLoss(null);
                        this.listBox1.Items.Add(currentRecord);
                        this.listBox1.SelectedItem = currentRecord;
                    }else{
                        this.listBox1.SelectedItem = listBox1.Items[0];
                    }
                    break;
                case DataBaseType.RawType:
                    this.listBox1.Items.AddRange(Config.DP.RawList.ToArray());
                    this.panelRawData1.Visible = true;
                    this.panelRawData1.Dock = DockStyle.Fill;
                    if (isNew)
                    {
                        currentRecord = new DataRawStruct(null);
                        this.listBox1.Items.Add(currentRecord);
                        this.listBox1.SelectedItem = currentRecord;
                    }
                    else
                    {
                        this.listBox1.SelectedItem = listBox1.Items[0];
                    }
                    break;
                case DataBaseType.ProcessLossType:
                    this.listBox1.Items.AddRange(Config.DP.ProcessLossList.ToArray());
                    this.panelRawData1.Visible = true;
                    this.panelRawData1.Dock = DockStyle.Fill;
                    //panelRawData1.SetData(null, DataBaseType.DataProcessLossType);
                    if (isNew)
                    {
                        currentRecord = new DataRawStruct(null);
                        this.listBox1.Items.Add(currentRecord);
                        this.listBox1.SelectedItem = currentRecord;
                    }
                    else
                    {
                        this.listBox1.SelectedItem = listBox1.Items[0];
                    }
                    break;
                default:
                    throw new NotImplementedException("Не реализовано");
            }
            
            Config.DP.Changed += new EventHandler<DataProviderEventArgs>(this.dp_Changed);
        }

        // обновление списка и структуры после изменения БД
        void dp_Changed(object sender, DataProviderEventArgs args)
        {
            //int prevIDnum = currentRecord.id;
            //panelTotalLossData1._data = null;
            //panelRawData1._data = null;
            int curItem = listBox1.SelectedIndices[0];
            switch (myRecType)
            {
                case DataBaseType.TotalLossType:
                    if (!args.TotalLossChanged)
                    {
                        return; // если обновление не тех данных, то просто выходим
                    }
                    SortableBindingList<DataTotalLoss> newLoss = Config.DP.TotalLossList;
                    for (int i = 0; i < newLoss.Count; i++ )
                    {
                        if (newLoss[i].Equals(listBox1.Items[curItem]))
                        {
                            curItem = i;
                            break;
                        }
                    }
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(newLoss.ToArray());
                    break;
                case DataBaseType.RawType:
                    if (!args.RawChanged)
                    {
                        return;
                    }
                    SortableBindingList<DataRawStruct> newRaw = Config.DP.RawList;
                    for (int i = 0; i < newRaw.Count; i++)
                    {
                        if (((DataRawStruct)newRaw[i]).Equals(listBox1.Items[curItem]))
                        {
                            curItem = i;
                            break;
                        }
                    }
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(Config.DP.RawList.ToArray());
                    break;
                case DataBaseType.ProcessLossType:
                    if (!args.ProcessLossChanged)
                    {
                        return;
                    }
                    newRaw = Config.DP.ProcessLossList;
                    for (int i = 0; i < newRaw.Count; i++)
                    {
                        if (newRaw[i].Equals(listBox1.Items[curItem]))
                        {
                            curItem = i;
                            break;
                        }
                    }
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(Config.DP.ProcessLossList.ToArray());
                    break;
                default:
                    throw new NotImplementedException("Not implemented");
            }
            if (listBox1.Items.Count > curItem)
            {
                listBox1.SelectedIndex = curItem;
            }
            else
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            this.IsDataChanged = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Установка названия формы
        /// </summary>
        void SetFormName()
        {
            this.Text = "База данных калькулятора рецептур" + (myIsDataChanged ? "*" : "");
        }

        /// <summary>
        /// обработка изменения выделения в списке элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentRecord != null && currentRecord.IsChanged)
            {
                DoSave();
                return;
            }
            if (listBox1.SelectedItems.Count == 0 || listBox1.SelectedItems[0] == null)
            {
                return;
            }
            currentRecord = (DataBase)listBox1.SelectedItems[0];
            switch (myRecType)
            {
                case DataBaseType.TotalLossType:
                    panelTotalLossData1.SetData((DataTotalLoss)currentRecord);
                    break;
                case DataBaseType.RawType:
                    panelRawData1.SetData((DataRawStruct)currentRecord, DataBaseType.RawType);
                    break;
                case DataBaseType.ProcessLossType:
                    panelRawData1.SetData((DataRawStruct)currentRecord, DataBaseType.ProcessLossType);
                    break;
                default:
                    throw new NotImplementedException("Not implemented");
            }
        }

        private void tsbAddItem_Click(object sender, EventArgs e)
        {
            if (myIsNew)
            {
                return;
            }
            if (currentRecord != null && currentRecord.IsChanged)
            {
                DoSave();
            }
            switch (myRecType)
            {
                case DataBaseType.TotalLossType:
                    currentRecord = new DataTotalLoss(null);
                    listBox1.Items.Add(currentRecord);
                    listBox1.SelectedItem = currentRecord;
                    break;
                case DataBaseType.RawType:
                    currentRecord = new DataRawStruct(null);
                    listBox1.Items.Add(currentRecord);
                    listBox1.SelectedItem = currentRecord;
                    break;
                case DataBaseType.ProcessLossType:
                    currentRecord = new DataRawStruct(null);
                    listBox1.Items.Add(currentRecord);
                    listBox1.SelectedItem = currentRecord;
                    break;
                default:
                    throw new NotImplementedException("Not implemented");
            }
            myIsNew = true;
        }

        private void tsbCopyItem_Click(object sender, EventArgs e)
        {
            if (myIsNew)
            {
                return;
            }
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
                return;
            }
            if (currentRecord != null && currentRecord.IsChanged)
            {
                DoSave();
            }
            switch (myRecType)
            {
                case DataBaseType.TotalLossType:
                    currentRecord = (DataTotalLoss)((DataTotalLoss)listBox1.SelectedItems[0]).Clone();
                    break;
                case DataBaseType.RawType:
                    currentRecord = (DataRawStruct)((DataRawStruct)listBox1.SelectedItems[0]).Clone();
                    break;
                case DataBaseType.ProcessLossType:
                    currentRecord = (DataRawStruct)((DataRawStruct)listBox1.SelectedItems[0]).Clone();
                    break;
                default:
                    throw new Exception("Not implemented");
            }
            currentRecord.Id = 0;
            currentRecord.Name = currentRecord.Name + " (Копия)";
            currentRecord.IsChanged = false; // чтобы после выделения не ругалось про сохранение
            listBox1.Items.Add(currentRecord);
            listBox1.SelectedItem = currentRecord;
            currentRecord.IsChanged = true; // а теперь разрешаем ругаться :)
            myIsNew = true;
        }

        private void tsbDeleteItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
                MessageBox.Show("Выберите элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            else
                switch (myRecType)
            {
                case DataBaseType.TotalLossType:
                    if (myIsNew)// если режим создания, то записи нет в бд, поэтому ее удаляем из списка
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndices[0] - 1;
                        listBox1.Items.Remove(currentRecord);
                    }
                    else// в режиме просмотра выделена существующая запись - удаляем
                    {
                        Config.DP.DeleteTotalLoss((DataTotalLoss)listBox1.SelectedItems[0]);
                    }
                    break;
                case DataBaseType.RawType:
                    if (myIsNew)
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndices[0] - 1;
                        listBox1.Items.Remove(currentRecord);
                    }
                    else
                    {
                        Config.DP.DeleteRaw((DataRawStruct)listBox1.SelectedItems[0]);
                    }
                    break;
                case DataBaseType.ProcessLossType:
                    if (myIsNew)
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndices[0] - 1;
                        listBox1.Items.Remove(currentRecord);
                    }
                    else
                    {
                        Config.DP.DeleteProcessLoss((DataRawStruct)listBox1.SelectedItems[0]);
                    }
                    break;
                default:
                    throw new NotImplementedException("Not implemented");
            }
            myIsNew = false;
        }

        /// <summary>
        /// обработка закрытия формы (сохранение оставшихся записей)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentRecord != null && currentRecord.IsChanged)
            {
                DoSave();
            }
        }

        /// <summary>
        /// сохранение текущего элемента в бд или добавление
        /// </summary>
        private void DoSave()
        {
            DialogResult dlg = MessageBox.Show("Сохранить изменения?", "База данных", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            if (dlg == DialogResult.Yes)
            {
                SaveChanges();
            }else{
                CancelChanges();
            }
            myIsDataChanged = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// ф-я сохранения изменений
        /// </summary>
        internal void SaveChanges()
        {
            switch (myRecType)
            {
                case DataBaseType.TotalLossType:
                    if (myIsNew)
                    {
                        Config.DP.AddTotalLossStruct((DataTotalLoss)currentRecord);
                    }
                    else
                    {
                        Config.DP.UpdateTotalLossStruct((DataTotalLoss)currentRecord);
                    }
                    break;
                case DataBaseType.RawType:
                    if (myIsNew)
                    {
                        Config.DP.AddRaw((DataRawStruct)currentRecord);
                    }
                    else
                    {
                        Config.DP.UpdateRaw((DataRawStruct)currentRecord);
                    }
                    break;
                case DataBaseType.ProcessLossType:
                    if (myIsNew)
                    {
                        Config.DP.AddProcessLoss((DataRawStruct)currentRecord);
                    }else
                        Config.DP.UpdateProcessLoss((DataRawStruct)currentRecord);
                    break;
                default:
                    throw new Exception("Not implemented");
            }
            myIsNew = false;
            //currentRecord = null;
            //            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// ф-я отмены изменений
        /// </summary>
        internal void CancelChanges()
        {
            currentRecord = null;
            myIsNew = false;
            //Config.dp.Update();
            dp_Changed(null, new DataProviderEventArgs(myRecType));
            //throw new Exception("The method or operation is not implemented.");
        }

        private void tsbReload_Click(object sender, EventArgs e)
        {
            Config.DP.Update();
        }
    }
}