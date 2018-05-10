using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharpEntityBuilder
{
    public class EntityCreater
    {
        /// <summary>
        /// ����ʵ���ࡣ
        /// </summary>
        /// <param name="strTableName">����</param>
        /// <param name="strNameSpace">�����ռ�����</param>
        /// <param name="strClassName">������</param>
        /// <param name="columNames">ʵ���ֶ����б�</param>
        /// <param name="columDesc">ʵ���ֶ������б�</param>
        /// <param name="typeList">�ֶ������б�</param>
        /// <returns>ʵ����Ĵ���</returns>
        public static string CreateEntity(string strTableName,string strNameSpace, string strClassName,string[] columNames, string[] columDesc, string[] typeList)
        {
            StringBuilder sb = new StringBuilder();
            //�ļ�ͷע��
            sb.AppendLine("// ================================================================================");
            sb.AppendLine("// File: "+strClassName+".cs");
            sb.AppendLine("// Desc: ��["+strTableName+"]��ʵ����");
            sb.AppendLine("//  ��ʵ����ͨ���������ɹ��ߣ�CSharpEntityBuilder���Զ����ɡ�");
            sb.AppendLine("// Called by:  XX ");
            sb.AppendLine("//               ");
            sb.AppendLine("// Auth: XX");
            sb.AppendLine("// Date: " +DateTime.Now.ToString("yyyy��MM��dd��"));
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
            sb.AppendLine("    /// ��[" + strTableName + "]��ʵ����");
            sb.AppendLine("    /// </summary>");

            //class
            sb.AppendLine("    public class " + strClassName);
            sb.AppendLine("    {");
            sb.AppendLine();

            //˽�г�Ա�����캯��
            sb.AppendLine("        #region ��Ա���������캯��");
            sb.AppendLine("        string m_strTableName;");
            for (int i = 0; i < columNames.Length; i++)
            {
                sb.AppendLine("        " + typeList[i] + " m_" + columNames[i] + ";");
            }
            
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// ��ʼ���� " + strClassName + " ����ʵ����");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public " + strClassName + "()");
            sb.AppendLine("        {");
            sb.AppendLine("            m_strTableName=\"" + strTableName + "\";");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();

            //�ֶ�����
            sb.AppendLine("        #region �ֶ�����");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// ��ȡʵ�����Ӧ�����ݿ������");
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
        /// �����ַ������ļ�
        /// </summary>
        /// <param name="str">Ҫ������ַ���</param>
        /// <param name="filePath">�ļ�·��</param>
        public static void SaveStrToFile(string str, string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            if (!info.Directory.Exists)
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            StreamWriter stream =null;
            //����
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
