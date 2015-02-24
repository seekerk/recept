namespace Recept2
{
    partial class FormCompare
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.dgv = new System.Windows.Forms.DataGridView();
        	this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.btnSetToDB = new System.Windows.Forms.Button();
        	this.btnSetToFile = new System.Windows.Forms.Button();
        	this.btnUpdate = new System.Windows.Forms.Button();
        	this.btnSaveNew = new System.Windows.Forms.Button();
        	this.cbSelElem = new Recept2.Controls.ComboBoxFilter();
        	this.cbDoSame = new System.Windows.Forms.CheckBox();
        	this.cbHideEqual = new System.Windows.Forms.CheckBox();
        	((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// dgv
        	// 
        	this.dgv.AllowUserToAddRows = false;
        	this.dgv.AllowUserToDeleteRows = false;
        	this.dgv.AllowUserToResizeRows = false;
        	this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.colName,
        	        	        	this.colBase,
        	        	        	this.colFile,
        	        	        	this.colValue});
        	this.dgv.Location = new System.Drawing.Point(0, 50);
        	this.dgv.MultiSelect = false;
        	this.dgv.Name = "dgv";
        	this.dgv.Size = new System.Drawing.Size(705, 401);
        	this.dgv.TabIndex = 0;
        	// 
        	// colName
        	// 
        	this.colName.HeaderText = "Свойство";
        	this.colName.Name = "colName";
        	this.colName.ReadOnly = true;
        	this.colName.Width = 200;
        	// 
        	// colBase
        	// 
        	this.colBase.HeaderText = "База данных";
        	this.colBase.Name = "colBase";
        	this.colBase.ReadOnly = true;
        	this.colBase.Width = 150;
        	// 
        	// colFile
        	// 
        	this.colFile.HeaderText = "Книга рецептур";
        	this.colFile.Name = "colFile";
        	this.colFile.ReadOnly = true;
        	this.colFile.Width = 150;
        	// 
        	// colValue
        	// 
        	this.colValue.HeaderText = "Новое значение";
        	this.colValue.Name = "colValue";
        	this.colValue.Width = 150;
        	// 
        	// btnSetToDB
        	// 
        	this.btnSetToDB.Location = new System.Drawing.Point(60, 464);
        	this.btnSetToDB.Name = "btnSetToDB";
        	this.btnSetToDB.Size = new System.Drawing.Size(75, 36);
        	this.btnSetToDB.TabIndex = 2;
        	this.btnSetToDB.Text = "Сделать как в БД";
        	this.btnSetToDB.UseVisualStyleBackColor = true;
        	this.btnSetToDB.Click += new System.EventHandler(this.btnSetToDB_Click);
        	// 
        	// btnSetToFile
        	// 
        	this.btnSetToFile.Location = new System.Drawing.Point(152, 464);
        	this.btnSetToFile.Name = "btnSetToFile";
        	this.btnSetToFile.Size = new System.Drawing.Size(83, 36);
        	this.btnSetToFile.TabIndex = 3;
        	this.btnSetToFile.Text = "Сделать как в файле";
        	this.btnSetToFile.UseVisualStyleBackColor = true;
        	this.btnSetToFile.Click += new System.EventHandler(this.btnSetToFile_Click);
        	// 
        	// btnUpdate
        	// 
        	this.btnUpdate.Location = new System.Drawing.Point(251, 464);
        	this.btnUpdate.Name = "btnUpdate";
        	this.btnUpdate.Size = new System.Drawing.Size(75, 36);
        	this.btnUpdate.TabIndex = 4;
        	this.btnUpdate.Text = "Изменить и сохранить";
        	this.btnUpdate.UseVisualStyleBackColor = true;
        	// 
        	// btnSaveNew
        	// 
        	this.btnSaveNew.Location = new System.Drawing.Point(347, 464);
        	this.btnSaveNew.Name = "btnSaveNew";
        	this.btnSaveNew.Size = new System.Drawing.Size(75, 36);
        	this.btnSaveNew.TabIndex = 5;
        	this.btnSaveNew.Text = "Сохранить как новый";
        	this.btnSaveNew.UseVisualStyleBackColor = true;
        	this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
        	// 
        	// cbSelElem
        	// 
        	this.cbSelElem.FormattingEnabled = true;
        	this.cbSelElem.Location = new System.Drawing.Point(398, 15);
        	this.cbSelElem.Name = "cbSelElem";
        	this.cbSelElem.Size = new System.Drawing.Size(295, 21);
        	this.cbSelElem.TabIndex = 6;
        	this.cbSelElem.SelectedIndexChanged += new System.EventHandler(this.cbSelElem_SelectedIndexChanged);
        	// 
        	// cbDoSame
        	// 
        	this.cbDoSame.AutoSize = true;
        	this.cbDoSame.Location = new System.Drawing.Point(493, 475);
        	this.cbDoSame.Name = "cbDoSame";
        	this.cbDoSame.Size = new System.Drawing.Size(132, 17);
        	this.cbDoSame.TabIndex = 7;
        	this.cbDoSame.Text = "Аналогично для всех";
        	this.cbDoSame.UseVisualStyleBackColor = true;
        	this.cbDoSame.CheckedChanged += new System.EventHandler(this.CbDoSameCheckedChanged);
        	// 
        	// cbHideEqual
        	// 
        	this.cbHideEqual.AutoSize = true;
        	this.cbHideEqual.Location = new System.Drawing.Point(60, 17);
        	this.cbHideEqual.Name = "cbHideEqual";
        	this.cbHideEqual.Size = new System.Drawing.Size(156, 17);
        	this.cbHideEqual.TabIndex = 8;
        	this.cbHideEqual.Text = "Скрыть одинаковые поля";
        	this.cbHideEqual.UseVisualStyleBackColor = true;
        	this.cbHideEqual.CheckedChanged += new System.EventHandler(this.CbHideEqualCheckedChanged);
        	// 
        	// FormCompare
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(705, 512);
        	this.Controls.Add(this.cbHideEqual);
        	this.Controls.Add(this.cbDoSame);
        	this.Controls.Add(this.cbSelElem);
        	this.Controls.Add(this.btnSaveNew);
        	this.Controls.Add(this.btnUpdate);
        	this.Controls.Add(this.btnSetToFile);
        	this.Controls.Add(this.btnSetToDB);
        	this.Controls.Add(this.dgv);
        	this.Name = "FormCompare";
        	this.Text = "FormCompare";
        	((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnSetToDB;
        private System.Windows.Forms.Button btnSetToFile;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private Recept2.Controls.ComboBoxFilter cbSelElem;
        private System.Windows.Forms.CheckBox cbDoSame;
        private System.Windows.Forms.CheckBox cbHideEqual;
    }
}