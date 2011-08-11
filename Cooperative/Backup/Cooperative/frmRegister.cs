using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Globalization;

namespace Cooperative
{
    public partial class frmRegister : Form
    {
        enum State {None,Add,Modify,Delete}//ประกาศตัวแปร enum  เพื่อไปใช้ในการควบคุม Event ของปุ่ม
        private connDataBase cnnBase = new connDataBase();
        private MySqlDataAdapter adapter;
        private DataSet ds;
        private int current_pos;
        private int row_count;
        private State state = 0;
        DateTime dd = DateTime.Now;//add start_date
        DateTime ddEdit = DateTime.Now;//Edit  last_update
        DateTimeFormatInfo dtfInfo = DateTimeFormatInfo.InvariantInfo;
        

        MySqlConnection mycon = new MySqlConnection("datasource=localhost;username=root;password=root;database=db_cooperative");

        
        public frmRegister()
        {
            InitializeComponent();
        }

        //method display data to table gridView
        private void loadDatabase()
        {
            try
            {
                //cnnBase.SelectDatabase();
               
                // cnnBase.Open();
                //string sql_str = "Select * from member m where status_life = 'L' order by m_id";
               string sql_str = "SELECT m_id as ID,m_fname as Name,m_lname as LastName,m_sex as Sex,m_tel as Tel,";
                sql_str += " m_address as Address,start_date as StartDate,m_first_money as Bugget,status_life as FlagLife,idcard1 as IDCard1 ";
                sql_str += ",idcard2 as IDCard2,idcard3 as IDCard3 ,p_fname1 as Name1,p_lname1 as LastName1,p_fname2 as Name2,p_lname2 as LastName2 ";
                sql_str += ",p_fname3 as Name3,p_lname3 as LastName3,p_address as P_Address,p_tel as P_Tel,m_r_id as RelationID,m_group_id as GroupID";
                sql_str += " FROM member order by m_id desc LIMIT 0,50";
            
               //string sql_str = "Select * from member m  order by m_id";
                adapter = new MySqlDataAdapter(sql_str,mycon);
                // adapter = cnnBase.ExecuteQuery(sql_str);
                ds = new DataSet();
                adapter.Fill(ds, "member");
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "member";
                // dataGrid1.DataSource = myds.Tables["employee"].DefaultView;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Errors load database " + ex.Message);
            }
        }

        // clear Data
        private void ClearData()
        {

            m_txt_id.Text = "";
            m_cbx_gtype.Text = "";
            m_txt_fname.Text = "";
            m_txt_lname.Text = "";
            m_txt_address.Text = "";
            m_cbx_sex.Text = "";
            m_txt_tel.Text = "";
            m_txt_fmoney.Text = "";
            m_txt_datePTK.Text = "";

            p_txt_fname1.Text = "";
            p_txt_lname1.Text = "";
            p_txt_fname2.Text = "";
            p_txt_lname2.Text = "";
            p_txt_fname3.Text = "";
            p_txt_lname3.Text = "";
            p_txt_idcard1.Text = "";
            p_txt_idcard2.Text = "";
            p_txt_idcard3.Text = "";
            p_txt_address.Text = "";
            p_txt_tel.Text = "";
            m_cbx_relation.Text = "";
        }

        // เมธอด Resetdata
        private void ResetField()
        {
            //ในส่วนของข้อมูลสมาชิก  
            m_txt_id.ReadOnly = true;
            //m_txt_fname.ReadOnly = true;
            m_cbx_relation.Enabled = false;
            m_cbx_gtype.Enabled = false;
            m_txt_fname.ReadOnly = true;
            m_txt_lname.ReadOnly = true;
            m_txt_address.ReadOnly = true;
            m_cbx_sex.Enabled = false;
            m_txt_tel.ReadOnly = true;
            m_txt_fmoney.ReadOnly = true;
            m_txt_datePTK.Enabled = false;
            //ในส่วนของข้อมูล ผู้รับผลประโยช์
            p_txt_fname1.ReadOnly = true;
            p_txt_lname1.ReadOnly = true;
            p_txt_fname2.ReadOnly = true;
            p_txt_lname2.ReadOnly = true;
            p_txt_fname3.ReadOnly = true;
            p_txt_lname3.ReadOnly = true;
            p_txt_idcard1.ReadOnly = true;
            p_txt_idcard2.ReadOnly = true;
            p_txt_idcard3.ReadOnly = true;
            p_txt_address.ReadOnly = true;
            p_txt_tel.ReadOnly = true;
 
        }
        //method ชี้ตำแหน่งในฐานข้อมูล
        private void loadData(int position)
        {
           try
           {
            //ในส่วนของข้อมูลสมาชิก  
                                m_txt_id.ReadOnly = true;
                                //m_txt_fname.ReadOnly = true;
                                //m_txt_lname.ReadOnly = true;
                                m_cbx_gtype.Enabled = false;
                                m_txt_fname.ReadOnly = true;
                                m_txt_lname.ReadOnly = true;
                                m_txt_address.ReadOnly = true;
                                m_cbx_sex.Enabled = false;
                                m_txt_tel.ReadOnly = true;
                                m_txt_fmoney.ReadOnly = true;
                                m_txt_datePTK.Enabled = false;
                                m_cbx_relation.Enabled = false;
               //ในส่วนของข้อมูล ผู้รับผลประโยช์
                                p_txt_fname1.ReadOnly = true;
                                p_txt_lname1.ReadOnly = true;
                                p_txt_fname2.ReadOnly = true;
                                p_txt_lname2.ReadOnly = true;
                                p_txt_fname3.ReadOnly = true;
                                p_txt_lname3.ReadOnly = true;
                                p_txt_idcard1.ReadOnly = true;
                                p_txt_idcard2.ReadOnly = true;
                                p_txt_idcard3.ReadOnly = true;
                                p_txt_address.ReadOnly = true;
                                p_txt_tel.ReadOnly = true;

                                //ถ้าค่าที่ตัวแปรชี้ตำแหน่งในฐานข้อมูลมากกว่าจำนวนตำแหน่งในฐานข้อมูลจริง  ค่าตัวแปรจะชีบอกตำแหน่ง
                                if (position > this.BindingContext[ds, "member"].Count - 1)
                                {
                                    current_pos = this.BindingContext[ds,"member"].Count-1;
                                    position = this.BindingContext[ds, "member"].Count - 1;
                                }

                                //ถ้าตัวชี้ตำแหน่งในฐานข้อมูล < 0  ข้อมูลจะฟ้องว่าไม่พบข้อมูลใน database 
                                if (position < 0)
                                {
                                    tsTxtPageNum.Text = "No Record";
                                    stBDelete.Enabled = false;
                                    stBEdit.Enabled = false;

                                    ClearData();

                                    return;
                                }

                                //ส่วนนี้เป้นการเอาค่าที่ได้จากตำแหน่งในฟิลด์ตั้งแต่ฟิลด์แรกถึงฟิดด์สุดท้ายมาใส่ใน text box
                                m_txt_id.Text= ds.Tables["member"].Rows[position][0].ToString();
                                m_txt_fname.Text = ds.Tables["member"].Rows[position][1].ToString();
                                m_txt_lname.Text = ds.Tables["member"].Rows[position][2].ToString();
                                m_cbx_sex.Text = ds.Tables["member"].Rows[position][3].ToString();
                                m_txt_tel.Text = ds.Tables["member"].Rows[position][4].ToString();
                                m_txt_address.Text = ds.Tables["member"].Rows[position][5].ToString();
                                m_txt_datePTK.Text= ds.Tables["member"].Rows[position][6].ToString();
                               
                                m_txt_fmoney.Text = ds.Tables["member"].Rows[position][7].ToString();
                               

                                //****.ส่วนของผู้รับผลประโยช์
                                p_txt_fname1.Text = ds.Tables["member"].Rows[position][12].ToString();
                                p_txt_lname1.Text = ds.Tables["member"].Rows[position][13].ToString();
                                p_txt_fname2.Text = ds.Tables["member"].Rows[position][14].ToString();
                                p_txt_lname2.Text = ds.Tables["member"].Rows[position][15].ToString();
                                p_txt_fname3.Text = ds.Tables["member"].Rows[position][16].ToString();
                                p_txt_lname3.Text = ds.Tables["member"].Rows[position][17].ToString();
                                p_txt_idcard1.Text = ds.Tables["member"].Rows[position][9].ToString();
                                p_txt_idcard2.Text = ds.Tables["member"].Rows[position][10].ToString();
                                p_txt_idcard3.Text = ds.Tables["member"].Rows[position][11].ToString();
                                p_txt_address.Text = ds.Tables["member"].Rows[position][18].ToString();
                                p_txt_tel.Text = ds.Tables["member"].Rows[position][19].ToString();

                                m_cbx_relation.Text = ds.Tables["member"].Rows[position][20].ToString();              
                                m_cbx_gtype.Text = ds.Tables["member"].Rows[position][21].ToString();
               
                               row_count = this.BindingContext[ds, "member"].Count;
                                
                                //ถ้าตำแหน่งที่นับได้มากกว่าหรือเท่ากับจำจวนแถุวที่นัดได้จิงให้ปุ่ม next และปุ่ม First ไม่สามารถทำงานได้
                                if (current_pos >= row_count - 1)
                                {
                                    tsBMoveNext.Enabled = false;
                                    tsBMoveFirst.Enabled = false;
                                }
                                else
                                {
                                // ถ้าตำแหน่งที่นับไม่ได้มากกว่าหรือเท่ากับจำนวนแถวที่นับได้ให้ปุ่ม next & first ทำงาน
                                    tsBMoveNext.Enabled = true;
                                    tsBMoveFirst.Enabled = true;
                                }

                                //ถ้าตำแหน่งที่นับได้น้อยกว่าหรอืเท่ากับ 0จิง ให้ปุ่ม previous และปุ่ม last ไม่สามารถทำงานได้
                                if (current_pos <= 0)
                                {
                                    tsBMoveProvious.Enabled = false;
                                    tsBMoveLast.Enabled = false;
                                   
                                }
                                else
                                {
                                    //ถ้าตำแหน่งที่นับไม่ได้น้อยก่วาศูนย์ให้ทั้งสองปุ่มทำงาน
                                    tsBMoveProvious.Enabled = true;
                                    tsBMoveLast.Enabled = true;
                                }

                                stBAdd.Enabled = true;
                                stBEdit.Enabled = true;
                                stBDelete.Enabled = true;
                                stBCancel.Enabled = false;//**********
                                this.BindingContext[ds, "member"].Position = position;
                                //ให้อ่านค่าตำแหน่งที่ถูกต้องแล้วนำมาแสดงบน tstTextPaeNum.text
                                tsTxtPageNum.Text = Convert.ToString(current_pos+1);
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(" Load Data Errors " +ex.Message);
                    }

        }

        //metho การดึงข้อมูลค่าจาฐานข้อมูลมาแสดงใน Commbobox
        private void showCombo()
        {

            try
            {

                ///MySqlConnection mycon = new MySqlConnection("datasource=localhost;username=root;password=root;database=db_cooperative");
                //create a mysql DataAdapter
                string sql = "select * from member_group order by group_id";
              
                //cnnBase.SelectDatabase();
                //cnnBase.Open();
               adapter = new MySqlDataAdapter(sql, mycon);
               // adapter = cnnBase.ExecuteQuery(sql);
                ds = new DataSet();
                adapter.Fill(ds, "member_group");
                m_cbx_gtype.DataSource = ds.Tables["member_group"];
                m_cbx_gtype.DisplayMember = "group_name";
                m_cbx_gtype.ValueMember = "group_id";
                mycon.Close();
         
             }
            catch(Exception ex)
            {
                Console.WriteLine(" showCombo() Errors " + ex.Message);
            }
           
        }
        //metho การดึงข้อมูลค่าจาฐานข้อมูลมาแสดงใน Commbobox Relation
        private void showComboRelation()
        { 
            try
            {
                string sql = "select * from relation order by r_id";
              
                //cnnBase.SelectDatabase();
                //cnnBase.Open();
               adapter = new MySqlDataAdapter(sql, mycon);
               // adapter = cnnBase.ExecuteQuery(sql);
                ds = new DataSet();
                adapter.Fill(ds, "relation");
                m_cbx_relation.DataSource = ds.Tables["relation"];
                m_cbx_relation.DisplayMember = "r_name";
                m_cbx_relation.ValueMember = "r_id";
                mycon.Close();
         
             }
            catch(Exception ex)
            {
                Console.WriteLine(" showComboRelation( Errors " + ex.Message);
            }
        }

       //การโหลดข้อมูลแสดงบนหน้าจอเมือนถูกเปิดขั้น
        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                m_cbx_sex.Items.Add("หญิง");
                m_cbx_sex.Items.Add("ชาย");
                showCombo();//****************call mathod
                showComboRelation();//****************call mathod

                loadDatabase();//******** call method
                current_pos = this.BindingContext[ds, "member"].Count;//นับตำแหน่ง
                tsTxtPageSum.Text += "[" + current_pos + "]";//แสดงผลรวมนับตำแหน่ง
                current_pos = this.BindingContext[ds, "member"].Position;//ชี้บอกตำแหน่ง

                loadData(current_pos);//call method  ชี้ตำแหน่งใน Database
            }
            catch(Exception ex)
            {
                Console.WriteLine("frmRegister load Errors " + ex.Message);
            }
        }

        private void tsBMoveNext_Click(object sender, EventArgs e)
        {
           try
           {
            if (state != State.None)
                return;
            //ชี้ตำแหน่งถัดไปจากตำแหน่งแรกที่พบ
            this.BindingContext[ds, "member"].Position = this.BindingContext[ds, "member"].Position + 1;
            //นับตำแหน่งที่ชี้
            current_pos = this.BindingContext[ds, "member"].Position;

            loadData(current_pos);//call  method
            }
            catch(Exception ex)
            {
                Console.WriteLine(" tsBMoveNext_Click  Errors " + ex.Message);
            }
        }

        private void tsBMoveFirst_Click(object sender, EventArgs e)
        {
            try
            {
               if (state != State.None)
                        return;
                    //ชี้ตำแหน่งท้ายสุด
                    this.BindingContext[ds, "member"].Position = this.BindingContext[ds,"member"].Count-1;
                    //นับตำแหน่งที่ชี้
                    current_pos = this.BindingContext[ds, "member"].Position;

                    loadData(current_pos);//call  method
            }
            catch(Exception ex)
            {
                Console.WriteLine(" tsBMoveFirst_Click  Errors " + ex.Message);
            }


        }

        private void tsBMoveProvious_Click(object sender, EventArgs e)
        {
               try
               {
            
                   if (state != State.None)
                        return;
                    //ชี้ตำแหน่งถอยหลังจากตำแหน่งที่พบแรกสุด
                    this.BindingContext[ds, "member"].Position = this.BindingContext[ds, "member"].Position- 1;
                    //นับตำแหน่งที่ชี้
                    current_pos = this.BindingContext[ds, "member"].Position;

                    loadData(current_pos);//call  method
            }
            catch(Exception ex)
            {
                Console.WriteLine(" tsBMoveProvious_Click  Errors " + ex.Message);
            }

        }

        private void tsBMoveLast_Click(object sender, EventArgs e)
        {
               try
               {
                    if (state != State.None)
                        return;
                    //ชี้ตำแหน่งไปตำแหน่งแรกสุด
                    this.BindingContext[ds, "member"].Position = 0;
                    //นับตำแหน่งที่ชี้
                    current_pos = this.BindingContext[ds, "member"].Position;

                    loadData(current_pos);//call  method
             }
            catch(Exception ex)
            {
                Console.WriteLine(" tsBMoveLast_Click  Errors " + ex.Message);
            }
        }

       //เมธอด Add data to base
        private void stBAdd_Click(object sender, EventArgs e)
        {
            //ถ้ายังไม่กดปุ่ม add ให้การทำงานต่างๆของ Oject บนห้น้าจอเหมือนที่เปิดหน้าจอครั้งแรก
            if (state == State.None)
            {
                state = State.Add;  //ถ้ากดปุ่ม add ให้ Text box ถูกเตรียมเพือรับข้อมุล
                stBAdd.Text = " &Save ";

                string MaxID = "";

                string sql = "SELECT max(m_id) as maxID FROM member";
                MySqlCommand Cmd = new MySqlCommand(sql, mycon);
                try
                {
                    //this.Cursor = Cursors.WaitCursor;
                    mycon.Open();

                    //Obj Reader
                    MySqlDataReader data1 = Cmd.ExecuteReader();
                    while (data1.Read())
                    {
                        MaxID = data1.GetValue(0).ToString();
                       // MaxID = data1.GetString("maxID").ToString();

                    }
                    if (MaxID == "")
                    {
                        MaxID = "000000";
                    }
                    mycon.Close();

                    // this.Cursor = Cursors.Default;mycon
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL select max_id Errors..!!!" + ex.Message);
                }
                //--------------
                //ในส่วนของข้อมูลสมาชิก  
                m_txt_id.ReadOnly = false;
                m_txt_fname.ReadOnly = false;
                m_txt_lname.ReadOnly = false;
                m_txt_address.ReadOnly = false;
                m_txt_tel.ReadOnly = false;
                m_txt_fmoney.ReadOnly = false;

                m_cbx_sex.Enabled = true;
                m_cbx_gtype.Enabled = true;
                m_txt_datePTK.Enabled = true;
                m_cbx_relation.Enabled = true;
                //ในส่วนของข้อมูล ผู้รับผลประโยช์
                p_txt_fname1.ReadOnly = false;
                p_txt_lname1.ReadOnly = false;
                p_txt_fname2.ReadOnly = false;
                p_txt_lname2.ReadOnly = false;
                p_txt_fname3.ReadOnly = false;
                p_txt_lname3.ReadOnly = false;
                p_txt_idcard1.ReadOnly = false;
                p_txt_idcard2.ReadOnly = false;
                p_txt_idcard3.ReadOnly = false;
                p_txt_address.ReadOnly = false;
                p_txt_tel.ReadOnly = false;

                ClearData();
                m_txt_id.Text = getNewid(MaxID);//getNewID
                stBEdit.Enabled = false;
                stBDelete.Enabled = false;
                stBCancel.Enabled = true;

            }
            else //ถ้ายังกรอกข้อมูลใน txt box ไม่ครบจะแสดงข้อความเตือนขึ้นมา
            {
                if (m_txt_id.Text == "")
                {
                    MessageBox.Show("กรุณาป้อนรหัสสมาชิกด้วยคคับ...!!","คำแนะนำ...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    m_txt_id.Focus();
                    return;
                }
                else if (m_txt_fname.Text == "")
               {
                        MessageBox.Show("กรุณาป้อนชื่อสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        m_txt_fname.Focus();
                        return;
                }
                else if (m_txt_lname.Text == "")
                {
                            MessageBox.Show("กรุณาป้อนนามสกุลสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            m_txt_lname.Focus();
                            return;
                }
                else if (m_cbx_gtype.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบกลุ่มสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_gtype.Focus();
                    return;
                }
                else if (m_txt_datePTK.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบวันที่ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_datePTK.Focus();
                    return;
                }
                else if (m_txt_address.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบที่อยู่สมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_address.Focus();
                    return;
                }
                else if (m_cbx_sex.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบเพศด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_sex.Focus();
                    return;
                }
                else if (m_txt_tel.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบเบอร์โทรด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_tel.Focus();
                    return;
                }
               else if (m_txt_fmoney.Text == ""|| int.Parse(m_txt_fmoney.Text)<=0)
                {
                    MessageBox.Show("กรุณาตรวสอบจำนวนเงินแรกเข้าด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_fmoney.Focus();
                    return;
                }
                    //******ตรวสอบในส่วนของผู้รับผลประโยช์**********//
                else if (p_txt_address.Text == "")
                {
                    MessageBox.Show("กรุณาตรวสอบที่อยู่ผู้รับผลประโยชน์ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_address.Focus();
                    return;
                }
                else if (p_txt_tel.Text == "")
                {
                    MessageBox.Show("กรุณาตรวสอบเบอร์โทรผู้รับผลประโยชน์ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_tel.Focus();
                    return;
                }
                else if (m_cbx_relation.Text == "")
                {
                    MessageBox.Show("กรุณาตรวสอบสถานะเกี่ยวข้องเป็น  ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_relation.Focus();
                    return;
                }
                else if (p_txt_fname1.Text != "")
                {
                    if (p_txt_lname1.Text == "")
                    {
                        MessageBox.Show("กรุณาตรวจสอบนามสกุลผู้รับผลประโยชน์ 1 ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_lname1.Focus();
                        return;
                    }
                }
                else if (p_txt_fname1.Text == "" && p_txt_lname1.Text=="")
                {
                    if (p_txt_fname2.Text != "" || p_txt_lname2.Text != ""||p_txt_fname3.Text != "" || p_txt_lname3.Text != "")
                    {
                        MessageBox.Show("กรุณากรอกชื่อ-นามสกุลผู้รับผลประโยชน์ 1 ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_fname1.Focus();
                        return;
                    }
                }
                //แปลงงันที่ให้เป็นรูปแปบบ
                String ddmmyy = "yyyy-MM-dd";
               // CultureInfo thai = new CultureInfo("th-TH");

                string sex = "";
                if (m_cbx_sex.SelectedItem.Equals("ชาย"))
                {
                    sex= "M";
                }
                else
                {
                    sex = "F";
                }

                /*// ตรวจสอบว่ารหัส ID ซ้ำใน Database หรือไม่
                string chkID = null;
                string sqlCheck = "SELECT m_id  FROM member where m_id='" + m_txt_id.Text + "'";
                MySqlCommand CmdCheck = new MySqlCommand(sqlCheck, mycon);
                try
                {
                    //this.Cursor = Cursors.WaitCursor;
                    mycon.Open();
                    //Obj Reader
                    MySqlDataReader data1 = CmdCheck.ExecuteReader();
                    while (data1.Read())
                    {
                       chkID= data1.GetValue(0).ToString();
                        // MaxID = data1.GetString("maxID").ToString();
                    }
                    mycon.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL select max_id Errors..!!!" + ex.Message);
                }
                MessageBox.Show("ID ซ้ำ  "+chkID);
                m_txt_id.Focus();
                */
               

               // MessageBox.Show("test:" + dt.ToString(ddmmyy, thai));
                string SQLstr = "";
                try
                {
                    //**ถ้ามีข้อมูลหมดให้ทำการบันทึกลง database และเปลี่ยนสถานะให้เหมือนตอนแรกที่เปิดขึ้นมา
                    SQLstr = "INSERT INTO member(m_id,m_fname,m_lname,m_sex,m_tel,m_address,start_date,m_first_money,status_life,idcard1,idcard2,idcard3,";
                    SQLstr += " p_fname1,p_lname1,p_fname2,p_lname2,p_fname3,p_lname3,p_address,p_tel,m_r_id,m_group_id) ";
                    SQLstr += " VALUES('" + m_txt_id.Text + "','" + m_txt_fname.Text + "','" + m_txt_lname.Text + "','" + sex + "',";
                    SQLstr += "'" + m_txt_tel.Text + "','" + m_txt_address.Text + "','" + dd.ToString(ddmmyy,dtfInfo) + "','" + m_txt_fmoney.Text + "','L', ";
                    SQLstr += "'" + p_txt_idcard1.Text + "','" + p_txt_idcard2.Text + "','" + p_txt_idcard3.Text + "','" + p_txt_fname1.Text + "','" + p_txt_lname1.Text + "',";
                    SQLstr += "'" + p_txt_fname2.Text + "','" + p_txt_lname2.Text + "','" + p_txt_fname3.Text + "','" + p_txt_lname3.Text + "','" + p_txt_address.Text + "', ";
                    SQLstr += " '" + p_txt_tel.Text + "','"+m_cbx_relation.SelectedValue+"','"+ m_cbx_gtype.SelectedValue +"' );";
               
                     //MySqlCommand CmdAdd = new MySqlCommand(SQLstr,mycon);
                    
                   // mycon.Open();
                    //CmdAdd.ExecuteNonQuery();
                    MySqlCommand myCommand = new MySqlCommand(SQLstr);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();


                    ResetField(); //cal method
                    loadDatabase();//call method
                    current_pos = this.BindingContext[ds, "member"].Count;
                    tsTxtPageSum.Text = " of [ "+current_pos+" ]";
                    loadData(current_pos); //call method

                    stBCancel.Enabled = false;
                    state = State.None;//กลับไปสถานะปรติก
                    stBAdd.Text = " &Add ";
                   

                }
                catch (Exception ex)
                {
                     MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้คับ...!!", "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     MessageBox.Show("Erors..Add data" + ex.Message,"เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     MessageBox.Show("SQL.." + SQLstr, "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     ResetField();// call method

                     loadDatabase();//call method
                     current_pos = this.BindingContext[ds, "member"].Count;
                     tsTxtPageSum.Text = " of [ " + current_pos + " ]";
                     loadData(current_pos); //call method
                     stBCancel.Enabled = false;
                     state = State.None;//กลับไปสถานะปรติก
                     stBAdd.Text = " &Add ";
    
                }

            }//End els
        }
       //เมธอด EditData to base
        private void stBEdit_Click(object sender, EventArgs e)
        {
            //ถ้ายังไม่กดปุ่ม Edit ให้การทำงานต่างๆของ Object บนหน้าจอเหมือนเดิมที่เปิดครั้งเเรก
            if (state == State.None)
            {
                //เมือกดปุ่มEdit ในส่วนของ Object ทีสามารภแก้ไขได้คือ name ,lname......
                stBAdd.Enabled = false;
                stBEdit.Enabled = true;
                stBDelete.Enabled = false;
                stBCancel.Enabled = true;

                //ในส่วนของข้อมูลสมาชิก  
               // m_txt_id.ReadOnly = false;
                m_txt_fname.ReadOnly = false;
                m_txt_lname.ReadOnly = false;
                m_txt_address.ReadOnly = false;
                m_txt_tel.ReadOnly = false;
                m_txt_fmoney.ReadOnly = false;

                m_cbx_sex.Enabled = true;
                m_cbx_gtype.Enabled = true;
                m_txt_datePTK.Enabled = true;
                m_cbx_relation.Enabled = true;
                //ในส่วนของข้อมูล ผู้รับผลประโยช์
                p_txt_fname1.ReadOnly = false;
                p_txt_lname1.ReadOnly = false;
                p_txt_fname2.ReadOnly = false;
                p_txt_lname2.ReadOnly = false;
                p_txt_fname3.ReadOnly = false;
                p_txt_lname3.ReadOnly = false;
                p_txt_idcard1.ReadOnly = false;
                p_txt_idcard2.ReadOnly = false;
                p_txt_idcard3.ReadOnly = false;
                p_txt_address.ReadOnly = false;
                p_txt_tel.ReadOnly = false;

                stBEdit.Text = " &Update ";
                state = State.Modify;// เมื่อแก้ไขเส็ดจะเข้าขั้นตอนการปรับปรุ่งค่า

            }
            else
            {
             //ถ้าปรับปรุงเส็ดแล้วเมือ่กดปุ่มกลับมาเหมือนเดิม
                if (m_txt_id.Text == "")
                {
                    MessageBox.Show("กรุณาป้อนรหัสสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_id.Focus();
                    return;
                }
                else if (m_txt_fname.Text == "")
                {
                    MessageBox.Show("กรุณาป้อนชื่อสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_fname.Focus();
                    return;
                }
                else if (m_txt_lname.Text == "")
                {
                    MessageBox.Show("กรุณาป้อนนามสกุลสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_lname.Focus();
                    return;
                }
                else if (m_cbx_gtype.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบกลุ่มสมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_gtype.Focus();
                    return;
                }
                else if (m_txt_datePTK.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบวันที่ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_datePTK.Focus();
                    return;
                }
                else if (m_txt_address.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบที่อยู่สมาชิกด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_address.Focus();
                    return;
                }
                else if (m_cbx_sex.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบเพศด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_sex.Focus();
                    return;
                }
                else if (m_txt_tel.Text == "")
                {
                    MessageBox.Show("กรุณาตรวจสอบเบอร์โทรด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_tel.Focus();
                    return;
                }
                else if (m_txt_fmoney.Text == "" || int.Parse(m_txt_fmoney.Text) <= 0)
                {
                    MessageBox.Show("กรุณาตรวสอบจำนวนเงินแรกเข้าด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_fmoney.Focus();
                    return;
                }
                //******ตรวสอบในส่วนของผู้รับผลประโยช์**********//
                else if (p_txt_address.Text == "")
                {
                    MessageBox.Show("กรุณาตรวสอบที่อยู่ผู้รับผลประโยชน์ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_address.Focus();
                    return;
                }
                else if (p_txt_tel.Text == "")
                {
                    MessageBox.Show("กรุณาตรวสอบเบอร์โทรผู้รับผลประโยชน์ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_tel.Focus();
                    return;
                }
                else if (m_cbx_relation.Text == "")
                {
                    MessageBox.Show("กรุณาตรวสอบสถานะเกี่ยวข้องเป็น  ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_relation.Focus();
                    return;
                }
                else if (p_txt_fname1.Text != "")
                {
                    if (p_txt_lname1.Text == "")
                    {
                        MessageBox.Show("กรุณาตรวจสอบนามสกุลผู้รับผลประโยชน์ 1 ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_lname1.Focus();
                        return;
                    }
                }
                else if (p_txt_fname1.Text == "" && p_txt_lname1.Text == "")
                {
                    if (p_txt_fname2.Text != "" || p_txt_lname2.Text != "" || p_txt_fname3.Text != "" || p_txt_lname3.Text != "")
                    {
                        MessageBox.Show("กรุณากรอกชื่อ-นามสกุลผู้รับผลประโยชน์ 1 ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_fname1.Focus();
                        return;
                    }
                }

                //แปลงงันที่ให้เป็นรูปแปบบ
                String ddmmyy = "yyyy-MM-dd";
                //CultureInfo thai = new CultureInfo("th-TH");
                
                // set data*--------------------
                ResetField();//call medthod
                
                string sex = "";


                if (m_cbx_sex.Text.Equals("ชาย"))
                {
                    sex = "M";
                }
                else if (m_cbx_sex.Text.Equals("M"))
                {
                    sex = "M";
                }
                else
                {
                    sex = "F";
                }
                string SQLEdit = "";
               // System.Text.Encoding.UTF8.GetString(utf8Bytes);
        

                try
                {
                    SQLEdit = "UPDATE member SET m_fname='"+m_txt_fname.Text+"',m_lname = '"+m_txt_lname.Text+"',m_sex='"+sex+"',m_tel='"+m_txt_tel.Text+"',";
                    SQLEdit += "m_address='" + m_txt_address.Text + "',start_date='" + dd.ToString(ddmmyy, dtfInfo) + "',m_first_money='" + m_txt_fmoney.Text + "',";
                    SQLEdit += "p_fname1='"+p_txt_fname1.Text+"',p_lname1='"+p_txt_lname1.Text+"',p_fname2='"+p_txt_fname2.Text+"',p_lname2='"+p_txt_lname2.Text+"',";
                    SQLEdit += "p_fname3='"+p_txt_fname3.Text+"',p_lname3='"+p_txt_lname3.Text+"',idcard1='"+p_txt_idcard1.Text+"',idcard2='"+p_txt_idcard2.Text+"',idcard3='"+p_txt_idcard3.Text+"', ";
                    SQLEdit += "p_address='" + p_txt_address.Text + "',p_tel='" + p_txt_tel.Text + "',m_last_update='" + ddEdit.ToString(ddmmyy, dtfInfo) + "',m_r_id='" + m_cbx_relation.SelectedValue + "',m_group_id='" + m_cbx_gtype.SelectedValue + "' ";
                    SQLEdit += " WHERE m_id='"+m_txt_id.Text+"'; ";

                    MySqlCommand myCommand = new MySqlCommand(SQLEdit);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                    
                    MessageBox.Show("ระบบได้ทำการ Update ข้อมูลเรียบร้อยแล้วคับ...OK!!", "Update data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    loadDatabase();
                    loadData(current_pos);
                    stBEdit.Text = " &Edit ";
                    state = State.None;
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ระบบไม่สามารถ Update ข้อมูลได้คับ...!!", "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Erors..Edit data" + ex.Message);
                    MessageBox.Show("SQL.." + SQLEdit);
                    
                    ResetField();//call method
                    loadDatabase();//******
                    loadData(current_pos);
                    stBEdit.Text = " &Edit ";
                    state = State.None;
                }
            }//End else if state== None

        }
        //เมธอด Delete to base
        private void stBDelete_Click(object sender, EventArgs e)
        {
            string sqlDel = "";
            if (MessageBox.Show("คุณต้องการลบข้อมูลสมาชิก '" + m_txt_id.Text + "' ใช่หรือไม่...?", "คำยืนยัน...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    sqlDel = "DELETE FROM member WHERE m_id='" + m_txt_id.Text + "'";

                    MySqlCommand myCommand = new MySqlCommand(sqlDel);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                    loadDatabase();//******
                    loadData(current_pos);
                    current_pos = this.BindingContext[ds, "member"].Count;
                    tsTxtPageSum.Text = "of [ " + current_pos + " ]";

                    MessageBox.Show("ระบบได้ทำการ Delete ข้อมูลเรียบร้อยแล้วคับ...OK!!", "Delete data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tsBMoveFirst_Click(sender, e);
                    mycon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ระบบไม่สามารถ Delete ข้อมูลได้คับ...!!", "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Erors..Delete data" + ex.Message);
                    MessageBox.Show("SQL.." + sqlDel);

                    loadDatabase();//******
                    loadData(current_pos);
                    tsBMoveFirst_Click(sender, e);

                }
            }//End if confirm
        }
        //เมธอด Cancel button
        private void stBCancel_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.Add: //เมือกดปุ่ม add แล้วต้องการกดปุ่ม Cancel
                    stBAdd.Text = " &Add ";
                    ResetField();// to state defult
                    loadData(current_pos);
                    break;
                case State.Modify:// เมื่อกดปุ่ม Edit แล้วต้องการกดปุ่ม Cencel
                    stBEdit.Text = " &Edit ";
                    ResetField(); //to state defult
                    loadData(current_pos);
                    break;
                case State.Delete: //เมื่อกดปุ่ม Deleete การกด Cancel จำไม่ทำงาน
                    break;
                default:
                    break;
            }
            state = State.None;//ถ้าเปิดปุ่มหน้าจอขึ้นมาใหม่ สถานะปุ่ม cancel จะไม่ทำงาน
            stBCancel.Enabled = false;
        }
        //------------------------------
       //เมธอด หาID ล่วงหน้า
        private string getNewid(string b)
        {
           // string temp = "" + (Integer.parseInt(b) + 1);
            string temp = ""+(int.Parse(b)+1);
            string newSp_id;
            //switch (temp.length())
            switch(temp.Length)
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
        //methoให้ป้อนเฉพาะตัวเลขน่ะคับ
        private void m_txt_fmoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลขเท่านั้นคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_txt_fmoney.Focus();
                e.Handled = true;
            }
        }

        private void m_txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลขเท่านั้นคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_txt_id.Focus();
                e.Handled = true;
            }
        }

       // method เปลี่ยนวันที่ ในการบันทึก
        private void m_txt_datePTK_ValueChanged(object sender, EventArgs e)
        {
            dd = m_txt_datePTK.Value;
        }

    }
}