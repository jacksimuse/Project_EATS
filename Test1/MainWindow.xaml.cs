using MahApps.Metro.Controls;
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
using Test1.Model;

namespace Test1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Person person = new Person();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = person;
        }

        private void TxtUserId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(TxtUserId.Text) || string.IsNullOrEmpty(TxtUserPassword.Password))
            {
                MessageBox.Show(this, "아이디/패스워드를 입력하세요! ");
            }

            //sqlconnection 연결

           
        }
    }
}
