using kiosk1.Logic;
using kiosk1.Model;
using kiosk1.View.main;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using uPLibrary.Networking.M2Mqtt;

namespace kiosk1.View.Pay
{
    /// <summary>
    /// payView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class payView : Page
    {
        public int TableNum { get; set; }
        private List<MenuItems> menuList;
        public int OrderNum { get; set; }

        MqttClient client;
        int totalPrice = 0;
        readonly IPAddress brokerAddress = IPAddress.Parse("210.119.12.96");

        public payView(int tableNum, List<MenuItems> menus, int orderNum)
        {
            InitializeComponent();
            TableNum = tableNum;
            menuList = menus;
            OrderNum = orderNum;    
        }

        #region EventHandler

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvOrder.ItemsSource = menuList;
            MqttConnection();
            PayMoneyCalc();
        }
        private void btnPayMoney_Click(object sender, RoutedEventArgs e)
        {
            // mqtt 메시지 전송, DB 저장, 메인화면으로 
            // 1. 오더코드 생성 
            string orderCode = DateTime.Today.ToString("yyyyMMdd") + OrderNum.ToString("D3");

            // 2. DB에 주문 내역 추가 
            SaveOrderToDB(orderCode);

            // 3. MQTT 메시지 전송 
            MessagePublish(orderCode);

            // 메인화면으로 
            ReturnToMain();
        }
        private void Btncancel_Click(object sender, RoutedEventArgs e)
        {
            ReturnToMain();
            
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            client.Disconnect();
        }

        #endregion





        #region CustomMethod

        /// <summary>
        /// 메인 화면으로 
        /// </summary>
        private void ReturnToMain()
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                MainView main = new MainView();
                NavigationService.Navigate(main);
            }
        }

        /// <summary>
        /// 메뉴 총 가격 계산
        /// </summary>
        private void PayMoneyCalc()
        {
            foreach (var item in menuList)
            {
                totalPrice += item.Price * item.Amount;
            }

            lblPayMoney.Content = "결제 금액 : " + totalPrice.ToString("N0") + "원";
        }

        /// <summary>
        /// Mqtt 프로토콜 연결
        /// </summary>
        private void MqttConnection()
        {
            try
            {
                client = new MqttClient(brokerAddress);
                if (!client.IsConnected)
                    client.Connect("Kiosk");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Mqtt 메시지 전송
        /// </summary>
        /// <param name="orderCode">고유 주문 번호</param>
        private void MessagePublish(string orderCode)
        {
            try
            {
                JObject orderJson = new JObject()
                {
                    new JProperty("MessageType", "Order"),
                    new JProperty("OrderCode", orderCode),
                    new JProperty("TableNum", TableNum),
                    new JProperty("OrderTime", DateTime.Now.ToString())
                };

                var message = Encoding.UTF8.GetBytes(orderJson.ToString());
                string topic = "EATS/TABLE/";
                
                client.Publish(topic, message, 1, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// DB에 주문 내역 저장
        /// </summary>
        /// <param name="orderCode">고유 주문 번호</param>
        private void SaveOrderToDB(string orderCode)
        {
            using (EATSEntities db = new EATSEntities())
            {
                var menus = DataAccess.GetMenu();
                if (db.Ordertbl.Count(o => o.OrderCode.Equals(orderCode)) == 0)
                {
                var order = new Ordertbl()
                {
                    OrderCode = orderCode,
                    OrderTime = DateTime.Now,
                    TblNum = TableNum,
                    OrderPrice = totalPrice, // TODO : 계산식 추가
                    TableInUse = true,
                    OrderRemark = null // TODO : 주문 특이사항 이후 추가 
                };

                db.Ordertbl.Add(order);
                }

                foreach (var item in menuList)
                {
                    var orderDetail = new OrderDetailtbl()
                    {
                        OrderCode = orderCode,
                        MenuCode = menus.FirstOrDefault(m => m.MenuName.Equals(item.MenuName)).MenuCode,
                        Amount = item.Amount,
                        OrderComplete = false
                    };
                    db.OrderDetailtbl.Add(orderDetail);
                }

                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("주문 완료", "Complete");
                }
                else MessageBox.Show("주문 실패, 관리자에게 문의!", "Fail");
            }
        }

        #endregion



    }
}
