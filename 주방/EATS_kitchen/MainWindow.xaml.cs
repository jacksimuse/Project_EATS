using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();

        }

        private void InitializeMqtt()
        {
            
        }

        private  void BtnOrder_Click(object sender, RoutedEventArgs e)
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
            //client.Disconnect();
            await Commons.ShowMessageAsync("영업", "종료합니다");
        }
        private void UpdateText(string message)
        {
            throw new NotImplementedException();
        }
    }
}
