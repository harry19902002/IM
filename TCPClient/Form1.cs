using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Socket newclient;
        public bool Connected;
        public Thread myThread;
        public delegate void MyInvoke(string str);
        public Form1()
        {
            InitializeComponent();
            
        }
        public void Connect()
        {
            byte[] data = new byte[1024];
            newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string ipadd = serverIP.Text.Trim();
            int port = Convert.ToInt32(serverPort.Text.Trim());
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);
            try
            {
                newclient.Connect(ie);
                connect.Enabled = false;
                Connected = true;
               
            }
            catch(SocketException e)
            {
                MessageBox.Show("连接服务器失败  "+e.Message);
                return;
            }
            ThreadStart myThreaddelegate = new ThreadStart(ReceiveMsg);
            myThread = new Thread(myThreaddelegate);
            myThread.Start();

        }
        public void ReceiveMsg()
        {
            while (true)
            {
                byte[] data = new byte[1024];
                int recv = newclient.Receive(data);
                string stringdata = Encoding.UTF8.GetString(data, 0, recv);
                showMsg(stringdata + "\r\n");
                //receiveMsg.AppendText(stringdata + "\r\n");
            }
        }
        public void showMsg(string msg)
        {
            {
            //在线程里以安全方式调用控件
            if (receiveMsg.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(showMsg);
                receiveMsg.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                receiveMsg.AppendText(msg);
            }
        }
        }
       

        private void SendMsg_Click(object sender, EventArgs e)
        {
            int m_length = mymessage.Text.Length;
            byte[] data=new byte[m_length];
            data = Encoding.UTF8.GetBytes(mymessage.Text);
            int i = newclient.Send(data);
            showMsg("我说：" + mymessage.Text + "\r\n");
            //receiveMsg.AppendText("我说："+mymessage.Text + "\r\n");
            mymessage.Text = "";
            //newclient.Shutdown(SocketShutdown.Both);
        }

        private void connect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        
    }
}
