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

namespace kiosk1.View.Pay
{
    /// <summary>
    /// payView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class payView : Page
    {
        public payView(string menu, int amount,  string price)
        {
            InitializeComponent();
            Txtmenu.Text = menu;
            Txtamount.Text = amount.ToString();
            Txtprice.Text = price;

        }

        private void Btncancel_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                Select.Menu1 menu1 = new Select.Menu1();
                NavigationService.Navigate(menu1);
            }
        }
    }
}
