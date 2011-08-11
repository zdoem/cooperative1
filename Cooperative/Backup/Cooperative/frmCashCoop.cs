using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogingSendID;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace Cooperative
{
    public partial class frmCashCoop : Form
    {

        private connDataBase cnnBase = new connDataBase();
        private MySqlDataAdapter adapter;
        private DataSet ds;
        DateTime dd = DateTime.Now;//add start_date
      //  String ddmmyy = "yyyy-MM-dd";
        DateTimeFormatInfo dtfInfo = DateTimeFormatInfo.InvariantInfo;
     
        string str_con = "datasource=localhost;username=root;password=root;database=db_cooperative";
        MySqlConnection mycon;

        //-----------
        string m_id = "";
        string m_fname = "";
        string m_lname = "";
        string m_address = "";
        string m_tel = "";
        string start_date = "";
        string m_amount = "";
        
        
        
        public frmCashCoop()
        {
            InitializeComponent();
        }
        
        // เฉพาะตัวเลขเท่านั้นน่ะคับ
        private void txtm_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลขเท่านั้นคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtm_id.SelectAll();
                txtm_id.Focus();
                e.Handled = true;
            }

        }
        // เฉพาะตัวเลขเท่านั้นน่ะคับของ Combobox lot /งวด
        private void cbx_lot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลขเท่านั้นคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_lot.SelectAll();
                cbx_lot.Focus();
                e.Handled = true;
            }
        }
        
        
        //method ClearData
        private void ClearDataFrom()
        {
            txtm_id.Text = "";
            lbm_name.Text = "";
            lbm_address.Text = "";
            lbm_tel.Text = "";
            lbm_startDate.Text = "";
            lbm_cash.Text = "";
            lbm_DieNames.Text = "";
            lbm_amount.Text = "";

            cbx_lot.Text = "";

            dataGridNoCash.DataSource = null;
            dataGridCash.DataSource = null;

            
 
        }

        //method Stly  CustomDataGrid()
        private void CustomDataGrid()
        {
            DataGridTableStyle grdTS = new DataGridTableStyle();

            //ระบบุความสัมพัน
            grdTS.MappingName = "pay";
            grdTS.BackColor = Color.Aquamarine;
            grdTS.AlternatingBackColor = Color.White;

            DataGridColumnStyle cs1 = new DataGridTextBoxColumn();
            cs1.MappingName = "pay_id";
            cs1.HeaderText = "รหัส Pay";
            cs1.ReadOnly = true;
            cs1.Width = 10;
            grdTS.GridColumnStyles.Add(cs1);


            //dataGridNoCash.TableStyles.Add(grdTS);
        }

        // method Load Display GridView
        private void LoadDataDispay(string mID)
        {
           
            
            //เลือกเฉพาะงวดที่ค้างชำระน่ะคับ
            try
            {

                mycon = new MySqlConnection(str_con);

                // cnnBase.Open();
                string sqlQuery1 = "SELECT pay_id as No,l_id as LotID,m_id as MemberID,pay_date as PayDate,pay_cash as PayCash, ";
                sqlQuery1 += "status as Status FROM pay where m_id ='" + mID + "' AND status=0 ";
                

                adapter = new MySqlDataAdapter(sqlQuery1, mycon);
                ds = new DataSet();
                adapter.Fill(ds, "pay");
                dataGridNoCash.ReadOnly = true;
                dataGridNoCash.DataSource = ds;
                dataGridNoCash.DataMember = "pay";

                mycon.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Errors เลือกเฉพาะงวดที่ค้างชำระน่ะคับ..." + ex.Message);
            }
            
            
            //งวดที่ชำระแล้วนะคับ----------
            try
            {

                mycon = new MySqlConnection(str_con);

                // cnnBase.Open();
                string sqlQuery2 = "SELECT pay_id as No,l_id as LotID,m_id as MemberID,pay_date as PayDate,pay_cash as PayCash, ";
                sqlQuery2 += "status as Status FROM pay where m_id ='" + mID + "' AND status=1 order by l_id desc";

                adapter = new MySqlDataAdapter(sqlQuery2, mycon);
                ds = new DataSet();
                adapter.Fill(ds, "pay");
                dataGridCash.ReadOnly = true;
                dataGridCash.DataSource = ds;
                dataGridCash.DataMember = "pay";

                mycon.Close();
              
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Errors งวดที่ชำระแล้วนะคับ...." + ex.Message);
            }
         
        }
     

        //------แสดงคอมโบบ๊อกสำหรับเลือกการชำระเงินน่ะคับ
        private void showComboLot(string mID)
        {
            mycon = new MySqlConnection(str_con);
            try
            {


                string sql_lot = "SELECT pay_id,l_id,m_id FROM pay where m_id ='" + mID + "' AND status=0  ";
                
                //cnnBase.Open();
                adapter = new MySqlDataAdapter(sql_lot, mycon);
                // adapter = cnnBase.ExecuteQuery(sql);
                ds = new DataSet();
                adapter.Fill(ds, "pay");
                cbx_lot.DataSource = ds.Tables["pay"];
                cbx_lot.DisplayMember = "l_id";
                cbx_lot.ValueMember = "m_id";
               // cbx_lot.ValueMember[1].ToString = "pay_id";//---------------

                mycon.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errors.. แสดงคอมโบบ๊อกสำหรับเลือกการชำระเงินน่ะคับ... " + ex.Message);
            }

        }


        //ค้นหาข้อมูลสมาชิก
        private void btn_find_Click(object sender, EventArgs e)
        {
           
           
            if (txtm_id.Text == "")
            {
                MessageBox.Show("กรุณาป้อนรหัสสมาชิกด้วยคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtm_id.SelectAll();
                txtm_id.Focus();

            }
            else
            {
                mycon = new MySqlConnection(str_con); //connect

                string SQLfind = "SELECT m_id,m_fname,m_lname,m_tel,m_address,start_date,amount FROM member m ";
                SQLfind += " WHERE m.m_id='" +txtm_id.Text + "' and status_life <> 'D'";
                MySqlCommand cmdStr = new MySqlCommand(SQLfind, mycon);
                
                try
                {

                    //Conn.Open();
                    mycon.Open();
                    this.Cursor = Cursors.WaitCursor;
                    MySqlDataReader dataR1= cmdStr.ExecuteReader();

                   if(dataR1.Read())
                    {
                        m_id = dataR1.GetValue(0).ToString();
                        m_fname = dataR1.GetValue(1).ToString();
                        m_lname = dataR1.GetValue(2).ToString();
                        m_tel = dataR1.GetValue(3).ToString();
                        m_address = dataR1.GetValue(4).ToString();
                        start_date = dataR1.GetValue(5).ToString();
                        m_amount = dataR1.GetValue(6).ToString();

                    }

                    dataR1.Close();
                    mycon.Close();
                    this.Cursor = Cursors.Default;

                    if (txtm_id.Text!= m_id)
                    {
                        MessageBox.Show("ไม่พบรหัสสมาชิกในระบบคับ...!!", "ผลการค้นหา...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        ClearDataFrom(); //clearDataFrom() this
                        
                        btn_save.Enabled = false;
                        btn_cancel.Enabled = false;
                        btn_print.Enabled = false;
                        
                        btn_go.Enabled = false;
                        cbx_lot.Enabled = false;
                        txtm_id.Text = "";
                        txtm_id.Focus();
                    }
                    else
                    {
                        if (txtm_id.Text == m_id)
                        {
                            this.txtm_id.Text = m_id;
                            this.lbm_name.Text = m_fname+"  "+m_lname;
                            this.lbm_tel.Text = m_tel;
                            this.lbm_address.Text = m_address;
                            this.lbm_startDate.Text = start_date;
                            this.lbm_amount.Text = m_amount;

                            //แสดงข้อมูลใน Grid
                            LoadDataDispay(m_id);// call method

                            btn_go.Enabled = true;
                            cbx_lot.Enabled = true;

                            showComboLot(m_id);// call method
                            cbx_lot.Text = "";// clear Data Combobox

                            //--------------
                            if (mycon != null)
                            {
                                mycon.Close();
                            }

                         }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errors Exception!!" + ex.Message, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("SQL string  !!" + SQLfind, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btn_find.Enabled = true;
                   // ClearData();
                }

            }
        }
        
        
        // Event this Form Loads
        private void frmCashCoop_Load(object sender, EventArgs e)
        {

            cbx_lot.Enabled = false;
            btn_go.Enabled = false;
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            btn_print.Enabled = false;

            txtm_id.Focus();
        }

        // function ตัด String วันที่น่ะคับพี่น้อง
        private string subDateStr(string param)
        {
            string dd = "";
            if (param.Length > 0 && param.Length == 18)
            {
                dd = param.Substring(0,10);
            }
            else if (param.Length > 0 && param.Length == 17)
            {
                dd = param.Substring(0,9);
            }
            else if (param.Length > 0 && param.Length == 16)
            {
                dd = param.Substring(0,8);
            }
            else
            {
                dd = param;
            }

            return dd;
        }

        //seclect คนตายในงวดที่เลือกน่ะคับผม
        private void btn_go_Click(object sender, EventArgs e)
        {


            if (cbx_lot.Text == "")
            {
                MessageBox.Show("กรุณาเลือกเลขที่งวดที่ต้องการชำระด้วยคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_lot.SelectAll();
                cbx_lot.Focus();
            }
            else
            {
                mycon = new MySqlConnection(str_con); //connect

                //string[,] str_data;
                int cnum = 0;
                string check = "";

              // string SQLgoFind = "SELECT l_id FROM list_die where l_id='" + cbx_lot.Text + "' and status=1 ";

                string SQLgoFind = "SELECT l_id,m_id FROM pay where l_id='"+cbx_lot.Text+"' and m_id ='" +txtm_id.Text+ "' AND status=0 ";
                
                MySqlCommand cmdChk = new MySqlCommand(SQLgoFind, mycon);

                try
                {

                    //Conn.Open();
                    mycon.Open();
                    this.Cursor = Cursors.WaitCursor;
                    MySqlDataReader drChk = cmdChk.ExecuteReader();

                    while (drChk.Read())
                    {
                        check = drChk.GetValue(0).ToString();
                    }

                    drChk.Close();
                    mycon.Close();
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errors Exception!! ตรวจสอบรหัสงวดในระบบ...  " + ex.Message, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // ClearData();
                }


                //ตรวจสอบว่ามีรหัสงว่ามีจิงหรือป่าวน่ะคับ
                if (check == "" || check!=cbx_lot.Text)
                {
                    MessageBox.Show("ไม่พบเลขที่งวดที่ต้องการชำระในระบบ   \nหรือ เลขที่งวด'"+cbx_lot.Text+"' ได้มีการชำระแล้ว...!!", "ผลการค้นหา...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbx_lot.Text = "";
                    cbx_lot.SelectAll();
                    cbx_lot.Focus();
                }
                else
                {

                    string SQLgo = "SELECT count(l_id) as cnum FROM list_die_details where l_id='" + cbx_lot.Text + "' ";

                    MySqlCommand cmdStr = new MySqlCommand(SQLgo, mycon);

                    try
                    {

                        //Conn.Open();
                        mycon.Open();
                        this.Cursor = Cursors.WaitCursor;
                        MySqlDataReader dataR1 = cmdStr.ExecuteReader();

                        if (dataR1.Read())
                        {
                            cnum = dataR1.GetInt32(0);

                        }

                        dataR1.Close();
                        mycon.Close();
                        this.Cursor = Cursors.Default;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errors Exception!!" + ex.Message, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // ClearData();
                    }
                    // cnum++;
                    //  MessageBox.Show("aa" +cnum);
                    //string[][] str_data = { new string[cnum], new string[6] };
                    string[,] str_data = new string[cnum, 6];

                    SQLgo = "SELECT l_id,dd_date,dd_m_id FROM list_die_details where l_id='" + cbx_lot.Text + "' ";
                    //MessageBox.Show(cbx_lot.Text);

                    MySqlCommand cmdStr2 = new MySqlCommand(SQLgo, mycon);

                    try
                    {
                        int i = 0;
                        //Conn.Open();
                        mycon.Open();
                        this.Cursor = Cursors.WaitCursor;
                        MySqlDataReader dataR2 = cmdStr2.ExecuteReader();

                        while (dataR2.Read())
                        {
                            str_data[i, 0] = dataR2.GetValue(0).ToString();
                            str_data[i, 1] = dataR2.GetValue(1).ToString();
                            str_data[i, 2] = dataR2.GetValue(2).ToString();


                            //  MessageBox.Show(i+" " + dataR2.GetValue(0).ToString());
                            i++;
                        }

                        dataR2.Close();
                        mycon.Close();
                        this.Cursor = Cursors.Default;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errors get Data to Array!!" + ex.Message, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // ClearData();
                    }

                    //**********************
                    //ต่อเป้นการ query เอาชือและนาสกุลมาเก็บไว้ใน arry น่ะคับพี่น้อง
                    //********************

                    // try
                    // { 
                    mycon.Open();
                    this.Cursor = Cursors.WaitCursor;
                    MySqlDataReader dataR3 = null;
                    for (int n = 0; n < cnum; n++)
                    {

                        SQLgo = "SELECT m_fname,m_lname from member where m_id='" + str_data[n, 2] + "' ";
                        MySqlCommand cmdStr3 = new MySqlCommand(SQLgo, mycon);

                        //Conn.Open();

                        dataR3 = cmdStr3.ExecuteReader();

                        if (dataR3.Read())
                        {
                            str_data[n, 3] = dataR3.GetValue(0).ToString();
                            str_data[n, 4] = dataR3.GetValue(1).ToString();
                            //str_data[i, 2] = dataR3.GetValue(2).ToString();
                        }
                        dataR3.Close();
                    }
                    mycon.Close();
                    this.Cursor = Cursors.Default;

                    /*}
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errors get Data Loop2 to Array!!" + ex.Message, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // ClearData();
                    }*/

                    int j = 1;

                    for (int n = 0; n < cnum; n++)
                    {
                        // cash += 20;
                        this.lbm_DieNames.Text += j + ". " + str_data[n, 0] + " " + subDateStr(str_data[n, 1]) + " " + str_data[n, 2] + " " + str_data[n, 3] + " " + str_data[n, 4] + "\n";
                        j++;
                    }
                    this.lbm_cash.Text = "" + (j * 20) + ".00";//แสดงจำนวนเงินน่ะคับพี่น้อง

                    cbx_lot.Enabled = false;
                    btn_go.Enabled = false;
                    txtm_id.ReadOnly = true;
                    btn_find.Enabled = false;

                    //---------
                    btn_save.Enabled = true;
                    btn_cancel.Enabled = true;


                }
            }
        }


        //ยกเลิก
        private void btn_cancel_Click(object sender, EventArgs e)
        {

            this.lbm_DieNames.Text = "";
            this.lbm_cash.Text = "";
            this.cbx_lot.Text = "";
            cbx_lot.Enabled = true;
            btn_go.Enabled = true;
           
            
           txtm_id.ReadOnly = false;
            btn_find.Enabled = true;

            //---------
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;

        }

       
        float total = 0;
        //เมื่อมีการบันทึกข้อมูล
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการบันทึกข้อมูล ใช่หรือไม่...?", "คำยืนยัน...", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                float sum = float.Parse(lbm_amount.Text);
                //แปลงจำนวนเงินสะสมเก็บไว้ที่ตัวแปร sum
                float thisCash = float.Parse(lbm_cash.Text);
                //แปลงจำนวนเงินที่ต้อชำระในงวดนี้
                
                total = sum + thisCash;
                
                try
                {
                    string sqlSave1 = "UPDATE member SET amount ='" + total + "' WHERE m_id='" +txtm_id.Text+ "' and status_life <>'D'";

                    MySqlCommand myCommand1 = new MySqlCommand(sqlSave1);
                    myCommand1.Connection = mycon;
                    mycon.Open();
                    myCommand1.ExecuteNonQuery();
                    myCommand1.Connection.Close();

                    mycon.Close();



                    //----update pay นะคับสำหรับคนที่จ่ายเงินในงวดนั้นๆๆ
                    string sqlSave2 = "UPDATE pay SET pay_date =NOW(),pay_cash=" + thisCash + ", status =1  WHERE l_id = '"+cbx_lot.Text+"' AND  m_id = '"+txtm_id.Text+"'";

                    MySqlCommand myCommand2 = new MySqlCommand(sqlSave2);
                    myCommand2.Connection = mycon;
                    mycon.Open();
                    myCommand2.ExecuteNonQuery();
                    myCommand2.Connection.Close();

                    mycon.Close();


                    MessageBox.Show("ระบบได้ทำการบันทึกข้อมูลเรียบร้อยแล้วคับ...OK!!", "Saves data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ระบบไม่สามารถบันทึกข้อมูลเนื่องจาก.."+ex, "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                btn_print.Enabled = true;
                btn_save.Enabled = false;
                btn_cancel.Enabled = false;


            }

        }


        // print
        private void btn_print_Click(object sender, EventArgs e)
        {
            this.lbm_DieNames.Text = "";
            this.lbm_cash.Text = "";
            this.cbx_lot.Text = "";
          //  cbx_lot.Enabled = false;
          //  btn_go.Enabled = false;


            txtm_id.ReadOnly = false;
            btn_find.Enabled = true;
 
            this.lbm_amount.Text=""+total;
            //แสดงข้อมูลใน Grid
           // LoadDataDispay(m_id);// call method
            LoadDataDispay(txtm_id.Text);

            btn_go.Enabled = true;
            cbx_lot.Enabled = true;

            //showComboLot(m_id);// call method
            showComboLot(txtm_id.Text);
            cbx_lot.Text = "";// clear Data Combobox

            
            
            //---------
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            btn_print.Enabled = false;

            //ClearDataFrom();

        }

        

    }
}