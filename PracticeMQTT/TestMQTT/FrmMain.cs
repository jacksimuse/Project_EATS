using M2Mqtt;
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DeviceSubApp
{
    public partial class FrmMain : Form
    {
        MqttClient client;
        readonly string ip = "210.119.12.96"; // 서버 IP
        public FrmMain()
        {
            InitializeComponent();
            InitializeAllData();
        }

        private void InitializeAllData()
        {
            // client 객체 생성
            try
            {
                IPAddress brokerAddress = IPAddress.Parse(ip);
                client = new MqttClient(brokerAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            client.Connect("SUBSCR01");   // SUBSCR01

            BtnConnect.Enabled = false;
            BtnDisconnect.Enabled = true;

            LblAlert.Text = "CONNECTED!!";
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();

            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
            LblAlert.Text = "DISCONNECTED!!";
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string subscriptionTopic = "TOMATO/";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(TxtMsg.Text), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "SUCCESS!!";
        }
    }
}
