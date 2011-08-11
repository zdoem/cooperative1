using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Cooperative
{
    public partial class frmFindMember : Form
    {
       // private connDataBase cnnBase = new connDataBase();
        private MySqlDataAdapter adapter;
        //private OleDbDataAdapter adapter;
        private DataSet ds;
       // private BindingSource searchBindingBook;
       
        MySqlConnection mycon = new MySqlConnection("datasource=localhost;username=root;password=root;database=db_cooperative");

        
        public frmFindMember()
        {
            InitializeComponent();
        }

       
        //เมธอดสำหรับค้นหาตามเงื่อนไขน่ะคับพี่้น้อง
        private void tsM_find_Click(object sender, EventArgs e)
        {
           // cnnBase.SelectDatabase();
           // cnnBase.Open();
           // string f_id = "";
           // f_id = tsM_txtid.Text;
            string sql_str = "";
            try
            {
                //cnnBase.SelectDatabase();

                // cnnBase.Open();
                //string sql_str = "Select * from member m where status_life = 'L' order by m_id";

                if (tsM_txtid.Text == "")
                {
                    sql_str = "SELECT m_id as ID,m_fname as Name,m_lname as LastName,m_sex as Sex,m_tel as Tel,";
                    sql_str += " m_address as Address,start_date as StartDate,m_first_money as Bugget,status_life as FlagLife,idcard1 as IDCard1 ";
                    sql_str += ",idcard2 as IDCard2,idcard3 as IDCard3 ,p_fname1 as Name1,p_lname1 as LastName1,p_fname2 as Name2,p_lname2 as LastName2 ";
                    sql_str += ",p_fname3 as Name3,p_lname3 as LastName3,p_address as P_Address,p_tel as P_Tel,m_r_id as RelationID,m_group_id as GroupID";
                    sql_str += " FROM member order by m_id";
                }
                else
                {
                    sql_str = "SELECT m_id as ID,m_fname as Name,m_lname as LastName,m_sex as Sex,m_tel as Tel,";
                    sql_str += " m_address as Address,start_date as StartDate,m_first_money as Bugget,status_life as FlagLife,idcard1 as IDCard1 ";
                    sql_str += ",idcard2 as IDCard2,idcard3 as IDCard3 ,p_fname1 as Name1,p_lname1 as LastName1,p_fname2 as Name2,p_lname2 as LastName2 ";
                    sql_str += ",p_fname3 as Name3,p_lname3 as LastName3,p_address as P_Address,p_tel as P_Tel,m_r_id as RelationID,m_group_id as GroupID";
                    sql_str += " FROM member where m_id='" + tsM_txtid.Text + "' or m_id like '%" + tsM_txtid.Text + "%' ";
                }
                //string sql_str = "Select * from member m  order by m_id";
                adapter = new MySqlDataAdapter(sql_str, mycon);
                // adapter = cnnBase.ExecuteQuery(sql_str);
                ds = new DataSet();
                adapter.Fill(ds, "member");

                dwFind.DataSource = ds;
                dwFind.DataMember = "member";
                mycon.Close();
                // dataGrid1.DataSource = myds.Tables["employee"].DefaultView;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Errors Search data " + ex.Message);
            }
            finally
            {
                try
                {
                    if (mycon != null)
                        mycon.Close();
                }
                catch(Exception ec) 
                {
                    Console.WriteLine("Errors Search data " + ec.Message);
                }
            }
        }

        private void stM_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsM_find_name_Click(object sender, EventArgs e)
        {
            string sql_str="";  
            try
            {

                if (tsM_txtname.Text == "")
                {
                    sql_str = "SELECT m_id as ID,m_fname as Name,m_lname as LastName,m_sex as Sex,m_tel as Tel,";
                    sql_str += " m_address as Address,start_date as StartDate,m_first_money as Bugget,status_life as FlagLife,idcard1 as IDCard1 ";
                    sql_str += ",idcard2 as IDCard2,idcard3 as IDCard3 ,p_fname1 as Name1,p_lname1 as LastName1,p_fname2 as Name2,p_lname2 as LastName2 ";
                    sql_str += ",p_fname3 as Name3,p_lname3 as LastName3,p_address as P_Address,p_tel as P_Tel,m_r_id as RelationID,m_group_id as GroupID";
                    sql_str += " FROM member order by m_fname";
                }
                else
                {
                    sql_str = "SELECT m_id as ID,m_fname as Name,m_lname as LastName,m_sex as Sex,m_tel as Tel,";
                    sql_str += " m_address as Address,start_date as StartDate,m_first_money as Bugget,status_life as FlagLife,idcard1 as IDCard1 ";
                    sql_str += ",idcard2 as IDCard2,idcard3 as IDCard3 ,p_fname1 as Name1,p_lname1 as LastName1,p_fname2 as Name2,p_lname2 as LastName2 ";
                    sql_str += ",p_fname3 as Name3,p_lname3 as LastName3,p_address as P_Address,p_tel as P_Tel,m_r_id as RelationID,m_group_id as GroupID";
                    sql_str += " FROM member where m_fname='" + tsM_txtname.Text + "' or m_fname like '%" + tsM_txtname.Text + "%' ";
                }
                //string sql_str = "Select * from member m  order by m_id";
                adapter = new MySqlDataAdapter(sql_str, mycon);
                // adapter = cnnBase.ExecuteQuery(sql_str);
                ds = new DataSet();
                adapter.Fill(ds, "member");

                dwFind.DataSource = ds;
                dwFind.DataMember = "member";
                mycon.Close();
                // dataGrid1.DataSource = myds.Tables["employee"].DefaultView;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Errors Search data name " + ex.Message);
            }
            finally
            {
                try
                {
                    if (mycon != null)
                        mycon.Close();
                }
                catch(Exception ec)
                {
                    Console.WriteLine("Errors Search data " + ec.Message);
                }
            }
        }


    }
}