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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class MainWindow : Window
    {
        private static byte[] result = new byte[1024];
        private int myPort = 888;       //端口号
        public MainWindow()
        {
            Login login = new Login();
            login.ShowDialog();
            if (login.isPass)
            {
               Application.Run(new MainWindow());
            }
            else return;
            InitializeComponent();
            //IPAddress ip = IPAddress.Parse("127.0.0.1");            //将IP地址转化为IPAddress实例
            //Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //clientSocket.Connect(new IPEndPoint(ip, myPort));
            //int receiveLength = clientSocket.Receive(result);
        }
    }
}
