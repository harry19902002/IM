using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool serverState=false;
        private static byte[] result = new byte[1024];
        private int myPort = 888;       //端口号
        static Socket serverSocket;
        static Thread myThread;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StartServer()
        {
            //服务器参数设置
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myPort));
            serverSocket.Listen(10);
            Display.AppendText("开启监听成功");
            //通过Clientsocket发送数据
            myThread = new Thread(ListenClientConnect);
            myThread.Start();
        }
        private void ControlBtn_Click(object sender, RoutedEventArgs e)
        {
            if(serverState)
            {
                serverState = false;
                ControlBtn.Content = "开启服务";
                //serverSocket.Close();
                myThread.Abort();
                
            }
            else
            {
                serverState = true;
                ControlBtn.Content = "停止服务";
                StartServer();
            }
        }
        private void ListenClientConnect()
        {
            while(true)
            {
                Socket clientSocket = serverSocket.Accept();
                clientSocket.Send(Encoding.ASCII.GetBytes("Servy Say Hello"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }
        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while(true)
            {
                int receiveNumber = myClientSocket.Receive(result);
                Display.AppendText(Encoding.ASCII.GetString(result, 0, receiveNumber));
            }
        }
    }
}
