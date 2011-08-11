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

                //��С�ȵ���� strConn �����红�ͤ����������� Database
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

        //����¹��ŧ�ҹ�����ŷ��Դ���
        public void ChangeDatabase(string db_name)
        {
            try
            {
                if (IsConnect())
                {
                    this._DBName = db_name;
                    this._conn.ChangeDatabase(db_name);
                }
                else//���������͡�ҹ�������������͹
                {
                    throw new Exception("Not Connection Database...");
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        //method �׹��ҵ����
        public string DBName()
        {
            return this._DBName;
        }

        //method ���Թ��áѺ�ҹ������
        public int ExecuteNonQuery(string str_sql)
        {
            try
            {
                //��� connect Database Ok
                if (IsConnect())
                {
                    MySqlCommand cmd = new MySqlCommand(str_sql);
                    cmd.CommandTimeout = 30;
                    //�ҡ����ա����ҹ�ҹ���������� 30 �Թҷ����Դ�ҹ������
                    cmd.Connection = this._conn;//�������Ͱҹ������
                    return cmd.ExecuteNonQuery();//�觤�ҡѺ
                }
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return 0;
        }

        //method ����Ѻ�Դ��� ����� SQL
        public MySqlDataAdapter ExecuteQuery(string str_sql)
        {
            if (IsConnect())//����ա�����͵������
            {
                MySqlCommand cmd = new MySqlCommand(str_sql);
                cmd.Connection = this._conn;//���͵�� Database
                return new MySqlDataAdapter(cmd);
            }
            return null;
        }

        //method ��Ǩ�ͺ��õԴ��Ͱҹ������
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

 

