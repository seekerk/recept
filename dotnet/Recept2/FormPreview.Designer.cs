namespace Recept2
{
    partial class FormPreview
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
        	this.webBrowser1 = new System.Windows.Forms.WebBrowser();
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnReload = new System.Windows.Forms.Button();
        	this.btnPrint = new System.Windows.Forms.Button();
        	this.btnSaveToFile = new System.Windows.Forms.Button();
        	this.btnSettings = new System.Windows.Forms.Button();
        	this.tableLayoutPanel1.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// webBrowser1
        	// 
        	this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.webBrowser1.Location = new System.Drawing.Point(3, 65);
        	this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
        	this.webBrowser1.Name = "webBrowser1";
        	this.webBrowser1.Size = new System.Drawing.Size(723, 461);
        	this.webBrowser1.TabIndex = 0;
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.ColumnCount = 1;
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel1.Controls.Add(this.webBrowser1, 0, 1);
        	this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
        	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 2;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 529);
        	this.tableLayoutPanel1.TabIndex = 1;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnSettings);
        	this.panel1.Controls.Add(this.btnReload);
        	this.panel1.Controls.Add(this.btnPrint);
        	this.panel1.Controls.Add(this.btnSaveToFile);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel1.Location = new System.Drawing.Point(3, 3);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(723, 56);
        	this.panel1.TabIndex = 1;
        	// 
        	// btnReload
        	// 
        	this.btnReload.Image = global::Recept2.Properties.Resources.icon_reload;
        	this.btnReload.Location = new System.Drawing.Point(3, 0);
        	this.btnReload.Name = "btnReload";
        	this.btnReload.Size = new System.Drawing.Size(56, 56);
        	this.btnReload.TabIndex = 3;
        	this.btnReload.UseVisualStyleBackColor = true;
        	this.btnReload.Click += new System.EventHandler(this.BtnReloadClick);
        	// 
        	// btnPrint
        	// 
        	this.btnPrint.AutoSize = true;
        	this.btnPrint.Image = global::Recept2.Properties.Resources.icon_printer;
        	this.btnPrint.Location = new System.Drawing.Point(127, 0);
        	this.btnPrint.Name = "btnPrint";
        	this.btnPrint.Size = new System.Drawing.Size(56, 56);
        	this.btnPrint.TabIndex = 2;
        	this.btnPrint.UseVisualStyleBackColor = true;
        	this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
        	// 
        	// btnSaveToFile
        	// 
        	this.btnSaveToFile.AutoSize = true;
        	this.btnSaveToFile.Image = global::Recept2.Properties.Resources.file_export_icon;
        	this.btnSaveToFile.Location = new System.Drawing.Point(65, 0);
        	this.btnSaveToFile.Name = "btnSaveToFile";
        	this.btnSaveToFile.Size = new System.Drawing.Size(56, 56);
        	this.btnSaveToFile.TabIndex = 1;
        	this.btnSaveToFile.UseVisualStyleBackColor = true;
        	this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
        	// 
        	// btnSettings
        	// 
        	this.btnSettings.Image = global::Recept2.Properties.Resources.settings;
        	this.btnSettings.Location = new System.Drawing.Point(189, 0);
        	this.btnSettings.Name = "btnSettings";
        	this.btnSettings.Size = new System.Drawing.Size(56, 56);
        	this.btnSettings.TabIndex = 4;
        	this.btnSettings.UseVisualStyleBackColor = true;
        	this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
        	// 
        	// FormPreview
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(729, 529);
        	this.Controls.Add(this.tableLayoutPanel1);
        	this.Name = "FormPreview";
        	this.Text = "FormPreview";
        	this.tableLayoutPanel1.ResumeLayout(false);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnReload;

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
    }
}