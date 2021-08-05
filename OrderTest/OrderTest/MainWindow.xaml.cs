using MahApps.Metro.Controls;
using OrderTest.Logic;
using OrderTest.model;
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

namespace OrderTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        int customerNum = 0;
        int tableNum = 0;
        int price = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 라벨 지우기 
            lblBeverage.Visibility = lblCustomerNum.Visibility = lblMainMenu.Visibility
                = lblPayment.Visibility = lblSideMenu.Visibility = lblTableNum.Visibility
                = Visibility.Hidden;

            

            // 메뉴 DB 불러오기
            List<Menutbl> menus = DataAccess.GetMenus();

            // 콤보박스에 데이터 채우기 
            foreach (Menutbl item in menus)
            {
                if (item.MenuCode.Substring(0, 1) == "M")
                {
                    cboMainMenu.Items.Add(item.MenuName.ToString());
                }
                else if (item.MenuCode.Substring(0, 1) == "S")
                {
                    cboSideMenu.Items.Add(item.MenuName.ToString());
                }
                else if (item.MenuCode.Substring(0, 1) == "B")
                {
                    cboBeverage.Items.Add(item.MenuName.ToString());
                }
                else MessageBox.Show("error to read DB");
            }

            // 메뉴 수량 0으로 초기화
            numMainMenu.Value = numSideMenu.Value = numBeverage.Value = 0;
        }

#region Event Handler
        private void numMainMenu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            LabelChange();

        }
        private void numSideMenu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            LabelChange();

        }
        private void numBeverage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            LabelChange();

        }

        private void cboMainMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabelChange();
        }
        private void cboSideMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabelChange();
        }
        private void cboBeverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabelChange();
        }

        private void btnCustomer1_Click(object sender, RoutedEventArgs e)
        {
            lblCustomerNum.Visibility = Visibility.Visible;
            customerNum = 1;
            lblCustomerNum.Content = "1명";
        }
        private void btnCustomer2_Click(object sender, RoutedEventArgs e)
        {
            lblCustomerNum.Visibility = Visibility.Visible;
            customerNum = 2;
            lblCustomerNum.Content = "2명";
        }
        private void btnCustomer3_Click(object sender, RoutedEventArgs e)
        {
            lblCustomerNum.Visibility = Visibility.Visible;
            customerNum = 3;
            lblCustomerNum.Content = "3명";
        }
        private void btnCustomer4_Click(object sender, RoutedEventArgs e)
        {
            lblCustomerNum.Visibility = Visibility.Visible;
            customerNum = 4;
            lblCustomerNum.Content = "4명";
        }

        private void btnTable1_Click(object sender, RoutedEventArgs e)
        {
            lblTableNum.Visibility = Visibility.Visible;
            tableNum = 1;
            lblTableNum.Content = "1번 테이블";
        }
        private void btnTable2_Click(object sender, RoutedEventArgs e)
        {
            lblTableNum.Visibility = Visibility.Visible;
            tableNum = 2;
            lblTableNum.Content = "2번 테이블";
        }
        private void btnTable3_Click(object sender, RoutedEventArgs e)
        {
            lblTableNum.Visibility = Visibility.Visible;
            tableNum = 3;
            lblTableNum.Content = "3번 테이블";
        }
        private void btnTable4_Click(object sender, RoutedEventArgs e)
        {
            lblTableNum.Visibility = Visibility.Visible;
            tableNum = 4;
            lblTableNum.Content = "4번 테이블";
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lblCustomerNum.Visibility == Visibility.Hidden)
            {
                MessageBox.Show("인원 수를 선택하세요.");
                return;
            }
            if (lblTableNum.Visibility == Visibility.Hidden)
            {
                MessageBox.Show("테이블을 선택하세요.");
                return;
            }
            SaveDB();
        }


#endregion

#region Custom Method
        /// <summary>
        /// 메뉴 표시 수정
        /// </summary>
        private void LabelChange()
        {
            // 메뉴 이름 공백 or 메뉴 수량 0 이면 표시 라벨 숨기기 
            if (cboMainMenu.SelectedIndex < 0 || numMainMenu.Value == 0)
                lblMainMenu.Visibility = Visibility.Hidden;
            else
            {
                string str = cboMainMenu.SelectedValue.ToString() + " " + numMainMenu.Value.ToString() + "인분";
                lblMainMenu.Visibility = Visibility.Visible;
                lblMainMenu.Content = str;
            }

            if (cboSideMenu.SelectedIndex < 0 || numSideMenu.Value == 0)
                lblSideMenu.Visibility = Visibility.Hidden;
            else
            {
                string str = cboSideMenu.SelectedValue.ToString() + " " + numSideMenu.Value.ToString() + "개";
                lblSideMenu.Visibility = Visibility.Visible;
                lblSideMenu.Content = str;
            }

            if (cboBeverage.SelectedIndex < 0 || numBeverage.Value == 0)
                lblBeverage.Visibility = Visibility.Hidden;
            else
            {
                string str = cboBeverage.SelectedValue.ToString() + " " + numBeverage.Value.ToString() + "잔";
                lblBeverage.Visibility = Visibility.Visible;
                lblBeverage.Content = str;
            }
            TotalPay();
        }

        /// <summary>
        /// 선택한 메뉴의 가격 계산
        /// </summary>
        private void TotalPay()
        {
            price = 0;
            List<Menutbl> menus = DataAccess.GetMenus();


            if (cboMainMenu.SelectedIndex < 0 || numMainMenu.Value == 0)
                price += 0;
            else
            {
                int mainMenu = (from item in menus
                                where item.MenuName.Equals(cboMainMenu.SelectedValue.ToString())
                                select item.Price).FirstOrDefault();
                price += mainMenu * (int)numMainMenu.Value;
            }

            if (cboSideMenu.SelectedIndex < 0 || numSideMenu.Value == 0)
                price += 0;
            else
            {
                int sideMenu = (from item in menus
                                where item.MenuName.Equals(cboSideMenu.SelectedValue.ToString())
                                select item.Price).FirstOrDefault();
                price += sideMenu * (int)numSideMenu.Value;
            }

            if (cboBeverage.SelectedIndex < 0 || numBeverage.Value == 0)
                price += 0;
            else
            {
                int beverage = (from item in menus
                                where item.MenuName.Equals(cboBeverage.SelectedValue.ToString())
                                select item.Price).FirstOrDefault();
                price += beverage * (int)numBeverage.Value;
            }


            lblTotalPay.Content = price.ToString() + " 원";
        }

        /// <summary>
        /// 주문을 DB에 저장 
        /// </summary>
        private void SaveDB()
        {
            using (EATSEntities db = new EATSEntities())
            {
                // DB에 저장된 가장 최신 주문
                var lastOrder = db.Ordertbl.OrderByDescending(u => u.OrderCode).Take(1).ToList()[0].OrderCode;

                // 새로운 주문번호 생성 
                int num = int.Parse(lastOrder.Substring(8)) + 1;
                string orderCode = DateTime.Today.ToString("yyyyMMdd") + num.ToString("D3");

                // 주문 객체 생성 
                var order = new Ordertbl()
                {
                    OrderCode = orderCode,
                    OrderTime = DateTime.Now,
                    CustomerNum = customerNum,
                    TblNum = tableNum,
                    OrderPrice = price,
                    OrderRemark = null
                };

                // DB에 주문 추가 
                db.Ordertbl.Add(order);
                if (numMainMenu.Value > 0 && cboMainMenu.SelectedIndex > -1)
                {
                    OrderDetailtbl orderDetail = new OrderDetailtbl()
                    {
                        OrderCode = orderCode,
                        MenuCode = DataAccess.GetMenus().FirstOrDefault(m => m.MenuName.Equals(cboMainMenu.SelectedValue.ToString())).MenuCode,
                        Amount = (int)numMainMenu.Value
                    };
                    db.OrderDetailtbl.Add(orderDetail);
                }
                if (numSideMenu.Value > 0 && cboSideMenu.SelectedIndex > -1)
                {
                    OrderDetailtbl orderDetail = new OrderDetailtbl()
                    {
                        OrderCode = orderCode,
                        MenuCode = DataAccess.GetMenus().FirstOrDefault(m => m.MenuName.Equals(cboSideMenu.SelectedValue.ToString())).MenuCode,
                        Amount = (int)numSideMenu.Value
                    };
                    db.OrderDetailtbl.Add(orderDetail);
                }
                if (numBeverage.Value > 0 && cboBeverage.SelectedIndex > -1)
                {
                    OrderDetailtbl orderDetail = new OrderDetailtbl()
                    {
                        OrderCode = orderCode,
                        MenuCode = DataAccess.GetMenus().FirstOrDefault(m => m.MenuName.Equals(cboBeverage.SelectedValue.ToString())).MenuCode,
                        Amount = (int)numBeverage.Value
                    };
                    db.OrderDetailtbl.Add(orderDetail);
                }

                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("DB 저장 성공!");
                }
                else MessageBox.Show("DB 저장 실패!");

            }
        }

#endregion


    }
}
