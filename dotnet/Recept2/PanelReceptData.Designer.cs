namespace Recept2
{
    partial class PanelReceptData
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.tbName = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.dgvRawList = new AdvancedDataGridView.TreeGridView();
        	this.dgvId = new AdvancedDataGridView.TreeGridColumn();
        	this.dgvRecName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dgvRecProcessLoss = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.dgvRecCountBrutto = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dgvRecCountNetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dgvRecComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tbNum = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.cbTotalLoss = new System.Windows.Forms.ComboBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.tbWater = new System.Windows.Forms.TextBox();
        	this.tbWaterPlus = new System.Windows.Forms.TextBox();
        	this.tbWaterMinus = new System.Windows.Forms.TextBox();
        	this.label7 = new System.Windows.Forms.Label();
        	this.tbTotalExit = new System.Windows.Forms.TextBox();
        	this.tbPreview = new System.Windows.Forms.TextBox();
        	this.label9 = new System.Windows.Forms.Label();
        	this.tbNormativDoc = new System.Windows.Forms.TextBox();
        	this.label10 = new System.Windows.Forms.Label();
        	this.tbSource = new System.Windows.Forms.TextBox();
        	this.cbName = new System.Windows.Forms.ComboBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.cbSetWater = new System.Windows.Forms.ComboBox();
        	this.rbSetWater = new System.Windows.Forms.RadioButton();
        	this.label11 = new System.Windows.Forms.Label();
        	this.tbCountExit = new System.Windows.Forms.TextBox();
        	this.label8 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.rbCalcExit = new System.Windows.Forms.RadioButton();
        	this.rbCalcWater = new System.Windows.Forms.RadioButton();
        	this.label12 = new System.Windows.Forms.Label();
        	this.tbAcidity = new System.Windows.Forms.TextBox();
        	this.label13 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRawList)).BeginInit();
        	this.groupBox1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tbName
        	// 
        	this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbName.Location = new System.Drawing.Point(84, 42);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(498, 20);
        	this.tbName.TabIndex = 0;
        	this.tbName.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(13, 45);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(57, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Название";
        	// 
        	// dgvRawList
        	// 
        	this.dgvRawList.AllowUserToAddRows = false;
        	this.dgvRawList.AllowUserToDeleteRows = false;
        	this.dgvRawList.AllowUserToResizeRows = false;
        	this.dgvRawList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        	dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
        	dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	this.dgvRawList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvRawList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.dgvId,
        	        	        	this.dgvRecName,
        	        	        	this.dgvRecProcessLoss,
        	        	        	this.dgvRecCountBrutto,
        	        	        	this.dgvRecCountNetto,
        	        	        	this.dgvRecComment});
        	dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
        	dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
        	dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
        	dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dgvRawList.DefaultCellStyle = dataGridViewCellStyle6;
        	this.dgvRawList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvRawList.ImageList = null;
        	this.dgvRawList.Location = new System.Drawing.Point(0, 283);
        	this.dgvRawList.MultiSelect = false;
        	this.dgvRawList.Name = "dgvRawList";
        	dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        	dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8F);
        	dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	this.dgvRawList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
        	dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        	this.dgvRawList.RowsDefaultCellStyle = dataGridViewCellStyle8;
        	this.dgvRawList.Size = new System.Drawing.Size(694, 223);
        	this.dgvRawList.TabIndex = 21;
        	this.dgvRawList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRawList_CellValueChanged);
        	this.dgvRawList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRawList_CellLeave);
        	this.dgvRawList.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRawList_UserAddedRow);
        	this.dgvRawList.Leave += new System.EventHandler(this.dgvRawList_Leave);
        	this.dgvRawList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRawList_DataError);
        	this.dgvRawList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRawList_CellEnter);
        	// 
        	// dgvId
        	// 
        	this.dgvId.DefaultNodeImage = null;
        	this.dgvId.HeaderText = "№ п/п";
        	this.dgvId.Name = "dgvId";
        	this.dgvId.ReadOnly = true;
        	this.dgvId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.dgvId.Width = 50;
        	// 
        	// dgvRecName
        	// 
        	dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	this.dgvRecName.DefaultCellStyle = dataGridViewCellStyle2;
        	this.dgvRecName.HeaderText = "Наименование сырья";
        	this.dgvRecName.Name = "dgvRecName";
        	this.dgvRecName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvRecName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.dgvRecName.Width = 200;
        	// 
        	// dgvRecProcessLoss
        	// 
        	dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	this.dgvRecProcessLoss.DefaultCellStyle = dataGridViewCellStyle3;
        	this.dgvRecProcessLoss.HeaderText = "Потери обработки";
        	this.dgvRecProcessLoss.Name = "dgvRecProcessLoss";
        	// 
        	// dgvRecCountBrutto
        	// 
        	dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        	this.dgvRecCountBrutto.DefaultCellStyle = dataGridViewCellStyle4;
        	this.dgvRecCountBrutto.HeaderText = "Масса брутто, г";
        	this.dgvRecCountBrutto.Name = "dgvRecCountBrutto";
        	this.dgvRecCountBrutto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	// 
        	// dgvRecCountNetto
        	// 
        	this.dgvRecCountNetto.HeaderText = "Масса нетто, г";
        	this.dgvRecCountNetto.Name = "dgvRecCountNetto";
        	this.dgvRecCountNetto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	// 
        	// dgvRecComment
        	// 
        	dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	this.dgvRecComment.DefaultCellStyle = dataGridViewCellStyle5;
        	this.dgvRecComment.HeaderText = "Комментарий";
        	this.dgvRecComment.Name = "dgvRecComment";
        	this.dgvRecComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	// 
        	// tbNum
        	// 
        	this.tbNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.tbNum.Location = new System.Drawing.Point(635, 42);
        	this.tbNum.Name = "tbNum";
        	this.tbNum.Size = new System.Drawing.Size(46, 20);
        	this.tbNum.TabIndex = 1;
        	this.tbNum.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// label2
        	// 
        	this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(588, 45);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(41, 13);
        	this.label2.TabIndex = 4;
        	this.label2.Text = "Номер";
        	// 
        	// cbTotalLoss
        	// 
        	this.cbTotalLoss.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        	this.cbTotalLoss.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this.cbTotalLoss.FormattingEnabled = true;
        	this.cbTotalLoss.Location = new System.Drawing.Point(207, 120);
        	this.cbTotalLoss.Name = "cbTotalLoss";
        	this.cbTotalLoss.Size = new System.Drawing.Size(164, 21);
        	this.cbTotalLoss.TabIndex = 4;
        	this.cbTotalLoss.TextChanged += new System.EventHandler(this.cbTextChanged);
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(16, 123);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(185, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Норма потерь холодной обработки";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(200, 16);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(13, 13);
        	this.label5.TabIndex = 8;
        	this.label5.Text = "+";
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(248, 16);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(13, 13);
        	this.label6.TabIndex = 9;
        	this.label6.Text = "—";
        	// 
        	// tbWater
        	// 
        	this.tbWater.Enabled = false;
        	this.tbWater.Location = new System.Drawing.Point(95, 13);
        	this.tbWater.Name = "tbWater";
        	this.tbWater.Size = new System.Drawing.Size(75, 20);
        	this.tbWater.TabIndex = 5;
        	this.tbWater.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbWaterPlus
        	// 
        	this.tbWaterPlus.Location = new System.Drawing.Point(219, 13);
        	this.tbWaterPlus.Name = "tbWaterPlus";
        	this.tbWaterPlus.Size = new System.Drawing.Size(23, 20);
        	this.tbWaterPlus.TabIndex = 6;
        	this.tbWaterPlus.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbWaterMinus
        	// 
        	this.tbWaterMinus.Location = new System.Drawing.Point(267, 13);
        	this.tbWaterMinus.Name = "tbWaterMinus";
        	this.tbWaterMinus.Size = new System.Drawing.Size(27, 20);
        	this.tbWaterMinus.TabIndex = 7;
        	this.tbWaterMinus.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label7.Location = new System.Drawing.Point(251, 0);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(171, 39);
        	this.label7.TabIndex = 13;
        	this.label7.Text = "Рецептура";
        	// 
        	// tbTotalExit
        	// 
        	this.tbTotalExit.Enabled = false;
        	this.tbTotalExit.Location = new System.Drawing.Point(95, 42);
        	this.tbTotalExit.Name = "tbTotalExit";
        	this.tbTotalExit.Size = new System.Drawing.Size(75, 20);
        	this.tbTotalExit.TabIndex = 8;
        	// 
        	// tbPreview
        	// 
        	this.tbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbPreview.Location = new System.Drawing.Point(0, 194);
        	this.tbPreview.Multiline = true;
        	this.tbPreview.Name = "tbPreview";
        	this.tbPreview.Size = new System.Drawing.Size(694, 83);
        	this.tbPreview.TabIndex = 9;
        	this.tbPreview.Text = "Краткое описание рецептуры";
        	// 
        	// label9
        	// 
        	this.label9.AutoSize = true;
        	this.label9.Location = new System.Drawing.Point(16, 71);
        	this.label9.Name = "label9";
        	this.label9.Size = new System.Drawing.Size(129, 13);
        	this.label9.TabIndex = 17;
        	this.label9.Text = "Нормативный документ";
        	// 
        	// tbNormativDoc
        	// 
        	this.tbNormativDoc.Location = new System.Drawing.Point(151, 68);
        	this.tbNormativDoc.Name = "tbNormativDoc";
        	this.tbNormativDoc.Size = new System.Drawing.Size(220, 20);
        	this.tbNormativDoc.TabIndex = 2;
        	// 
        	// label10
        	// 
        	this.label10.AutoSize = true;
        	this.label10.Location = new System.Drawing.Point(16, 97);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(95, 13);
        	this.label10.TabIndex = 19;
        	this.label10.Text = "Источник данных";
        	// 
        	// tbSource
        	// 
        	this.tbSource.Location = new System.Drawing.Point(151, 94);
        	this.tbSource.Name = "tbSource";
        	this.tbSource.Size = new System.Drawing.Size(220, 20);
        	this.tbSource.TabIndex = 3;
        	// 
        	// cbName
        	// 
        	this.cbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        	this.cbName.FormattingEnabled = true;
        	this.cbName.Location = new System.Drawing.Point(368, 348);
        	this.cbName.Name = "cbName";
        	this.cbName.Size = new System.Drawing.Size(121, 21);
        	this.cbName.TabIndex = 20;
        	this.cbName.TabStop = false;
        	this.cbName.Visible = false;
        	this.cbName.Leave += new System.EventHandler(this.cbName_Leave);
        	this.cbName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cbName_PreviewKeyDown);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox1.Controls.Add(this.cbSetWater);
        	this.groupBox1.Controls.Add(this.rbSetWater);
        	this.groupBox1.Controls.Add(this.label11);
        	this.groupBox1.Controls.Add(this.tbCountExit);
        	this.groupBox1.Controls.Add(this.label8);
        	this.groupBox1.Controls.Add(this.label4);
        	this.groupBox1.Controls.Add(this.rbCalcExit);
        	this.groupBox1.Controls.Add(this.rbCalcWater);
        	this.groupBox1.Controls.Add(this.tbTotalExit);
        	this.groupBox1.Controls.Add(this.tbWaterMinus);
        	this.groupBox1.Controls.Add(this.label6);
        	this.groupBox1.Controls.Add(this.tbWaterPlus);
        	this.groupBox1.Controls.Add(this.label5);
        	this.groupBox1.Controls.Add(this.tbWater);
        	this.groupBox1.Location = new System.Drawing.Point(387, 68);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(304, 99);
        	this.groupBox1.TabIndex = 22;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Основание расчета";
        	// 
        	// cbSetWater
        	// 
        	this.cbSetWater.FormattingEnabled = true;
        	this.cbSetWater.Location = new System.Drawing.Point(161, 68);
        	this.cbSetWater.Name = "cbSetWater";
        	this.cbSetWater.Size = new System.Drawing.Size(133, 21);
        	this.cbSetWater.TabIndex = 22;
        	this.cbSetWater.Visible = false;
        	// 
        	// rbSetWater
        	// 
        	this.rbSetWater.AutoSize = true;
        	this.rbSetWater.Location = new System.Drawing.Point(6, 69);
        	this.rbSetWater.Name = "rbSetWater";
        	this.rbSetWater.Size = new System.Drawing.Size(149, 17);
        	this.rbSetWater.TabIndex = 21;
        	this.rbSetWater.TabStop = true;
        	this.rbSetWater.Text = "Определить норму воды";
        	this.rbSetWater.UseVisualStyleBackColor = true;
        	this.rbSetWater.Visible = false;
        	this.rbSetWater.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
        	// 
        	// label11
        	// 
        	this.label11.AutoSize = true;
        	this.label11.Location = new System.Drawing.Point(267, 45);
        	this.label11.Name = "label11";
        	this.label11.Size = new System.Drawing.Size(20, 13);
        	this.label11.TabIndex = 20;
        	this.label11.Text = "шт";
        	// 
        	// tbCountExit
        	// 
        	this.tbCountExit.Location = new System.Drawing.Point(200, 42);
        	this.tbCountExit.Name = "tbCountExit";
        	this.tbCountExit.Size = new System.Drawing.Size(61, 20);
        	this.tbCountExit.TabIndex = 19;
        	this.tbCountExit.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// label8
        	// 
        	this.label8.AutoSize = true;
        	this.label8.Location = new System.Drawing.Point(176, 45);
        	this.label8.Name = "label8";
        	this.label8.Size = new System.Drawing.Size(12, 13);
        	this.label8.TabIndex = 18;
        	this.label8.Text = "г";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(176, 16);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(15, 13);
        	this.label4.TabIndex = 17;
        	this.label4.Text = "%";
        	// 
        	// rbCalcExit
        	// 
        	this.rbCalcExit.Location = new System.Drawing.Point(6, 39);
        	this.rbCalcExit.Name = "rbCalcExit";
        	this.rbCalcExit.Size = new System.Drawing.Size(83, 24);
        	this.rbCalcExit.TabIndex = 16;
        	this.rbCalcExit.TabStop = true;
        	this.rbCalcExit.Text = "Выход";
        	this.rbCalcExit.UseVisualStyleBackColor = true;
        	this.rbCalcExit.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
        	// 
        	// rbCalcWater
        	// 
        	this.rbCalcWater.Location = new System.Drawing.Point(6, 13);
        	this.rbCalcWater.Name = "rbCalcWater";
        	this.rbCalcWater.Size = new System.Drawing.Size(83, 24);
        	this.rbCalcWater.TabIndex = 15;
        	this.rbCalcWater.TabStop = true;
        	this.rbCalcWater.Text = "Влажность";
        	this.rbCalcWater.UseVisualStyleBackColor = true;
        	this.rbCalcWater.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
        	// 
        	// label12
        	// 
        	this.label12.AutoSize = true;
        	this.label12.Location = new System.Drawing.Point(243, 150);
        	this.label12.Name = "label12";
        	this.label12.Size = new System.Drawing.Size(72, 13);
        	this.label12.TabIndex = 23;
        	this.label12.Text = "Кислотность";
        	// 
        	// tbAcidity
        	// 
        	this.tbAcidity.Location = new System.Drawing.Point(321, 147);
        	this.tbAcidity.Name = "tbAcidity";
        	this.tbAcidity.Size = new System.Drawing.Size(50, 20);
        	this.tbAcidity.TabIndex = 24;
        	this.tbAcidity.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// label13
        	// 
        	this.label13.AutoSize = true;
        	this.label13.Location = new System.Drawing.Point(3, 178);
        	this.label13.Name = "label13";
        	this.label13.Size = new System.Drawing.Size(157, 13);
        	this.label13.TabIndex = 25;
        	this.label13.Text = "Краткое описание рецептуры";
        	// 
        	// PanelReceptData
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.label13);
        	this.Controls.Add(this.tbAcidity);
        	this.Controls.Add(this.label12);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.cbName);
        	this.Controls.Add(this.tbSource);
        	this.Controls.Add(this.label10);
        	this.Controls.Add(this.tbNormativDoc);
        	this.Controls.Add(this.label9);
        	this.Controls.Add(this.tbPreview);
        	this.Controls.Add(this.label7);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.cbTotalLoss);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.tbNum);
        	this.Controls.Add(this.dgvRawList);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.tbName);
        	this.Name = "PanelReceptData";
        	this.Size = new System.Drawing.Size(694, 506);
        	((System.ComponentModel.ISupportInitialize)(this.dgvRawList)).EndInit();
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbAcidity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSetWater;
        private System.Windows.Forms.RadioButton rbSetWater;
        private System.Windows.Forms.TextBox tbCountExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbCalcWater;
        private System.Windows.Forms.RadioButton rbCalcExit;
        private System.Windows.Forms.GroupBox groupBox1;

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private AdvancedDataGridView.TreeGridView dgvRawList;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTotalLoss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbWater;
        private System.Windows.Forms.TextBox tbWaterPlus;
        private System.Windows.Forms.TextBox tbWaterMinus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTotalExit;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNormativDoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSource;
        private AdvancedDataGridView.TreeGridColumn dgvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvRecProcessLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecCountBrutto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecCountNetto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecComment;
        private System.Windows.Forms.ComboBox cbName;
    }
}
