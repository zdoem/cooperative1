namespace Cooperative
{
    partial class frmCashCoop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtm_id = new System.Windows.Forms.TextBox();
            this.dataGridNoCash = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbm_address = new System.Windows.Forms.Label();
            this.lbm_startDate = new System.Windows.Forms.Label();
            this.lbm_tel = new System.Windows.Forms.Label();
            this.lbm_amount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbm_name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbm_cash = new System.Windows.Forms.Label();
            this.btn_go = new System.Windows.Forms.Button();
            this.lbm_DieNames = new System.Windows.Forms.Label();
            this.cbx_lot = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridCash = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNoCash)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCash)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_find
            // 
            this.btn_find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_find.Location = new System.Drawing.Point(555, 21);
            this.btn_find.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(91, 32);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "ค้นหา..";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "กรุณาป้อนรหัสสมาชิก :";
            // 
            // txtm_id
            // 
            this.txtm_id.BackColor = System.Drawing.Color.Coral;
            this.txtm_id.Location = new System.Drawing.Point(381, 26);
            this.txtm_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtm_id.MaxLength = 7;
            this.txtm_id.Name = "txtm_id";
            this.txtm_id.Size = new System.Drawing.Size(165, 23);
            this.txtm_id.TabIndex = 0;
            this.txtm_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtm_id_KeyPress);
            // 
            // dataGridNoCash
            // 
            this.dataGridNoCash.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridNoCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNoCash.Location = new System.Drawing.Point(12, 82);
            this.dataGridNoCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridNoCash.Name = "dataGridNoCash";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridNoCash.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dataGridNoCash.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridNoCash.Size = new System.Drawing.Size(478, 176);
            this.dataGridNoCash.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.lbm_address);
            this.groupBox1.Controls.Add(this.lbm_startDate);
            this.groupBox1.Controls.Add(this.lbm_tel);
            this.groupBox1.Controls.Add(this.lbm_amount);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbm_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 263);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(968, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลสมาชิก..";
            // 
            // lbm_address
            // 
            this.lbm_address.BackColor = System.Drawing.Color.Gainsboro;
            this.lbm_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_address.Location = new System.Drawing.Point(100, 48);
            this.lbm_address.Name = "lbm_address";
            this.lbm_address.Size = new System.Drawing.Size(356, 59);
            this.lbm_address.TabIndex = 15;
            // 
            // lbm_startDate
            // 
            this.lbm_startDate.BackColor = System.Drawing.Color.Gainsboro;
            this.lbm_startDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_startDate.Location = new System.Drawing.Point(574, 64);
            this.lbm_startDate.Name = "lbm_startDate";
            this.lbm_startDate.Size = new System.Drawing.Size(152, 20);
            this.lbm_startDate.TabIndex = 14;
            // 
            // lbm_tel
            // 
            this.lbm_tel.BackColor = System.Drawing.Color.Gainsboro;
            this.lbm_tel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_tel.Location = new System.Drawing.Point(574, 22);
            this.lbm_tel.Name = "lbm_tel";
            this.lbm_tel.Size = new System.Drawing.Size(152, 20);
            this.lbm_tel.TabIndex = 13;
            // 
            // lbm_amount
            // 
            this.lbm_amount.BackColor = System.Drawing.Color.Black;
            this.lbm_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbm_amount.ForeColor = System.Drawing.Color.Lime;
            this.lbm_amount.Location = new System.Drawing.Point(770, 38);
            this.lbm_amount.Name = "lbm_amount";
            this.lbm_amount.Size = new System.Drawing.Size(183, 55);
            this.lbm_amount.TabIndex = 12;
            this.lbm_amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(502, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 17);
            this.label20.TabIndex = 9;
            this.label20.Text = "เบอร์โทร :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(58, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 17);
            this.label19.TabIndex = 8;
            this.label19.Text = "ที่อยู่ :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(796, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "จำนวนเงินสะสม :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "วันที่เป็นสมาชิก :";
            // 
            // lbm_name
            // 
            this.lbm_name.BackColor = System.Drawing.Color.Gainsboro;
            this.lbm_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_name.Location = new System.Drawing.Point(102, 21);
            this.lbm_name.Name = "lbm_name";
            this.lbm_name.Size = new System.Drawing.Size(354, 20);
            this.lbm_name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อ-นามสกุล :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbm_cash);
            this.groupBox2.Controls.Add(this.btn_go);
            this.groupBox2.Controls.Add(this.lbm_DieNames);
            this.groupBox2.Controls.Add(this.cbx_lot);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 382);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(784, 217);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ชำระเงิน...";
            // 
            // lbm_cash
            // 
            this.lbm_cash.BackColor = System.Drawing.Color.Black;
            this.lbm_cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbm_cash.ForeColor = System.Drawing.Color.Lime;
            this.lbm_cash.Location = new System.Drawing.Point(574, 80);
            this.lbm_cash.Name = "lbm_cash";
            this.lbm_cash.Size = new System.Drawing.Size(202, 133);
            this.lbm_cash.TabIndex = 18;
            this.lbm_cash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(382, 25);
            this.btn_go.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(91, 32);
            this.btn_go.TabIndex = 14;
            this.btn_go.Text = "Go...";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // lbm_DieNames
            // 
            this.lbm_DieNames.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbm_DieNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbm_DieNames.ForeColor = System.Drawing.Color.Blue;
            this.lbm_DieNames.Location = new System.Drawing.Point(6, 81);
            this.lbm_DieNames.Name = "lbm_DieNames";
            this.lbm_DieNames.Size = new System.Drawing.Size(562, 132);
            this.lbm_DieNames.TabIndex = 13;
            // 
            // cbx_lot
            // 
            this.cbx_lot.FormattingEnabled = true;
            this.cbx_lot.Location = new System.Drawing.Point(183, 30);
            this.cbx_lot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_lot.MaxLength = 7;
            this.cbx_lot.Name = "cbx_lot";
            this.cbx_lot.Size = new System.Drawing.Size(183, 24);
            this.cbx_lot.TabIndex = 12;
            this.cbx_lot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbx_lot_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "รายการผู้เสียชีวิตประจำงวด :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Crimson;
            this.label12.Location = new System.Drawing.Point(572, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(202, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "ยอดเงินที่ต้องชำระประจำงวดนี้ :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 17);
            this.label10.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "เลขที่งวดที่ต้องการชำระ :";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(39, 146);
            this.btn_print.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 32);
            this.btn_print.TabIndex = 17;
            this.btn_print.Text = "Print...";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(39, 34);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 32);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Save...";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(39, 92);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(91, 32);
            this.btn_cancel.TabIndex = 15;
            this.btn_cancel.Text = "Cancel..";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "งวดที่ยังค้างชำระ";
            // 
            // dataGridCash
            // 
            this.dataGridCash.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCash.Location = new System.Drawing.Point(500, 82);
            this.dataGridCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridCash.Name = "dataGridCash";
            this.dataGridCash.Size = new System.Drawing.Size(482, 176);
            this.dataGridCash.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightGreen;
            this.label15.Location = new System.Drawing.Point(863, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 17);
            this.label15.TabIndex = 8;
            this.label15.Text = "งวดที่ชำระไปแล้ว";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox3.Controls.Add(this.btn_save);
            this.groupBox3.Controls.Add(this.btn_print);
            this.groupBox3.Controls.Add(this.btn_cancel);
            this.groupBox3.Location = new System.Drawing.Point(811, 382);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(168, 217);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controls...";
            // 
            // frmCashCoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(991, 610);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dataGridCash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridNoCash);
            this.Controls.Add(this.txtm_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_find);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCashCoop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ชำระเงินฌาปนกิจศพตามงวด...";
            this.Load += new System.EventHandler(this.frmCashCoop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNoCash)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCash)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtm_id;
        private System.Windows.Forms.DataGridView dataGridNoCash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbm_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbm_address;
        private System.Windows.Forms.Label lbm_startDate;
        private System.Windows.Forms.Label lbm_tel;
        private System.Windows.Forms.Label lbm_amount;
        private System.Windows.Forms.Label lbm_cash;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Label lbm_DieNames;
        private System.Windows.Forms.ComboBox cbx_lot;
        private System.Windows.Forms.DataGridView dataGridCash;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}