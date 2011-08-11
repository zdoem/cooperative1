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
        enum State {None,Add,Modify,Delete}//��С�ȵ���� enum  �������㹡�äǺ��� Event �ͧ����
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

        // ���ʹ Resetdata
        private void ResetField()
        {
            //���ǹ�ͧ��������Ҫԡ  
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
            //���ǹ�ͧ������ ����Ѻ�Ż���ª�
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
        //method �����˹�㹰ҹ������
        private void loadData(int position)
        {
           try
           {
            //���ǹ�ͧ��������Ҫԡ  
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
               //���ǹ�ͧ������ ����Ѻ�Ż���ª�
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

                                //��Ҥ�ҷ�����ê����˹�㹰ҹ�������ҡ���Ҩӹǹ���˹�㹰ҹ�����Ũ�ԧ  ��ҵ���èЪպ͡���˹�
                                if (position > this.BindingContext[ds, "member"].Count - 1)
                                {
                                    current_pos = this.BindingContext[ds,"member"].Count-1;
                                    position = this.BindingContext[ds, "member"].Count - 1;
                                }

                                //��ҵ�Ǫ����˹�㹰ҹ������ < 0  �����Ũп�ͧ�����辺������� database 
                                if (position < 0)
                                {
                                    tsTxtPageNum.Text = "No Record";
                                    stBDelete.Enabled = false;
                                    stBEdit.Enabled = false;

                                    ClearData();

                                    return;
                                }

                                //��ǹ����鹡����Ҥ�ҷ����ҡ���˹�㹿�Ŵ������Ŵ��á�֧�Դ���ش���������� text box
                                m_txt_id.Text= ds.Tables["member"].Rows[position][0].ToString();
                                m_txt_fname.Text = ds.Tables["member"].Rows[position][1].ToString();
                                m_txt_lname.Text = ds.Tables["member"].Rows[position][2].ToString();
                                m_cbx_sex.Text = ds.Tables["member"].Rows[position][3].ToString();
                                m_txt_tel.Text = ds.Tables["member"].Rows[position][4].ToString();
                                m_txt_address.Text = ds.Tables["member"].Rows[position][5].ToString();
                                m_txt_datePTK.Text= ds.Tables["member"].Rows[position][6].ToString();
                               
                                m_txt_fmoney.Text = ds.Tables["member"].Rows[position][7].ToString();
                               

                                //****.��ǹ�ͧ����Ѻ�Ż���ª�
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
                                
                                //��ҵ��˹觷��Ѻ���ҡ����������ҡѺ�Өǹ��Ƿ��Ѵ��ԧ������ next ��л��� First �������ö�ӧҹ��
                                if (current_pos >= row_count - 1)
                                {
                                    tsBMoveNext.Enabled = false;
                                    tsBMoveFirst.Enabled = false;
                                }
                                else
                                {
                                // ��ҵ��˹觷��Ѻ������ҡ����������ҡѺ�ӹǹ�Ƿ��Ѻ�������� next & first �ӧҹ
                                    tsBMoveNext.Enabled = true;
                                    tsBMoveFirst.Enabled = true;
                                }

                                //��ҵ��˹觷��Ѻ����¡���������ҡѺ 0�ԧ ������ previous ��л��� last �������ö�ӧҹ��
                                if (current_pos <= 0)
                                {
                                    tsBMoveProvious.Enabled = false;
                                    tsBMoveLast.Enabled = false;
                                   
                                }
                                else
                                {
                                    //��ҵ��˹觷��Ѻ�������¡����ٹ��������ͧ�����ӧҹ
                                    tsBMoveProvious.Enabled = true;
                                    tsBMoveLast.Enabled = true;
                                }

                                stBAdd.Enabled = true;
                                stBEdit.Enabled = true;
                                stBDelete.Enabled = true;
                                stBCancel.Enabled = false;//**********
                                this.BindingContext[ds, "member"].Position = position;
                                //�����ҹ��ҵ��˹觷��١��ͧ���ǹ����ʴ��� tstTextPaeNum.text
                                tsTxtPageNum.Text = Convert.ToString(current_pos+1);
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(" Load Data Errors " +ex.Message);
                    }

        }

        //metho ��ô֧�����Ť�ҨҰҹ���������ʴ�� Commbobox
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
        //metho ��ô֧�����Ť�ҨҰҹ���������ʴ�� Commbobox Relation
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

       //�����Ŵ�������ʴ���˹�Ҩ����͹�١�Դ���
        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                m_cbx_sex.Items.Add("˭ԧ");
                m_cbx_sex.Items.Add("���");
                showCombo();//****************call mathod
                showComboRelation();//****************call mathod

                loadDatabase();//******** call method
                current_pos = this.BindingContext[ds, "member"].Count;//�Ѻ���˹�
                tsTxtPageSum.Text += "[" + current_pos + "]";//�ʴ�������Ѻ���˹�
                current_pos = this.BindingContext[ds, "member"].Position;//���͡���˹�

                loadData(current_pos);//call method  �����˹�� Database
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
            //�����˹觶Ѵ仨ҡ���˹��á��辺
            this.BindingContext[ds, "member"].Position = this.BindingContext[ds, "member"].Position + 1;
            //�Ѻ���˹觷����
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
                    //�����˹觷����ش
                    this.BindingContext[ds, "member"].Position = this.BindingContext[ds,"member"].Count-1;
                    //�Ѻ���˹觷����
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
                    //�����˹觶����ѧ�ҡ���˹觷�辺�á�ش
                    this.BindingContext[ds, "member"].Position = this.BindingContext[ds, "member"].Position- 1;
                    //�Ѻ���˹觷����
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
                    //�����˹�仵��˹��á�ش
                    this.BindingContext[ds, "member"].Position = 0;
                    //�Ѻ���˹觷����
                    current_pos = this.BindingContext[ds, "member"].Position;

                    loadData(current_pos);//call  method
             }
            catch(Exception ex)
            {
                Console.WriteLine(" tsBMoveLast_Click  Errors " + ex.Message);
            }
        }

       //���ʹ Add data to base
        private void stBAdd_Click(object sender, EventArgs e)
        {
            //����ѧ��衴���� add ����÷ӧҹ��ҧ�ͧ Oject �����Ҩ�����͹����Դ˹�Ҩͤ����á
            if (state == State.None)
            {
                state = State.Add;  //��ҡ����� add ��� Text box �١���������Ѻ������
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
                //���ǹ�ͧ��������Ҫԡ  
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
                //���ǹ�ͧ������ ����Ѻ�Ż���ª�
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
            else //����ѧ��͡������� txt box ���ú���ʴ���ͤ�����͹�����
            {
                if (m_txt_id.Text == "")
                {
                    MessageBox.Show("��سһ�͹������Ҫԡ���¤�Ѻ...!!","���й�...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    m_txt_id.Focus();
                    return;
                }
                else if (m_txt_fname.Text == "")
               {
                        MessageBox.Show("��سһ�͹������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        m_txt_fname.Focus();
                        return;
                }
                else if (m_txt_lname.Text == "")
                {
                            MessageBox.Show("��سһ�͹���ʡ����Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            m_txt_lname.Focus();
                            return;
                }
                else if (m_cbx_gtype.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_gtype.Focus();
                    return;
                }
                else if (m_txt_datePTK.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�ѹ�����¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_datePTK.Focus();
                    return;
                }
                else if (m_txt_address.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ���������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_address.Focus();
                    return;
                }
                else if (m_cbx_sex.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�ȴ��¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_sex.Focus();
                    return;
                }
                else if (m_txt_tel.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�����ô��¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_tel.Focus();
                    return;
                }
               else if (m_txt_fmoney.Text == ""|| int.Parse(m_txt_fmoney.Text)<=0)
                {
                    MessageBox.Show("��سҵ���ͺ�ӹǹ�Թ�á��Ҵ��¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_fmoney.Focus();
                    return;
                }
                    //******����ͺ���ǹ�ͧ����Ѻ�Ż���ª�**********//
                else if (p_txt_address.Text == "")
                {
                    MessageBox.Show("��سҵ���ͺ����������Ѻ�Ż���ª����¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_address.Focus();
                    return;
                }
                else if (p_txt_tel.Text == "")
                {
                    MessageBox.Show("��سҵ���ͺ�����ü���Ѻ�Ż���ª����¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_tel.Focus();
                    return;
                }
                else if (m_cbx_relation.Text == "")
                {
                    MessageBox.Show("��سҵ���ͺʶҹ�����Ǣ�ͧ��  ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_relation.Focus();
                    return;
                }
                else if (p_txt_fname1.Text != "")
                {
                    if (p_txt_lname1.Text == "")
                    {
                        MessageBox.Show("��سҵ�Ǩ�ͺ���ʡ�ż���Ѻ�Ż���ª�� 1 ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_lname1.Focus();
                        return;
                    }
                }
                else if (p_txt_fname1.Text == "" && p_txt_lname1.Text=="")
                {
                    if (p_txt_fname2.Text != "" || p_txt_lname2.Text != ""||p_txt_fname3.Text != "" || p_txt_lname3.Text != "")
                    {
                        MessageBox.Show("��سҡ�͡����-���ʡ�ż���Ѻ�Ż���ª�� 1 ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_fname1.Focus();
                        return;
                    }
                }
                //�ŧ�ѹ���������ٻỺ�
                String ddmmyy = "yyyy-MM-dd";
               // CultureInfo thai = new CultureInfo("th-TH");

                string sex = "";
                if (m_cbx_sex.SelectedItem.Equals("���"))
                {
                    sex= "M";
                }
                else
                {
                    sex = "F";
                }

                /*// ��Ǩ�ͺ������� ID ���� Database �������
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
                MessageBox.Show("ID ���  "+chkID);
                m_txt_id.Focus();
                */
               

               // MessageBox.Show("test:" + dt.ToString(ddmmyy, thai));
                string SQLstr = "";
                try
                {
                    //**����բ�����������ӡ�úѹ�֡ŧ database �������¹ʶҹ��������͹�͹�á����Դ�����
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
                    state = State.None;//��Ѻ�ʶҹлõԡ
                    stBAdd.Text = " &Add ";
                   

                }
                catch (Exception ex)
                {
                     MessageBox.Show("�������ö�ѹ�֡��������Ѻ...!!", "�Դ��ͼԴ��Ҵ...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     MessageBox.Show("Erors..Add data" + ex.Message,"�Դ��ͼԴ��Ҵ...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     MessageBox.Show("SQL.." + SQLstr, "�Դ��ͼԴ��Ҵ...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     ResetField();// call method

                     loadDatabase();//call method
                     current_pos = this.BindingContext[ds, "member"].Count;
                     tsTxtPageSum.Text = " of [ " + current_pos + " ]";
                     loadData(current_pos); //call method
                     stBCancel.Enabled = false;
                     state = State.None;//��Ѻ�ʶҹлõԡ
                     stBAdd.Text = " &Add ";
    
                }

            }//End els
        }
       //���ʹ EditData to base
        private void stBEdit_Click(object sender, EventArgs e)
        {
            //����ѧ��衴���� Edit ����÷ӧҹ��ҧ�ͧ Object ��˹�Ҩ�����͹�������Դ������á
            if (state == State.None)
            {
                //���͡�����Edit ���ǹ�ͧ Object ��������������� name ,lname......
                stBAdd.Enabled = false;
                stBEdit.Enabled = true;
                stBDelete.Enabled = false;
                stBCancel.Enabled = true;

                //���ǹ�ͧ��������Ҫԡ  
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
                //���ǹ�ͧ������ ����Ѻ�Ż���ª�
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
                state = State.Modify;// ����������紨���Ң�鹵͹��û�Ѻ���ا���

            }
            else
            {
             //��һ�Ѻ��ا�����������衴������Ѻ������͹���
                if (m_txt_id.Text == "")
                {
                    MessageBox.Show("��سһ�͹������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_id.Focus();
                    return;
                }
                else if (m_txt_fname.Text == "")
                {
                    MessageBox.Show("��سһ�͹������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_fname.Focus();
                    return;
                }
                else if (m_txt_lname.Text == "")
                {
                    MessageBox.Show("��سһ�͹���ʡ����Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_lname.Focus();
                    return;
                }
                else if (m_cbx_gtype.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_gtype.Focus();
                    return;
                }
                else if (m_txt_datePTK.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�ѹ�����¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_datePTK.Focus();
                    return;
                }
                else if (m_txt_address.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ���������Ҫԡ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_address.Focus();
                    return;
                }
                else if (m_cbx_sex.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�ȴ��¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_sex.Focus();
                    return;
                }
                else if (m_txt_tel.Text == "")
                {
                    MessageBox.Show("��سҵ�Ǩ�ͺ�����ô��¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_tel.Focus();
                    return;
                }
                else if (m_txt_fmoney.Text == "" || int.Parse(m_txt_fmoney.Text) <= 0)
                {
                    MessageBox.Show("��سҵ���ͺ�ӹǹ�Թ�á��Ҵ��¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_txt_fmoney.Focus();
                    return;
                }
                //******����ͺ���ǹ�ͧ����Ѻ�Ż���ª�**********//
                else if (p_txt_address.Text == "")
                {
                    MessageBox.Show("��سҵ���ͺ����������Ѻ�Ż���ª����¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_address.Focus();
                    return;
                }
                else if (p_txt_tel.Text == "")
                {
                    MessageBox.Show("��سҵ���ͺ�����ü���Ѻ�Ż���ª����¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_txt_tel.Focus();
                    return;
                }
                else if (m_cbx_relation.Text == "")
                {
                    MessageBox.Show("��سҵ���ͺʶҹ�����Ǣ�ͧ��  ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_cbx_relation.Focus();
                    return;
                }
                else if (p_txt_fname1.Text != "")
                {
                    if (p_txt_lname1.Text == "")
                    {
                        MessageBox.Show("��سҵ�Ǩ�ͺ���ʡ�ż���Ѻ�Ż���ª�� 1 ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_lname1.Focus();
                        return;
                    }
                }
                else if (p_txt_fname1.Text == "" && p_txt_lname1.Text == "")
                {
                    if (p_txt_fname2.Text != "" || p_txt_lname2.Text != "" || p_txt_fname3.Text != "" || p_txt_lname3.Text != "")
                    {
                        MessageBox.Show("��سҡ�͡����-���ʡ�ż���Ѻ�Ż���ª�� 1 ���¤�Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p_txt_fname1.Focus();
                        return;
                    }
                }

                //�ŧ�ѹ���������ٻỺ�
                String ddmmyy = "yyyy-MM-dd";
                //CultureInfo thai = new CultureInfo("th-TH");
                
                // set data*--------------------
                ResetField();//call medthod
                
                string sex = "";


                if (m_cbx_sex.Text.Equals("���"))
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

                    
                    MessageBox.Show("�к���ӡ�� Update ���������º�������ǤѺ...OK!!", "Update data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    loadDatabase();
                    loadData(current_pos);
                    stBEdit.Text = " &Edit ";
                    state = State.None;
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�к��������ö Update ��������Ѻ...!!", "�Դ��ͼԴ��Ҵ...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //���ʹ Delete to base
        private void stBDelete_Click(object sender, EventArgs e)
        {
            string sqlDel = "";
            if (MessageBox.Show("�س��ͧ���ź��������Ҫԡ '" + m_txt_id.Text + "' ���������...?", "���׹�ѹ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

                    MessageBox.Show("�к���ӡ�� Delete ���������º�������ǤѺ...OK!!", "Delete data OK...!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tsBMoveFirst_Click(sender, e);
                    mycon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�к��������ö Delete ��������Ѻ...!!", "�Դ��ͼԴ��Ҵ...!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Erors..Delete data" + ex.Message);
                    MessageBox.Show("SQL.." + sqlDel);

                    loadDatabase();//******
                    loadData(current_pos);
                    tsBMoveFirst_Click(sender, e);

                }
            }//End if confirm
        }
        //���ʹ Cancel button
        private void stBCancel_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.Add: //���͡����� add ���ǵ�ͧ��á����� Cancel
                    stBAdd.Text = " &Add ";
                    ResetField();// to state defult
                    loadData(current_pos);
                    break;
                case State.Modify:// ����͡����� Edit ���ǵ�ͧ��á����� Cencel
                    stBEdit.Text = " &Edit ";
                    ResetField(); //to state defult
                    loadData(current_pos);
                    break;
                case State.Delete: //����͡����� Deleete ��á� Cancel �����ӧҹ
                    break;
                default:
                    break;
            }
            state = State.None;//����Դ����˹�Ҩ͢�������� ʶҹл��� cancel �����ӧҹ
            stBCancel.Enabled = false;
        }
        //------------------------------
       //���ʹ ��ID ��ǧ˹��
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
        //metho����͹੾�е���Ţ��ФѺ
        private void m_txt_fmoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("��سҡ�͡੾�е���Ţ��ҹ�鹤Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_txt_fmoney.Focus();
                e.Handled = true;
            }
        }

        private void m_txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("��سҡ�͡੾�е���Ţ��ҹ�鹤Ѻ...!!", "���й�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_txt_id.Focus();
                e.Handled = true;
            }
        }

       // method ����¹�ѹ��� 㹡�úѹ�֡
        private void m_txt_datePTK_ValueChanged(object sender, EventArgs e)
        {
            dd = m_txt_datePTK.Value;
        }

    }
}