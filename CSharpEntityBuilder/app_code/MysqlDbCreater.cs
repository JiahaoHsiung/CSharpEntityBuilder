using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace CSharpEntityBuilder
{
    public class MysqlDbCreater:ICreator
    {
        #region ˽�б���

        string mConnString = string.Empty;
        string mTableName = string.Empty;
        string mDbName = string.Empty;
        MySqlConnection con = null;
        #endregion

        public EntityCreater EntityCreater
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region ICreator�ӿ�ʵ��

        /// <summary>
        /// �������ݿ����Ӵ���
        /// </summary>
        /// <param name="pConStr">���Ӵ�</param>
        public void InitConn(string pConStr)
        {
            mConnString = pConStr;
        }

        /// <summary>
        /// �������ݿ�
        /// </summary>
        public void ConnDB()
        {
            con = new MySqlConnection(mConnString);
            con.Open();
        }

        /// <summary>
        /// ��ȡ���б�
        /// </summary>
        /// <returns></returns>
        public List<string> GetTables()
        {
            string strSQL = string.Format("use {0};show tables;",con.Database);
            MySqlCommand com = new MySqlCommand(strSQL, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            MySqlDataReader reader= com.ExecuteReader();
            List<string> tableList = new List<string>();
            while (reader.Read())
            {
               tableList.Add(reader[0].ToString());
            }
            reader.Close();

            return tableList;
        }

        /// <summary>
        /// ����Ҫ����ʵ���table
        /// </summary>
        /// <param name="tableName">����</param>
        public void InitTableName(string tableName)
        {
            mTableName = tableName;
        }

        /// <summary>
        /// ����ʵ���ࣨ���ַ�������
        /// </summary>
        /// <param name="strNameSpace">�����ռ�����</param>
        /// <param name="strClassName">������</param>
        /// <param name="strFilePath">������ĵ�ַ</param>
        /// <returns>��������ַ���</returns>
        public string CreateEntity(string strNameSpace,string strClassName,string strFilePath)
        {
            //select column_name,data_type,column_comment from information_schema.columns where table_name='RMBCode';
            string strSQL = string.Format("select column_name,data_type,column_comment from information_schema.columns where table_name='{0}'", mTableName);
            MySqlCommand com = new MySqlCommand(strSQL, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            MySqlDataReader reader = com.ExecuteReader();
            List<string> columNames = new List<string>();
            List<string> columDesc = new List<string>();
            List<string> typeList = new List<string>();
            while (reader.Read())
            {
                columNames.Add(reader["column_name"].ToString());
                columDesc.Add(reader["column_comment"].ToString());
                typeList.Add(GetCSharpTypeFromDbType(reader["data_type"].ToString()));
            }
            reader.Close();

            return EntityCreater.CreateEntity(mTableName,strNameSpace,strClassName,columNames.ToArray(),
                columDesc.ToArray(),typeList.ToArray());
        }

        //public DataSet GetDS()
        //{
        //    MySqlCommand com = new MySqlCommand("select * from cqwg", con);
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    MySqlDataAdapter da = new MySqlDataAdapter(com);
        //    DataSet ds=new DataSet();
        //    da.Fill(ds, "tb1");
        //    return ds;
        //}
        #endregion

        #region ˽�з���
        /// <summary>
        /// �����ݿ��е�����ת��Ϊc#������
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private string GetCSharpTypeFromDbType(string dbType)
        {
            switch (dbType.ToLower())
            {
                case "tinyint":
                case "smallint":
                case "mediumint":
                case "int":
                case "numeric":
                    return "int";
                case "bigint":
                    return "long";
                case "decimal":
                    return "decimal";
                case "bit":
                    return "bool";
                case "enum":
                case "set":
                case "char":
                case "varchar":
                case "text":
                    return "string";
                case "tinyblob":
                case "blob":
                case "mediumblob":
                case "longblob":
                case "binary":
                case "varbinary":
                    return "byte[]";
                case "datetime":
                    return "DateTime";
                default:
                    return dbType;
            }
        }
        #endregion
    }
}
