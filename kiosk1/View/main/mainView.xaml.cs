
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
using kiosk1.View.Select;
using kiosk1.Model;


using MessageBox = System.Windows.Forms.MessageBox;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace kiosk1.View.main
{
    /// <summary>
    /// mainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Page
    {
        MqttClient client;
        string topic = "EATS/TABLE/";

        public MainView()
        {
            InitializeComponent();
        }

        #region EventHandler

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // 테이블 사용 여부 표시 
            TableInUse();
            // Mqtt 클라이언트 연결 
            MqttConnection();
        }
       
        /// <summary>
        /// MQTT 메시지 수신 이벤트 핸들러
        /// </summary>
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                var message = Encoding.UTF8.GetString(e.Message);
                var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
                if (currentData["MessageType"] == "TableSet")
                {
                    int tblNum = int.Parse(currentData["TableNumber"]);
                    TableSetEmpty(tblNum);
                }
                TableInUse();
            }));
        }

        private void Btnwait_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                Waiting.Wait wait1 = new Waiting.Wait();
                NavigationService.Navigate(wait1);
            }
        }
        private void btnTable1_Click(object sender, RoutedEventArgs e)
        {
            TableSelect(1);
            
        }
        private void btnTable2_Click(object sender, RoutedEventArgs e)
        {
            TableSelect(2);
        }
        private void btnTable3_Click(object sender, RoutedEventArgs e)
            {
            TableSelect(3);
            }
        private void btnTable4_Click(object sender, RoutedEventArgs e)
        {
            TableSelect(4);
        }

        #endregion


        #region CustomMethod

        /// <summary>
        /// DB에 테이블 현재 사용 여부를 갱신
        /// </summary>
        /// <param name="tblNum">테이블 번호</param>
        private void TableSetEmpty(int tblNum)
        {
            using (EATSEntities db = new EATSEntities())
            {
                Ordertbl useTable = db.Ordertbl.Where(o => o.TableInUse && o.TblNum == tblNum).FirstOrDefault();
                if (useTable != null)
                    useTable.TableInUse = false;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 가장 최신 주문을 불러와서 테이블 사용 여부 체크
        /// </summary>
        /// <param name="tblNum">테이블 번호</param>
        /// <returns>주문 번호</returns>
        private int OrderCheck(int tblNum)
        {
            // 1. 테이블이 현재 사용 중인가?
            // 2. 오늘의 첫 주문인가? 
            using (EATSEntities db = new EATSEntities())
            {
                var lastOrder = db.Ordertbl.OrderByDescending(u => u.OrderCode).Take(1).ToList()[0].OrderCode;
                var tableInUse = db.Ordertbl.OrderByDescending(o => o.OrderCode).Where(o => o.TblNum.Equals(tblNum)).Take(1).ToList()[0];
                if (lastOrder.Substring(0, 8) != DateTime.Today.ToString("yyyyMMdd"))
                {
                    return 1;
                }

                else
                {
                    return int.Parse(lastOrder.Substring(8)) + 1;
                }
            }
        }

        /// <summary>
        /// 테이블 선택 시 메뉴 선택 창으로 이동
        /// </summary>
        /// <param name="tblNum">테이블 번호</param>
        private void TableSelect(int tblNum)
        {
            bool flagInUse = false;
            switch (tblNum)
            {
                case 1:
                    flagInUse = btnTable1.Background == Brushes.Gray;
                    break;
                case 2:
                    flagInUse = btnTable2.Background == Brushes.Gray;
                    break;
                case 3:
                    flagInUse = btnTable3.Background == Brushes.Gray;
                    break;
                case 4:
                    flagInUse = btnTable4.Background == Brushes.Gray;
                    break;
            }
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                if (flagInUse)
                {
                    DialogResult dialogResult = MessageBox.Show("추가 주문 하시겠습니까?", "주문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                }
                MenuSelect menuSelect = new MenuSelect(tblNum, OrderCheck(tblNum));
                NavigationService.Navigate(menuSelect);
            }
        }

        /// <summary>
        /// 현재 사용 중인 테이블 목록 갱신, 표시 
        /// </summary>
        private void TableInUse()
        {
            using (EATSEntities db = new EATSEntities())
            {
                // 사용 중인 테이블 목록 
                var useTable = db.Ordertbl.Where(o => o.TableInUse).ToList();

                btnTable1.Background = Brushes.GreenYellow;
                btnTable2.Background = Brushes.GreenYellow;
                btnTable3.Background = Brushes.GreenYellow;
                btnTable4.Background = Brushes.GreenYellow;
                // 사용 중 변경
                foreach (var item in useTable)
                {
                    switch (item.TblNum)
                    {
                        case 1:
                            btnTable1.Background = Brushes.Gray;
                            break;
                        case 2:
                            btnTable2.Background = Brushes.Gray;
                            break;
                        case 3:
                            btnTable3.Background = Brushes.Gray;
                            break;
                        case 4:
                            btnTable4.Background = Brushes.Gray;
                            break;

                    }
                }

                if (useTable.Count == 4)
                {
                    grdOrder.Visibility = Visibility.Hidden;
                }
                else grdOrder.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Mqtt 프로토콜 연결
        /// </summary>
        private void MqttConnection()
        {
            IPAddress brokerAddress = IPAddress.Parse("210.119.12.96");
            client = new MqttClient(brokerAddress);

            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            if (!client.IsConnected)
                client.Connect("Kiosk Main");
            client.Subscribe(new string[] { topic },
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        }

        #endregion

    }
}
