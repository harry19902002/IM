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
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static byte[] result = new byte[1024];
        private char[] username;
        private char[] password;
        private int myPort = 888;       //端口号
        public MainWindow()
        {
            InitializeComponent();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(ip, myPort));
            int receiveLength = clientSocket.Receive(result);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordInput.MaxLength = 14;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            bool isPass = false;

            isPass = this.checkPassword();

            if (isPass)
            {
                MessageBox.Show("登陆成功！");
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }
        private bool checkPassword()
        {
            String username = this.UsernameInput.Text;
            String password = this.PasswordInput.Password;

            if (username == "name" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
