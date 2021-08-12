using kiosk1.Model;
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
using uPLibrary.Networking.M2Mqtt.Messages;

namespace kiosk1.View.Pay
{
    /// <summary>
    /// payView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class payView : Page
    {
        MqttClient client;
        string connectionString;
        string clientId = " ";
        string Topic = "name/test/";
        string message = "가지마 최연성";

       


        public payView()
        {
            InitializeComponent();


            Logic.btncontrol btc = new Logic.btncontrol();
            btc.BtnControl("Btnpay");



        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            throw new NotImplementedException();
        }


        public payView(List<MenuItems> menuItems)
        {
            InitializeComponent();
            lsvOrder.ItemsSource = menuItems;

            Logic.btncontrol btc = new Logic.btncontrol();
            btc.BtnControl("Btnpay");


        }

        private void Btncancel_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
            else
            {
                Select.MenuSelect menu = new Select.MenuSelect();
                NavigationService.Navigate(menu);
            }
        }

        private void Btncash_Click(object sender, RoutedEventArgs e)
        {
            Publish(message);
        }

        private void Publish(string message)
        {
            client.Publish(Topic,
                                Encoding.UTF8.GetBytes(message),
                                0,
                                true);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IPAddress BrokerAddress = IPAddress.Parse("210.119.12.88");

            client = new MqttClient(BrokerAddress);

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            clientId = Guid.NewGuid().ToString();

            client.Connect(clientId);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            client.Disconnect();
        }
    }
}
