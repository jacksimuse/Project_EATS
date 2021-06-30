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
        string subscriptionTopic = "MOTOR/TEST/";
        string message = string.Empty;

        public FrmMain()
        {
            InitializeComponent();
            InitializeAllData();
        }

        private void InitializeAllData()
        {
            IPAddress brokerAddress = IPAddress.Parse("210.119.12.96");
            BtnStop.Enabled = false;
            BtnPause.Enabled = false;
            BtnSend1.Enabled = false;
            BtnSend2.Enabled = false;
            BtnSend3.Enabled = false;
            BtnStart.Enabled = false;
            BtnDisconnect.Enabled = false;

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
            BtnSend1.Enabled = true;
            BtnSend2.Enabled = true;
            BtnSend3.Enabled = true;
            BtnStart.Enabled = true;

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
            Reconnect();
            message = "0";
            // Publish
            Publish(message);
            LblAlert.Text = "0도 회전";
        }

        private void BtnSend2_Click(object sender, EventArgs e)
        {
            Reconnect();
            message = "90";
            // Publish
            Publish(message);
            LblAlert.Text = "90도 회전";
        }

        private void BtnSend3_Click(object sender, EventArgs e)
        {
            Reconnect();
            message = "180";
            // Publish
            Publish(message);
            LblAlert.Text = "180도 회전";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Reconnect();
            BtnStart.Enabled = false;
            BtnSend1.Enabled = false;
            BtnSend2.Enabled = false;
            BtnSend3.Enabled = false;

            BtnStop.Enabled = true;
            BtnPause.Enabled = true;

            message = "s";
            // Publish
            Publish(message);
            LblAlert.Text = "회전 시작";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Reconnect();
            BtnStop.Enabled = false;
            BtnPause.Enabled = false;

            BtnStart.Enabled = true;
            BtnSend1.Enabled = true;
            BtnSend2.Enabled = true;
            BtnSend3.Enabled = true;

            message = "t";
            // Publish
            Publish(message);
            LblAlert.Text = "회전 끝";
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            Reconnect();
            message = "p";
            // Publish
            Publish(message);
            LblAlert.Text = "3초 간 일시정지";
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (client.IsConnected)
                client.Disconnect();
        }

        private void Reconnect()
        {
            if (!client.IsConnected)
            {
                client.Connect("SUBSCR1");
            }
        }

        private void Publish(string message)
        {
            client.Publish(subscriptionTopic, // topic
                              Encoding.UTF8.GetBytes(message), // message body
                              0, // QoS level
                              true); // retained
        }
    }
}
