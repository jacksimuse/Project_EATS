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
        //string subscriptionTopic = "TRAFFICLIGHT/TEST/";
        string message = string.Empty;

        public FrmMain()
        {
            InitializeComponent();
            InitializeAllData();
        }

        private void InitializeAllData()
        {
            IPAddress brokerAddress = IPAddress.Parse("210.119.12.93");
            BtnStop.Enabled = false;
            BtnBack.Enabled = false;
            BtnPause.Enabled = false;
            BtnSend1.Enabled = false;
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
            BtnSend3.Enabled = true;
            BtnStart.Enabled = true;
            BtnStop.Enabled = true;
            BtnBack.Enabled = true;
            BtnPause.Enabled = true;

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
            //BtnSend1.Enabled = false;
            message = "l";
            // Publish
            Publish(message);
            LblAlert.Text = "Left";
        }

        private void BtnSend3_Click(object sender, EventArgs e)
        {
            Reconnect();
            //BtnSend3.Enabled = false;
            message = "r";
            // Publish
            Publish(message);
            LblAlert.Text = "Right";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Reconnect();
            //BtnStart.Enabled = false;

            message = "s";
            // Publish
            Publish(message);
            LblAlert.Text = "Start";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Reconnect();
            /*BtnStop.Enabled = false;
            BtnPause.Enabled = false;

            BtnStart.Enabled = true;
            BtnSend1.Enabled = true;
            BtnSend3.Enabled = true;*/

            message = "t";
            // Publish
            Publish(message);
            LblAlert.Text = "Stop";
        }
        private void BtnPause_Click(object sender, EventArgs e)
        {
            Reconnect();
            /*BtnStop.Enabled = false;
            BtnPause.Enabled = false;

            BtnStart.Enabled = true;
            BtnSend1.Enabled = true;
            BtnSend3.Enabled = true;*/

            message = "p";
            // Publish
            Publish(message);
            LblAlert.Text = "Pause";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Reconnect();
            message = "b";
            // Publish
            Publish(message);
            LblAlert.Text = "Back";
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
