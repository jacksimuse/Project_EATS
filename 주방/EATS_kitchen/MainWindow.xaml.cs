using EATS_kitchen.Model;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace EATS_kitchen
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MqttClient client;
        readonly IPAddress brokerAddress = IPAddress.Parse("210.119.12.96");

        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new Order();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnActivation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new Activation();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LblDatetime.Content = DateTime.Now.ToString("yy년MM월dd일 HH:mm:ss");
        }


        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (client.IsConnected) client.Disconnect();
            await Helper.Commons.ShowMessageAsync("영업", "종료합니다");
        }
        
        private void btnTable1_Click(object sender, RoutedEventArgs e)
        {
            int num = 1;
            // 0. 메시지박스로 질문
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(num.ToString() + "번 테이블에 손님이 없나요?", "", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // 1. Ordertbl.TableInUse 갱신 
            // TableSetEmpty(num);

            // 2. 새로고침 메시지 전송 
            RefreshMessagePublish(num);
        }

        private void RefreshMessagePublish(int tblNum)
        {
            try
            {
                client = new MqttClient(brokerAddress);
                if (!client.IsConnected) client.Connect("Kitchen");
                

                JObject refreshJson = new JObject(
                        new JProperty("MessageType", "TableSet"),
                        new JProperty("CLient_ID", "TableClient"),
                        new JProperty("TableNumber", tblNum.ToString()),
                        new JProperty("Pub_Message_Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"))
                        );
                
                var message = Encoding.UTF8.GetBytes(refreshJson.ToString());
                string topic = "EATS/TABLE/";

                client.Publish(topic, message, 2, true);
                System.Windows.MessageBox.Show("메시지 전송 성공");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnTable2_Click(object sender, RoutedEventArgs e)
        {
            int num = 2;
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(num.ToString() + "번 테이블에 손님이 없나요?", "", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            // TableSetEmpty(num);
            RefreshMessagePublish(num);
        }
        private void btnTable3_Click(object sender, RoutedEventArgs e)
        {
            int num = 3;
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(num.ToString() + "번 테이블에 손님이 없나요?", "", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            // TableSetEmpty(num);
            RefreshMessagePublish(num);
        }
        private void btnTable4_Click(object sender, RoutedEventArgs e)
        {
            int num = 4;
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(num.ToString() + "번 테이블에 손님이 없나요?", "", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            // TableSetEmpty(num);
            RefreshMessagePublish(num);
        }

        private void TableSetEmpty(int tblNum)
        {
            using (EATSEntities db = new EATSEntities())
            {
                // 사용중인 테이블 0으로 만들기 (단 하나)
                Ordertbl useTable = db.Ordertbl.Where(o => o.TableInUse && o.TblNum == tblNum).FirstOrDefault();
                if (useTable != null)
                    useTable.TableInUse = false;
                if (db.SaveChanges() > 0)
                {
                    System.Windows.MessageBox.Show("DB 저장 성공");
                }
                else System.Windows.MessageBox.Show("해당 테이블은 이미 비어있습니다.");
            }
        }
    }
}
