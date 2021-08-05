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
    /// menu2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Menu2 : Page
    {
        public Menu2()
        {
            InitializeComponent();
        }


        private void BtnMenu2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NudAmount2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void BtnMenu2_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void NudAmount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void NudAmount_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {

        }

        private void BtnMenu2_Click_2(object sender, RoutedEventArgs e)
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
