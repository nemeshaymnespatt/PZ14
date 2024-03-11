using System;
using System.Windows;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        private Random random;
        private double currentTemperature;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            currentTemperature = 0;

            // Запускаем таймер, который будет обновлять температурные данные каждую секунду
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(UpdateTemperature);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void UpdateTemperature(object sender, EventArgs e)
        {
            // Генерируем новое значение температуры
            currentTemperature = random.Next(-20, 20) ;

            // Обновляем значение на экране
            temperatureTextBlock.Text = currentTemperature.ToString("F1");

            // Проверяем, если значение температуры находится в предусмотренном диапазоне (-5 до 5),
            // то показываем уведомление пользователю
            if (currentTemperature >= -5 && currentTemperature <= 5)
            {
                MessageBox.Show("Температура приближается к критической отметке!");
            }
        }
    }
}