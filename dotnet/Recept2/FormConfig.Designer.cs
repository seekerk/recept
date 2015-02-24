namespace Recept2
{
    partial class FormConfig
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
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.tbBDName = new System.Windows.Forms.TextBox();
        	this.tbTemplate = new System.Windows.Forms.TextBox();
        	this.tbExit = new System.Windows.Forms.TextBox();
        	this.tbPrecision = new System.Windows.Forms.TextBox();
        	this.tbPandoc = new System.Windows.Forms.TextBox();
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.btnBDSelect = new System.Windows.Forms.Button();
        	this.btnTemplateSelect = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.cbDBType = new System.Windows.Forms.ComboBox();
        	this.btnPandocSelect = new System.Windows.Forms.Button();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.panelConfigReport1 = new Recept2.PanelConfigReport();
        	this.groupBox1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(39, 18);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(55, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Файл БД";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(39, 70);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(120, 13);
        	this.label2.TabIndex = 1;
        	this.label2.Text = "Шаблон по умолчанию";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(39, 96);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(96, 13);
        	this.label3.TabIndex = 2;
        	this.label3.Text = "Выход рецептуры";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(39, 122);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(118, 13);
        	this.label4.TabIndex = 3;
        	this.label4.Text = "Точность вычислений";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(39, 148);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(105, 13);
        	this.label5.TabIndex = 4;
        	this.label5.Text = "Программа pandoc";
        	// 
        	// tbBDName
        	// 
        	this.tbBDName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbBDName.Location = new System.Drawing.Point(168, 18);
        	this.tbBDName.Name = "tbBDName";
        	this.tbBDName.Size = new System.Drawing.Size(262, 20);
        	this.tbBDName.TabIndex = 5;
        	this.tbBDName.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbTemplate
        	// 
        	this.tbTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbTemplate.Location = new System.Drawing.Point(168, 70);
        	this.tbTemplate.Name = "tbTemplate";
        	this.tbTemplate.Size = new System.Drawing.Size(262, 20);
        	this.tbTemplate.TabIndex = 7;
        	this.tbTemplate.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbExit
        	// 
        	this.tbExit.Location = new System.Drawing.Point(168, 96);
        	this.tbExit.Name = "tbExit";
        	this.tbExit.Size = new System.Drawing.Size(100, 20);
        	this.tbExit.TabIndex = 8;
        	this.tbExit.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbPrecision
        	// 
        	this.tbPrecision.Location = new System.Drawing.Point(168, 122);
        	this.tbPrecision.Name = "tbPrecision";
        	this.tbPrecision.Size = new System.Drawing.Size(100, 20);
        	this.tbPrecision.TabIndex = 9;
        	this.tbPrecision.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbPandoc
        	// 
        	this.tbPandoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbPandoc.Location = new System.Drawing.Point(168, 148);
        	this.tbPandoc.Name = "tbPandoc";
        	this.tbPandoc.Size = new System.Drawing.Size(262, 20);
        	this.tbPandoc.TabIndex = 9;
        	this.tbPandoc.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(65, 411);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 10;
        	this.button1.Text = "Сохранить";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(175, 411);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(75, 23);
        	this.button2.TabIndex = 11;
        	this.button2.Text = "Отмена";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// btnBDSelect
        	// 
        	this.btnBDSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnBDSelect.Location = new System.Drawing.Point(436, 16);
        	this.btnBDSelect.Name = "btnBDSelect";
        	this.btnBDSelect.Size = new System.Drawing.Size(24, 23);
        	this.btnBDSelect.TabIndex = 12;
        	this.btnBDSelect.Text = "...";
        	this.btnBDSelect.UseVisualStyleBackColor = true;
        	this.btnBDSelect.Click += new System.EventHandler(this.btnBDSelect_Click);
        	// 
        	// btnTemplateSelect
        	// 
        	this.btnTemplateSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnTemplateSelect.Location = new System.Drawing.Point(436, 68);
        	this.btnTemplateSelect.Name = "btnTemplateSelect";
        	this.btnTemplateSelect.Size = new System.Drawing.Size(24, 23);
        	this.btnTemplateSelect.TabIndex = 13;
        	this.btnTemplateSelect.Text = "...";
        	this.btnTemplateSelect.UseVisualStyleBackColor = true;
        	this.btnTemplateSelect.Click += new System.EventHandler(this.btnTemplateSelect_Click);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(289, 411);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(129, 23);
        	this.button3.TabIndex = 14;
        	this.button3.Text = "Сбросить настройки";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.button3_Click);
        	// 
        	// cbDBType
        	// 
        	this.cbDBType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.cbDBType.Location = new System.Drawing.Point(168, 44);
        	this.cbDBType.Name = "cbDBType";
        	this.cbDBType.Size = new System.Drawing.Size(110, 21);
        	this.cbDBType.TabIndex = 6;
        	this.cbDBType.SelectedIndexChanged += new System.EventHandler(this.cbDBTypeChanged);
        	// 
        	// btnPandocSelect
        	// 
        	this.btnPandocSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnPandocSelect.Location = new System.Drawing.Point(436, 145);
        	this.btnPandocSelect.Name = "btnPandocSelect";
        	this.btnPandocSelect.Size = new System.Drawing.Size(24, 23);
        	this.btnPandocSelect.TabIndex = 15;
        	this.btnPandocSelect.Text = "...";
        	this.btnPandocSelect.UseVisualStyleBackColor = true;
        	this.btnPandocSelect.Click += new System.EventHandler(this.BtnPandocSelectClick);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.AutoSize = true;
        	this.groupBox1.Controls.Add(this.panelConfigReport1);
        	this.groupBox1.Location = new System.Drawing.Point(65, 174);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(366, 213);
        	this.groupBox1.TabIndex = 16;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Настройки отчета";
        	// 
        	// panelConfigReport1
        	// 
        	this.panelConfigReport1.Location = new System.Drawing.Point(6, 19);
        	this.panelConfigReport1.Name = "panelConfigReport1";
        	this.panelConfigReport1.Size = new System.Drawing.Size(354, 175);
        	this.panelConfigReport1.TabIndex = 0;
        	// 
        	// FormConfig
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(491, 457);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.btnPandocSelect);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.btnTemplateSelect);
        	this.Controls.Add(this.btnBDSelect);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.tbPandoc);
        	this.Controls.Add(this.tbPrecision);
        	this.Controls.Add(this.tbExit);
        	this.Controls.Add(this.tbTemplate);
        	this.Controls.Add(this.cbDBType);
        	this.Controls.Add(this.tbBDName);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Name = "FormConfig";
        	this.Text = "Настройки программы";
        	this.groupBox1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private Recept2.PanelConfigReport panelConfigReport1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPandocSelect;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBDName;
        private System.Windows.Forms.TextBox tbTemplate;
        private System.Windows.Forms.TextBox tbExit;
        private System.Windows.Forms.TextBox tbPrecision;
        private System.Windows.Forms.TextBox tbPandoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBDSelect;
        private System.Windows.Forms.Button btnTemplateSelect;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox cbDBType;
    }
}