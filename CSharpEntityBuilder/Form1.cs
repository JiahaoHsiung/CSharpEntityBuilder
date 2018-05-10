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
        #region 变量
        const string DefaultEntityName = "DefaultEntity";
        const string DefaultNameSpace = "DefaultNameSpace";

        //实体类文件保存路径
        string mSaveFilePath = "";

        //进行数据库交互的类
        ICreator Creator = null;
        #endregion

        #region 事件

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置默认值
            txtEntityName.Text = DefaultEntityName;
            txtNameSpace.Text = DefaultNameSpace;
            txtFilePath.Text = "E:\\DataRepository" + "\\"+DefaultEntityName+".cs";
            Creator = new MysqlDbCreater();
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            lb_show.Text = "";
            //检查
            if (!ConnCheck())
            {
                return;
            }

            //初始化连接串。
            Creator.InitConn(txtConStr.Text.Trim());

            //连接数据库。
            try
            {
                Creator.ConnDB();

                //获取表信息
                List<string> lsTables= Creator.GetTables();
                cmbTables.Items.Clear();
                cmbTables.Items.AddRange(lsTables.ToArray());

                //显示提示信息
                lb_show.ForeColor = Color.Green;
                lb_show.Text = "数据库连接成功！请选择一个表进行实体类生成！";
            }
            catch(Exception ex)
            {
                //显示提示信息
                lb_show.ForeColor = Color.Red;
                lb_show.Text = "数据库连接失败！";

                Msg("连接失败！" + ex.Message);
            }
        }

        /// <summary>
        /// 生成
        /// </summary>
        private void btnCreateEntityFile_Click(object sender, EventArgs e)
        {
            //检查
            if (!CreateCheck())
            {
                return;
            }

            //初始化表
            Creator.InitTableName(cmbTables.Text);

            try
            {
                //生成实体类
                string strEntity= Creator.CreateEntity(txtNameSpace.Text.Trim(), txtEntityName.Text.Trim(), txtFilePath.Text);

                //保存到文件
                EntityCreater.SaveStrToFile(strEntity, txtFilePath.Text);

                //提示
                Msg("生成成功！");
                lb_show.Text = "成功生成一个实体类！";
            }
            catch(Exception ex)
            {
                //提示
                lb_show.ForeColor = Color.Red;
                lb_show.Text = "成功生成实体类失败！";

                Msg("生成失败！"+ex.Message);
            }
        }

        /// <summary>
        /// 选择保存路径
        /// </summary>
        private void btnSelectFilePath_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.cs|*.cs|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = saveFileDialog1.FileName;    
            }
        }

        /// <summary>
        /// 单击实体名称文本框
        /// </summary>
        private void txtNameSpace_Click(object sender, EventArgs e)
        {
            if (txtNameSpace.Text == DefaultNameSpace)
            {
                txtNameSpace.Text = "";
            }
        }

        /// <summary>
        /// 单击实体名称文本框
        /// </summary>
        private void txtEntityName_Click(object sender, EventArgs e)
        {
            if (txtEntityName.Text == DefaultEntityName)
            {
                txtEntityName.Text = "";
            }
        }

        /// <summary>
        /// 数据库类型单选框。
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

        #region 私有方法
        /// <summary>
        /// 点击连接按钮时检查。
        /// </summary>
        /// <returns></returns>
        private bool ConnCheck()
        {
            //填写了自己的连接串，则直接返回true
            if (string.IsNullOrEmpty(txtConStr.Text.Trim()))
            {
                Msg("请输入连接串！");
                txtConStr.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 点击生成时的检查
        /// </summary>
        /// <returns></returns>
        private bool CreateCheck()
        {
            if (cmbTables.SelectedIndex == -1)
            {
                Msg("请选择一个要转换成实体类的表！");
                cmbTables.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNameSpace.Text.Trim()))
            {
                Msg("请填写命名空间名称！");
                txtNameSpace.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEntityName.Text.Trim()))
            {
                Msg("请填写实体类名称！");
                txtEntityName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                Msg("请输入或选择保存实体类文件的路径！");
                txtFilePath.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="message"></param>
        private void Msg(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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