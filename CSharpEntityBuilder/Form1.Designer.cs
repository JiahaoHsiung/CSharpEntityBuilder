namespace CSharpEntityBuilder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.rbMySQL = new System.Windows.Forms.RadioButton();
            this.txtConStr = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnCreateEntityFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFilePath = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_show = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型：";
            // 
            // rbMySQL
            // 
            this.rbMySQL.AutoSize = true;
            this.rbMySQL.Checked = true;
            this.rbMySQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbMySQL.Location = new System.Drawing.Point(118, 18);
            this.rbMySQL.Name = "rbMySQL";
            this.rbMySQL.Size = new System.Drawing.Size(52, 16);
            this.rbMySQL.TabIndex = 1;
            this.rbMySQL.TabStop = true;
            this.rbMySQL.Text = "MySQL";
            this.rbMySQL.UseVisualStyleBackColor = true;
            this.rbMySQL.CheckedChanged += new System.EventHandler(this.rbSQLType_CheckedChanged);
            // 
            // txtConStr
            // 
            this.txtConStr.BackColor = System.Drawing.SystemColors.Window;
            this.txtConStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConStr.Location = new System.Drawing.Point(23, 48);
            this.txtConStr.Multiline = true;
            this.txtConStr.Name = "txtConStr";
            this.txtConStr.Size = new System.Drawing.Size(503, 65);
            this.txtConStr.TabIndex = 0;
            this.txtConStr.Text = "Database=brhein_iot;Data Source=47.94.212.174;User Id=brhein;Password=brhein123";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(523, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(54, 65);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "连 接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "选择表：";
            // 
            // cmbTables
            // 
            this.cmbTables.ForeColor = System.Drawing.Color.Black;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(106, 131);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(179, 20);
            this.cmbTables.TabIndex = 15;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // btnCreateEntityFile
            // 
            this.btnCreateEntityFile.Location = new System.Drawing.Point(23, 238);
            this.btnCreateEntityFile.Name = "btnCreateEntityFile";
            this.btnCreateEntityFile.Size = new System.Drawing.Size(126, 36);
            this.btnCreateEntityFile.TabIndex = 50;
            this.btnCreateEntityFile.Text = "生成实体类文件";
            this.btnCreateEntityFile.UseVisualStyleBackColor = true;
            this.btnCreateEntityFile.Click += new System.EventHandler(this.btnCreateEntityFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "文件存放路径：";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Location = new System.Drawing.Point(106, 202);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(409, 21);
            this.txtFilePath.TabIndex = 19;
            // 
            // btnSelectFilePath
            // 
            this.btnSelectFilePath.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSelectFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFilePath.Location = new System.Drawing.Point(512, 202);
            this.btnSelectFilePath.Name = "btnSelectFilePath";
            this.btnSelectFilePath.Size = new System.Drawing.Size(25, 21);
            this.btnSelectFilePath.TabIndex = 20;
            this.btnSelectFilePath.Text = "…";
            this.btnSelectFilePath.UseVisualStyleBackColor = false;
            this.btnSelectFilePath.Click += new System.EventHandler(this.btnSelectFilePath_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "命名空间：";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtNameSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameSpace.Location = new System.Drawing.Point(350, 166);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(187, 21);
            this.txtNameSpace.TabIndex = 18;
            this.txtNameSpace.Click += new System.EventHandler(this.txtNameSpace_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "实体类名：";
            // 
            // txtEntityName
            // 
            this.txtEntityName.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtEntityName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntityName.Location = new System.Drawing.Point(106, 166);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(177, 21);
            this.txtEntityName.TabIndex = 16;
            this.txtEntityName.Click += new System.EventHandler(this.txtEntityName_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_show});
            this.statusStrip1.Location = new System.Drawing.Point(0, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 52;
            // 
            // lb_show
            // 
            this.lb_show.Font = new System.Drawing.Font("宋体", 11F);
            this.lb_show.ForeColor = System.Drawing.Color.OliveDrab;
            this.lb_show.Name = "lb_show";
            this.lb_show.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 315);
            this.Controls.Add(this.txtConStr);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.btnSelectFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCreateEntityFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.rbMySQL);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "C#实体类生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbMySQL;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnCreateEntityFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFilePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEntityName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lb_show;

    }
}

