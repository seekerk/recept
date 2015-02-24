namespace Recept2
{
    partial class PanelReceptProcess
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtbProcess = new System.Windows.Forms.RichTextBox();
            this.lblReceptName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(130, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Описание процесса";
            // 
            // rtbProcess
            // 
            this.rtbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbProcess.Location = new System.Drawing.Point(0, 82);
            this.rtbProcess.Name = "rtbProcess";
            this.rtbProcess.Size = new System.Drawing.Size(616, 319);
            this.rtbProcess.TabIndex = 1;
            this.rtbProcess.Text = "";
            this.rtbProcess.TextChanged += new System.EventHandler(this.rtbProcess_TextChanged);
            // 
            // lblReceptName
            // 
            this.lblReceptName.AutoSize = true;
            this.lblReceptName.Location = new System.Drawing.Point(266, 61);
            this.lblReceptName.Name = "lblReceptName";
            this.lblReceptName.Size = new System.Drawing.Size(35, 13);
            this.lblReceptName.TabIndex = 2;
            this.lblReceptName.Text = "label2";
            this.lblReceptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelReceptProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblReceptName);
            this.Controls.Add(this.rtbProcess);
            this.Controls.Add(this.label1);
            this.Name = "PanelReceptProcess";
            this.Size = new System.Drawing.Size(616, 401);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbProcess;
        private System.Windows.Forms.Label lblReceptName;
    }
}
