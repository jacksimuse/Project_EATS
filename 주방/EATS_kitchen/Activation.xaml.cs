using EATS_kitchen.Helper;
using EATS_kitchen.Model;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace EATS_kitchen
{
    /// <summary>
    /// Activation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Activation : Page
    {
        private string menuKey = "";
        public Activation()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            menuKey = "R";
            MenuLoad();
        }
        private void Meat_Selected(object sender, RoutedEventArgs e)
        {
            menuKey = "R";
            MenuLoad();
        }
        private void Side_Selected(object sender, RoutedEventArgs e)
        {
            menuKey = "S";
            MenuLoad();
        }
        private void Beverage_Selected(object sender, RoutedEventArgs e)
        {
            menuKey = "B";
            MenuLoad();
        }
        private void lsvMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // TODO  활성 비활성 flag완성하기
            var menus = Commons.GetMenu();
            var selectedMenu = menus.Where(m => m.MenuCode.Equals((lsvMenu.SelectedItem as MenuItems).MenuCode)).FirstOrDefault();

            if (selectedMenu.Activation == true)
            {
                DialogResult dialogResult = MessageBox.Show("메뉴 비활성 하시겠습니까?", "비활성", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var saveActivation = menus.FirstOrDefault(m => m.MenuName == selectedMenu.MenuName);
                saveActivation.Activation = false;
                Commons.SetMenuActive(saveActivation);
                lsvMenu.Items.Clear();

                MenuLoad();
            }
            else if (selectedMenu.Activation == false)
            {
                DialogResult dialogResult = MessageBox.Show("메뉴 활성 하시겠습니까?", "활성", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var saveActivation = menus.FirstOrDefault(m => m.MenuName == selectedMenu.MenuName);
                saveActivation.Activation = true;
                Commons.SetMenuActive(saveActivation);
                lsvMenu.Items.Clear();

                MenuLoad();
            }

            //var saveActivation = menus.FirstOrDefault(m => m.MenuName == selectedMenu.MenuName);
            //saveActivation.Activation = false;
            //Commons.SetMenuActive(saveActivation);
            //lsvMenu.Items.Clear();

            //MenuLoad();

        }


        /// <summary>
        /// 메뉴 목록 출력  
        /// </summary>
        private void MenuLoad()
        {
            
            lsvMenu.Items.Clear();
            using (EATSEntities db = new EATSEntities())
            {
                var menus = db.Menutbl.Where(m => m.MenuCode.Substring(0, 1).Equals(menuKey)).ToList();
                foreach (var item in menus)
                {
                    if (item.Activation)
                    {
                        MenuItems menuItems = new MenuItems()
                        {
                            MenuCode = item.MenuCode,
                            MenuName = item.MenuName,
                            Price = item.Price,
                            ImageSrc = "D:/GitRepository/Project_EATS/kiosk1/Image/" + item.ImageName + ".jpg"
                        };
                        lsvMenu.Items.Add(menuItems);
                    }
                    else if (!item.Activation)
                    {
                        MenuItems menuItems = new MenuItems()
                        {
                            MenuCode = item.MenuCode,
                            ImageSrc = "D:/GitRepository/Project_EATS/주방/EATS_kitchen/image/재료소진.jpg",
                            MenuName = item.MenuName + " 재료소진",
                            Price = 0,
                        };
                        lsvMenu.Items.Add(menuItems);
                    }
                }
            }
            

            
            
        }

        
    }
}
