using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSharpEntityBuilder
{
    public partial class Form1 : Form
    {
        #region ����
        const string DefaultEntityName = "DefaultEntity";
        const string DefaultNameSpace = "DefaultNameSpace";

        //ʵ�����ļ�����·��
        string mSaveFilePath = "";

        //�������ݿ⽻������
        ICreator Creator = null;
        #endregion

        #region �¼�

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��������¼�
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //����Ĭ��ֵ
            txtEntityName.Text = DefaultEntityName;
            txtNameSpace.Text = DefaultNameSpace;
            txtFilePath.Text = "E:\\DataRepository" + "\\"+DefaultEntityName+".cs";
            Creator = new MysqlDbCreater();
        }

        /// <summary>
        /// �������ݿ�
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            lb_show.Text = "";
            //���
            if (!ConnCheck())
            {
                return;
            }

            //��ʼ�����Ӵ���
            Creator.InitConn(txtConStr.Text.Trim());

            //�������ݿ⡣
            try
            {
                Creator.ConnDB();

                //��ȡ����Ϣ
                List<string> lsTables= Creator.GetTables();
                cmbTables.Items.Clear();
                cmbTables.Items.AddRange(lsTables.ToArray());

                //��ʾ��ʾ��Ϣ
                lb_show.ForeColor = Color.Green;
                lb_show.Text = "���ݿ����ӳɹ�����ѡ��һ�������ʵ�������ɣ�";
            }
            catch(Exception ex)
            {
                //��ʾ��ʾ��Ϣ
                lb_show.ForeColor = Color.Red;
                lb_show.Text = "���ݿ�����ʧ�ܣ�";

                Msg("����ʧ�ܣ�" + ex.Message);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        private void btnCreateEntityFile_Click(object sender, EventArgs e)
        {
            //���
            if (!CreateCheck())
            {
                return;
            }

            //��ʼ����
            Creator.InitTableName(cmbTables.Text);

            try
            {
                //����ʵ����
                string strEntity= Creator.CreateEntity(txtNameSpace.Text.Trim(), txtEntityName.Text.Trim(), txtFilePath.Text);

                //���浽�ļ�
                EntityCreater.SaveStrToFile(strEntity, txtFilePath.Text);

                //��ʾ
                Msg("���ɳɹ���");
                lb_show.Text = "�ɹ�����һ��ʵ���࣡";
            }
            catch(Exception ex)
            {
                //��ʾ
                lb_show.ForeColor = Color.Red;
                lb_show.Text = "�ɹ�����ʵ����ʧ�ܣ�";

                Msg("����ʧ�ܣ�"+ex.Message);
            }
        }

        /// <summary>
        /// ѡ�񱣴�·��
        /// </summary>
        private void btnSelectFilePath_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.cs|*.cs|�����ļ�|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = saveFileDialog1.FileName;    
            }
        }

        /// <summary>
        /// ����ʵ�������ı���
        /// </summary>
        private void txtNameSpace_Click(object sender, EventArgs e)
        {
            if (txtNameSpace.Text == DefaultNameSpace)
            {
                txtNameSpace.Text = "";
            }
        }

        /// <summary>
        /// ����ʵ�������ı���
        /// </summary>
        private void txtEntityName_Click(object sender, EventArgs e)
        {
            if (txtEntityName.Text == DefaultEntityName)
            {
                txtEntityName.Text = "";
            }
        }

        /// <summary>
        /// ���ݿ����͵�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSQLType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMySQL.Checked)
            {
                txtConStr.Text = "Server=localhost;Database=mydb;Uid=root;Pwd=admin;charset=gbk;";
                Creator = new MysqlDbCreater();
            }

            //TODO
            /*if (rbMSSQL.Checked)
            {
                
            }

            if (rbOracle.Checked)
            {
                txtConStr.Text = "Data Source=orcl;User ID=cscec;Password=cscec3b";
                Creator = new OracleDbCreater();
            }*/
        }

        //blog
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("iexplore.exe", "http://tuyile006.cnblogs.com");
        }

        #endregion

        #region ˽�з���
        /// <summary>
        /// ������Ӱ�ťʱ��顣
        /// </summary>
        /// <returns></returns>
        private bool ConnCheck()
        {
            //��д���Լ������Ӵ�����ֱ�ӷ���true
            if (string.IsNullOrEmpty(txtConStr.Text.Trim()))
            {
                Msg("���������Ӵ���");
                txtConStr.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// �������ʱ�ļ��
        /// </summary>
        /// <returns></returns>
        private bool CreateCheck()
        {
            if (cmbTables.SelectedIndex == -1)
            {
                Msg("��ѡ��һ��Ҫת����ʵ����ı�");
                cmbTables.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNameSpace.Text.Trim()))
            {
                Msg("����д�����ռ����ƣ�");
                txtNameSpace.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEntityName.Text.Trim()))
            {
                Msg("����дʵ�������ƣ�");
                txtEntityName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                Msg("�������ѡ�񱣴�ʵ�����ļ���·����");
                txtFilePath.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��ʾ
        /// </summary>
        /// <param name="message"></param>
        private void Msg(string message)
        {
            MessageBox.Show(message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Name = this.cmbTables.Text;
            var txt = this.txtConStr.Text;
            var txtConStr = txt.Substring(9, (txt.IndexOf(";")-9));
            txtNameSpace.Text = txtConStr;
            txtEntityName.Text = Name;
            txtFilePath.Text = "E:\\DataRepository" + "\\" + Name + ".cs";
        }
    }
}