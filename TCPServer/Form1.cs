using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public bool btnstatu = true;  //开始停止服务按钮状态
        public Thread myThread;       //声明一个线程实例
        public Socket newsock;        //声明一个Socket实例
        public Socket server1;
        public Socket Client;
        public delegate void MyInvoke(string str);
        public IPEndPoint localEP;    
        public int localPort;
        public EndPoint remote;
        public Hashtable _sessionTable;
        
        public bool m_Listening;
        //用来设置服务端监听的端口号
        public int setPort            
        {
            get { return localPort; }
            set { localPort = value; }
        }
        
        //用来往richtextbox框中显示消息
        public void showClientMsg(string msg)
        {
            //在线程里以安全方式调用控件
            if (showinfo.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(showClientMsg);
                showinfo.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                showinfo.AppendText(msg);
            }
        }
        public void userListOperate(string msg)
        {
            //在线程里以安全方式调用控件
            if (userList.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(userListOperate);
                userList.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                userList.Items.Add(msg);
            }
        }
        public void userListOperateR(string msg)
        {
            //在线程里以安全方式调用控件
            if (userList.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(userListOperateR);
                userList.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                userList.Items.Remove(msg);
            }
        }
        //监听函数
        public void Listen()
        {   //设置端口
            setPort=int.Parse(serverport.Text.Trim());
            //初始化SOCKET实例
            newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //允许SOCKET被绑定在已使用的地址上。
            newsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //初始化终结点实例
            localEP=new IPEndPoint(IPAddress.Any,setPort);
            try
            {
                _sessionTable = new Hashtable(53);
                //绑定
                newsock.Bind(localEP);
                //监听
                newsock.Listen(10);
               //开始接受连接，异步。
                newsock.BeginAccept(new AsyncCallback(OnConnectRequest), newsock);
             }
            catch (Exception ex)
            {
                showClientMsg(ex.Message);
            }

        }
        //当有客户端连接时的处理
        public void OnConnectRequest(IAsyncResult ar)
        {
           //初始化一个SOCKET，用于其它客户端的连接
            server1 = (Socket)ar.AsyncState;
            Client = server1.EndAccept(ar);
            //将要发送给连接上来的客户端的提示字符串
            DateTimeOffset now = DateTimeOffset.Now;
            string strDateLine = "欢迎登录到服务器";
            Byte[] byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);
            //将提示信息发送给客户端,并在服务端显示连接信息。
            remote = Client.RemoteEndPoint;
            showClientMsg(Client.RemoteEndPoint.ToString() + "连接成功。" + now.ToString("G")+"\r\n");
            Client.Send(byteDateLine, byteDateLine.Length, 0);
            userListOperate(Client.RemoteEndPoint.ToString());
            //把连接成功的客户端的SOCKET实例放入哈希表
            _sessionTable.Add(Client.RemoteEndPoint, null);
            
            //等待新的客户端连接
            server1.BeginAccept(new AsyncCallback(OnConnectRequest), server1);
            
            while (true)
            {
                int recv = Client.Receive(byteDateLine);
                string stringdata = Encoding.UTF8.GetString(byteDateLine, 0, recv);
                string ip = Client.RemoteEndPoint.ToString();
                //获取客户端的IP和端口
                
                if (stringdata == "STOP")
                {
                    //当客户端终止连接时
                    showClientMsg(ip+"   "+now.ToString("G")+"  "+"已从服务器断开"+"\r\n");
                    _sessionTable.Remove(Client.RemoteEndPoint);
                    break; 
                }
                //显示客户端发送过来的信息
                showClientMsg(ip + "  " + now.ToString("G") + "   " + stringdata + "\r\n");             
            }
                       
        }
        //以下实现发送广播消息
        public void SendBroadMsg()
        {
            string strDataLine = sendmsg.Text;
            Byte[] sendData = Encoding.UTF8.GetBytes(strDataLine);
            /*
            IDictionaryEnumerator myEnumerator = _sessionTable.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                EndPoint tempend = (EndPoint)_sessionTable.Values;
                Client.SendTo(sendData, tempend);
            }
             * */
            foreach (DictionaryEntry de in _sessionTable)
            {
                EndPoint temp = (EndPoint)de.Key;
                
                Client.SendTo(sendData, temp);
            }
            sendmsg.Text = "";


        }
      //开始停止服务按钮
        private void startService_Click(object sender, EventArgs e)
        {
            //新建一个委托线程
            ThreadStart myThreadDelegate = new ThreadStart(Listen);
            //实例化新线程
            myThread = new Thread(myThreadDelegate);
             
            if (btnstatu)
            {
               
                myThread.Start();
                statuBar.Text = "服务已启动，等待客户端连接";
                btnstatu = false;
                startService.Text = "停止服务";
            }
            else
            {
                //停止服务（绑定的套接字没有关闭,因此客户端还是可以连接上来）
                myThread.Interrupt();
                myThread.Abort();
                
                //showClientMsg("服务器已停止服务"+"\r\n");
                btnstatu = true;
                startService.Text = "开始服务";
                statuBar.Text = "服务已停止";
                
            }
             
        }
        //窗口关闭时中止线程。
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myThread != null)
            {
                myThread.Abort();
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            SendBroadMsg();
        }

        

       
    }


}
