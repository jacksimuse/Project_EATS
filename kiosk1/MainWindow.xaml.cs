using kiosk1.View.main;
using kiosk1.View.Pay;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using uPLibrary.Networking.M2Mqtt;

namespace kiosk1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MqttClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                MqttConnect();
                ActiveControl.Content = new MainView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MqttConnect()
        {
            IPAddress brokerAddress = IPAddress.Parse("210.119.12.96");

#pragma warning disable CS0618
            client = new MqttClient(brokerAddress);
#pragma warning restore CS0618
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
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }
    }
}
