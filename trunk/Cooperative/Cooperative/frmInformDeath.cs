using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using LogingSendID;
using System.Globalization;


namespace Cooperative
{
    public partial class frmInformDeath : Form
    {

        private connDataBase cnnBase = new connDataBase();
        private MySqlDataAdapter adapter;
        private DataSet ds;
        DateTime dd = DateTime.Now;//add start_date
        String ddmmyy = "yyyy-MM-dd";
        DateTimeFormatInfo dtfInfo = DateTimeFormatInfo.InvariantInfo;
        private string temp_m_id = "";
        //  private void Conn()
        // {
        string str_con = "datasource=localhost;username=root;password=root;database=db_cooperative";
        MySqlConnection mycon;

        //*************
        string ld_id = "";
        //string ld_date = "";
        float ld_sum = 0;
        int ld_count = 0;
        string sql_temp = "";
        float sum_temp = 0;

        //******************
        string m_id = "";
        string m_fname = "";
        string m_lname = "";
        string m_sex = "";
        string m_address = "";
        string m_tel = "";
        string start_date = "";
        string m_amount = "";

        string p_idcard1 = "";
        string p_idcard2 = "";
        string p_idcard3 = "";
        string p_fname1 = "";
        string p_lname1 = "";
        string p_fname2 = "";
        string p_lname2 = "";
        string p_fname3 = "";
        string p_lname3 = "";
        string p_address = "";
        string p_tel = "";

        string relation = "";
        string group_name = "";


        public frmInformDeath()
        {
            InitializeComponent();
        }

        private void frmInformDeath_Load(object sender, EventArgs e)
        {

            lbl_currentdate.Text = DateTime.Today.ToShortDateString();
            setForm();//callmethod

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnPrint.Enabled = false;

            if (mtxt_id.Text == "")
            {
                mtxt_id.Focus();
            }
          
           // MessageBox.Show("Test  "+MaxID_currentDie());
            No_l_id.Text = MaxID_currentDie();//แสดงเลขที่งวดปัจจุบัน/หรืองวดล่วงหน้า
            loadDataMemberDie_current(No_l_id.Text);//เอาข้อมูลคนตายล่าสุดมาแสดงใน GridView
        
        }

        //method clear Data in text box
        private void ClearData()
        {
            //ในส่วนของข้อมูลสมาชิก  
            mtxt_id.Text = "";
            mtxt_fname.Text = "";
            mtxt_lname.Text = "";
            mcbx_sex.Text = "";
            mtxt_address.Text = "";
            mtxt_tel.Text = "";
            
            dtpk_start.Text = "";
            mcbx_die.Text = "";
            //dtpk_die.Text = "";
            mcbx_gtype.Text = "";
            lbl_summoney.Text = "";
            //***ในส่วนของ ผุ้รับผลประโยชน์
            ptxt_fname1.Text = "";
            ptxt_lname1.Text = "";
            ptxt_fname2.Text = "";
            ptxt_lname2.Text = "";
            ptxt_fname3.Text = "";
            ptxt_lname3.Text = "";
            ptxt_idcard1.Text = "";
            ptxt_idcard2.Text = "";
            ptxt_idcard3.Text = "";
            ptxt_tel.Text = "";
            ptxt_address.Text = "";
            mcbx_relation.Text = "";
           
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnPrint.Enabled = false;

        }
        //method set data
        private void setForm()
        {

            //ในส่วนของข้อมูลสมาชิก  

            mtxt_fname.ReadOnly = true;
            mtxt_lname.ReadOnly = true;
            mcbx_sex.Enabled = false;
            mtxt_address.ReadOnly = true;
            mtxt_tel.ReadOnly = true;
          
            dtpk_start.Enabled = false;
            mcbx_die.Enabled = false;
            dtpk_die.Enabled = false;
            mcbx_gtype.Enabled = false;

            //***ในส่วนของ ผุ้รับผลประโยชน์
            ptxt_fname1.ReadOnly = true;
            ptxt_lname1.ReadOnly = true;
            ptxt_fname2.ReadOnly = true;
            ptxt_lname2.ReadOnly = true;
            ptxt_fname3.ReadOnly = true;
            ptxt_lname3.ReadOnly = true;
            ptxt_idcard1.ReadOnly = true;
            ptxt_idcard2.ReadOnly = true;
            ptxt_idcard3.ReadOnly = true;
            ptxt_tel.ReadOnly = true;
            ptxt_address.ReadOnly = true;
            mcbx_relation.Enabled = false;

        }

        //เมธอด หาID ล่วงหน้า
        private string getNewid(string b)
        {
            // string temp = "" + (Integer.parseInt(b) + 1);
            string temp = "" + (int.Parse(b) + 1);
            string newSp_id;
            //switch (temp.length())
            switch (temp.Length)
            {
                case 1: newSp_id = "000000" + temp; break;
                case 2: newSp_id = "00000" + temp; break;
                case 3: newSp_id = "0000" + temp; break;
                case 4: newSp_id = "000" + temp; break;
                case 5: newSp_id = "00" + temp; break;
                case 6: newSp_id = "0" + temp; break;
                default: newSp_id = temp; break;
            }
            return newSp_id;
        }
        
        
        //ค้น ID สูงสุดของตาตางคนตาย/งวด
        private string MaxID_currentDie()
        {

            mycon = new MySqlConnection(str_con);
            string MaxID = "";

           //********
       //เป้นการหาว่างวดปัจจุบันนี้ตายครบห้าคนหรือไม่ ถ้าไม่จะเอา ID ไปใช้ในการ บันทึกข้อมูลคนตายในงวดนี้
            string sql = "SELECT max(l_id) as maxID FROM list_die WHERE l_count < 5";
            MySqlCommand Cmd = new MySqlCommand(sql, mycon);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                mycon.Open();

                //Obj Reader
                MySqlDataReader data1 = Cmd.ExecuteReader();
                //if(data1.Read())
                while(data1.Read())
                {
                    MaxID = data1.GetValue(0).ToString();
                }
               
                data1.Close();
                mycon.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errror  SELECT max(l_id) as maxID FROM list_die WHERE l_count < 5" + ex.Message);
                return MaxID="000000";
            }
        //****************************************
        //แต่ถ้าตายครบ 5 คนแล้วให้ทำการเอาค่างวดที่มากที่สุดมาเป้น ID ในการกำหนดเลขที่งวดล่วงหน้า ต่อไป
            try
            {
                if (MaxID == "")
                {

                    this.Cursor = Cursors.WaitCursor;
                    mycon.Open();

                    sql = "SELECT max(l_id) as maxID FROM list_die";
                    MySqlCommand Cmd2 = new MySqlCommand(sql, mycon);
                    MySqlDataReader data2 = Cmd2.ExecuteReader();
                    //if (data2.Read())
                    while(data2.Read())
                    {
                        MaxID = data2.GetValue(0).ToString();
                    }

                    //MaxID = "000000";
                    data2.Close();
                    mycon.Close();
                    this.Cursor = Cursors.Default;

                    if (MaxID == "")
                    {
                        MaxID = "000000";
                    }
                    //*****กำหนด ID ล่วงหน้าต่อไปโดยการเรียก method getNewID()
                    MaxID = getNewid(MaxID);

                }
                
                return MaxID;//เลขที่งวด
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errror  SELECT max(l_id) as maxID FROM list_die .." + ex.Message);
                return MaxID = "000000";
            } 
               
        }
        
        //method display data to table gridView หาคนตายล่าสุดในงวดปัจจุบัน
        private void loadDataMemberDie_current(string no_id)
        {
            try
            {
                
                mycon = new MySqlConnection(str_con);

                // cnnBase.Open();
                // ต้องเพิ่มเงื่อนไข ว่า m.flag_life ='L' คือยังมีชีวติถึงจะตายได้คับ
                string sql_str = "SELECT ld.l_id as ON_ID,ld.dd_date as Date,m.start_date as StartDate,ld.dd_m_id as MemberID,m.m_fname as FNameDie,m.m_lname as LNameDie,";
                sql_str += "ld.dd_amount as SumMoney,m.p_fname1 as ResultFname,m.p_lname1 as ResultLname";
                sql_str +=" FROM list_die_details ld,member m WHERE ld.dd_m_id=m.m_id and ld.l_id='"+no_id+"' ";
               
                adapter = new MySqlDataAdapter(sql_str, mycon);
                // adapter = cnnBase.ExecuteQuery(sql_str);
                ds = new DataSet();
                adapter.Fill(ds, "list_die_details,member");
                dataGridView_currentDie.ReadOnly = true;
                dataGridView_currentDie.DataSource = ds;
                dataGridView_currentDie.DataMember = "list_die_details,member";
                
                mycon.Close();
                // dataGrid1.DataSource = myds.Tables["employee"].DefaultView;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Errors loadDataMemberDie_current()" + ex.Message);
            }
        }

        //metho การดึงข้อมูลค่าจาฐานข้อมูลมาแสดงใน Commbobox
        private void showComboDeath_List()
        {
            mycon = new MySqlConnection(str_con);
            try
            {

                ///MySqlConnection mycon = new MySqlConnection("datasource=localhost;username=root;password=root;database=db_cooperative");
                //create a mysql DataAdapter
                string sql = "select * from cause_die order by cd_id";

                //cnnBase.SelectDatabase();
                //cnnBase.Open();
                adapter = new MySqlDataAdapter(sql, mycon);
                // adapter = cnnBase.ExecuteQuery(sql);
                ds = new DataSet();
                adapter.Fill(ds, "cause_die");
                mcbx_die.DataSource = ds.Tables["cause_die"];
                mcbx_die.DisplayMember = "cd_name";
                mcbx_die.ValueMember = "cd_id";
               
                mycon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(" showComboDeath Errors " + ex.Message);
            }

        }
        //ใส่ตัวเลขเท่านั้น
        private void mtxt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลขเท่านั้นคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxt_id.Focus();
                e.Handled = true;
            }
        }

        // ค้นหาสมาชิกมาแสดงข้อมูลและผู้รับผลประโยชน์
        private void btn_find_Click(object sender, EventArgs e)
        {

            mycon = new MySqlConnection(str_con);
            if (mtxt_id.Text == "")
            {
                MessageBox.Show("กรุณาป้อนรหัสสมาชิกด้วยคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxt_id.SelectAll();
                mtxt_id.Focus();
            }
            else
            {

                string SQLfind = "select m_id,m_fname,m_lname,m_sex,m_tel,m_address,start_date,amount,idcard1,idcard2,";
                SQLfind += "idcard3,p_fname1,p_lname1,p_fname2,p_lname2,p_fname3,p_lname3,p_tel,p_address,r_name,group_name";
                SQLfind += " from member m,member_group g,relation r  where m.m_group_id=g.group_id and m.m_r_id= r.r_id and";
                SQLfind += " m.m_id='" + mtxt_id.Text + "' and status_life <> 'D'  ";
                MySqlCommand cmdStr = new MySqlCommand(SQLfind,mycon);
              

                try
                {
                    
                    //Conn.Open();
                    mycon.Open();
                    this.Cursor = Cursors.WaitCursor;
                    MySqlDataReader dataGet = cmdStr.ExecuteReader();
                   
                    while(dataGet.Read())
                    {
                        m_id = dataGet.GetValue(0).ToString();
                        m_fname = dataGet.GetValue(1).ToString();
                        m_lname = dataGet.GetValue(2).ToString();
                        m_sex = dataGet.GetValue(3).ToString();
                        m_tel = dataGet.GetValue(4).ToString();
                        m_address = dataGet.GetValue(5).ToString();
                        start_date = dataGet.GetValue(6).ToString();
                        
                        m_amount = dataGet.GetValue(7).ToString();
                        
                        p_idcard1 = dataGet.GetValue(8).ToString();
                        p_idcard2 = dataGet.GetValue(9).ToString();
                        p_idcard3 = dataGet.GetValue(10).ToString();
                        p_fname1 = dataGet.GetValue(11).ToString();
                        p_lname1 = dataGet.GetValue(12).ToString();
                        p_fname2 = dataGet.GetValue(13).ToString();
                        p_lname2 = dataGet.GetValue(14).ToString();
                        p_fname3 = dataGet.GetValue(15).ToString();
                        p_lname3 = dataGet.GetValue(16).ToString();
                        p_tel = dataGet.GetValue(17).ToString();
                        p_address = dataGet.GetValue(18).ToString();
                        relation = dataGet.GetValue(19).ToString();
                        group_name = dataGet.GetValue(20).ToString();

                    }

                    dataGet.Close();
                    mycon.Close();
                   this.Cursor = Cursors.Default;

                   if (mtxt_id.Text != m_id || mtxt_id.Text == temp_m_id)//และตรวจสอบรหัส ID ซ้ำ
                    {
                        MessageBox.Show("ไม่พบรหัสสมาชิกในระบบคับ...!!", "ผลการค้นหา...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearData();
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnPrint.Enabled = false;
                        mtxt_id.Text = "";
                        mtxt_id.Focus();
                    }
                    else
                    {
                        if (mtxt_id.Text == m_id)
                        {
                           // this.btn_find.Enabled = false;
                            this.mtxt_id.Text = m_id;
                            this.mtxt_fname.Text = m_fname;
                            this.mtxt_lname.Text = m_lname;
                            this.mcbx_sex.Text = m_sex;
                            this.mtxt_tel.Text = m_tel;
                            this.mtxt_address.Text = m_address;
                            this.dtpk_start.Text = start_date;

                            this.lbl_summoney.Text = m_amount;

                            this.ptxt_idcard1.Text = p_idcard1;
                            this.ptxt_idcard2.Text = p_idcard2;
                            this.ptxt_idcard3.Text = p_idcard3;
                            this.ptxt_fname1.Text = p_fname1;
                            this.ptxt_fname2.Text = p_fname2;
                            this.ptxt_fname3.Text = p_fname3;
                            this.ptxt_lname1.Text = p_lname1;
                            this.ptxt_lname2.Text = p_lname2;
                            this.ptxt_lname3.Text = p_lname3;
                            this.ptxt_tel.Text = p_tel;
                            this.ptxt_address.Text = p_address;
                            this.mcbx_gtype.Text = group_name;
                            this.mcbx_relation.Text = relation;

                            this.mcbx_die.Enabled = true;
                            this.dtpk_die.Enabled = true;
                           
                            showComboDeath_List();//call method death List  becuase
                            mcbx_die.Text = "";
                            
                            btnSave.Enabled = true;
                           // btnCancel.Enabled = false;
                           // btnPrint.Enabled = false;
                            
                            if (mycon != null)
                            {
                                mycon.Close();
                            }

                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errors Exception!!"+ex.Message, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("SQL string  !!"+SQLfind, "Errors!!!...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btn_find.Enabled = true;
                    ClearData();
                }
            }

        }
        // บันทึกข้อมูลคนตาย
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            mycon = new MySqlConnection(str_con);
            
            if (dtpk_die.Text == "")
            {
                MessageBox.Show("กรุณาเลือกวันที่เสียชีวิตด้วยคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpk_die.Focus();
                return;
            }
            else if (mcbx_die.Text == "")
            {
                MessageBox.Show("กรุณาเลือกสาเหตุการเสียชีวิตด้วยคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mcbx_die.Focus();
                return;
            }
            else
            {
                string SQLEdit = "";
                //*****************
                // เปลี่ยน flag  ให้เสียชีวิต
                try
                {
                    SQLEdit = "UPDATE member SET end_date='" + dd.ToString(ddmmyy, dtfInfo) + "',status_life='D',m_cd_id= " + mcbx_die.SelectedValue + " ";
                    SQLEdit += " WHERE m_id='" + mtxt_id.Text + "'; ";

                    MySqlCommand myCommand = new MySqlCommand(SQLEdit);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();
                    mycon.Close();

                    // MessageBox.Show("ระบบได้ทำการ Update ข้อมูลเรียบร้อยแล้วคับ...OK!!", "Update data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errors!.ระบบไม่สามารถบันทึกข้อมูลผู้เสียชีวิตได้...!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //****
                //ในส่วนของการหาว่า L_ID  เป้น งวดเก่าหรือว่างวดใหม่ ถ้าเป้นงวดเก่าให้ Update ข้อมูลโดยการ set ค่า ตัวนับจำนวนเงิน เป้นต้น++
                //แต่ถ้าไม่มีการบันทึกข้อมูลให้ทำการในตาราง List_die  ให้ทำการ insert into เข้าไปในตารางโดย มีค่า ตัวนับเป้น1
                string str_temp_ld_id = "";
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    mycon.Open();

                    //No_l_id คือ เลขที่งวดน่ะคับ/เลขที่งวดปัจจุบัน 
                    sql_temp = "SELECT l_id,l_sum,l_count FROM list_die where l_id='" + No_l_id.Text + "'";
                    MySqlCommand Cmd3 = new MySqlCommand(sql_temp, mycon);
                    MySqlDataReader data3 = Cmd3.ExecuteReader();
                    if(data3.Read())
                    {
                        str_temp_ld_id = data3.GetValue(0).ToString();
                        //ld_date = data3.GetValue(1).ToString();
                        ld_sum = data3.GetFloat(1);
                        // ld_sum = Convert.ToInt32
                        ld_count = data3.GetInt32(2);
                        ld_id = str_temp_ld_id;
                    }

                    data3.Close();
                    mycon.Close();
                    this.Cursor = Cursors.Default;

                    //******************
                    sum_temp = float.Parse(lbl_summoney.Text);
                    ld_sum = ld_sum + sum_temp;
                    ld_count++;
                    //MessageBox.Show(" sum_temp ...." + sum_temp + "\nld_sum.." + ld_sum);
                    //ตรวจสอบว่า ld_id มีในตาราง List_die หรือไม่คือถ้ามีให้ทำการ Update ดังนี้
                    MessageBox.Show("list_die id="+ld_id);
                    if (str_temp_ld_id != "")
                    {
                      
                        //**********Update List_die ++
                        mycon = new MySqlConnection(str_con);
                        string sql_update = "";
                        sql_update = "UPDATE list_die SET l_update= NOW(),l_sum=" + ld_sum + ",l_count= " + ld_count + " ";
                        sql_update += " WHERE l_id='" + ld_id + "'; ";

                        MySqlCommand myCmd1 = new MySqlCommand(sql_update);
                        myCmd1.Connection = mycon;
                        mycon.Open();
                        myCmd1.ExecuteNonQuery();
                        myCmd1.Connection.Close();
                        mycon.Close();


                        //******insert to table List_die_details
                        mycon = new MySqlConnection(str_con);
                        string sql_add = "";
                        sql_add = "insert into list_die_details(l_id,dd_date,dd_amount,dd_m_id)";
                        sql_add += " values('" +ld_id + "',NOW()," + sum_temp + ",'" + mtxt_id.Text + "') ";
                        MySqlCommand myCmd2 = new MySqlCommand(sql_add);
                        myCmd2.Connection = mycon;
                        mycon.Open();
                        myCmd2.ExecuteNonQuery();
                        myCmd2.Connection.Close();
                        mycon.Close();
                        
                        temp_m_id = mtxt_id.Text;//เอาค่า ID ล่าสุดที่ตายไว้ตรวจสอบกรณีที่มีการป้อน ID member ซ้ำ

                        
                        //*ตรวจสอบว่า count จำนวนคนตายครบ 5 คนหรือไม่ในงวดนั้นๆๆ
                            if (ld_count >= 5)
                            {
                                // update status = 1 พร้อมชำระ
                                // insert cash_list statust =1 พร้อมชำระ
                                 string sql_temp1 = "";
                                try
                                {
                                    mycon = new MySqlConnection(str_con);
                                   
                                    sql_temp1 = "UPDATE list_die SET l_update= NOW(),l_sum=" + ld_sum + ",l_count= " + ld_count + ",status=1 ";
                                    sql_temp1 += " WHERE l_id='" + ld_id + "'; ";

                                    MySqlCommand myCmd3 = new MySqlCommand(sql_temp1);
                                    myCmd3.Connection = mycon;
                                    mycon.Open();
                                    myCmd3.ExecuteNonQuery();
                                    myCmd3.Connection.Close();
                                    mycon.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Errors!..UPDATE list_die.!!\n"+sql_temp1+"\n"+ ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }


                                //******insert to table cash ชำระเงิน
                                //*****หาจำนวนทั้งหมดของสมาชิกทีมีชีวิตอยู่น่ะคับพีน้อง
                                /*string get_countid = "";
                                try
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    mycon.Open();

                                    get_countid = "SELECT m_id FROM member WHERE  status_life <> 'D';";
                                    MySqlCommand CmdStr1 = new MySqlCommand(get_countid, mycon);
                                    MySqlDataReader dataGet1 = CmdStr1.ExecuteReader();
                                    
                                    //*******insert
                                    string sql_insert= "insert into pay(l_id,m_id,status) ";
                                    MySqlCommand CmdAdd;
                                    mycon = new MySqlConnection(str_con);
                                    while(dataGet1.Read())
                                    {
                                        get_countid = dataGet1.GetValue(0).ToString();
                                        //--insert to  pay
                                        sql_insert += " values('" + ld_id + "','" + get_countid + "',0)";

                                        CmdAdd = new MySqlCommand(sql_insert);
                                        CmdAdd.Connection = mycon;
                                        mycon.Open();
                                        CmdAdd.ExecuteNonQuery();
                                    }
                                    //*close insert
                                   // CmdAdd.Connection.Close();
                                    mycon.Close();
                                    //--------
                                    dataGet1.Close();
                                    mycon.Close();
                                    this.Cursor = Cursors.Default;

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Errors!..insert to table cash ชำระเงิน.!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }*/


                               string get_countid= "";
                                int ncount = 0;
                                string[] arrM_id=new string[1];
                                
                                try
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    mycon.Open();

                                    get_countid = "SELECT count(m_id) AS id FROM member WHERE  status_life <> 'D';";
                                    MySqlCommand CmdStr1 = new MySqlCommand(get_countid, mycon);
                                    MySqlDataReader dataGet1 = CmdStr1.ExecuteReader();
                                    while (dataGet1.Read())
                                    {
                                        ncount = dataGet1.GetInt32(0);
                                    }
                                    dataGet1.Close();
                                    mycon.Close();
                                    this.Cursor = Cursors.Default;

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Errors!.หาจำนวนทั้งหมดของสมาชิกทีมีชีวิตอยู่..!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                               //**จบการหารจำนวนสมาชิกทั้งหมดน่ะคับ
                               
                               
                                if (ncount != 0)
                                {
                                    //ncount++;
                                    arrM_id = new string[ncount];// กำหนดจำนวน array
                                }

                                //*******เอาค่า ID member มาเก็บใน array
                                string getValue = "";
                                try
                                {
                                    int i = 0;

                                    this.Cursor = Cursors.WaitCursor;
                                    mycon.Open();

                                    getValue = "SELECT m_id  FROM member WHERE  status_life <> 'D';";
                                    MySqlCommand CmdStr2 = new MySqlCommand(getValue, mycon);
                                    MySqlDataReader dataGet2 = CmdStr2.ExecuteReader();
                                    while (dataGet2.Read())
                                    {
                                        //ncount = dataGet2.GetInt32(0);
                                        //temp_ld_id = data_get.GetValue(0).ToString();
                                        arrM_id[i] = dataGet2.GetValue(0).ToString();
                                        i++;
                                    }
                                    dataGet2.Close();
                                    mycon.Close();
                                    this.Cursor = Cursors.Default;

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Errors!.เอาค่า ID member มาเก็บใน array..!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                //**เอาค่า ID member มาเก็บใน array

                                mycon = new MySqlConnection(str_con);
                                string AddStr = "";

                               // insert ข้อมูลสมาชิกทั้งหมดเข้า ตาราง pay คับพี่น้องจะไหวไหมเนียถ้า member เยอะอ่ะจะบ้าตาย
                                for (int j = 0; j < ncount; j++)
                                {
                                   AddStr = "insert into pay(l_id,m_id,status)";
                                    AddStr += " values('" + ld_id + "','" + arrM_id[j] + "',0) ";

                                    MySqlCommand cmdAdd = new MySqlCommand(AddStr);
                                    cmdAdd.Connection = mycon;
                                    mycon.Open();
                                    cmdAdd.ExecuteNonQuery();
                                    cmdAdd.Connection.Close();
                                    //MessageBox.Show("m_id = "+arrM_id[j]);
                                    
                                }
                              mycon.Close();
                               

                            }//จบการตรวจสอบว่าจำนวนงวดครบ 5 คนหรือไม่   if(ld_count >= 5)
 
                    }
                    else //ถ้าไม่มีในตาราง List_Die ให้ทำการ Insert เข้า Database 
                    {
                       

                        mycon = new MySqlConnection(str_con);
                        string sql_add = "";
                        sql_add = "insert into list_die(l_id,l_date,l_sum,l_count)";
                        sql_add += " values('" + No_l_id.Text + "',NOW()," + sum_temp + ",1) ";

                        MySqlCommand myCmd1 = new MySqlCommand(sql_add);
                        myCmd1.Connection = mycon;
                        mycon.Open();
                        myCmd1.ExecuteNonQuery();
                        myCmd1.Connection.Close();
                        mycon.Close();

                        //MessageBox.Show("insert list die " + sql_add);
                        //******insert to table List_die_details
                        mycon = new MySqlConnection(str_con);
                        sql_add = "";
                        sql_add = "insert into list_die_details(l_id,dd_date,dd_amount,dd_m_id)";
                        sql_add += " values('" + No_l_id.Text + "',NOW()," + sum_temp + ",'" + mtxt_id.Text + "') ";
                        MySqlCommand myCmd2 = new MySqlCommand(sql_add);
                        myCmd2.Connection = mycon;
                        mycon.Open();
                        myCmd2.ExecuteNonQuery();
                        myCmd2.Connection.Close();
                        mycon.Close();
                        
                        temp_m_id = mtxt_id.Text;//เอาค่า ID ล่าสุดที่ตายไว้ตรวจสอบกรณีที่มีการป้อน ID member ซ้ำ
                       
                    }//else //ถ้าไม่มีในตาราง List_Die ให้ทำการ Insert เข้า Database 
                    
                    
                    //*****************
                    // MessageBox.Show("Test  "+MaxID_currentDie());
                    No_l_id.Text = MaxID_currentDie();//แสดงเลขที่งวดปัจจุบัน/หรืองวดล่วงหน้า
                    loadDataMemberDie_current(No_l_id.Text);//เอาข้อมูลคนตายล่าสุดมาแสดงใน GridView
                    ClearData();// clear Form data

                    // control button
                   // mtxt_id.ReadOnly = true;
                    mtxt_id.Enabled = false;
                    btn_find.Enabled = false;
                    mcbx_die.Enabled = false;
                    dtpk_die.Enabled = false;

                    btnCancel.Enabled = true;
                    btnPrint.Enabled = true;
                    //**********
                    if (mycon != null)
                    {
                        mycon.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errors!.เรื่องการ Update หรือ Insert เข้าตาราง List_die/Liste_die_details..!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }// End ถ้าไม่เป้นค่าว่างน่ะคับพี่น้อง


         }//End save
        
        // ผูกวันที่น่ะคับเลือกวันที่ได้เลย
        private void dtpk_die_ValueChanged(object sender, EventArgs e)
        {
            dd = dtpk_die.Value;
        }
        
       
        
        // เมือคลิก Cencel ในรายการที่ทำสำการแจ้งเสียชีวิต***********************************************************
        private void btnCancel_Click(object sender, EventArgs e)
        {

            //**หาว่าในตาราง list_die นั้นมีข้อมูลอะไรบ้างแล้วให้ทำการคือค่าเก่า
            string temp_ld_id = "";
            float temp_sum = 0;
            int temp_count = 0;
            int temp_status = 0;

            //ถ้าเป้นคนแรกใน liste_die จะมีค่าเป้น null
            //ให้ตรวจสอบว่าเป้นค่าว่างป่าวถ้าว่างให้เอาค่าจาก งวดที่แสดงมาใส่ตัวแปร
            if (ld_id == "")
            {
                ld_id = No_l_id.Text;//งวดแรก
            }
            string sql_get = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                mycon.Open();

                //No_l_id คือ เลขที่งวดน่ะคับ/เลขที่งวดปัจจุบัน 
                sql_get = "SELECT l_id,l_date,l_update,l_sum,l_count,status FROM list_die where l_id='" +ld_id+ "'";
                MySqlCommand Cmd_get = new MySqlCommand(sql_get, mycon);
                MySqlDataReader data_get = Cmd_get.ExecuteReader();
                while (data_get.Read())
                {
                    temp_ld_id = data_get.GetValue(0).ToString();
                    
                    temp_sum = data_get.GetFloat(3);
                    temp_count = data_get.GetInt32(4);
                    temp_status = data_get.GetInt32(5);

                }

                data_get.Close();
                mycon.Close();
                this.Cursor = Cursors.Default;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Errors!.SQL command!!" + sql_get, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Errors!.!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
          
            // สำหรับในส่วนของ List_die_Details*****************

            string sql_ldd = "";

            try
            {
                mycon = new MySqlConnection(str_con);
                sql_ldd = "DELETE FROM list_die_details  WHERE dd_m_id = '" +m_id+ "' AND l_id = '" +ld_id+ "'";

                MySqlCommand myCmd_ldd = new MySqlCommand(sql_ldd);
                myCmd_ldd.Connection = mycon;
                mycon.Open();
                myCmd_ldd.ExecuteNonQuery();
                myCmd_ldd.Connection.Close();
                mycon.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Errors!.SQL command!!" +sql_ldd, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Errors!.!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            //** สำหรับ List_die***************************
             
            string sql_ld = "";
            //***************

            temp_sum = temp_sum - sum_temp;
            temp_count--;
            //**********
            try
            {
                mycon = new MySqlConnection(str_con);

                sql_ld = "UPDATE list_die SET l_update= NOW(),l_sum=" + temp_sum + ",l_count=" + temp_count + " ";
                sql_ld += " WHERE l_id='" +ld_id+ "'; ";

                MySqlCommand myCmd_ld = new MySqlCommand(sql_ld);
                myCmd_ld.Connection = mycon;
                mycon.Open();
                myCmd_ld.ExecuteNonQuery();
                myCmd_ld.Connection.Close();
                mycon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Errors!..!!" + sql_ld, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Errors!.!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
            //*****************
            MessageBox.Show("Update list Die  "+sql_ld);
            No_l_id.Text = MaxID_currentDie();//แสดงเลขที่งวดปัจจุบัน/หรืองวดล่วงหน้า
            loadDataMemberDie_current(No_l_id.Text);//เอาข้อมูลคนตายล่าสุดมาแสดงใน GridView
            ClearData();// clear Form data
            // control button
            // mtxt_id.ReadOnly = true;
            mtxt_id.Enabled = true;
            btn_find.Enabled = true;
            mcbx_die.Enabled = true;
            dtpk_die.Enabled = true;

            btnCancel.Enabled = false;
            btnPrint.Enabled = false;

            temp_m_id = "";// clear ค่าเก่าด้วยน่ะสำหรับเช็กว่าตายซ้ำป่าวน่ะคับ
            
           //สำหรับ Member cancle****************************
            string sql_mem = "";

            try
            {
                mycon = new MySqlConnection(str_con);
                sql_mem = "UPDATE member SET end_date=null,status_life='L',m_cd_id=null  ";
                sql_mem += " WHERE m_id='" +m_id+ "'; ";


                MySqlCommand myCmd_mem = new MySqlCommand(sql_mem);
                myCmd_mem.Connection = mycon;
                mycon.Open();
                myCmd_mem.ExecuteNonQuery();
                myCmd_mem.Connection.Close();
                mycon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Errors!..SQL " + sql_mem, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Errors!.!!" + ex.Message, "Errors...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show("member SQL Update  " +sql_mem);

        }

        //**method สำหรับ print ใบเสร็จแจ้งรายการรับเงินสำหรับผู้ที่ได้รับประโยชน์
        private void btnPrint_Click(object sender, EventArgs e)
        {
            mtxt_id.Enabled = true;
            btn_find.Enabled = true;
            //mcbx_die.Enabled = true;
            //dtpk_die.Enabled = true;

            btnCancel.Enabled = false;
            btnPrint.Enabled = false;
        }
    }
}