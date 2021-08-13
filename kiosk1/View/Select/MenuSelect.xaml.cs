
using kiosk1.Model;
using kiosk1.View.main;
using kiosk1.View.Pay;
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

namespace kiosk1.View.Select
{
    /// <summary>
    /// MenuSelect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuSelect : Page
    {
        private int tableNum = 0;
        private int orderCode = 0;
        private Tables table = new Tables();
        
        public MenuSelect(int tblNum, int orderNum)
        {
            InitializeComponent();
            tableNum = tblNum;
            orderCode = orderNum;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MenuLoad("R");
        }
        private void Meat_Selected(object sender, RoutedEventArgs e)
        {
            MenuLoad("R");
        }

        private void Side_Selected(object sender, RoutedEventArgs e)
        {
            MenuLoad("S");
        }

        private void Beverage_Selected(object sender, RoutedEventArgs e)
        {
            MenuLoad("B");
        }

        private void MenuLoad(string menuKey)
        {
            lsvMenu.Items.Clear();
            var menus = Logic.DataAccess.GetMenu().Where(m => m.MenuCode.Substring(0,1).Equals(menuKey)).ToList();
            foreach (var item in menus)
            {
                MenuItems menuItems = new MenuItems()
                {
                    MenuName = item.MenuName,
                    Price = item.Price,
                    ImageSrc = "D:/GitRepository/Project_EATS/kiosk1/Image/" + item.ImageName + ".jpg"
                };
                lsvMenu.Items.Add(menuItems);
            }
        }

        

        private void lsvMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuItems menu = lsvMenu.SelectedItem as MenuItems;
            //List<Menutbl> menu = new List<Menutbl>(); 
            //menu = Logic.DataAccess.GetMenu();
            AddSelectedMenu(menu);
            SetLsvOrderItem();

        }

        /// <summary>
        /// 주문 리스트 갱신
        /// </summary>
        private void SetLsvOrderItem()
        {
            lsvOrder.ItemsSource = null;
            // TODO : 총 가격 계산 
            lsvOrder.ItemsSource = table.MenuList;
        }

        private void AddSelectedMenu(MenuItems menu)
        {
            var menuName = menu.MenuName;
            var price = menu.Price;

            if (table.MenuList.Exists(x => x.MenuName == menuName))
            {
                table.MenuList.Find(x => x.MenuName == menuName).Amount++;
            }
            else
            {
                var newMenu = new MenuItems()
                {
                    MenuName = menuName,
                    Amount = 1,
                    Price = price
                };

                table.MenuList.Add(newMenu);
            }
        }

        private void lsvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show("선택");
            var nudSelection = new NumericUpDown();
            nudSelection.Value = 1;
            nudSelection.Minimum = 0;
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            // 처음 화면으로 
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                MainView mainView = new MainView();
                NavigationService.Navigate(mainView);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MenuItems menuitem = lsvOrder.SelectedItem as MenuItems;
                int index = table.MenuList.FindIndex(x => x.MenuName == menuitem.MenuName);
                table.MenuList.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("음식을 선택하세요.", "오류");
                
            }
            finally
            {
                SetLsvOrderItem();
            }
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                if (table.MenuList.Count == 0)
                {
                    MessageBox.Show("메뉴를 선택해주세요");
                    return;
                }
                payView pay = new payView(tableNum, table.MenuList, orderCode);
                NavigationService.Navigate(pay);
            }
        }
    }
}
