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
    public partial class frmCauseDie : Form
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
        //---------------- 

        //method display data to table gridView
        private void loadDatabase()
        {
            try
            {
                // cnnBase.Open();
                //string sql_str = "Select * from member m where status_life = 'L' order by m_id";
                string sql_str = "SELECT cause_die.cd_id as ID, cause_die.cd_name as Name  FROM db_cooperative.cause_die cause_die order by  cause_die.cd_id";

                adapter = new MySqlDataAdapter(sql_str, mycon);

                ds = new DataSet();
                adapter.Fill(ds, "cause_die");
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "cause_die";

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
        
        public frmCauseDie()
        {
            InitializeComponent();
        }

        private void frmCauseDie_Load(object sender, EventArgs e)
        {
            loadDatabase();
        }
    }
}
