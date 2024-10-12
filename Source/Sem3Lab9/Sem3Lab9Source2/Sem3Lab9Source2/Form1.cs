using Newtonsoft.Json.Linq;

namespace Sem3Lab9Source2
{
    /* (todo)
     * - ����� ������� ���, ����� ��� ������� ���������� ������, �������
     * ������ � �����, ����� ��� ������ ��������� � �� ��� ���������� ����������
     * ������ � �������, ����� �� ���� ����������� �������� ��� �� 6 ���� (������
     * ������ ��������� �������� ������ � �������, ����� ��������) � ����� ������� � 
     * textbox1 ��� ���������� � ������
     */
    public partial class Form1 : Form
    {
        private string File_Path = "C:/Users/173/Desktop/����/����������������/C#/Tasks/�#09/city.txt";
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines(File_Path);
            foreach (string line in lines)
            {
                string[] parts = line.Split('\t');
                listBox1.Items.Add(parts[0]);
            }
        }

        // ������� �� ����� � listbox1 +
        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Weather Current_Weather = await Perform(File_Path);
                DisplayInfo(Current_Weather);
            }
            catch (Exception ex)
            {

            }

        }


        // ����� ���������� � textbox1 +
        private void DisplayInfo(Weather weather)
        {
            textBox1.Text = $"{weather.Temp:F2}C\n";
        }


        // ��������� ���� �� 6 ����
        private static async Task<Weather> Perform(string filepath)
        {
            string apiKey = "542a3f18aadff0a091857dbe1416ec83";
            List<double> cords = Read_Cords(filepath);
            double shirota = cords[0];
            double dolgota = cords[1];
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


        //������ ��������� �� �����
        private static List<double> Read_Cords(string filepath)
        {
            List<double> cords = new List<double>();
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('\t');
                    cords.Add(double.Parse(parts[0])); // ������
                    cords.Add(double.Parse(parts[1])); // �������
                }
            }
            catch { }
            return cords;
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