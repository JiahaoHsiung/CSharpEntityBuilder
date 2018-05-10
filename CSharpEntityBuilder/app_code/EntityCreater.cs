using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpEntityBuilder
{
    public class EntityCreater
    {
        /// <summary>
        /// 生成实体类。
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="strNameSpace">命名空间名称</param>
        /// <param name="strClassName">类名称</param>
        /// <param name="columNames">实体字段名列表</param>
        /// <param name="columDesc">实体字段描述列表</param>
        /// <param name="typeList">字段类型列表</param>
        /// <returns>实体类的代码</returns>
        public static string CreateEntity(string strTableName,string strNameSpace, string strClassName,string[] columNames, string[] columDesc, string[] typeList)
        {
            StringBuilder sb = new StringBuilder();
            //文件头注释
            sb.AppendLine("// ================================================================================");
            sb.AppendLine("// File: "+strClassName+".cs");
            sb.AppendLine("// Desc: 表["+strTableName+"]的实体类");
            sb.AppendLine("//  此实体类通过代码生成工具（CSharpEntityBuilder）自动生成。");
            sb.AppendLine("// Called by:  XX ");
            sb.AppendLine("//               ");
            sb.AppendLine("// Auth: XX");
            sb.AppendLine("// Date: " +DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("// ================================================================================");
            sb.AppendLine("// Change History");
            sb.AppendLine("// ================================================================================");
            sb.AppendLine("// 		Date:		Author:				Description:");
            sb.AppendLine("// 		--------	--------			-------------------");
            sb.AppendLine("//    ");
            sb.AppendLine("// ================================================================================");
            sb.AppendLine("// Copyright (C) 2010-2020  http://tuyile006.cnblogs.com/");
            sb.AppendLine("// ================================================================================");

            //Using
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine();

            //namespace
            sb.AppendLine("namespace " + strNameSpace);
            sb.AppendLine("{");

            //class desc
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 表[" + strTableName + "]的实体类");
            sb.AppendLine("    /// </summary>");

            //class
            sb.AppendLine("    public class " + strClassName);
            sb.AppendLine("    {");
            sb.AppendLine();

            //私有成员、构造函数
            sb.AppendLine("        #region 成员变量、构造函数");
            sb.AppendLine("        string m_strTableName;");
            for (int i = 0; i < columNames.Length; i++)
            {
                sb.AppendLine("        " + typeList[i] + " m_" + columNames[i] + ";");
            }
            
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 初始化类 " + strClassName + " 的新实例。");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public " + strClassName + "()");
            sb.AppendLine("        {");
            sb.AppendLine("            m_strTableName=\"" + strTableName + "\";");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();

            //字段属性
            sb.AppendLine("        #region 字段属性");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取实体类对应的数据库表名。");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public string TableName");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return m_strTableName;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            for (int i = 0; i < columNames.Length; i++)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine("        /// " + columDesc[i]);
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        public " + typeList[i] + " " + columNames[i]);
                sb.AppendLine("        {");
                sb.AppendLine("            get");
                sb.AppendLine("            {");
                sb.AppendLine("                return" + " m_" + columNames[i] + ";");
                sb.AppendLine("            }");
                sb.AppendLine("            set");
                sb.AppendLine("            {");
                sb.AppendLine("                " + " m_" + columNames[i] + "=value;");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                sb.AppendLine();
            }
            sb.AppendLine("        #endregion");
            sb.AppendLine();

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// 保存字符串到文件
        /// </summary>
        /// <param name="str">要保存的字符串</param>
        /// <param name="filePath">文件路径</param>
        public static void SaveStrToFile(string str, string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            if (!info.Directory.Exists)
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            StreamWriter stream =null;
            //保存
            try
            {
                stream = new StreamWriter(filePath, false, Encoding.Default);
                stream.Write(str);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
