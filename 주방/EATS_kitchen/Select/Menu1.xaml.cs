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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EATS_kitchen.Helper;
using EATS_kitchen.Model;

namespace kiosk1.View.Select
{
    /// <summary>
    /// menu1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Menu1 : Page
    {
        List<MenuItems> menuItems = new List<MenuItems>();

        bool isClicked = false;

        List<Menutbl> menuName = Commons.GetMenu();

        static string temp;
        public Menu1()
        {
            InitializeComponent();


            //if (menuName[i].Activation == true)
            //{
            //    BtnMenu1.Background = Brushes.White;
            //    BtnMenu1Sub.Text = "삼겹살 / 4000원";
            //    isClicked = false;
            //}
            //else
            //{
            //    BtnMenu1.Background = Brushes.Gray;
            //    BtnMenu1Sub.Text = "재료 소진";
            //    isClicked = true;
            //}
            
        }


        private void BtnMenu1_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            
            if (isClicked)
            {
                while (true)
                {
                    if (menuName[i].MenuName == temp)
                    {
                        menuName[i].Activation = true;
                        var result = Commons.SetMenuActive(menuName[i]);
                        break;
                    }
                    i++;
                }
                //BtnMenu1.Background = Brushes.White;
                //BtnMenu1Sub.Text = "삼겹살 / 4000원";
                isClicked = false;
            }
            else
            {
                
                //while (true)
                //{
                //    if (menuName[i].MenuName == BtnMenu1Sub.Text)
                //    {
                //        menuName[i].Activation = false;
                //        var result = Commons.SetMenuActive(menuName[i]);
                //        break;
                //    }
                //    i++;
                //}
                //BtnMenu1.Background = Brushes.Gray;
                //BtnMenu1Sub.Text = "재료 소진";
                //isClicked = true;
            }
            
        }

        private void NudAmount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
           // var temp = BtnMenu1Sub.Text.Split('/');
            //int price = int.Parse(temp[1].Trim().Substring(0, temp[1].IndexOf('원')-1));
            //int amount = int.Parse(NudAmount.Value.ToString());

            //Txtprice.Text = ((int)NudAmount.Value * price) + "원";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            

        }


        private void LbiMain_Selected(object sender, RoutedEventArgs e)
        {
            isValidCheck();
        }

        private void LbiSide_Selected(object sender, RoutedEventArgs e)
        {
            isValidCheck();
        }

        private void LbiBeverage_Selected(object sender, RoutedEventArgs e)
        {
            isValidCheck();
        }

        private void isValidCheck()
        {
            
            
        }
    }
}

