namespace Recept2
{
    partial class PanelBookdata
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
        	this.tbBookName = new System.Windows.Forms.TextBox();
        	this.tbCompanyName = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.tbChiefName = new System.Windows.Forms.TextBox();
        	this.tbDeveloperName = new System.Windows.Forms.TextBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.tbDeveloperCompany = new System.Windows.Forms.TextBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.tbChiefPost = new System.Windows.Forms.TextBox();
        	this.label7 = new System.Windows.Forms.Label();
        	this.groupBox1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tbBookName
        	// 
        	this.tbBookName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbBookName.Location = new System.Drawing.Point(150, 71);
        	this.tbBookName.Name = "tbBookName";
        	this.tbBookName.Size = new System.Drawing.Size(324, 20);
        	this.tbBookName.TabIndex = 0;
        	this.tbBookName.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbCompanyName
        	// 
        	this.tbCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbCompanyName.Location = new System.Drawing.Point(228, 19);
        	this.tbCompanyName.Name = "tbCompanyName";
        	this.tbCompanyName.Size = new System.Drawing.Size(232, 20);
        	this.tbCompanyName.TabIndex = 1;
        	this.tbCompanyName.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(31, 74);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(89, 13);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "Название книги";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(17, 22);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(152, 13);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "Название фирмы-заказчика";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(17, 48);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(96, 13);
        	this.label3.TabIndex = 4;
        	this.label3.Text = "ФИО начальника";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(17, 22);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(190, 13);
        	this.label4.TabIndex = 5;
        	this.label4.Text = "ФИО ответственного разработчика";
        	// 
        	// tbChiefName
        	// 
        	this.tbChiefName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbChiefName.Location = new System.Drawing.Point(228, 45);
        	this.tbChiefName.Name = "tbChiefName";
        	this.tbChiefName.Size = new System.Drawing.Size(232, 20);
        	this.tbChiefName.TabIndex = 6;
        	this.tbChiefName.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// tbDeveloperName
        	// 
        	this.tbDeveloperName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbDeveloperName.Location = new System.Drawing.Point(228, 19);
        	this.tbDeveloperName.Name = "tbDeveloperName";
        	this.tbDeveloperName.Size = new System.Drawing.Size(232, 20);
        	this.tbDeveloperName.TabIndex = 7;
        	this.tbDeveloperName.TextChanged += new System.EventHandler(this.tbTextChanged);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox1.Controls.Add(this.label6);
        	this.groupBox1.Controls.Add(this.tbDeveloperCompany);
        	this.groupBox1.Controls.Add(this.tbDeveloperName);
        	this.groupBox1.Controls.Add(this.label4);
        	this.groupBox1.Location = new System.Drawing.Point(14, 228);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(478, 78);
        	this.groupBox1.TabIndex = 8;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Информация о разработчиках";
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(17, 48);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(200, 13);
        	this.label6.TabIndex = 9;
        	this.label6.Text = "Фирма ответственного разработчика";
        	// 
        	// tbDeveloperCompany
        	// 
        	this.tbDeveloperCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbDeveloperCompany.Location = new System.Drawing.Point(228, 45);
        	this.tbDeveloperCompany.Name = "tbDeveloperCompany";
        	this.tbDeveloperCompany.Size = new System.Drawing.Size(232, 20);
        	this.tbDeveloperCompany.TabIndex = 8;
        	// 
        	// label5
        	// 
        	this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.label5.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label5.Location = new System.Drawing.Point(128, 17);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(249, 39);
        	this.label5.TabIndex = 9;
        	this.label5.Text = "Книга рецептур";
        	this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox2.Controls.Add(this.label7);
        	this.groupBox2.Controls.Add(this.tbChiefPost);
        	this.groupBox2.Controls.Add(this.tbCompanyName);
        	this.groupBox2.Controls.Add(this.label3);
        	this.groupBox2.Controls.Add(this.tbChiefName);
        	this.groupBox2.Controls.Add(this.label2);
        	this.groupBox2.Location = new System.Drawing.Point(14, 121);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(478, 100);
        	this.groupBox2.TabIndex = 10;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Информация о фирме-заказчике";
        	// 
        	// tbChiefPost
        	// 
        	this.tbChiefPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbChiefPost.Location = new System.Drawing.Point(228, 71);
        	this.tbChiefPost.Name = "tbChiefPost";
        	this.tbChiefPost.Size = new System.Drawing.Size(232, 20);
        	this.tbChiefPost.TabIndex = 7;
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Location = new System.Drawing.Point(17, 74);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(127, 13);
        	this.label7.TabIndex = 8;
        	this.label7.Text = "Должность начальника";
        	// 
        	// PanelBookdata
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.tbBookName);
        	this.Name = "PanelBookdata";
        	this.Size = new System.Drawing.Size(505, 320);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox tbChiefPost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDeveloperCompany;
        private System.Windows.Forms.Label label6;

        #endregion

        private System.Windows.Forms.TextBox tbBookName;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbChiefName;
        private System.Windows.Forms.TextBox tbDeveloperName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}
