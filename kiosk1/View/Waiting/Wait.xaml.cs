using kiosk1.Model;
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

namespace kiosk1.View.Waiting
{
    /// <summary>
    /// Wait.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Wait : Page
    {
        // List<Waitnum> waitnums = new List<Waitnum>();

        string phoneNum = "010";

        int numlen;       

        public Wait()
        {
            InitializeComponent();
            TxtNum.Text = phoneNum;
            /*waitnums.Add(new Waitnum
            {
                num = 1
            });*/
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            phoneNum = phoneNum.Substring(0, phoneNum.Length - 1);
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            phoneNum += "1";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            phoneNum += "2";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            phoneNum += "3";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            phoneNum += "4";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            phoneNum += "5";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            phoneNum += "6";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            phoneNum += "7";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            phoneNum += "8";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            phoneNum += "9";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            phoneNum += "0";
            TxtNum.Text = phoneNum;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (phoneNum.Length != 11)
            {
                MessageBox.Show("번호가 맞지않습니다.");
            }
            else
            {
                MessageBox.Show("메세지가 전송되었습니다.");
            }
        }
    }
}
