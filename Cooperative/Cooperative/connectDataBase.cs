/*using System;
using System.Collections.Generic;
using System.Text;

namespace Cooperative
{
    class connectDataBase
    {
    }
}*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Cooperative
{
    public class connDataBase
    {
        private MySqlConnection _conn = null;
        private MySqlDataAdapter _adapt = null;
        private string _DBName;

        //method connect database
        public connDataBase()
        {
            _conn = new MySqlConnection();
            _adapt = new MySqlDataAdapter();
            this._DBName = "";
        }

        //method Open Database
        public void Open()
        {
            if (this._DBName != "")
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();

                //ประกาศตัวแปร strConn เพื่อเก็บข้อความเชื่อมต่อ Database
                string strConn = "datasource=localhost;username=root;password=root;database=db_cooperative";
                _conn.ConnectionString = strConn;
                _conn.Open();
            }
        }


        //method Close Data Base
        public void Close()
        {
            if (this._conn != null)
            {
                if (this._conn.State == ConnectionState.Open)
                    this._conn.Close();
            }
        }

        //method seclect connection database
        public void SelectDatabase(String db_name)
        {
            this._DBName = db_name;
        }

        //เปลี่ยนเเปลงฐานข้อมูลที่ติดต่อ
        public void ChangeDatabase(string db_name)
        {
            try
            {
                if (IsConnect())
                {
                    this._DBName = db_name;
                    this._conn.ChangeDatabase(db_name);
                }
                else//ถ้าไม่เลือกฐานข้อมูลให้แจ้งเตือน
                {
                    throw new Exception("Not Connection Database...");
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        //method คืนค่าตัวแปร
        public string DBName()
        {
            return this._DBName;
        }

        //method ดำเนินการกับฐานข้อมูล
        public int ExecuteNonQuery(string str_sql)
        {
            try
            {
                //ถ้า connect Database Ok
                if (IsConnect())
                {
                    MySqlCommand cmd = new MySqlCommand(str_sql);
                    cmd.CommandTimeout = 30;
                    //หากไม่มีการใช้งานฐานข้อมูลภายใน 30 วินาทีให้ปิดฐานข้อมูล
                    cmd.Connection = this._conn;//เชื่อมต่อฐานข้อมุล
                    return cmd.ExecuteNonQuery();//ส่งค่ากับ
                }
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return 0;
        }

        //method สำหรับติดต่อ คำสั่ง SQL
        public MySqlDataAdapter ExecuteQuery(string str_sql)
        {
            if (IsConnect())//ถ้ามีการเชื่อต่อแล้ว
            {
                MySqlCommand cmd = new MySqlCommand(str_sql);
                cmd.Connection = this._conn;//เชื่อต่อ Database
                return new MySqlDataAdapter(cmd);
            }
            return null;
        }

        //method ตรวจสอบการติดต่อฐานข้อมูล
        public bool IsConnect()
        {
            if (this._conn == null)
                return false;
            if (this._conn.State == ConnectionState.Closed)
                return false;
            return true;
        }

    }
}

 

