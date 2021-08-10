using kiosk1.View.main;

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
using System.Windows.Forms;

namespace kiosk1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
 

        public MainWindow()
        {
            InitializeComponent();
        }

       

       

        private void Btnmain_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new MainView();

            }
            catch (Exception)
            {

                throw;
            }




        }

        private void Btnselect_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
