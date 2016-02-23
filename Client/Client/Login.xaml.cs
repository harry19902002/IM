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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for Loggin.xaml
    /// </summary>
    public partial class Login : Window
    {
        public bool isPass;
        public Login()
        {
            InitializeComponent();
            PasswordInput.MaxLength = 14;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            isPass = false;

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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
        //<summary>
        //验证用户名以及密码
        //</summary>
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
