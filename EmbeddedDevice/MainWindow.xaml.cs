using EmbeddedDevice.Models;
using System.Net.Http;
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

namespace EmbeddedDevice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnTriggerAlert_Click(object sender, RoutedEventArgs e) 
        {
            using var http = new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };//Hans hade allt detta i en egen console app projekt

            var alert = new Alert
            {
                TimeStamp = DateTime.Now,
                Severity = "High",
                Type = "Overheating",
                Machine = "EmbeddedDevice",
                Message = "Temp: 82C"
            };

        }
    }
}