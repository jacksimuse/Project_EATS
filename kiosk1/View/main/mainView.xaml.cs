
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
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

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


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (EATSEntities db = new EATSEntities())
            {
                // 사용 중인 테이블 목록 
                var useTable = db.Ordertbl.Where(o => o.TableInUse).ToList();
                
                // 사용 중 변경
                foreach (var item in useTable)
            {
                    switch (item.TblNum)
                    {
                        case 1:
                            btnTable1.Background = Brushes.Gray;
                            btnTable1.Content = "1";
                            break;
                        case 2:
                            btnTable2.Background = Brushes.Gray;
                            btnTable2.Content = "2";
                            break;
                        case 3:
                            btnTable3.Background = Brushes.Gray;
                            btnTable3.Content = "3";
                            break;
                        case 4:
                            btnTable4.Background = Brushes.Gray;
                            btnTable4.Content = "4";
                            break;

            }
                }
            
                if (useTable.Count == 4)
                {
                    grdOrder.Visibility = Visibility.Hidden;
        }

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
        private void btnTable1_Click(object sender, RoutedEventArgs e)
        {
            TableSelect(1);
            
        }
        private void btnTable2_Click(object sender, RoutedEventArgs e)
            {
            TableSelect(2);
            }
        private void btnTable3_Click(object sender, RoutedEventArgs e)
            {
            TableSelect(3);
            }
        private void btnTable4_Click(object sender, RoutedEventArgs e)
        {
            TableSelect(4);
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

            else
            {
                    return int.Parse(lastOrder.Substring(8)) + 1;
                }
            }
        }

        private void TableSelect(int tblNum)
        {
            bool flagInUse = false;
            switch (tblNum)
        {
                case 1:
                    flagInUse = btnTable1.Background == Brushes.Gray;
                    break;
                case 2:
                    flagInUse = btnTable2.Background == Brushes.Gray;
                    break;
                case 3:
                    flagInUse = btnTable3.Background == Brushes.Gray;
                    break;
                case 4:
                    flagInUse = btnTable4.Background == Brushes.Gray;
                    break;
            }
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

                if (flagInUse)
            {
                    DialogResult dialogResult = MessageBox.Show("추가 주문 하시겠습니까?", "주문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                {
                        return;
                }
                   
                }
                MenuSelect menuSelect = new MenuSelect(tblNum, OrderCheck(tblNum));
                NavigationService.Navigate(menuSelect);
            }
        }
    }
}
