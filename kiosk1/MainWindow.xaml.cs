using kiosk1.View.main;
using kiosk1.View.select;
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

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {

        }

        private void MetroWindow_Activated(object sender, EventArgs e)
        {

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
