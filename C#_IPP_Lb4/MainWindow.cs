using C__IPP_Lb4.Classes;
using System;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace C__IPP_Lb4
{
    public partial class MainWindow : Form
    {
        private void GetResult()
        {
            string result = WeatherLibrary.WeatherService.GetTemperature(textBoxCityName.Text);
            if (result == "Error!")
                MessageBox.Show("Incorrect city name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Root cityWeather = JsonSerializer.Deserialize<Root>(result);
                MessageBox.Show($"City: {cityWeather.name}\n" +
                    $"Country: {cityWeather.sys.country}\n" +
                    $"Description weather: {cityWeather.weather[0].description}\n" +
                    $"Min temp: {cityWeather.main.temp_min} °C\n" +
                    $"Max temp: {cityWeather.main.temp_max} °C\n" +
                    $"Temperature: {cityWeather.main.temp} °C\n",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGetWeather_Click(object sender, EventArgs e)
        {
            if (textBoxCityName.Text == string.Empty) 
                MessageBox.Show("Enter city name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var threadGetWeather = new Thread(GetResult);
                threadGetWeather.Start();
            }
        }
    }
}
