using kiosk1.Model;
using kiosk1.View.select;
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

namespace kiosk1.View.Select
{
    /// <summary>
    /// menu1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Menu1 : Page
    {
        List<MenuItems> menuItems = new List<MenuItems>();

        public Menu1()
        {
            InitializeComponent();

            menuItems.Add(new MenuItems {
                Name = "고기",
                Price = 4000,
                ImageSrc = @"D:\GitRepository\Project_EATS\kiosk1\meat.png"
            });
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMenu1_Click(object sender, RoutedEventArgs e)
        {
            var temp = BtnMenu1Sub.Text.Split('/');
            Txtmenu.Text = temp[0].Trim();
            Txtprice.Text = temp[1].Trim();
            NudAmount.Value = 1;
        }

        private void NudAmount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            var temp = BtnMenu1Sub.Text.Split('/');
            int price = int.Parse(temp[1].Trim().Substring(0, temp[1].IndexOf('원')-1));
            //int amount = int.Parse(NudAmount.Value.ToString());

            Txtprice.Text = ((int)NudAmount.Value * price) + "원";
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                //Pay.payView pay1 = new Pay.payView(Txtmenu.Text.ToString(), int.Parse(NudAmount.Value.ToString()), Txtprice.Text.ToString());
                
                //NavigationService.Navigate(pay1);
            }
        }

        private void BtnMenu2_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                Select.Menu2 menu2 = new Select.Menu2();
                NavigationService.Navigate(menu2);
            }
        }
    }
}

