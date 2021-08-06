using EATS_kitchen.Model;
using kiosk1.View.Select;
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

namespace EATS_kitchen
{
    /// <summary>
    /// Activation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Activation : Page
    {
        bool isClicked = false;

         

        public Activation()
        {
            InitializeComponent();
            ActiveControl.Content = new Menu1();
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            

           // var save = Helper.Commons.SetMenuActive(active);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
