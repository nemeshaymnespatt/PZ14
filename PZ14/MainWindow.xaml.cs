using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace PatrolApp
{
    public partial class MainWindow : Window
    {
        private double speed = 0;
        private double acceleration = 180;
        private double maxSpeed = 200;
        private double minSpeed = 0;
        private bool increasingSpeed = true;

        private DispatcherTimer speedTimer;

        public MainWindow()
        {
            InitializeComponent();

            speedTimer = new DispatcherTimer();
            speedTimer.Interval = TimeSpan.FromMilliseconds(100);
            speedTimer.Tick += SpeedTimer_Tick;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            speed = 0;
            increasingSpeed = true;
            SpeedTextBlock.Text = "0 км/ч";
            SpeedTextBlock.Foreground = Brushes.Black;

            speedTimer.Start();
        }

        private void SpeedTimer_Tick(object sender, EventArgs e)
        {
            if (increasingSpeed)
            {
                speed += acceleration * 0.1;

                if (speed >= maxSpeed)
                {
                    speed = maxSpeed;
                    increasingSpeed = false;
                }
            }
            else
            {
                speed -= acceleration * 0.1;

                if (speed <= minSpeed)
                {
                    speed = minSpeed;
                    increasingSpeed = true;
                }
            }

            SpeedTextBlock.Text = $"{speed:F1} км/ч";

            if (speed > 55)
            {
                SpeedTextBlock.Foreground = Brushes.Red;
            }
            else
            {
                SpeedTextBlock.Foreground = Brushes.Black;
            }
        }
    }
}