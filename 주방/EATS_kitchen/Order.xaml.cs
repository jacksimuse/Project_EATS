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

namespace EATS_kitchen
{
    /// <summary>
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Order : Page
    {
        MqttClient client;
        string connectionString;
        delegate void UpdateTextCallback(string message);
        string thisId = "MOTOR/TEST/";
        string message = "나는 전설이다.";

        BackgroundWorker _worker = null;

        bool isClicked = false;
        bool isUsing = false;


        public Order()
        {
            InitializeComponent();

            IPAddress brokerAddress = IPAddress.Parse("210.119.12.86");
            client = new MqttClient(brokerAddress);
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.Connect(thisId);
            client.Subscribe(new string[] { "EATS/order/data/" },
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            
            MessageBox.Show("MQTT 서버에 연결");
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            UpdateText(message);
            var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message); // 데이터를 받을때 역 직렬화(DeserializeObject) <-> 보낼땐 직렬화(SerializeObject)
           //var message2 =  $"테이블이름 : {currentData["table"].ToString()} \n주문내역 : {currentData["order"].ToString()}";
            //UpdateText(message2);
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

        private void UpdateText(string message)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message); // 데이터를 받을때 역 직렬화(DeserializeObject) <-> 보낼땐 직렬화(SerializeObject)
                DateTime dt = DateTime.Now;

                OrderDetailtbl item = new OrderDetailtbl()
                {
                    OrderCode = currentData["ordercode"].ToString(),
                    MenuCode = currentData["menucode"].ToString(),
                    Amount = int.Parse(currentData["amount"]),
                    OrderComplete = false
                };

                // 1. DB에 주문내역을 저장
                var result = Helper.Commons.SetOrderDetail(item);

                // 2. DB상에 있는 메뉴를 불러옴
                var menuinfo = Helper.Commons.GetMenuInfo(item);

                // 3. 내용 출력

                switch (currentData["table"].ToString())
                {
                    case "1":
                        //GetOrderCode();
                        TxbTbl1.Text = menuinfo.MenuName + "  " + item.Amount + "개";
                        Lbltbl1.Content = "주문시각  " + dt.ToString("t");
                        
                        break;
                    case "2":
                        TxbTbl2.Text = menuinfo.MenuName + "  " + item.Amount + "개";
                        Lbltbl2.Content = "주문시각  " + dt.ToString("t");

                        break;
                    case "3":
                        TxbTbl3.Text = menuinfo.MenuName + "  " + item.Amount + "개";
                        Lbltbl3.Content = "주문시각  " + dt.ToString("t");
                        break;
                    case "4":
                        TxbTbl4.Text = menuinfo.MenuName + "  " + item.Amount + "개";
                        Lbltbl4.Content = "주문시각  " + dt.ToString("t");

                        break;
                }
            }));
            
        }

        private void Btntbl1_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();
            
            Publish(message);
        }

        

        private void Btntbl2_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();
            
            Publish(message);
        }

        private void Btntbl3_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();

            Publish(message);
        }

        private void Btntbl4_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();


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
            client.Publish(thisId,
                                Encoding.UTF8.GetBytes(message),
                                0,
                                true);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            client.Disconnect();
        }
    }
}


