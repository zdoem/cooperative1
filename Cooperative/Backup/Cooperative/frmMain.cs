using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Cooperative
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        UserLogin controlBoxs = new UserLogin();
        //method control button other
        private void SetMode(WindowsLogin.CoopUser s)
        {
            switch (s)
            {
                //ถ้าเป้น 1 คือ User นะคับ
                case WindowsLogin.CoopUser.User:
                    this.stbPanelStatus.Text = WindowsLogin.CoopUser.User.ToString();
                    msCurrentDeath.Enabled = true;
                    msInformDeath.Enabled = true;
                    msCashCoop.Enabled = true;
                    msExit.Enabled = true;

                    msRegister.Enabled = false;
                    msFind.Enabled = false;

                    msRelationShip.Enabled = true;
                    msGroup_Member.Enabled = true;
                    msCauseDeath.Enabled = true;

                    //*****************
                    tsRegister.Enabled = true;
                    tsInformDeath.Enabled = true;
                    tsCashCoop.Enabled = true;
                    tsFind.Enabled = true;
                    tsCurrentDeath.Enabled = true;
                    tsExit.Enabled = true;
                    break;
                
                //ถ้าเป้น 2 เป้น Addmin
                case WindowsLogin.CoopUser.Admin:
                    this.stbPanelStatus.Text = WindowsLogin.CoopUser.Admin.ToString();
                    msCurrentDeath.Enabled = true;
                    msInformDeath.Enabled = true;
                    msCashCoop.Enabled = true;
                    msExit.Enabled = true;

                    msRegister.Enabled = true;
                    msFind.Enabled = true;

                    msRelationShip.Enabled = true;
                    msGroup_Member.Enabled = true;
                    msCauseDeath.Enabled = true;

                    //*****************
                    tsRegister.Enabled = true;
                    tsInformDeath.Enabled = true;
                    tsCashCoop.Enabled = true;
                    tsFind.Enabled = true;
                    tsCurrentDeath.Enabled = true;
                    tsExit.Enabled = true;
                    
                    break;
            }
        }
 
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.stbPanelDay.Text = "Date :"+DateTime.Today.ToShortDateString();
            this.stbPanelTime.Text = "Time :" + DateTime.Now.ToShortTimeString(); ;
        }

        //
        //
        public void Show(int nCoopUser)
        {
            this.Show();
            this.SetMode((WindowsLogin.CoopUser)nCoopUser);
        }

        private void tsExit_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void msRegister_Click(object sender, EventArgs e)
        {
            frmRegister regisPage = new frmRegister();
            regisPage.MdiParent = this;
            regisPage.Show();
        }

        //ค้นหาสมาชิก
        private void msFind_Click(object sender, EventArgs e)
        {
           
           
        }

        private void msExit_Click(object sender, EventArgs e)
        {
            frmLogin loadNewPage = new frmLogin();
            loadNewPage.MdiParent = this;
            loadNewPage.Show();
            this.toolStrip1.Enabled = false;
            this.menuStrip1.Enabled = false;
            this.stbPanelStatus.Text = "Logout?...if  you want to Logout..Choose Cancel";
        }

        private void tsRegister_Click(object sender, EventArgs e)
        {
           // if()
            frmRegister regisPage2 = new frmRegister();
            regisPage2.MdiParent = this;
            regisPage2.Show();
        }

        private void tsFind_Click(object sender, EventArgs e)
        {
            frmFindMember ffMember = new frmFindMember();
            ffMember.MdiParent = this;
            ffMember.Show();
        }

        private void tsInformDeath_Click(object sender, EventArgs e)
        {
            frmInformDeath fifDeath = new frmInformDeath();
            fifDeath.MdiParent = this;
            fifDeath.Show();
        }

       //สำหรับชำระเงินตามงวดน่ะคับพี่น้อง
        private void tsCashCoop_Click(object sender, EventArgs e)
        {
            frmCashCoop frmCCoop = new frmCashCoop();
            frmCCoop.MdiParent = this;
            frmCCoop.Show();
        }
    }
}