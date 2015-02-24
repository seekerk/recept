/*
 * Created by SharpDevelop.
 * User: kirill
 * Date: 23.10.2009
 * Time: 12:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Recept2
{
    partial class PanelConfigReport
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	this.tbUseCounts = new System.Windows.Forms.TextBox();
        	this.tbUseExits = new System.Windows.Forms.TextBox();
        	this.cbIsShowOriginal = new System.Windows.Forms.CheckBox();
        	this.cbShowConfig = new System.Windows.Forms.CheckBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// tbUseCounts
        	// 
        	this.tbUseCounts.Location = new System.Drawing.Point(161, 41);
        	this.tbUseCounts.Name = "tbUseCounts";
        	this.tbUseCounts.Size = new System.Drawing.Size(168, 20);
        	this.tbUseCounts.TabIndex = 0;
        	// 
        	// tbUseExits
        	// 
        	this.tbUseExits.Location = new System.Drawing.Point(161, 67);
        	this.tbUseExits.Name = "tbUseExits";
        	this.tbUseExits.Size = new System.Drawing.Size(168, 20);
        	this.tbUseExits.TabIndex = 1;
        	// 
        	// cbIsShowOriginal
        	// 
        	this.cbIsShowOriginal.AutoSize = true;
        	this.cbIsShowOriginal.Location = new System.Drawing.Point(25, 18);
        	this.cbIsShowOriginal.Name = "cbIsShowOriginal";
        	this.cbIsShowOriginal.Size = new System.Drawing.Size(249, 17);
        	this.cbIsShowOriginal.TabIndex = 2;
        	this.cbIsShowOriginal.Text = "Использовать в отчете исходную рецептуру";
        	this.cbIsShowOriginal.UseVisualStyleBackColor = true;
        	// 
        	// cbShowConfig
        	// 
        	this.cbShowConfig.AutoSize = true;
        	this.cbShowConfig.Location = new System.Drawing.Point(19, 146);
        	this.cbShowConfig.Name = "cbShowConfig";
        	this.cbShowConfig.Size = new System.Drawing.Size(301, 17);
        	this.cbShowConfig.TabIndex = 3;
        	this.cbShowConfig.Text = "Показывать настройки перед формированием отчета";
        	this.cbShowConfig.UseVisualStyleBackColor = true;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(25, 44);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(130, 13);
        	this.label1.TabIndex = 4;
        	this.label1.Text = "Перечень выходов в шт.";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(25, 70);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(122, 13);
        	this.label2.TabIndex = 5;
        	this.label2.Text = "Перечень выходов в г.";
        	// 
        	// label3
        	// 
        	this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(19, 95);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(301, 41);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Для разделения элементов в перечне используйте пробел, символ \'|\' или символ \';\'";
        	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// PanelConfigReport
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.cbShowConfig);
        	this.Controls.Add(this.cbIsShowOriginal);
        	this.Controls.Add(this.tbUseExits);
        	this.Controls.Add(this.tbUseCounts);
        	this.MinimumSize = new System.Drawing.Size(345, 174);
        	this.Name = "PanelConfigReport";
        	this.Size = new System.Drawing.Size(345, 174);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbShowConfig;
        private System.Windows.Forms.CheckBox cbIsShowOriginal;
        private System.Windows.Forms.TextBox tbUseExits;
        private System.Windows.Forms.TextBox tbUseCounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
