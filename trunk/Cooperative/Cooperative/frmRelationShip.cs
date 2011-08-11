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
    public partial class frmRelationShip : Form
    {
        enum State { None, Add, Modify, Delete }//ประกาศตัวแปร enum  เพื่อไปใช้ในการควบคุม Event ของปุ่ม
        private connDataBase cnnBase = new connDataBase();
        private MySqlDataAdapter adapter;
        private DataSet ds;
        private int current_pos;
        private int row_count;
        private State state = 0;
        DateTime dd = DateTime.Now;//add start_date
        DateTime ddEdit = DateTime.Now;//Edit  last_update
        DateTimeFormatInfo dtfInfo = DateTimeFormatInfo.InvariantInfo;

        private static  string TABLE_NAME = "relation";

        MySqlConnection mycon = new MySqlConnection("datasource=localhost;username=root;password=root;database=db_cooperative");
       
        
        public frmRelationShip()
        {
            InitializeComponent();
        }

        //method display data to table gridView
        private void loadDatabase()
        {
            try
            {
                // cnnBase.Open();
                //string sql_str = "Select * from member m where status_life = 'L' order by m_id";
                string sql_str = "SELECT relation.r_id as ID,relation.r_name as RelationName  FROM db_cooperative.relation relation order by  relation.r_id";

                adapter = new MySqlDataAdapter(sql_str, mycon);

                ds = new DataSet();
                adapter.Fill(ds, TABLE_NAME);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = TABLE_NAME;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Errors load database " + ex.Message);
            }
            finally
            {
                if (mycon != null)
                {
                    mycon.Close();
                }
            }
        }

        //method ชี้ตำแหน่งในฐานข้อมูล
        private void loadData(int position)
        {
            try
            {
                //แฟ้มข้อมูลความสัมพันธ์
                txtR_ID.ReadOnly = true;
                txtR_Name.ReadOnly = true;

                //ถ้าค่าที่ตัวแปรชี้ตำแหน่งในฐานข้อมูลมากกว่าจำนวนตำแหน่งในฐานข้อมูลจริง  ค่าตัวแปรจะชีบอกตำแหน่ง
                if (position > this.BindingContext[ds, TABLE_NAME].Count - 1)
                {
                    current_pos = this.BindingContext[ds, TABLE_NAME].Count - 1;
                    position = this.BindingContext[ds, TABLE_NAME].Count - 1;
                }

                //ถ้าตัวชี้ตำแหน่งในฐานข้อมูล < 0  ข้อมูลจะฟ้องว่าไม่พบข้อมูลใน database 
                if (position < 0)
                {
                    tsTxtPageNum.Text = "No Record";
                    stBDelete.Enabled = false;
                    stBEdit.Enabled = false;

                   // ClearData();

                    return;
                }

                //ส่วนนี้เป้นการเอาค่าที่ได้จากตำแหน่งในฟิลด์ตั้งแต่ฟิลด์แรกถึงฟิดด์สุดท้ายมาใส่ใน text box
                txtR_ID.Text = ds.Tables[TABLE_NAME].Rows[position][0].ToString();
                txtR_Name.Text = ds.Tables[TABLE_NAME].Rows[position][1].ToString();

                row_count = this.BindingContext[ds, TABLE_NAME].Count;

                tsTxtPageSum.Text = "OF ["+row_count+"]";

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
                this.BindingContext[ds, TABLE_NAME].Position = position;
                //ให้อ่านค่าตำแหน่งที่ถูกต้องแล้วนำมาแสดงบน tstTextPaeNum.text
                tsTxtPageNum.Text = Convert.ToString(current_pos + 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Load Data Errors " + ex.Message);
            }

        }

        private void ResetField()
        {
            txtR_ID.ReadOnly = true;
            txtR_Name.ReadOnly = true;
        }

        //FormLoad
        private void frmRelationShip_Load(object sender, EventArgs e)
        {
            loadDatabase();
            ResetField();

            //Reset Control Event
            stBEdit.Enabled = false;
            stBDelete.Enabled = false;
            stBCancel.Enabled = false;

        }

        //Move FirstRecord
        private void tsBMoveLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (state != State.None)
                    return;
                //ชี้ตำแหน่งไปตำแหน่งแรกสุด
                this.BindingContext[ds, TABLE_NAME].Position = 0;
                //นับตำแหน่งที่ชี้
                current_pos = this.BindingContext[ds, TABLE_NAME].Position;

                loadData(current_pos);//call  method
            }
            catch (Exception ex)
            {
                Console.WriteLine(" tsBMoveLast_Click  Errors " + ex.Message);
            }
        }
        //Move Prevoius
        private void tsBMoveProvious_Click(object sender, EventArgs e)
        {
            try
            {
                if (state != State.None)
                    return;
                //ชี้ตำแหน่งถอยหลังจากตำแหน่งที่พบแรกสุด
                this.BindingContext[ds, TABLE_NAME].Position = this.BindingContext[ds, TABLE_NAME].Position - 1;
                //นับตำแหน่งที่ชี้
                current_pos = this.BindingContext[ds, TABLE_NAME].Position;

                loadData(current_pos);//call  method
            }
            catch (Exception ex)
            {
                Console.WriteLine(" tsBMoveProvious_Click  Errors " + ex.Message);
            }
        }
        //Move Next Record
        private void tsBMoveNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (state != State.None)
                    return;
                //ชี้ตำแหน่งถัดไปจากตำแหน่งแรกที่พบ
                this.BindingContext[ds, TABLE_NAME].Position = this.BindingContext[ds, TABLE_NAME].Position + 1;
                //นับตำแหน่งที่ชี้
                current_pos = this.BindingContext[ds, TABLE_NAME].Position;

                loadData(current_pos);//call  method
            }
            catch (Exception ex)
            {
                Console.WriteLine(" tsBMoveNext_Click  Errors " + ex.Message);
            }
        }
        //Move Last Record 
        private void tsBMoveFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (state != State.None)
                    return;
                //ชี้ตำแหน่งท้ายสุด
                this.BindingContext[ds, TABLE_NAME].Position = this.BindingContext[ds, TABLE_NAME].Count - 1;
                //นับตำแหน่งที่ชี้
                current_pos = this.BindingContext[ds, TABLE_NAME].Position;

                loadData(current_pos);//call  method
            }
            catch (Exception ex)
            {
                Console.WriteLine(" tsBMoveFirst_Click  Errors " + ex.Message);
            }
        }

        //Action Add 
        private void stBAdd_Click(object sender, EventArgs e)
        {
            //ถ้ายังไม่กดปุ่ม add ให้การทำงานต่างๆของ Oject บนห้น้าจอเหมือนที่เปิดหน้าจอครั้งแรก
            if (state == State.None)
            {
                state = State.Add;  //ถ้ากดปุ่ม add ให้ Text box ถูกเตรียมเพือรับข้อมุล
                stBAdd.Text = " &Save ";

                //แฟ้มข้อมูลความสัมพันธ์
                //txtR_ID.ReadOnly = false;
                txtR_Name.ReadOnly = false;

                txtR_ID.Text = "";
                txtR_Name.Text = "";

                 //เปลี่ยนรูปภาพ  เป็นรูป Save
                this.stBAdd.Image = Properties.Resources.save_as;
                //Reset Control Event
                stBEdit.Enabled = false;
                stBDelete.Enabled = false;
                stBCancel.Enabled = true;

            }
            else //ถ้ายังกรอกข้อมูลใน txt box ไม่ครบจะแสดงข้อความเตือนขึ้นมา
            {
                if (txtR_Name.Text == "")
                {
                    MessageBox.Show("กรุณากรอกชื่อข้อมูลความสัมพันธ์ด้วยครับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtR_Name.Focus();
                    return;
                }
               
                
                //แปลงงันที่ให้เป็นรูปแปบบ
                //String ddmmyy = "yyyy-MM-dd";
                // CultureInfo thai = new CultureInfo("th-TH");

                // MessageBox.Show("test:" + dt.ToString(ddmmyy, thai));
                string SQLstr = "";
                try
                {
                    //**ถ้ามีข้อมูลหมดให้ทำการบันทึกลง database และเปลี่ยนสถานะให้เหมือนตอนแรกที่เปิดขึ้นมา
                    SQLstr = "INSERT INTO relation(r_name) ";
                    SQLstr += " VALUES('" + txtR_Name.Text + "')";
                   
                    MySqlCommand myCommand = new MySqlCommand(SQLstr);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย...!!", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //ResetField(); //cal method
                    loadDatabase();//call method
                    current_pos = this.BindingContext[ds, "relation"].Count;
                    tsTxtPageSum.Text = " OF [ " + current_pos + " ]";
                    loadData(current_pos); //call method

                    stBCancel.Enabled = false;
                    state = State.None;//กลับไปสถานะปรกติก
                    stBAdd.Text = " &Add ";
                    //เปลี่ยนรูปภาพ เป็น ADD
                    this.stBAdd.Image = Properties.Resources.plus;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้คับ...!!", "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Erors..Add data" + ex.Message, "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("SQL.." + SQLstr, "เกิดข้อผิดผลาด...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ResetField();// call method

                    loadDatabase();//call method
                    current_pos = this.BindingContext[ds, "relation"].Count;
                    tsTxtPageSum.Text = " OF [ " + current_pos + " ]";
                    loadData(current_pos); //call method
                    stBCancel.Enabled = false;
                    state = State.None;//กลับไปสถานะปรติก
                    stBAdd.Text = " &Add ";

                }

            }//End ELSE

        }

        //Action Edit
        private void stBEdit_Click(object sender, EventArgs e)
        {
            //ถ้ายังไม่กดปุ่ม Edit ให้การทำงานต่างๆของ Object บนหน้าจอเหมือนเดิมที่เปิดครั้งเเรก
            if (state == State.None)
            {
                //เมือกดปุ่มEdit ในส่วนของ Object ทีสามารถแก้ไขได้คือ name ,lname......
                //set controller
                stBAdd.Enabled = false;
                stBEdit.Enabled = true;
                stBDelete.Enabled = false;
                stBCancel.Enabled = true;

                //ในส่วนของข้อมูลสมาชิก  
                txtR_ID.ReadOnly = true;
                txtR_Name.ReadOnly = false;
                
                //เปลี่ยนรูปจาก แก้ไขเป็น Save
                stBEdit.Image = Properties.Resources.save_as;
                stBEdit.Text = " &Update ";
                state = State.Modify;// เมื่อแก้ไขเส็ดจะเข้าขั้นตอนการปรับปรุ่งค่า

            }
            else
            {
                //ถ้าปรับปรุงเส็ดแล้วเมือ่กดปุ่มกลับมาเหมือนเดิม
                if (txtR_Name.Text == "")
                {
                    MessageBox.Show("กรุณาป้อนข้อมูลความสัมพันธ์ด้วยคคับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtR_Name.Focus();
                    return;
                }
                
                //แปลงงันที่ให้เป็นรูปแปบบ
                //String ddmmyy = "yyyy-MM-dd";
                //CultureInfo thai = new CultureInfo("th-TH");

                // set data*--------------------
                ResetField();//call medthod

                string SQLEdit = "";
                // System.Text.Encoding.UTF8.GetString(utf8Bytes);

                try
                {
                    SQLEdit = "UPDATE relation SET r_name='" + txtR_Name.Text + "' ";
                    SQLEdit += " WHERE r_id=" + txtR_ID.Text;

                    MySqlCommand myCommand = new MySqlCommand(SQLEdit);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();


                    MessageBox.Show("ระบบได้ทำการ Update ข้อมูลเรียบร้อยแล้วคับ...OK!!", "Update data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadDatabase();
                    loadData(current_pos);

                    //เปลี่ยนรูปจาก แก้ไขเป็น Save
                    stBEdit.Image = Properties.Resources.pencil_edit;
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

                    //เปลี่ยนรูปจาก แก้ไขเป็น Edit
                    stBEdit.Image = Properties.Resources.pencil_edit;

                    stBEdit.Text = " &Edit ";
                    state = State.None;
                }
            }//End else if state== None
        }
        //Action Delete
        private void stBDelete_Click(object sender, EventArgs e)
        {
   
            string sqlDel = "";
            if (MessageBox.Show("คุณต้องการลบข้อมูล ID '" + txtR_ID.Text + "' ใช่หรือไม่...?", "คำยืนยัน...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    //check duplicate use ID from meber table

                    // ตรวจสอบว่ารหัส ID ว่ามีการใช้งานอยู่หรือไม่ ถ้ามี ลบไม่ได้ ถ้าไม่มี ให้สามารถลบได้
                    bool FLAG_CHK_DUP = false;

                    string sqlCheck = "SELECT member.m_id, relation.r_name, member.m_r_id ";
                    sqlCheck += " FROM    db_cooperative.relation relation ";
                    sqlCheck += " INNER JOIN db_cooperative.member member ON (relation.r_id = member.m_r_id)";
                    sqlCheck += " WHERE member.m_r_id =" + txtR_ID.Text;
                    MySqlCommand CmdCheck = new MySqlCommand(sqlCheck, mycon);
                    try
                    {
                        //this.Cursor = Cursors.WaitCursor;
                        mycon.Open();
                        //Obj Reader
                        MySqlDataReader data1 = CmdCheck.ExecuteReader();
                        while (data1.Read())
                        {
                            //chkID = data1.GetValue(0).ToString();
                            FLAG_CHK_DUP = true;
                           // MessageBox.Show("ID ซ้ำ :" + data1.GetValue(0).ToString());
                        }
                        mycon.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("SQL Errors :" + ex.Message);
                    }

                    if (FLAG_CHK_DUP)
                    {
                        MessageBox.Show("ระบบไม่สามารถดำเนินการลบข้อมูล Record ได้ครับเนื่องจากมีการใช้งานอยุ่!!", "Warning...!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //END
                        return;
                    }
                    //END


                    sqlDel = "DELETE FROM relation WHERE r_id='" + txtR_ID.Text + "'";

                    MySqlCommand myCommand = new MySqlCommand(sqlDel);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                    loadDatabase();//******
                    loadData(current_pos);
                    current_pos = this.BindingContext[ds, "relation"].Count;
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
        //Action Cancel
        private void stBCancel_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.Add: //เมือกดปุ่ม add แล้วต้องการกดปุ่ม Cancel
                    stBAdd.Text = " &Add ";
                    //เปลี่ยนรูปภาพ เป็น ADD
                    this.stBAdd.Image = Properties.Resources.plus;

                    ResetField();// to state defult
                    loadData(current_pos);
                    break;
                case State.Modify:// เมื่อกดปุ่ม Edit แล้วต้องการกดปุ่ม Cencel
                    //เปลี่ยนรูปจาก แก้ไขเป็น Edit
                    stBEdit.Image = Properties.Resources.pencil_edit;
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
    }
}
