namespace TCPServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.serverport = new System.Windows.Forms.TextBox();
            this.showinfo = new System.Windows.Forms.RichTextBox();
            this.startService = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.send = new System.Windows.Forms.Button();
            this.sendmsg = new System.Windows.Forms.TextBox();
            this.userList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号：";
            // 
            // serverport
            // 
            this.serverport.Location = new System.Drawing.Point(359, 17);
            this.serverport.Name = "serverport";
            this.serverport.Size = new System.Drawing.Size(65, 21);
            this.serverport.TabIndex = 1;
            this.serverport.Text = "888";
            // 
            // showinfo
            // 
            this.showinfo.Location = new System.Drawing.Point(20, 58);
            this.showinfo.Name = "showinfo";
            this.showinfo.Size = new System.Drawing.Size(406, 254);
            this.showinfo.TabIndex = 2;
            this.showinfo.Text = "";
            // 
            // startService
            // 
            this.startService.Location = new System.Drawing.Point(29, 14);
            this.startService.Name = "startService";
            this.startService.Size = new System.Drawing.Size(99, 23);
            this.startService.TabIndex = 3;
            this.startService.Text = "开始服务";
            this.startService.UseVisualStyleBackColor = true;
            this.startService.Click += new System.EventHandler(this.startService_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(630, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuBar
            // 
            this.statuBar.Name = "statuBar";
            this.statuBar.Size = new System.Drawing.Size(68, 17);
            this.statuBar.Text = "未启动服务";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(240, 365);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(87, 25);
            this.send.TabIndex = 5;
            this.send.Text = "发送广播消息";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // sendmsg
            // 
            this.sendmsg.Location = new System.Drawing.Point(20, 368);
            this.sendmsg.Name = "sendmsg";
            this.sendmsg.Size = new System.Drawing.Size(175, 21);
            this.sendmsg.TabIndex = 6;
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.ItemHeight = 12;
            this.userList.Location = new System.Drawing.Point(476, 59);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(123, 244);
            this.userList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "用户列表";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 464);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.sendmsg);
            this.Controls.Add(this.send);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startService);
            this.Controls.Add(this.showinfo);
            this.Controls.Add(this.serverport);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverport;
        private System.Windows.Forms.RichTextBox showinfo;
        private System.Windows.Forms.Button startService;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statuBar;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox sendmsg;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Label label2;
    }
}

