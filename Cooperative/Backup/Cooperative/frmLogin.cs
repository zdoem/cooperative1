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
                MessageBox.Show("��سҡ�͡ Username ��� Password ���¤��.....", "Error");
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
                    //�����辺� Database
                    if (loginPage.User == "")
                    {
                        MessageBox.Show("    User Not Found....!      ");
                        txtUser.Text = "";
                    }
                   
                    //��Ҥ�ҷ���觡�Ѻ� loginPage.Pass �դ�ҷ�ҡ�¤��㹰�ҹ�����Ũ�ԧ
                    if (loginPage.Pass == pass)
                    {
                      
                        this.Hide();//frmLogin ����
                        frmMain mainFrm = new frmMain();
                        loginPage.Status = status;
                        //��Ǩ�ͺ��Ҥ�ҷ���觡�Ѻ�� Magager �������
                        if (loginPage.Status == "A")
                        {
                            //����� Addmin ������¡���ҽ� method   WindowsLogin/CoopUser
                            //��ʶҹ��� 2
                            //users.Coop  from user.cs/get/set
                            users.Coop = (int)WindowsLogin.CoopUser.Admin;//2
                        }
                        else if (loginPage.Status == "U")
                        {
                            //����� User �����¡���ҽ� method   WindowsLogin/CoopUser
                            //��ʶҹ��� 1
                            //users.Coop  from user.cs/get/set
                            users.Coop = (int)WindowsLogin.CoopUser.User;//1

                        }
                        //������͹��鹨ԧ frmMain show
                        mainFrm.Show(users.Coop);
                       
                        // mainFrm.Show(users.Coop);
                        //MessageBox.Show("Username OK"+user+"  :"+pass);
                    }
                    else
                    {
                        loginattempts++;
                        if (loginattempts >= 3)
                        {
                            MessageBox.Show("�س��ӡ�� Login �������к��Թ 3 ����...", "Errors!!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username ���� Password ���١��ͧ..", "Errors!!");
                            txtPass.Text = "";
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Exception:");
                    this.Cursor = Cursors.Default;
                }

                //��ҡ����ͧ��ҵ���� id1 ���������� Class LoginSendID �����ҹ� frm   ������ա����ҧ�ԧ
              LogingSendID.SendIDEmp.setEmpID(id1);

            }


        }

        private void frmLogin_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //�鹡�������� FormLogin.cs ��ͺ�Ѻ frmSho �����觤�� id1 �ʴ��� 
            //txtNEmplyee �ͧ from
           RemotingConfiguration.RegisterWellKnownServiceType(typeof(LogingSendID.SendIDEmp), "SendIDEmp.rem", WellKnownObjectMode.SingleCall);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}