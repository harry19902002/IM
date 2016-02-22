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

namespace code
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[] username;
        private char[] password;
        public MainWindow()
        {
            InitializeComponent();
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
