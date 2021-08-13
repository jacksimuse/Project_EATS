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

namespace EATS_kitchen
{
    /// <summary>
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Order : Page
    {
        MqttClient client;
        
        delegate void UpdateTextCallback(string message);
        List<MenuItems> menuTable1 = new List<MenuItems>();
        List<MenuItems> menuTable2 = new List<MenuItems>();
        List<MenuItems> menuTable3 = new List<MenuItems>();
        List<MenuItems> menuTable4 = new List<MenuItems>();

        string message = "나는 전설이다.";
        string topic = "EATS/ORDER/";
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
        }

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

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            if (message == "나는 전설이다.") 
            {
                
            }
            else
            {
                var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
                string orderCode = currentData["OrderCode"];
                int tblNum = int.Parse(currentData["TableNum"]);

                // 주문 갱신 (가장 최근 4개 주문) 
                UpdateOrder(orderCode, tblNum);
            } 
            // var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message); // 데이터를 받을때 역 직렬화(DeserializeObject) <-> 보낼땐 직렬화(SerializeObject)
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            client.Disconnect();
        }
        private void UpdateOrder(string orderCode, int tblNum)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                using (EATSEntities db = new EATSEntities())
                {
                    List<OrderDetailtbl> orderDetailList = db.OrderDetailtbl.Where(o => o.OrderCode.Equals(orderCode) && !o.OrderComplete).ToList();
                    List<MenuItems> orderList = new List<MenuItems>();
                    foreach (var item in orderDetailList)
                    {
                        var order = new MenuItems()
                        {
                            OrderIdx = item.idx,
                            OrderCode = orderCode,
                            MenuName = db.Menutbl.FirstOrDefault(m => m.MenuCode.Equals(item.MenuCode)).MenuName,
                            Amount = item.Amount,
                            OrderComplete = item.OrderComplete
                        };
                        
                        orderList.Add(order);
                    }

                    if (tblNum == 1)
                    {
                        menuTable1 = orderList;
                        Lbltbl1.Content = DateTime.Now.ToString();
                        lsvTable1.ItemsSource = orderList;
                    }
                    else if (tblNum == 2)
                    {
                        menuTable2 = orderList;
                        Lbltbl2.Content = DateTime.Now.ToString();
                        lsvTable2.ItemsSource = orderList;
                    }
                    else if (tblNum == 3)
                    {
                        menuTable3 = orderList;
                        Lbltbl3.Content = DateTime.Now.ToString();
                        lsvTable3.ItemsSource = orderList;
                    }
                    else if (tblNum == 4)
                    {
                        menuTable4 = orderList;
                        Lbltbl4.Content = DateTime.Now.ToString();
                        lsvTable4.ItemsSource = orderList;
                    }
                
                };
            }));

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
                Publish(message);
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

                Publish(message);
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
                Publish(message);
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
                Publish(message);
            }
        }



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
        private void Publish(string message)
        {
            client.Publish(topic,
                                Encoding.UTF8.GetBytes(message),
                                1,
                                false);
        }

        


        /// <summary>
        /// 메뉴 별 서빙 완료 여부 갱신 
        /// </summary>
        /// <param name="index"></param>
        private void OrderDetailDBUpdate(int index)
        {
            using (EATSEntities db = new EATSEntities())
            {
                List<MenuItems> orderList = new List<MenuItems>();
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

    }
}


