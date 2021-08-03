using EntityFrameworkTest.Model;
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
using System.Windows.Shapes;

namespace EntityFrameworkTest.View
{
    /// <summary>
    /// Window.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window : Window
    {
        public Window()
        {
            InitializeComponent();

            LoadingDataGrid();
        }

        private void LoadingDataGrid()
        {
            /*메뉴*/
            List<Menutbl> menutbls;

            using (var ctx = new EATSEntities())
                menutbls = ctx.Menutbl.ToList();

            GrdMenu.DataContext = menutbls;

            /*주문*/
            List<Ordertbl> ordertbls;

            using (var ctx = new EATSEntities())
                ordertbls = ctx.Ordertbl.ToList();

            GrdOrder.DataContext = ordertbls;

            /*주문상세*/
            List<OrderDetailtbl> detailtbls;

            using (var ctx = new EATSEntities())
                detailtbls = ctx.OrderDetailtbl.ToList();

            GrdOrderDetail.DataContext = detailtbls;

            /*사용자*/
            List<Usertbl> usertbls;

            using (var ctx = new EATSEntities())
                usertbls = ctx.Usertbl.ToList();

            GrdUser.DataContext = usertbls;
        }
    }
}
