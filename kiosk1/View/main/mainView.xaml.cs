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
using System.Windows.Forms;
using System.Reflection;
using Application = System.Windows.Application;

namespace kiosk1.View.main
{
    /// <summary>
    /// mainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Page
    {

        public MainView()
        {
            InitializeComponent();

            Logic.btncontrol btc = new Logic.btncontrol();
            btc.BtnControl("Btnmain");
        }
       
        private void tableone_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoForward)
            {
                
                NavigationService.GoForward();
            }
            else
            {
                Select.Menu1 menu1 = new Select.Menu1();
                NavigationService.Navigate(menu1);
            }
            
        }

        private void tabletwo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tablethree_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tablefour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnwait_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                Waiting.Wait wait1 = new Waiting.Wait();
                NavigationService.Navigate(wait1);
            }
        }
    }
}
