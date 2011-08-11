namespace Cooperative
{
    partial class frmFindMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindMember));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tdM_findx = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsM_txtid = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsM_find = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsM_label2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsM_txtname = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsM_find_name = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.stM_close = new System.Windows.Forms.ToolStripButton();
            this.dwFind = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwFind)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tdM_findx,
            this.toolStripSeparator1,
            this.tsM_txtid,
            this.toolStripSeparator2,
            this.tsM_find,
            this.toolStripSeparator3,
            this.tsM_label2,
            this.toolStripSeparator4,
            this.tsM_txtname,
            this.toolStripSeparator5,
            this.tsM_find_name,
            this.toolStripSeparator6,
            this.stM_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tdM_findx
            // 
            this.tdM_findx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdM_findx.ForeColor = System.Drawing.Color.Green;
            this.tdM_findx.Image = ((System.Drawing.Image)(resources.GetObject("tdM_findx.Image")));
            this.tdM_findx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tdM_findx.Name = "tdM_findx";
            this.tdM_findx.Size = new System.Drawing.Size(138, 22);
            this.tdM_findx.Text = "กรุณารหัสสมาชิก :";
            this.tdM_findx.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsM_txtid
            // 
            this.tsM_txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsM_txtid.MaxLength = 7;
            this.tsM_txtid.Name = "tsM_txtid";
            this.tsM_txtid.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsM_find
            // 
            this.tsM_find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsM_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsM_find.ForeColor = System.Drawing.Color.Blue;
            this.tsM_find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsM_find.Name = "tsM_find";
            this.tsM_find.Size = new System.Drawing.Size(63, 22);
            this.tsM_find.Text = "ค้นหา...";
            this.tsM_find.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsM_find.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsM_find.Click += new System.EventHandler(this.tsM_find_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsM_label2
            // 
            this.tsM_label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsM_label2.ForeColor = System.Drawing.Color.Green;
            this.tsM_label2.Image = ((System.Drawing.Image)(resources.GetObject("tsM_label2.Image")));
            this.tsM_label2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsM_label2.Name = "tsM_label2";
            this.tsM_label2.Size = new System.Drawing.Size(156, 22);
            this.tsM_label2.Text = "กรุณาป้อนชื่อสมาชิก :";
            this.tsM_label2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsM_txtname
            // 
            this.tsM_txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsM_txtname.Name = "tsM_txtname";
            this.tsM_txtname.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsM_find_name
            // 
            this.tsM_find_name.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsM_find_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsM_find_name.ForeColor = System.Drawing.Color.Blue;
            this.tsM_find_name.Image = ((System.Drawing.Image)(resources.GetObject("tsM_find_name.Image")));
            this.tsM_find_name.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsM_find_name.Name = "tsM_find_name";
            this.tsM_find_name.Size = new System.Drawing.Size(58, 22);
            this.tsM_find_name.Text = "ค้นหา..";
            this.tsM_find_name.Click += new System.EventHandler(this.tsM_find_name_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // stM_close
            // 
            this.stM_close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stM_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stM_close.ForeColor = System.Drawing.Color.Red;
            this.stM_close.Image = ((System.Drawing.Image)(resources.GetObject("stM_close.Image")));
            this.stM_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stM_close.Name = "stM_close";
            this.stM_close.Size = new System.Drawing.Size(74, 22);
            this.stM_close.Text = "Close()..";
            this.stM_close.Click += new System.EventHandler(this.stM_close_Click);
            // 
            // dwFind
            // 
            this.dwFind.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dwFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwFind.Location = new System.Drawing.Point(12, 38);
            this.dwFind.Name = "dwFind";
            this.dwFind.Size = new System.Drawing.Size(942, 516);
            this.dwFind.TabIndex = 1;
            // 
            // frmFindMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(966, 566);
            this.Controls.Add(this.dwFind);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFindMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ค้นหาข้อมูลสมาชิกในระบบ...";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwFind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsM_txtid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsM_find;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dwFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel tdM_findx;
        private System.Windows.Forms.ToolStripLabel tsM_label2;
        private System.Windows.Forms.ToolStripTextBox tsM_txtname;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsM_find_name;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton stM_close;
    }
}