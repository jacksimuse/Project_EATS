using kiosk1.Model;
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
        private Tables table = new Tables();
        public MenuSelect()
        {
            InitializeComponent();
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
            var menus = Logic.DataAccess.GetMenu().Where(m => m.MenuCode.Substring(0,1).Equals(menuKey)).ToList();
            lsvMenu.ItemsSource = menus;
            // this.DataContext = menus;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MenuLoad("M");
        }

        private void lsvMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Menutbl menu = lsvMenu.SelectedItem as Menutbl;
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

        private void AddSelectedMenu(Menutbl menu)
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
    }
}
