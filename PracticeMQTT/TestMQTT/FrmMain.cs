using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace DeviceSubApp
{
    public partial class FrmMain : Form
    {
        MqttClient client;
        string subscriptionTopic = "TOMATO/";
        string message = string.Empty;

        public FrmMain()
        {
            InitializeComponent();
            InitializeAllData();
        }

        private void InitializeAllData()
        {

            IPAddress brokerAddress = IPAddress.Parse("192.168.0.5");

            // client 연결
            try
            {
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

        private void BtnSend1_Click(object sender, EventArgs e)
        {
            message = "0";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "0도 회전";
        }

        private void BtnSend2_Click(object sender, EventArgs e)
        {
            message = "90";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "90도 회전";
        }

        private void BtnSend3_Click(object sender, EventArgs e)
        {
            message = "180";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "180도 회전";
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            message = "r";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "회전";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            message = "s";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "회전 시작";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            message = "p";
            // Publish
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
            LblAlert.Text = "회전 끝";
        }
    }
}
