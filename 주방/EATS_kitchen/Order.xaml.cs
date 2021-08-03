using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls.Dialogs;

namespace EATS_kitchen
{
    /// <summary>
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Order : Page
    {
        BackgroundWorker _worker = null;
       
        bool isClicked = false;
        bool isUsing = false;
        private async void Progressing()
        {
            if (isUsing)
            {
                await Commons.ShowMessageAsync("예외", "현재 운행중입니다");
                return;
            }
            isUsing = true;
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressCahnged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.RunWorkerAsync();
            PgbColorCange();
        }

        private void DrivingCheck()
        {
            isClicked = true;
            if (isClicked)
            {
                BtnDriving.Background = Brushes.Gold;
            }
                        
        }
        public Order()
        {
            InitializeComponent();
        }

        private void Btntbl1_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();
        }
        
        private void Btntbl2_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();
        }

        private void Btntbl3_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();
        }

        private void Btntbl4_Click(object sender, RoutedEventArgs e)
        {
            Progressing();
            DrivingCheck();
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                _worker.ReportProgress(i);  // 값을 ReportProgress 매개변수로 전달
                Thread.Sleep(100);  // 0.1초
            }
        }

        private void _worker_ProgressCahnged(object sender, ProgressChangedEventArgs e)
        {
            PgbDriving.Value = e.ProgressPercentage;
        }
        private async void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PgbDriving.Value = PgbDriving.Maximum;
            isClicked = false;
            isUsing = false;
            await Commons.ShowMessageAsync("도착", "음식이 도착하였습니다");
            BtnDriving.Background = Brushes.Gray;
            PgbDriving.Value = 0;
        }
        private void PgbColorCange()
        {
            PgbDriving.Foreground = Brushes.Green;

            PgbDriving.Maximum = 100;
            PgbDriving.Minimum = 0;

        }

    }
}
