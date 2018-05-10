using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;

namespace CSharpEntityBuilder
{
    public class OracleDbCreater:ICreator
    { 
        #region 私有变量

        string mConnString = string.Empty;
        string mTableName = string.Empty;
        string mDbName = string.Empty;
        OracleConnection con = null;
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

        #region ICreator接口实现

        /// <summary>
        /// 设置数据库连接串。
        /// </summary>
        /// <param name="pConStr">链接串</param>
        public void InitConn(string pConStr)
        {
            mConnString = pConStr;
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        public void ConnDB()
        {
            con = new OracleConnection(mConnString);
            con.Open();
        }

        /// <summary>
        /// 获取表列表。
        /// </summary>
        /// <returns></returns>
        public List<string> GetTables()
        {
            string strSQL = "select object_name from user_objects ubs where ubs.OBJECT_TYPE='TABLE'";
            OracleCommand com = new OracleCommand(strSQL, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OracleDataReader reader= com.ExecuteReader();
            List<string> tableList = new List<string>();
            while (reader.Read())
            {
               tableList.Add(reader[0].ToString());
            }
            reader.Close();

            return tableList;
        }

        /// <summary>
        /// 设置要生成实体的table
        /// </summary>
        /// <param name="tableName">表名</param>
        public void InitTableName(string tableName)
        {
            mTableName = tableName;
        }

        /// <summary>
        /// 构造实体类（的字符串）。
        /// </summary>
        /// <param name="strNameSpace">命名空间名称</param>
        /// <param name="strClassName">类名称</param>
        /// <param name="strFilePath">生成类的地址</param>
        /// <returns>返回类的字符串</returns>
        public string CreateEntity(string strNameSpace,string strClassName,string strFilePath)
        {
            //select column_name,data_type,column_comment from information_schema.columns where table_name='RMBCode';
            string strSQL = string.Format("select a.column_name,a.data_type,b.comments from user_tab_columns a,user_col_comments b where a.table_name=b.TABLE_NAME and a.COLUMN_NAME=b.COLUMN_NAME and a.TABLE_NAME='{0}'", mTableName.ToUpper());
            OracleCommand com = new OracleCommand(strSQL, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OracleDataReader reader = com.ExecuteReader();
            List<string> columNames = new List<string>();
            List<string> columDesc = new List<string>();
            List<string> typeList = new List<string>();
            while (reader.Read())
            {
                columNames.Add(reader["column_name"].ToString());
                columDesc.Add(reader["comments"].ToString());
                typeList.Add(GetCSharpTypeFromDbType(reader["data_type"].ToString()));
            }
            reader.Close();

            return EntityCreater.CreateEntity(mTableName,strNameSpace,strClassName,columNames.ToArray(),
                columDesc.ToArray(),typeList.ToArray());
        }

    
        #endregion

        #region 私有方法
        /// <summary>
        /// 将数据库中的类型转换为c#的类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private string GetCSharpTypeFromDbType(string dbType)
        {
            switch (dbType.ToLower())
            {
                case "number":
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
                case "varchar2":
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
                case "date":
                    return "DateTime";
                default:
                    return dbType;
            }
        }
        #endregion
    }
}