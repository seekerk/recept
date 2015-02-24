using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using AdvancedDataGridView;

namespace Recept2
{
	public partial class PanelReceptData : UserControl
	{
		DataRecept myData;
		SortableBindingList<DataTotalLoss> myTotalLoss;
		SortableBindingList<DataRawStruct> myRaw;
		SortableBindingList<DataRawStruct> myProcessLoss;

		public PanelReceptData ()
		{
			InitializeComponent ();
			Config.DP.Changed += new EventHandler<DataProviderEventArgs> (dp_Changed);
			//cbName.Parent = dgvRawList;
			cbTotalLoss.DisplayMember = "DisplayMember";
			cbTotalLoss.ValueMember = "ValueMember";
			cbName.DisplayMember = "DisplayMember";
			cbName.ValueMember = "ValueMember";
			cbSetWater.DisplayMember = "DisplayMember";
			cbSetWater.ValueMember = "ValueMember";
			dgvRecProcessLoss.DisplayMember = "DisplayMember";
			dgvRecProcessLoss.ValueMember = "ValueMember";
		}

		void dp_Changed (object sender, DataProviderEventArgs args)
		{
			if (args.TotalLossChanged) {
				if (myTotalLoss != null) {
					myTotalLoss = Config.DP.TotalLossList;
					cbTotalLoss.Items.Clear ();
					cbTotalLoss.Items.AddRange (myTotalLoss.ToArray ());
				}
			}
			if (args.RawChanged) {
				if (myRaw != null) {
					myRaw = Config.DP.RawList;
					cbName.Items.Clear ();
					cbName.Items.AddRange (myRaw.ToArray ());
				}
			}
			if (args.ProcessLossChanged) {
				if (myProcessLoss != null) {
					myProcessLoss = Config.DP.ProcessLossList;
					dgvRecProcessLoss.Items.Clear ();
					dgvRecProcessLoss.Items.AddRange (myProcessLoss.ToArray ());
				}
			}
			//throw new Exception("The method or operation is not implemented.");
		}

		internal void LoadData (DataRecept data)
		{
			this.tbName.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbNum.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbWater.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbWaterPlus.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbWaterMinus.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbTotalExit.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbNormativDoc.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbSource.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.tbPreview.TextChanged -= new System.EventHandler (this.tbTextChanged);
			this.cbTotalLoss.TextChanged -= new System.EventHandler (this.cbTextChanged);
			this.tbAcidity.TextChanged -= new System.EventHandler(this.tbTextChanged);
			dgvRawList.CellValueChanged -= new DataGridViewCellEventHandler (dgvRawList_CellValueChanged);
			
			myData = data;
			// настраиваем список потерь
			if (myTotalLoss == null) {
				myTotalLoss = Config.DP.TotalLossList;
				cbTotalLoss.Items.Clear ();
				if (myTotalLoss != null && myTotalLoss.Count > 0)
					cbTotalLoss.Items.AddRange (myTotalLoss.ToArray ());
			}
			
			// настраиваем список компонент
			if (myRaw == null) {
				myRaw = Config.DP.RawList;
				cbName.Items.Clear ();
				cbSetWater.Items.Clear ();
				if (myRaw != null && myRaw.Count > 0) {
					cbName.Items.AddRange (myRaw.ToArray ());
					cbSetWater.Items.AddRange (myRaw.ToArray ());
				}
			}
			
			// настраиваем список производственных потерь
			if (myProcessLoss == null) {
				myProcessLoss = Config.DP.ProcessLossList;
				dgvRecProcessLoss.Items.Clear ();
				if (myProcessLoss != null && myProcessLoss.Count > 0)
					dgvRecProcessLoss.Items.AddRange (myProcessLoss.ToArray ());
			}
			
			// шапка формы
			tbName.Text = data.Name;
			tbNum.Text = data.Id.ToString (CultureInfo.CurrentCulture);
			tbWater.Text = data.water.ToString (CultureInfo.CurrentCulture);
			tbWaterPlus.Text = data.waterPlus.ToString (CultureInfo.CurrentCulture);
			tbWaterMinus.Text = data.waterMinus.ToString (CultureInfo.CurrentCulture);
			tbTotalExit.Text = data.TotalExit.ToString (CultureInfo.CurrentCulture);
			tbCountExit.Text = data.CountExit.ToString (CultureInfo.CurrentCulture);
			tbPreview.Text = data.preview;
			tbSource.Text = data.source;
			tbNormativDoc.Text = data.normativDoc;
			if (data.totalLoss != null) {
				cbTotalLoss.SelectedIndex = data.totalLoss.TotalLossNum;
			} else {
				cbTotalLoss.SelectedIndex = 0;
			}
			tbAcidity.Text = data.Acidity.ToString(CultureInfo.CurrentCulture);
			// TODO: добавить хранение элемента "вода" в настройках проги и включить отображение пункта когда он будет готов
			
			// тело формы
			dgvRawList.Nodes.Clear ();
			//dgvRawList.Rows.Clear();
			LoadReceptData (dgvRawList.Nodes, data);
			//MessageBox.Show("Start Load2: " + dgvRawList.Nodes.Count);
			rbCalcExit.Checked = data.isCalcExit;
			rbCalcWater.Checked = data.isCalcWater;
			rbSetWater.Checked = data.isSetWater;
			
			this.tbName.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbNum.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbWater.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbWaterPlus.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbWaterMinus.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbTotalExit.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbNormativDoc.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbSource.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.tbPreview.TextChanged += new System.EventHandler (this.tbTextChanged);
			this.cbTotalLoss.TextChanged += new System.EventHandler (this.cbTextChanged);
			dgvRawList.CellValueChanged += new DataGridViewCellEventHandler (dgvRawList_CellValueChanged);
			this.tbAcidity.TextChanged += new System.EventHandler (this.tbTextChanged);
			
			// Устанавливаем радиокнопки выбора
			//            this.rbCalcWater.CheckedChanged -= new System.EventHandler(this.RbCheckedChanged);
			//            this.rbCalcExit.CheckedChanged -= new System.EventHandler(this.RbCheckedChanged);
			//            this.rbSetWater.CheckedChanged -= new System.EventHandler(this.RbCheckedChanged);
			//            rbCalcExit.Checked = data.isCalcExit;
			//            rbCalcWater.Checked = data.isCalcWater;
			//            rbSetWater.Checked = data.isSetWater;
			//            this.rbCalcWater.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
			//            this.rbCalcExit.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
			//            this.rbSetWater.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
			
			myData.Changed += new EventHandler<DataBaseEventArgs> (_data_Changed);
		}

		/// <summary>
		/// Загрузка дерева рецептур в таблицу
		/// </summary>
		/// <param name="nodes">коллекция строк</param>
		/// <param name="data">рецептура</param>
		private void LoadReceptData (TreeGridNodeCollection nodes, DataRecept data)
		{
			TreeGridNode curNode = null;
			foreach (DataBase dr in data.Components) {
				//MessageBox.Show("Start Load: " + dr.name);
				
				// если компонента рецептуры есть сама рецептура, то делаем рекурсию
				if (dr is DataRecept) {
					DataRecept rec = dr as DataRecept;
					curNode = new TreeGridNode ();
					curNode.DefaultCellStyle.BackColor = Color.LightGray;
					curNode.Tag = rec;
					nodes.Add (curNode);
					curNode.Cells[dgvRecName.Index].Value = rec.Name;
					curNode.Cells[dgvRecCountNetto.Index].Value = rec.TotalExit;
					LoadReceptData (curNode.Nodes, rec);
					continue;
				}
				
				// иначе это обычная компонента и мы ее загружаем в корень
				DataRaw curRaw = dr as DataRaw;
				curNode = new TreeGridNode ();
				curNode.Tag = curRaw;
				nodes.Add (curNode);
				curNode.Cells[dgvRecCountNetto.Index].Value = (curRaw.Quantity != 0 ? curRaw.Quantity.ToString (CultureInfo.CurrentCulture) : string.Empty);
				curNode.Cells[dgvRecCountBrutto.Index].Value = (curRaw.Brutto != 0 ? curRaw.Brutto.ToString (CultureInfo.CurrentCulture) : string.Empty);
				curNode.Cells[dgvRecComment.Index].Value = curRaw.Comment;
				if (curRaw.RawStruct != null) {
					curNode.Cells[dgvRecName.Index].Value = curRaw.RawStruct.DisplayMember;
					if (curRaw.Brutto == 0 && curRaw.Quantity != 0 && curRaw.RawStruct.Brutto != 0) {
						curNode.Cells[dgvRecCountBrutto.Index].Value = CommonFunctions.Round (curRaw.Quantity * curRaw.RawStruct.Brutto);
					}
					if (curRaw.Quantity == 0 && curRaw.RawStruct.Brutto != 0 && curRaw.Brutto != 0) {
						curNode.Cells[dgvRecCountNetto.Index].Value = CommonFunctions.Round (curRaw.Brutto / curRaw.RawStruct.Brutto);
					}
				}
				if (curRaw.ProcessLoss != null) {
					(curNode.Cells[dgvRecProcessLoss.Index] as DataGridViewComboBoxCell).Value = curRaw.ProcessLoss.ValueMember;
				}
			}
			
			// добавляем пустую новую строку для каждой рецептуры
			nodes.Add (new TreeGridNode ());
		}

		void _data_Changed (object sender, DataBaseEventArgs args)
		{
			myData.Changed -= new EventHandler<DataBaseEventArgs> (_data_Changed);
			if (!tbName.Text.Equals (myData.Name)) {
				this.tbName.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbName.Text = myData.Name;
				this.tbName.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (!tbNum.Text.Equals (myData.Id.ToString (CultureInfo.CurrentCulture))) {
				this.tbNum.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbNum.Text = myData.Id.ToString (CultureInfo.CurrentCulture);
				this.tbNum.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (!tbWater.Text.Equals (myData.water.ToString (CultureInfo.CurrentCulture))) {
				this.tbWater.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbWater.Text = myData.water.ToString (CultureInfo.CurrentCulture);
				this.tbWater.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (!tbAcidity.Text.Equals (myData.Acidity.ToString (CultureInfo.CurrentCulture))) {
				tbAcidity.Text = myData.Acidity.ToString (CultureInfo.CurrentCulture);
			}
			if (!tbWaterPlus.Text.Equals (myData.waterPlus.ToString (CultureInfo.CurrentCulture))) {
				this.tbWaterPlus.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbWaterPlus.Text = myData.waterPlus.ToString (CultureInfo.CurrentCulture);
				this.tbWaterPlus.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (!tbWaterMinus.Text.Equals (myData.waterMinus.ToString (CultureInfo.CurrentCulture))) {
				this.tbWaterMinus.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbWaterMinus.Text = myData.waterMinus.ToString (CultureInfo.CurrentCulture);
				this.tbWaterMinus.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			tbTotalExit.Text = myData.TotalExit.ToString (CultureInfo.CurrentCulture);
			tbCountExit.Text = myData.CountExit.ToString (CultureInfo.CurrentCulture);
			if (!tbSource.Text.Equals (myData.source)) {
				this.tbSource.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbSource.Text = myData.source;
				this.tbSource.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (!tbPreview.Text.Equals (myData.preview)) {
				this.tbPreview.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbPreview.Text = myData.preview;
				this.tbPreview.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (!tbNormativDoc.Text.Equals (myData.normativDoc)) {
				this.tbNormativDoc.TextChanged -= new System.EventHandler (this.tbTextChanged);
				tbNormativDoc.Text = myData.normativDoc;
				this.tbNormativDoc.TextChanged += new System.EventHandler (this.tbTextChanged);
			}
			if (myData.totalLoss != null && cbTotalLoss.SelectedIndex != myData.totalLoss.TotalLossNum) {
				this.cbTotalLoss.TextChanged -= new System.EventHandler (this.cbTextChanged);
				cbTotalLoss.SelectedIndex = myData.totalLoss.TotalLossNum;
				this.cbTotalLoss.TextChanged += new System.EventHandler (this.cbTextChanged);
			}
			if (!rbCalcExit.Checked.Equals (myData.isCalcExit)) {
				this.rbCalcExit.CheckedChanged -= new System.EventHandler (this.RbCheckedChanged);
				rbCalcExit.Checked = myData.isCalcExit;
				this.rbCalcExit.CheckedChanged += new System.EventHandler (this.RbCheckedChanged);
			}
			if (!rbCalcWater.Checked.Equals (myData.isCalcWater)) {
				this.rbCalcWater.CheckedChanged -= new System.EventHandler (this.RbCheckedChanged);
				rbCalcWater.Checked = myData.isCalcWater;
				this.rbCalcWater.CheckedChanged += new System.EventHandler (this.RbCheckedChanged);
			}
			if (!rbSetWater.Checked.Equals (myData.isSetWater)) {
				this.rbSetWater.CheckedChanged -= new System.EventHandler (this.RbCheckedChanged);
				rbSetWater.Checked = myData.isSetWater;
				this.rbSetWater.CheckedChanged += new System.EventHandler (this.RbCheckedChanged);
			}
			// проверка данных таблицы
			dgvRawList.CellValueChanged -= new DataGridViewCellEventHandler (dgvRawList_CellValueChanged);
			// удаление и обновление существующих
			CheckReceptData (dgvRawList.Nodes, myData);
			dgvRawList.CellValueChanged += new DataGridViewCellEventHandler (dgvRawList_CellValueChanged);
			myData.Changed += new EventHandler<DataBaseEventArgs> (_data_Changed);
		}

		/// <summary>
		/// Проверка данных формы и данных рецептуры
		/// </summary>
		/// <param name="root">дерево строк формы</param>
		/// <param name="curRec">рецептура</param>
		private void CheckReceptData (TreeGridNodeCollection root, DataRecept curRec)
		{
			ArrayList toDelete = new ArrayList ();
			
			TreeGridNode lastNode = null;
			
			// собираем строчки для удаления
			if (dgvRawList.Nodes.Count > 0)
				foreach (TreeGridNode dr in root) {
				// если это пустая последняя строчка, то пропускаем
				if (dr.Tag == null) {
					if (lastNode == null) {
						lastNode = dr;
					} else
						toDelete.Add (dr);
					continue;
				}
				
				DataBase curBase = (DataBase)dr.Tag;
				if (!curRec.Components.Contains (curBase)) {
					toDelete.Add (dr);
					continue;
				}
				
				// если это рецептура, то рекурсия проверки
				if (curBase is DataRecept) {
					CheckReceptData (dr.Nodes, curBase as DataRecept);
					continue;
				}
				
				DataRaw curRaw = curBase as DataRaw;
				if (curRaw.RawStruct != null) {
					if (!curRaw.RawStruct.DisplayMember.Equals (dr.Cells[dgvRecName.Index].Value)) {
						dr.Cells[dgvRecName.Index].Value = curRaw.RawStruct.DisplayMember;
					}
				}
				if (!((Decimal)curRaw.Brutto).Equals (dr.Cells[dgvRecCountBrutto.Index].Value)) {
					dr.Cells[dgvRecCountBrutto.Index].Value = curRaw.Brutto;
				}
				if (curRaw.ProcessLoss != null) {
					if (!curRaw.ProcessLoss.ValueMember.Equals ((dr.Cells[dgvRecProcessLoss.Index] as DataGridViewComboBoxCell).Value)) {
						dr.Cells[dgvRecProcessLoss.Index].Value = curRaw.ProcessLoss.ValueMember;
					}
				}
				if (!curRaw.Quantity.Equals (dr.Cells[dgvRecCountNetto.Index].Value)) {
					dr.Cells[dgvRecCountNetto.Index].Value = curRaw.Quantity;
				}
				if (!curRaw.Comment.Equals (dr.Cells[dgvRecComment.Index].Value)) {
					dr.Cells[dgvRecComment.Index].Value = curRaw.Comment;
				}
				if (curRaw.RawStruct != null) {
					if (curRaw.Brutto == 0 && curRaw.Quantity != 0) {
						dr.Cells[dgvRecCountBrutto.Index].Value = CommonFunctions.Round (curRaw.Quantity * curRaw.RawStruct.Brutto);
					}
					if (curRaw.Quantity == 0 && curRaw.Brutto != 0 && curRaw.RawStruct.Brutto != 0) {
						dr.Cells[dgvRecCountNetto.Index].Value = CommonFunctions.Round (curRaw.Brutto / curRaw.RawStruct.Brutto);
					}
				}
			}
			if (toDelete.Count > 0) {
				foreach (TreeGridNode dr in toDelete) {
					root.Remove (dr);
				}
			}
			
			// добавление новых
			if (curRec.Components.Count > 0) {
				foreach (DataBase newRec in curRec.Components) {
					Boolean isExists = false;
					foreach (TreeGridNode dr in root) {
						if (newRec.Equals (dr.Tag)) {
							isExists = true;
							break;
						}
					}
					if (!isExists) {
						TreeGridNode node = new TreeGridNode ();
						node.Tag = newRec;
						root.Add (node);
						
						if (newRec is DataRecept) {
							//TreeGridNode curNode = root.Add(null, newRec.name, null, null, (newRec as DataRecept).totalExit, newRec.comment);
							node.Cells[dgvRecName.Index].Value = newRec.Name;
							node.Cells[dgvRecCountNetto.Index].Value = (newRec as DataRecept).TotalExit;
							node.DefaultCellStyle.BackColor = Color.LightGray;
							LoadReceptData (node.Nodes, newRec as DataRecept);
							continue;
						}
						
						DataRaw curRaw = newRec as DataRaw;
						//TreeGridNode newNode = root.Add(curRaw.id, null, null, curRaw.brutto, curRaw.quantity, curRaw.comment);
						node.Cells[dgvRecCountBrutto.Index].Value = curRaw.Brutto;
						node.Cells[dgvRecCountNetto.Index].Value = curRaw.Quantity;
						node.Cells[dgvRecComment.Index].Value = curRaw.Comment;
						if (curRaw.RawStruct != null) {
							node.Cells[dgvRecName.Index].Value = curRaw.RawStruct.DisplayMember;
							if (curRaw.Brutto == 0 && curRaw.Quantity != 0 && curRaw.RawStruct.Brutto != 0) {
								node.Cells[dgvRecCountBrutto.Index].Value = CommonFunctions.Round (curRaw.Quantity * curRaw.RawStruct.Brutto);
							}
							if (curRaw.Brutto != 0 && curRaw.Quantity == 0 && curRaw.RawStruct.Brutto != 0) {
								node.Cells[dgvRecCountNetto.Index].Value = CommonFunctions.Round (curRaw.Brutto / curRaw.RawStruct.Brutto);
							}
						}
						if (curRaw.ProcessLoss != null) {
							(node.Cells[dgvRecProcessLoss.Index] as DataGridViewComboBoxCell).Value = curRaw.ProcessLoss.ValueMember;
						}
					}
				}
			}
			
			// проверяем, чтобы последняя строчка была последней
			if (dgvRawList.Nodes.Count > 0 && (lastNode == null || !lastNode.IsLastSibling)) {
				root.Add (new TreeGridNode ());
				if (lastNode != null)
					root.Remove (lastNode);
			}
		}

		private void tbTextChanged (object sender, EventArgs e)
		{
			TextBox tbCur = (TextBox)sender;
			bool isCorrectValue = true;
			
			if (tbCur.Equals (tbName)) {
				if (tbName.Text.Length == 0) {
					tbName.BackColor = Color.Yellow;
				} else {
					myData.Name = tbName.Text;
					tbName.BackColor = Color.White;
				}
			}
			
			if (tbCur.Equals (tbPreview)) {
				if (!tbCur.Text.Equals (myData.preview)) {
					myData.preview = tbCur.Text;
				}
			}
			
			if (tbCur.Equals (tbSource)) {
				if (!tbCur.Text.Equals (myData.source)) {
					myData.source = tbCur.Text;
				}
			}
			
			if (tbCur.Equals (tbNormativDoc)) {
				if (!tbCur.Text.Equals (myData.normativDoc)) {
					myData.normativDoc = tbCur.Text;
				}
			}
			
			if (tbCur.Equals (tbNum)) {
				int ret = myData.Id;
				try {
					ret = Convert.ToInt32 (tbNum.Text, CultureInfo.CurrentCulture);
					if (ret < 0) {
						throw new OverflowException ();
					}
					tbNum.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbNum.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbNum.BackColor = Color.Yellow;
				}
				if (isCorrectValue && myData.Id != ret)
					myData.Id = ret;
			}
			
			if (tbCur.Equals (this.tbAcidity)) {
				decimal ret = myData.Acidity;
				try {
					ret = Convert.ToDecimal (tbCur.Text, CultureInfo.CurrentCulture);
					if (ret < 0) {
						throw new OverflowException ();
					}
					tbCur.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				}
				if (isCorrectValue && myData.Acidity != ret)
					myData.Acidity = ret;
			}
			
			if (tbCur.Equals (tbWater)) {
				Decimal ret = myData.water;
				try {
					ret = Convert.ToDecimal (tbWater.Text, CultureInfo.CurrentCulture);
					if (ret < 0 || ret > 100) {
						throw new OverflowException ();
					}
					tbWater.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				}
				if (isCorrectValue && ret != myData.water)
					myData.water = ret;
			}
			
			if (tbCur.Equals (tbWaterPlus)) {
				Decimal ret = myData.waterPlus;
				try {
					ret = Convert.ToDecimal (tbWaterPlus.Text, CultureInfo.CurrentCulture);
					if (ret < 0 || ret > 100) {
						throw new OverflowException ();
					}
					tbWaterPlus.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				}
				if (isCorrectValue && ret != myData.waterPlus) {
					myData.waterPlus = ret;
				}
			}
			
			if (tbCur.Equals (tbWaterMinus)) {
				Decimal ret = myData.waterMinus;
				try {
					ret = Convert.ToDecimal (tbWaterMinus.Text, CultureInfo.CurrentCulture);
					if (ret < 0 || ret > 100) {
						throw new OverflowException ();
					}
					tbWaterMinus.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				}
				if (isCorrectValue && ret != myData.waterMinus) {
					myData.waterMinus = ret;
				}
			}
			if (tbCur.Equals (tbTotalExit)) {
				Decimal ret = myData.TotalExit;
				try {
					ret = Convert.ToDecimal (tbTotalExit.Text, CultureInfo.CurrentCulture);
					if (ret < 0) {
						throw new OverflowException ();
					}
					tbTotalExit.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				}
				if (isCorrectValue && ret != myData.TotalExit) {
					myData.TotalExit = ret;
				}
			}
			if (tbCur.Equals (tbCountExit)) {
				Decimal ret = myData.CountExit;
				try {
					ret = Convert.ToDecimal (tbCountExit.Text, CultureInfo.CurrentCulture);
					if (ret < 0) {
						throw new OverflowException ();
					}
					tbCountExit.BackColor = Color.White;
				} catch (OverflowException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				} catch (FormatException) {
					isCorrectValue = false;
					tbCur.BackColor = Color.Yellow;
				}
				if (isCorrectValue && ret != myData.CountExit) {
					myData.CountExit = ret;
				}
			}
		}

		private void cbTextChanged (object sender, EventArgs e)
		{
			ComboBox cbCur = (ComboBox)sender;
			
			if (cbCur.Equals (cbTotalLoss)) {
				myData.totalLoss = (cbTotalLoss.SelectedIndex == -1 ? null : (DataTotalLoss)cbTotalLoss.SelectedItem);
			}
		}

		private void dgvRawList_CellValueChanged (object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0) {
				return;
			}
			
			TreeGridNode curNode = dgvRawList.GetNodeForRow (e.RowIndex);
			object curValue = dgvRawList[e.ColumnIndex, e.RowIndex].Value;
			DataBase curRec = curNode.Tag as DataBase;
			bool isNew = curNode.Tag == null ? true : false;
			
			if (curValue == null && isNew) {
				return;
			}
			
			dgvRawList.CellValueChanged -= new DataGridViewCellEventHandler (dgvRawList_CellValueChanged);
			
			// родительский объект
			DataBase par = curRec == null ? myData : curRec.Parent;
			if (curRec == null && curNode.Parent != null && curNode.Parent.Index >= 0 && curNode.Parent.Tag != null) {
				par = curNode.Parent.Tag as DataBase;
			}
			
			// если это последняя строчка, то добавляем следующую пустую, а для этой делаем структуру
			if (isNew) {
				curRec = new DataRaw (par);
			}
			
			if (curRec is DataRecept) {
				DataRecept curRecept = (DataRecept)curRec;
				// изменение имени
				if (e.ColumnIndex == dgvRecName.Index && !curRecept.Name.Equals (curValue)) {
					if (curValue == null || curValue.ToString ().Length == 0) {
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;
					} else {
						curRecept.Name = curValue.ToString ();
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGray;
					}
				}
				
				// изменение выхода
				if (e.ColumnIndex == dgvRecCountNetto.Index) {
					try {
						curRecept.TotalExit = Convert.ToDecimal (curValue, CultureInfo.CurrentCulture);
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGray;
					} catch (System.Exception) {
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;
					}
				}
				// обработка компоненты
			} else {
				DataRaw curData = (DataRaw)curRec;
				
				// изменение потерь
				if (e.ColumnIndex == dgvRecProcessLoss.Index) {
					curData.ProcessLoss = Config.DP.GetProcessLossByNum (Convert.ToInt32 (curValue, CultureInfo.CurrentCulture));
				}
				
				decimal brutto = 0;
				if (curData.RawStruct != null && curData.RawStruct.Brutto != 0) {
					brutto = curData.RawStruct.Brutto;
				}
				// изменение нетто
				if (e.ColumnIndex == dgvRecCountNetto.Index) {
					try {
						curData.Quantity = Convert.ToDecimal (curValue, CultureInfo.CurrentCulture);
						if (curData.Brutto == 0 && curData.Quantity != 0 && brutto != 0) {
							dgvRawList[dgvRecCountBrutto.Index, e.RowIndex].Value = CommonFunctions.Round (curData.Quantity * brutto);
						}
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
					} catch (System.Exception) {
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;
					}
				}
				
				// изменение брутто
				if (e.ColumnIndex == dgvRecCountBrutto.Index) {
					try {
						((DataRaw)curData).Brutto = Convert.ToDecimal (curValue, CultureInfo.CurrentCulture);
						if (curData.Quantity == 0 && curData.Brutto != 0 && brutto != 0) {
							dgvRawList[dgvRecCountNetto.Index, e.RowIndex].Value = CommonFunctions.Round (((DataRaw)curData).Brutto / brutto);
						}
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
					} catch (System.Exception) {
						dgvRawList[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow;
					}
				}
				
				// изменение коммента
				if (e.ColumnIndex == dgvRecComment.Index) {
					curData.Comment = Convert.ToString (dgvRawList[e.ColumnIndex, e.RowIndex].Value, CultureInfo.CurrentCulture);
				}
			}
			
			if (isNew) {
				par.Components.Add (curRec);
			}
			
			dgvRawList.CellValueChanged += new DataGridViewCellEventHandler (dgvRawList_CellValueChanged);
			
		}

		/// <summary>
		/// Обработка таблицы после добавления пользователем новых строк
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvRawList_UserAddedRow (object sender, DataGridViewRowEventArgs e)
		{
			foreach (DataGridViewRow dr in dgvRawList.Rows) {
				if (dr.IsNewRow || dr.Tag != null) {
					continue;
				}
				DataRaw raw = new DataRaw (myData);
				dr.Tag = raw;
				myData.Components.Add (raw);
			}
		}


		internal DataBase GetSelectedComponent ()
		{
			if (dgvRawList.SelectedRows.Count > 0) {
				return (DataBase)dgvRawList.SelectedRows[0].Tag;
			}
			if (dgvRawList.SelectedCells.Count > 0) {
				return (DataBase)dgvRawList.Rows[dgvRawList.SelectedCells[0].RowIndex].Tag;
			}
			
			return null;
			//throw new Exception("The method or operation is not implemented.");
		}

		private void dgvRawList_CellEnter (object sender, DataGridViewCellEventArgs e)
		{
			TreeGridNode curNode = dgvRawList.GetNodeForRow (e.RowIndex);
			
			if (curNode.Tag != null && curNode.Tag is DataRecept) {
				if (e.ColumnIndex == dgvRecName.Index || e.ColumnIndex == dgvRecCountNetto.Index) {
					dgvRawList.BeginEdit (false);
				}
				return;
			}
			
			if (e.ColumnIndex == dgvRecName.Index) {
				Rectangle pos = dgvRawList.GetCellDisplayRectangle (e.ColumnIndex, e.RowIndex, true);
				if (!cbName.Visible || cbName.Top != pos.Top + dgvRawList.Top || cbName.Left != pos.Left + dgvRawList.Left) {
					cbName.Top = pos.Top + dgvRawList.Top;
					cbName.Width = pos.Width;
					cbName.Left = pos.Left + dgvRawList.Left;
					cbName.Height = pos.Height;
					cbName.Tag = curNode;
					if (curNode.Tag != null)
						cbName.SelectedItem = (curNode.Tag as DataRaw).RawStruct;
					else
						cbName.SelectedIndex = -1;
					cbName.Visible = true;
					//dgvRawList.BeginEdit(false);
					cbName.Focus ();
				}
			} else {
				cbName.Visible = false;
				dgvRawList.BeginEdit (false);
			}
			
			// столбец брутто
			if (e.ColumnIndex == dgvRecCountBrutto.Index && dgvRawList.GetNodeForRow (e.RowIndex).Tag != null) {
				// убираем нулевые брутто и нетто если они есть
				if (dgvRawList[dgvRecCountBrutto.Index, e.RowIndex].Value.Equals ("0"))
					dgvRawList[dgvRecCountBrutto.Index, e.RowIndex].Value = "";
			}
			// столбец нетто
			if (e.ColumnIndex == dgvRecCountNetto.Index && dgvRawList.GetNodeForRow (e.RowIndex).Tag != null) {
				if (dgvRawList[dgvRecCountNetto.Index, e.RowIndex].Value.Equals ("0"))
					dgvRawList[dgvRecCountNetto.Index, e.RowIndex].Value = "";
			}
		}

		private void dgvRawList_DataError (object sender, DataGridViewDataErrorEventArgs e)
		{
			e.Cancel = true;
		}

		/// <summary>
		/// окончание работы со списком
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbName_Leave (object sender, EventArgs e)
		{
			//cbName.Visible = false;
			
			TreeGridNode curNode = cbName.Tag as TreeGridNode;
			DataRawStruct curSel = cbName.SelectedItem as DataRawStruct;
			
			if (curNode == null || curSel == null) {
				return;
			}
			
			DataRaw curRaw = curNode.Tag as DataRaw;
			
			// родительский объект
			DataBase par = curRaw == null ? myData : curRaw.Parent;
			
			// определение родительского объекта
			if (curRaw == null && curNode.Parent != null && curNode.Parent.Index >= 0 && curNode.Parent.Tag != null) {
				par = curNode.Parent.Tag as DataBase;
			}
			
			// если
			if (curRaw == null) {
				curRaw = new DataRaw (par);
				//curNode.Tag = curRaw;
				//if (curNode.Parent == null)
				//    dgvRawList.Nodes.Add(null, null, null, null, null, null);
				//else
				//    curNode.Parent.Nodes.Add(null, null, null, null, null, null);
			}
			
			if (curSel != null) {
				curRaw.RawStruct = curSel;
			} else {
				if (curRaw.RawStruct != null) {
					curRaw.RawStruct = null;
				}
			}
			if (curNode.Tag == null) {
				par.Components.Add (curRaw);
			}
			//curNode.Selected = true;
			
			//dgvRawList.EndEdit();
			//dgvRawList.Focus();
		}

		private void cbName_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode != Keys.Tab)
				cbName.DroppedDown = true;
		}

		private void dgvRawList_CellLeave (object sender, DataGridViewCellEventArgs e)
		{
			// столбец брутто
			if (e.ColumnIndex == dgvRecCountBrutto.Index && dgvRawList.GetNodeForRow (e.RowIndex).Tag != null) {
				// убираем нулевые брутто и нетто если они есть
				if (dgvRawList[dgvRecCountBrutto.Index, e.RowIndex].Value.Equals (""))
					dgvRawList[dgvRecCountBrutto.Index, e.RowIndex].Value = "0";
			}
			// столбец нетто
			if (e.ColumnIndex == dgvRecCountNetto.Index && dgvRawList.GetNodeForRow (e.RowIndex).Tag != null) {
				if (dgvRawList[dgvRecCountNetto.Index, e.RowIndex].Value.Equals (""))
					dgvRawList[dgvRecCountNetto.Index, e.RowIndex].Value = "0";
			}
		}

		private void dgvRawList_Leave (object sender, EventArgs e)
		{
			cbName.Visible = false;
		}

		/// <summary>
		/// Реакция на выбор методики расчета
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RbCheckedChanged (object sender, EventArgs e)
		{
			if (myData.isCalcWater != rbCalcWater.Checked && rbCalcWater.Checked)
				myData.isCalcWater = rbCalcWater.Checked;
			if (myData.isCalcExit != rbCalcExit.Checked && rbCalcExit.Checked)
				myData.isCalcExit = rbCalcExit.Checked;
			if (myData.isSetWater != rbSetWater.Checked && rbSetWater.Checked)
				myData.isSetWater = rbSetWater.Checked;
			if (rbCalcWater.Checked) {
				tbWater.Enabled = true;
				cbSetWater.Enabled = false;
			} else
				tbWater.Enabled = false;
			if (rbCalcExit.Checked) {
				tbTotalExit.Enabled = true;
			} else
				tbTotalExit.Enabled = false;
			if (rbSetWater.Checked) {
				tbTotalExit.Enabled = true;
				cbSetWater.Enabled = true;
				tbWater.Enabled = true;
			} else {
				cbSetWater.Enabled = false;
			}
		}
	}
}
