using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace Cooperative
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public string id1 = "";
        public string empFname = "";
        public string empLname = "";
        public string user = "";
        public string pass = "";
        public string status = "";
        public int loginattempts;

        User users = new User();
        UserLogin loginPage = new UserLogin();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginPage.User = txtUser.Text;
            loginPage.Pass = txtPass.Text;
            //check value null

            if (loginPage.User == "" || loginPage.Pass == "")
            {
                MessageBox.Show("กรุณากรอก Username และ Password ด้วยค่ะ.....", "Error");
                txtUser.Focus();
            }
            else
            {
                string strProvider;
                strProvider = "datasource=localhost;username=root;password=root;database=db_cooperative";
                MySqlConnection Conn = new MySqlConnection(strProvider);

                //sql check priority 
                string sql = "SELECT * FROM user WHERE user_login='" + loginPage.User + "'";
                MySqlCommand Cmd = new MySqlCommand(sql, Conn);
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Conn.Open();

                    //Obj Reader
                    MySqlDataReader data1 = Cmd.ExecuteReader();
                    while (data1.Read())
                    {
                        id1 = data1.GetValue(0).ToString();
                        status = data1.GetValue(5).ToString();
                        empFname = data1.GetValue(1).ToString();
                        empLname = data1.GetValue(2).ToString();
                        user = data1.GetValue(3).ToString();
                        pass = data1.GetValue(4).ToString();
                    }

                    Conn.Close();
                    this.Cursor = Cursors.Default;
                    loginPage.User = user;
                    //ถ้าไม่พบใน Database
                    if (loginPage.User == "")
                    {
                        MessageBox.Show("    User Not Found....!      ");
                        txtUser.Text = "";
                    }
                   
                    //ถ้าค่าที่ส่งกลับใน loginPage.Pass มีค้าทเากัยค่าในฐ้านข้อมูลจริง
                    if (loginPage.Pass == pass)
                    {
                      
                        this.Hide();//frmLogin หายไป
                        frmMain mainFrm = new frmMain();
                        loginPage.Status = status;
                        //ตรวจสอบว่าค่าที่ส่งกลับเป้น Magager หรือไม่
                        if (loginPage.Status == "A")
                        {
                            //ถ้าเป็น Addmin ให้เรียกใช้ค่าฝย method   WindowsLogin/CoopUser
                            //มีสถานะเป้น 2
                            //users.Coop  from user.cs/get/set
                            users.Coop = (int)WindowsLogin.CoopUser.Admin;//2
                        }
                        else if (loginPage.Status == "U")
                        {
                            //ถ้าเป้น User ห้เรียกใช้ค่าฝย method   WindowsLogin/CoopUser
                            //มีสถานะเป้น 1
                            //users.Coop  from user.cs/get/set
                            users.Coop = (int)WindowsLogin.CoopUser.User;//1

                        }
                        //เมือเงือนไงเป้นจิง frmMain show
                        mainFrm.Show(users.Coop);
                       
                        // mainFrm.Show(users.Coop);
                        //MessageBox.Show("Username OK"+user+"  :"+pass);
                    }
                    else
                    {
                        loginattempts++;
                        if (loginattempts >= 3)
                        {
                            MessageBox.Show("คุณได้ทำการ Login เข้าสู่ระบบเกิน 3 ครั้ง...", "Errors!!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username หรือ Password ไม่ถูกต้อง..", "Errors!!");
                            txtPass.Text = "";
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Exception:");
                    this.Cursor = Cursors.Default;
                }

                //ถ้าการส่องค้าตัวเปร id1 เข้าไปเก็บไว้ใน Class LoginSendID เพือใช้งานใน frm   เมื่อมีการอ้างอิง
              LogingSendID.SendIDEmp.setEmpID(id1);

            }


        }

        private void frmLogin_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //เป้นการใช้คำสั่ง FormLogin.cs โต้ตอบกับ frmSho ได้โดยส่งค่า id1 แสดงบน 
            //txtNEmplyee ของ from
           RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogingSendID.SendIDEmp), "SendIDEmp.rem", WellKnownObjectMode.SingleCall);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}