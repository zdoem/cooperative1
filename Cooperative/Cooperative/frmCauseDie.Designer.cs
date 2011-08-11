namespace Cooperative
{
    partial class frmCauseDie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauseDie));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBMoveLast = new System.Windows.Forms.ToolStripButton();
            this.tsBMoveProvious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTxtPageNum = new System.Windows.Forms.ToolStripTextBox();
            this.tsTxtPageSum = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBMoveNext = new System.Windows.Forms.ToolStripButton();
            this.tsBMoveFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.stBAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.stBEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.stBDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.stBCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(621, 221);
            this.dataGridView1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "สาเหตุการตาย :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัส :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(29, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 86);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แฟ้มข้อมูลสาเหตุการตาย";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(300, 33);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(287, 34);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 22);
            this.textBox1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBMoveLast,
            this.tsBMoveProvious,
            this.toolStripSeparator1,
            this.tsTxtPageNum,
            this.tsTxtPageSum,
            this.toolStripSeparator2,
            this.tsBMoveNext,
            this.tsBMoveFirst,
            this.toolStripSeparator3,
            this.stBAdd,
            this.toolStripSeparator4,
            this.stBEdit,
            this.toolStripSeparator5,
            this.stBDelete,
            this.toolStripSeparator6,
            this.stBCancel,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(679, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBMoveLast
            // 
            this.tsBMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBMoveLast.Image = ((System.Drawing.Image)(resources.GetObject("tsBMoveLast.Image")));
            this.tsBMoveLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBMoveLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBMoveLast.Name = "tsBMoveLast";
            this.tsBMoveLast.Size = new System.Drawing.Size(36, 36);
            this.tsBMoveLast.Text = "First Record";
            // 
            // tsBMoveProvious
            // 
            this.tsBMoveProvious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBMoveProvious.Image = ((System.Drawing.Image)(resources.GetObject("tsBMoveProvious.Image")));
            this.tsBMoveProvious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBMoveProvious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBMoveProvious.Name = "tsBMoveProvious";
            this.tsBMoveProvious.Size = new System.Drawing.Size(36, 36);
            this.tsBMoveProvious.Text = "Previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsTxtPageNum
            // 
            this.tsTxtPageNum.Name = "tsTxtPageNum";
            this.tsTxtPageNum.Size = new System.Drawing.Size(100, 39);
            // 
            // tsTxtPageSum
            // 
            this.tsTxtPageSum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsTxtPageSum.Name = "tsTxtPageSum";
            this.tsTxtPageSum.Size = new System.Drawing.Size(24, 36);
            this.tsTxtPageSum.Text = "OF";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBMoveNext
            // 
            this.tsBMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBMoveNext.Image = ((System.Drawing.Image)(resources.GetObject("tsBMoveNext.Image")));
            this.tsBMoveNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBMoveNext.Name = "tsBMoveNext";
            this.tsBMoveNext.Size = new System.Drawing.Size(36, 36);
            this.tsBMoveNext.Text = "Next";
            // 
            // tsBMoveFirst
            // 
            this.tsBMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBMoveFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsBMoveFirst.Image")));
            this.tsBMoveFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBMoveFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBMoveFirst.Name = "tsBMoveFirst";
            this.tsBMoveFirst.Size = new System.Drawing.Size(36, 36);
            this.tsBMoveFirst.Text = "Last Recode";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // stBAdd
            // 
            this.stBAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stBAdd.Image = ((System.Drawing.Image)(resources.GetObject("stBAdd.Image")));
            this.stBAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stBAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stBAdd.Name = "stBAdd";
            this.stBAdd.Size = new System.Drawing.Size(36, 36);
            this.stBAdd.Text = "เพิ่ม";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // stBEdit
            // 
            this.stBEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stBEdit.Image = ((System.Drawing.Image)(resources.GetObject("stBEdit.Image")));
            this.stBEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stBEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stBEdit.Name = "stBEdit";
            this.stBEdit.Size = new System.Drawing.Size(36, 36);
            this.stBEdit.Text = "แก้ไข";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // stBDelete
            // 
            this.stBDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stBDelete.Image = ((System.Drawing.Image)(resources.GetObject("stBDelete.Image")));
            this.stBDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stBDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stBDelete.Name = "stBDelete";
            this.stBDelete.Size = new System.Drawing.Size(36, 36);
            this.stBDelete.Text = "ลบ";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // stBCancel
            // 
            this.stBCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stBCancel.Image = ((System.Drawing.Image)(resources.GetObject("stBCancel.Image")));
            this.stBCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stBCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stBCancel.Name = "stBCancel";
            this.stBCancel.Size = new System.Drawing.Size(36, 36);
            this.stBCancel.Text = "Cancel";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // frmCauseDie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 426);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCauseDie";
            this.Text = "แฟ้มข้อมูลสาเหตุการตาย";
            this.Load += new System.EventHandler(this.frmCauseDie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBMoveLast;
        private System.Windows.Forms.ToolStripButton tsBMoveProvious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsTxtPageNum;
        private System.Windows.Forms.ToolStripLabel tsTxtPageSum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBMoveNext;
        private System.Windows.Forms.ToolStripButton tsBMoveFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton stBAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton stBEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton stBDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton stBCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}