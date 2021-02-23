using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using BLAPI;
using BO;
using System.Diagnostics;

namespace PL
{
    /// <summary>
    /// Interaction logic for UserArea.xaml
    /// </summary>
    public partial class UserArea : Window
    {  //{
       //    IBL bl;
       //    BO.User curUser;
       //    public UserArea()
       //    {
       //        InitializeComponent();
       //    }
        public UserArea(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            //curBus = _curBus;
            //busDetails.DataContext = curBus;
            //cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));


        }

        IBL bl;
    private Stopwatch stopWatch;
    private bool isTimerRun;
    private Thread timerThread;
    private TimeSpan start = TimeSpan.Zero;
     public UserArea()
    {
        InitializeComponent();
    }
        public UserArea(IBL _bl, BO.Station _curStat)
        {
            InitializeComponent();
            bl = _bl;
        
        }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        stopWatch = new Stopwatch();
            tb_timer.Text = stopWatch.Elapsed.ToString();

            lb_LineBus.ItemsSource = from station in bl.GetAllBusStations()
                                     select " תחנה " + station.BusStationKey + " : " + station.StationName;
        }

    private void StartClock()
    {
        if (!isTimerRun)
        {
            stopWatch.Restart();
            isTimerRun = true;

            timerThread = new Thread(RunTimer);
            timerThread.Start();
        }
    }

    private void RunTimer()
    {
        while (isTimerRun)
        {
            string timerText = (start + stopWatch.Elapsed).ToString();
            timerText = timerText.Substring(0, 8);

            SetTimer(timerText);
            Thread.Sleep(1000);
        }
    }

    void SetText(string text)
    {
            tb_timer.Text = text;
    }

    void SetTimer(string timerText)
    {
        if (!CheckAccess())
        {
            Action<string> d = SetText;
            Dispatcher.BeginInvoke(d, timerText);
        }
        else
        {
                tb_timer.Text = timerText;
        }
    }

    private void start_btn(object sender, RoutedEventArgs e)
    {
            tb_timer.Text = start.ToString();
        start = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        StartClock();
    }
    private void lbStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        Environment.Exit(Environment.ExitCode);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWin = new MainWindow();
            this.Close();
            mainWin.ShowDialog();
        }

        private void lb_Station_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedIndex != -1)
            {
                string station = lb.SelectedItem as string;
                //lb_LineBus.ItemsSource = from line in bl.GetAllLines()
                //                      where line.ListOfStations.Contains(station.Substring(6, 5))
                //                      select "line: " + line.BusLineNumber;
                UpdateLayout();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
