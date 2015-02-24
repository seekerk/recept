namespace Recept2
{
    partial class PanelBrowse
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
        	this.lbPages = new System.Windows.Forms.ListBox();
        	this.tvBook = new System.Windows.Forms.TreeView();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// lbPages
        	// 
        	this.lbPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.lbPages.FormattingEnabled = true;
        	this.lbPages.HorizontalExtent = 5;
        	this.lbPages.Location = new System.Drawing.Point(0, 0);
        	this.lbPages.Name = "lbPages";
        	this.lbPages.Size = new System.Drawing.Size(334, 186);
        	this.lbPages.TabIndex = 0;
        	this.lbPages.SelectedIndexChanged += new System.EventHandler(this.lbPages_SelectedIndexChanged);
        	// 
        	// tvBook
        	// 
        	this.tvBook.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tvBook.FullRowSelect = true;
        	this.tvBook.Location = new System.Drawing.Point(0, 0);
        	this.tvBook.Name = "tvBook";
        	this.tvBook.Size = new System.Drawing.Size(334, 111);
        	this.tvBook.TabIndex = 1;
        	this.tvBook.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBook_AfterSelect);
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Name = "splitContainer1";
        	this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.tvBook);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.lbPages);
        	this.splitContainer1.Size = new System.Drawing.Size(334, 306);
        	this.splitContainer1.SplitterDistance = 111;
        	this.splitContainer1.TabIndex = 1;
        	// 
        	// PanelBrowse
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.splitContainer1);
        	this.Name = "PanelBrowse";
        	this.Size = new System.Drawing.Size(334, 306);
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	this.splitContainer1.ResumeLayout(false);
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lbPages;
        private System.Windows.Forms.TreeView tvBook;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
