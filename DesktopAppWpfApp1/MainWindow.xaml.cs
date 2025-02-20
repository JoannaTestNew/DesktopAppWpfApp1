using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesktopAppWpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _timer;

    public MainWindow()
    {
        InitializeComponent();
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _timer.Start();
        UpdateClock();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        UpdateClock();
    }

    private void UpdateClock()
    {
        DateTime now = DateTime.Now;

        double secondAngle = now.Second * 6; // 360 degrees / 60 seconds
        double minuteAngle = now.Minute * 6 + now.Second * 0.1; // 360 degrees / 60 minutes
        double hourAngle = now.Hour * 30 + now.Minute * 0.5; // 360 degrees / 12 hours

        secondHand.RenderTransform = new RotateTransform(secondAngle, 150, 150);
        minuteHand.RenderTransform = new RotateTransform(minuteAngle, 150, 150);
        hourHand.RenderTransform = new RotateTransform(hourAngle, 150, 150);
    }
}
