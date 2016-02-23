namespace TCPClient
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
            if (Connected)
            {
                byte[] data=new byte[4];
                data = System.Text.Encoding.Default.GetBytes("STOP");
                int i = newclient.Send(data);
                newclient.Close();
            }
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
            this.serverIP = new System.Windows.Forms.TextBox();
            this.serverPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.receiveMsg = new System.Windows.Forms.RichTextBox();
            this.mymessage = new System.Windows.Forms.TextBox();
            this.SendMsg = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP：";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(113, 12);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(96, 21);
            this.serverIP.TabIndex = 1;
            this.serverIP.Text = "127.0.0.1";
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(286, 12);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(60, 21);
            this.serverPort.TabIndex = 3;
            this.serverPort.Text = "888";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口：";
            // 
            // receiveMsg
            // 
            this.receiveMsg.Location = new System.Drawing.Point(53, 92);
            this.receiveMsg.Name = "receiveMsg";
            this.receiveMsg.Size = new System.Drawing.Size(292, 138);
            this.receiveMsg.TabIndex = 4;
            this.receiveMsg.Text = "";
            // 
            // mymessage
            // 
            this.mymessage.Location = new System.Drawing.Point(53, 306);
            this.mymessage.Name = "mymessage";
            this.mymessage.Size = new System.Drawing.Size(293, 21);
            this.mymessage.TabIndex = 5;
            // 
            // SendMsg
            // 
            this.SendMsg.Location = new System.Drawing.Point(367, 306);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(47, 20);
            this.SendMsg.TabIndex = 6;
            this.SendMsg.Text = "发送";
            this.SendMsg.UseVisualStyleBackColor = true;
            this.SendMsg.Click += new System.EventHandler(this.SendMsg_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(411, 11);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(70, 22);
            this.connect.TabIndex = 7;
            this.connect.Text = "连接服务器";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 400);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.mymessage);
            this.Controls.Add(this.receiveMsg);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.TextBox serverPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox receiveMsg;
        private System.Windows.Forms.TextBox mymessage;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.Button connect;
    }
}

