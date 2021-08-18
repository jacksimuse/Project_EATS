using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Windows.Threading;
using System.Linq;
using EATS_kitchen.Model;
using kiosk1.Model;
using Newtonsoft.Json.Linq;

namespace EATS_kitchen
{
    /// <summary>
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Order : Page
    {
        MqttClient client;
        
        delegate void UpdateTextCallback(string message);
        List<MenuInfo> menuTable1 = new List<MenuInfo>();
        List<MenuInfo> menuTable2 = new List<MenuInfo>();
        List<MenuInfo> menuTable3 = new List<MenuInfo>();
        List<MenuInfo> menuTable4 = new List<MenuInfo>();

        string message = ""; // 자동차에게 보내는 메시지 


        string topic = "EATS/TABLE/";
        BackgroundWorker _worker = null;

        bool isClicked = false;
        bool isUsing = false;

        public Order()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MqttConnection();
            UpdateOrder();
        }

        

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            
            var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
            if (currentData["MessageType"] == "Order")
            {
                string orderCode = currentData["OrderCode"];
                int tblNum = int.Parse(currentData["TableNum"]);

                
                UpdateOrder();
            }
            // var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message); // 데이터를 받을때 역 직렬화(DeserializeObject) <-> 보낼땐 직렬화(SerializeObject)
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            client.Disconnect();
        }
        private void Btntbl1_Click(object sender, RoutedEventArgs e)
        {
            if (!lsvTable1.HasItems)
            {
                return;
            }
            if (MessageBox.Show("1번 테이블 서빙하시겠습니까?", "서빙", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Progressing();
                DrivingCheck();

                OrderDetailDBUpdate(1);
                Lbltbl1.Content = "";
                lsvTable1.ItemsSource = new List<MenuItems>();

                // 자동차에 보내는 메시지
                PublishMessageToCar(1);
            }
        }
        private void Btntbl2_Click(object sender, RoutedEventArgs e)
        {
            if (!lsvTable2.HasItems)
            {
                return;
            }
            if (MessageBox.Show("2번 테이블 서빙하시겠습니까?", "서빙", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Progressing();
                DrivingCheck();
                OrderDetailDBUpdate(2);
                Lbltbl2.Content = "";
                lsvTable2.ItemsSource = new List<MenuItems>();

                PublishMessageToCar(2);
            }
        }
        private void Btntbl3_Click(object sender, RoutedEventArgs e)
        {
            if (!lsvTable3.HasItems)
            {
                return;
            }
            if (MessageBox.Show("3번 테이블 서빙하시겠습니까?", "서빙", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Progressing();
                DrivingCheck();
                OrderDetailDBUpdate(3);
                Lbltbl3.Content = "";
                lsvTable3.ItemsSource = new List<MenuItems>();
                PublishMessageToCar(3);
            }
        }
        private void Btntbl4_Click(object sender, RoutedEventArgs e)
        {
            if (!lsvTable4.HasItems)
            {
                return;
            }
            if (MessageBox.Show("4번 테이블 서빙하시겠습니까?", "서빙", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Progressing();
                DrivingCheck();
                OrderDetailDBUpdate(4);
                Lbltbl4.Content = "";
                lsvTable4.ItemsSource = new List<MenuItems>();
                PublishMessageToCar(4);
            }
        }


        /// <summary>
        /// 화면에 주문 목록 출력 갱신 
        /// </summary>
        private void UpdateOrder()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                using (EATSEntities db = new EATSEntities())
                {
                    var orderList = db.Ordertbl.Where(o => o.TableInUse).ToList();
                    foreach (var order in orderList)
                    {
                        int tblNum = order.TblNum;
                        List<MenuInfo> orderInfo = new List<MenuInfo>();
                        List<OrderDetailtbl> orderDetailList = db.OrderDetailtbl.Where(o => o.OrderCode.Equals(order.OrderCode) && !o.OrderComplete).ToList();
                        foreach (var item in orderDetailList)
                        {
                            
                            var info = new MenuInfo()
                            {
                                OrderIdx = item.idx,
                                OrderCode = item.OrderCode,
                                MenuName = db.Menutbl.FirstOrDefault(m => m.MenuCode.Equals(item.MenuCode)).MenuName,
                                Amount = item.Amount,
                                OrderComplete = item.OrderComplete
                            };

                            orderInfo.Add(info);
                        }

                        if (tblNum == 1)
                        {
                            menuTable1 = orderInfo;
                            Lbltbl1.Content = DateTime.Now.ToString("HH:mm:ss");
                            lsvTable1.ItemsSource = orderInfo;
                        }
                        else if (tblNum == 2)
                        {
                            menuTable2 = orderInfo;
                            Lbltbl2.Content = DateTime.Now.ToString("HH:mm:ss");
                            lsvTable2.ItemsSource = orderInfo;
                        }
                        else if (tblNum == 3)
                        {
                            menuTable3 = orderInfo;
                            Lbltbl3.Content = DateTime.Now.ToString("HH:mm:ss");
                            lsvTable3.ItemsSource = orderInfo;
                        }
                        else if (tblNum == 4)
                        {
                            menuTable4 = orderInfo;
                            Lbltbl4.Content = DateTime.Now.ToString("HH:mm:ss");
                            lsvTable4.ItemsSource = orderInfo;
                        }
                    }
                    
                    
                    

                    

                };
            }));

        }

        /// <summary>
        /// 서빙로봇에게 메시지 전송 
        /// </summary>
        /// <param name="tblNum">테이블 번호</param>
        private void PublishMessageToCar(int tblNum)
        {
            JObject orderJson = new JObject()
            {
                new JProperty("MessageType", "CarOrder"),
                new JProperty("TableNum", tblNum.ToString()),
                new JProperty("OrderTime", DateTime.Now.ToString())
            };
            Publish(orderJson.ToString());
        }

        #region ProgressCar (서빙 시간 계산)
        private async void Progressing()
        {
            if (isUsing)
            {
                await Helper.Commons.ShowMessageAsync("예외", "현재 운행중입니다");
                return;
            }
            isUsing = true;
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressCahnged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.RunWorkerAsync();
            PgbColorCange();
        }
        private void DrivingCheck()
        {
            isClicked = true;
            if (isClicked)
            {
                BtnDriving.Background = Brushes.Gold;
            }
        }
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                _worker.ReportProgress(i);  // 값을 ReportProgress 매개변수로 전달
                Thread.Sleep(100);  // 0.1초
            }
        }
        private void _worker_ProgressCahnged(object sender, ProgressChangedEventArgs e)
        {
            PgbDriving.Value = e.ProgressPercentage;
        }
        private async void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PgbDriving.Value = PgbDriving.Maximum;
            isClicked = false;
            isUsing = false;
            await Helper.Commons.ShowMessageAsync("도착", "음식이 도착하였습니다");
            BtnDriving.Background = Brushes.Gray;
            PgbDriving.Value = 0;
        }
        private void PgbColorCange()
        {
            PgbDriving.Foreground = Brushes.Green;

            PgbDriving.Maximum = 100;
            PgbDriving.Minimum = 0;

        }
        #endregion


        
        /// <summary>
        /// 주문 메뉴 별 서빙 완료 여부 갱신 
        /// </summary>
        /// <param name="index">테이블 번호</param>
        private void OrderDetailDBUpdate(int index)
        {
            using (EATSEntities db = new EATSEntities())
            {
                List<MenuInfo> orderList = new List<MenuInfo>();
                switch (index)
                {
                    case 1:
                        orderList = menuTable1;
                        break;
                    case 2:
                        orderList = menuTable2;
                        break;
                    case 3:
                        orderList = menuTable3;
                        break;
                    case 4:
                        orderList = menuTable4;
                        break;
                }

                // orderList : 오더 코드, 메뉴명, 수량
                foreach (var item in orderList)
                {
                    db.OrderDetailtbl.FirstOrDefault(o => o.idx.Equals(item.OrderIdx)).OrderComplete = true;
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Mqtt 연결
        /// </summary>
        private void MqttConnection()
        {
            IPAddress brokerAddress = IPAddress.Parse("210.119.12.96");
#pragma warning disable CS0618
            client = new MqttClient(brokerAddress);
#pragma warning restore CS0618
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            if (!client.IsConnected)
                client.Connect("Kitchen1");
            client.Subscribe(new string[] { topic },
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });


        }
        
        /// <summary>
        /// Mqtt 메시지 전송
        /// </summary>
        /// <param name="message"></param>
        private void Publish(string message)
        {
            client.Publish(topic,
                                Encoding.UTF8.GetBytes(message),
                                1,
                                false);
        }

    }
}


