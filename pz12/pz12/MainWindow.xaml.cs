using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace pz12
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и инициализируем объект для сериализации
            var obj = new MyObject
            {
                Name = "Мартемьянов Денис",
                Age = 20,
                Email = "sf252578@gmail.com"
            };

            // Создаем объект XmlSerializer
            var serializer = new XmlSerializer(typeof(MyObject));

            // Создаем файл для сохранения сериализованного объекта
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "serialized.xml");

            // Сериализуем объект в XML и сохраняем его в файл
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, obj);
            }

            MessageBox.Show("Объект успешно сериализован и сохранен в файле!");
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем объект XmlSerializer
            var serializer = new XmlSerializer(typeof(MyObject));

            // Загружаем сериализованный объект из файла
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "serialized.xml");

            using (var reader = new StreamReader(filePath))
            {
                // Десериализуем объект из XML
                var deserializedObj = (MyObject)serializer.Deserialize(reader);

                // Выводим информацию о десериализованном объекте
                MessageBox.Show($"Имя: {deserializedObj.Name}\nВозраст: {deserializedObj.Age}\nEmail: {deserializedObj.Email}");
            }
        }
    }

    // Пример сериализуемого класса
    public class MyObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}