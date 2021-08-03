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

namespace DataInsert
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new Model.Ordertbl();

            order.OrderCode = TxtOrderCode.Text;
            order.OrderTime = DateTime.Now;
            order.CustomerNum = TxtCustomerNum.Text;
            order.TblNum = int.Parse(TxtTblNum.Text);


        }
    }
}
