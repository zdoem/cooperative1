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
    public partial class frmGroupOfMember : Form
    {

        //-------------------------
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

        MySqlConnection mycon = new MySqlConnection("datasource=localhost;username=root;password=root;database=db_cooperative");

        private static string TABLE_NAME = "member_group";
        //---------------- 
        

        public frmGroupOfMember()
        {
            InitializeComponent();
        }

        //this Method controller Event Action 
        private void ControllerEventAction(int c)
        {
            //1=Enable
            //0=Disable

            if (c == 0)
            {
                tsBMoveFirst.Enabled = false;
                tsBMoveLast.Enabled = false;
                tsBMoveNext.Enabled = false;
                tsBMoveProvious.Enabled = false;
            }
            else if (c == 1)
            {
                tsBMoveFirst.Enabled = true;
                tsBMoveLast.Enabled = true;
                tsBMoveNext.Enabled = true;
                tsBMoveProvious.Enabled = true;
            }
        }


        private void ResetField()
        {
            txtGM_ID.ReadOnly = true;
            txtGM_Name.ReadOnly = true;
        }
        //method display data to table gridView
        private void loadDatabase()
        {
            try
            {
                // cnnBase.Open();
                //string sql_str = "Select * from member m where status_life = 'L' order by m_id";
                string sql_str = "SELECT member_group.group_id as ID, member_group.group_name as Name  FROM db_cooperative.member_group member_group order by  member_group.group_id";

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

        //Form load
        private void frmGroupOfMember_Load(object sender, EventArgs e)
        {
            loadDatabase();
        }

        //method ชี้ตำแหน่งในฐานข้อมูล
        private void loadData(int position)
        {
            try
            {
                //แฟ้มข้อมูลความสัมพันธ์
                txtGM_ID.ReadOnly = true;
                txtGM_Name.ReadOnly = true;

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
                txtGM_ID.Text = ds.Tables[TABLE_NAME].Rows[position][0].ToString();
                txtGM_Name.Text = ds.Tables[TABLE_NAME].Rows[position][1].ToString();

                row_count = this.BindingContext[ds, TABLE_NAME].Count;

                tsTxtPageSum.Text = "OF [" + row_count + "]";

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
        
        //First Record
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

        //Previous Record
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

        //Next Record
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

        //Last Record
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

        //ADD Action
        private void stBAdd_Click(object sender, EventArgs e)
        {
            //ถ้ายังไม่กดปุ่ม add ให้การทำงานต่างๆของ Oject บนห้น้าจอเหมือนที่เปิดหน้าจอครั้งแรก
            if (state == State.None)
            {
                state = State.Add;  //ถ้ากดปุ่ม add ให้ Text box ถูกเตรียมเพือรับข้อมุล
                stBAdd.Text = " &Save ";

                //แฟ้มข้อมูลความสัมพันธ์
                //txtR_ID.ReadOnly = false;
                txtGM_Name.ReadOnly = false;

                txtGM_ID.Text = "";
                txtGM_Name.Text = "";

                //เปลี่ยนรูปภาพ  เป็นรูป Save
                this.stBAdd.Image = Properties.Resources.save_as;
                //Reset Control Event
                stBEdit.Enabled = false;
                stBDelete.Enabled = false;
                stBCancel.Enabled = true;

                //Disable controller
                ControllerEventAction(0);

            }
            else //ถ้ายังกรอกข้อมูลใน txt box ไม่ครบจะแสดงข้อความเตือนขึ้นมา
            {
                if (txtGM_Name.Text == "")
                {
                    MessageBox.Show("กรุณากรอกชื่อข้อมูลกลุ่มสมาชิกด้วยครับ...!!", "คำแนะนำ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGM_Name.Focus();
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
                    SQLstr = "INSERT INTO member_group(group_name) ";
                    SQLstr += " VALUES('" + txtGM_Name.Text.Trim() + "')";

                    MySqlCommand myCommand = new MySqlCommand(SQLstr);
                    myCommand.Connection = mycon;
                    mycon.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย...!!", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //ResetField(); //cal method
                    loadDatabase();//call method
                    current_pos = this.BindingContext[ds, TABLE_NAME].Count;
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
                    current_pos = this.BindingContext[ds, TABLE_NAME].Count;
                    tsTxtPageSum.Text = " OF [ " + current_pos + " ]";
                    loadData(current_pos); //call method
                    stBCancel.Enabled = false;
                    state = State.None;//กลับไปสถานะปรติก
                    stBAdd.Text = " &Add ";

                }
            }//End ELSE
        }

        //Edit Action
        private void stBEdit_Click(object sender, EventArgs e)
        {

        }

        //DELETE Action
        private void stBDelete_Click(object sender, EventArgs e)
        {

        }

        //Cancel Action
        private void stBCancel_Click(object sender, EventArgs e)
        {

        }


    }
}
