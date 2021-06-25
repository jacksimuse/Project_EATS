using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DeviceSubApp
{
    public partial class FrmMain : Form
    {
        MqttClient client;

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
