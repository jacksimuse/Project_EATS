
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
using kiosk1.View.Select;
using kiosk1.Model;

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
        }

        private void tableone_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                MenuSelect menu1 = new MenuSelect(1, OrderCheck(1));
                NavigationService.Navigate(menu1);
            }
            
        }

        

        private void tabletwo_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                MenuSelect menu2 = new MenuSelect(2, OrderCheck(2));
                NavigationService.Navigate(menu2);
            }
        }
        private void tablethree_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                MenuSelect menu3 = new MenuSelect(3, OrderCheck(3));
                NavigationService.Navigate(menu3);
            }
        }
        private void tablefour_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                MenuSelect menu4 = new MenuSelect(4, OrderCheck(4));
                NavigationService.Navigate(menu4);
            }
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

        private int OrderCheck(int tblNum)
        {
            // 1. 테이블이 현재 사용 중인가?
            // 2. 오늘의 첫 주문인가? 
            using (EATSEntities db = new EATSEntities())
            {
                var lastOrder = db.Ordertbl.OrderByDescending(u => u.OrderCode).Take(1).ToList()[0].OrderCode;
                var tableInUse = db.Ordertbl.OrderByDescending(o => o.OrderCode).Where(o => o.TblNum.Equals(tblNum)).Take(1).ToList()[0];
                if (lastOrder.Substring(0, 8) != DateTime.Today.ToString("yyyyMMdd"))
                {
                    return 1;
                }

                else if (!tableInUse.OrderComplete)
        {
                    return int.Parse(tableInUse.OrderCode.Substring(8));
                }

                else
                {
                    return int.Parse(lastOrder.Substring(8)) + 1;
                }
            }
        }
    }
}
