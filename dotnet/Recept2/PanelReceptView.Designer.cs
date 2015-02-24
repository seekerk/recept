namespace Recept2
{
    partial class PanelReceptView
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
        	this.labelName = new System.Windows.Forms.Label();
        	this.lblReceptName = new System.Windows.Forms.Label();
        	this.richTextBox1 = new System.Windows.Forms.RichTextBox();
        	this.SuspendLayout();
        	// 
        	// labelName
        	// 
        	this.labelName.AutoSize = true;
        	this.labelName.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.labelName.Location = new System.Drawing.Point(154, 17);
        	this.labelName.Name = "labelName";
        	this.labelName.Size = new System.Drawing.Size(207, 39);
        	this.labelName.TabIndex = 0;
        	this.labelName.Text = "Оформление";
        	this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// lblReceptName
        	// 
        	this.lblReceptName.AutoSize = true;
        	this.lblReceptName.Location = new System.Drawing.Point(240, 77);
        	this.lblReceptName.Name = "lblReceptName";
        	this.lblReceptName.Size = new System.Drawing.Size(35, 13);
        	this.lblReceptName.TabIndex = 7;
        	this.lblReceptName.Text = "label2";
        	this.lblReceptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// richTextBox1
        	// 
        	this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.richTextBox1.Location = new System.Drawing.Point(0, 93);
        	this.richTextBox1.Name = "richTextBox1";
        	this.richTextBox1.Size = new System.Drawing.Size(515, 305);
        	this.richTextBox1.TabIndex = 8;
        	this.richTextBox1.Text = "";
        	// 
        	// PanelReceptView
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.richTextBox1);
        	this.Controls.Add(this.lblReceptName);
        	this.Controls.Add(this.labelName);
        	this.Name = "PanelReceptView";
        	this.Size = new System.Drawing.Size(515, 398);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label labelName;

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblReceptName;
    }
}
