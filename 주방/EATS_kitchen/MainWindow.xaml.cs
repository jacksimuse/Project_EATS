using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Threading;

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
    }
}
