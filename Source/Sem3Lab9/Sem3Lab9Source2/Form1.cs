using Newtonsoft.Json.Linq;
using System.CodeDom;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;


namespace Sem3Lab9Source2
{
    /* в listbox будет просто файл где координаты и названия городов, 
     * нужно взять название города и выделить координаты так как в прошлой версии кода 
     * все остальное по ходу дела
     * 
     * в индексаторе listbox1 нужно реализовать парсинг строчки
    */
    public partial class Form1 : Form
    {
        private string File_Path = "C:/Users/SteveKameron/source/repos/Sem3Lab9Source2/city.txt";
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines(File_Path);
            foreach (string line in lines)
            {
                listBox1.Items.Add(line);
            }
        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string line = (string)listBox1.SelectedItem;
                string[] parts = line.Split('\t');
                string[] temp = parts[1].Split(',');
                double temp2 = double.Parse(temp[0],CultureInfo.InvariantCulture);
                MessageBox.Show(temp2.ToString());
                string[] another_1 = temp[0].Split('.');
                double.TryParse(another_1[0], out double one_one);
                double.TryParse(another_1[1], out double one_two);
                double result_1 = one_one + (one_two / Math.Pow(10, another_1.Length));
                string[] another_2 = temp[1].Split('.');
                double.TryParse(another_2[0], out double two_one);
                double.TryParse(another_2[1], out double two_two);
                double result_2 = two_one + (two_two / Math.Pow(10, another_2.Length));
                Weather Current_Weather = await Perform(result_1, result_2);
                DisplayInfo(Current_Weather);
            }
            catch (Exception ex)
            {

            }
        }

        private void DisplayInfo(Weather weather)
        {
            textBox1.Text = $"temperature : {weather.Temp:F2}C, description : {weather.Description}";
        }
        // входные параметры должны быть широта долгота
        private static async Task<Weather> Perform(double shirota, double dolgota)
        {
            string apiKey = "542a3f18aadff0a091857dbe1416ec83";
            string path = $"https://api.openweathermap.org/data/2.5/weather?lat={shirota}&lon={dolgota}&appid={apiKey}";
            Weather weather;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var dataString = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(dataString);
                    weather = new Weather()
                    {
                        Country = (string)data["sys"]["country"],
                        Name = (string)data["name"],
                        Temp = Convert.ToDouble(data["main"]["temp"]) - 273.15,
                        Description = (string)data["weather"][0]["description"]
                    };
                }
                else
                {
                    throw new Exception("error");
                }
            }
            return weather;

        }
        public struct Weather
        {
            public string Country { get; set; }
            public string Name { get; set; }
            public double Temp { get; set; }
            public string Description { get; set; }
        }
    }
}