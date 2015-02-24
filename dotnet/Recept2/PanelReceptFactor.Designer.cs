namespace Recept2
{
    partial class PanelReceptFactor
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
            this.rtbFactor = new System.Windows.Forms.RichTextBox();
            this.lblReceptName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbFactor
            // 
            this.rtbFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFactor.Location = new System.Drawing.Point(0, 111);
            this.rtbFactor.Name = "rtbFactor";
            this.rtbFactor.Size = new System.Drawing.Size(573, 172);
            this.rtbFactor.TabIndex = 0;
            this.rtbFactor.Text = "";
            this.rtbFactor.TextChanged += new System.EventHandler(this.rtbFactor_TextChanged);
            // 
            // lblReceptName
            // 
            this.lblReceptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceptName.AutoSize = true;
            this.lblReceptName.Location = new System.Drawing.Point(269, 74);
            this.lblReceptName.Name = "lblReceptName";
            this.lblReceptName.Size = new System.Drawing.Size(35, 13);
            this.lblReceptName.TabIndex = 4;
            this.lblReceptName.Text = "label2";
            this.lblReceptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(163, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Микробиология";
            // 
            // PanelReceptFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblReceptName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbFactor);
            this.Name = "PanelReceptFactor";
            this.Size = new System.Drawing.Size(573, 283);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbFactor;
        private System.Windows.Forms.Label lblReceptName;
        private System.Windows.Forms.Label label1;

    }
}
