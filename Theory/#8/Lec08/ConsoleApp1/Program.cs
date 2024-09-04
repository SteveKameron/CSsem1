using Newtonsoft.Json;
using System.Text.Json;

HttpClient client = new HttpClient();
var s = client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=57,46&lon=67,19&appid=c04ce3a1ed3d8c1fe0131b885b9dc065");

var dynamicObject = JsonConvert.DeserializeObject<dynamic>(s.Result);
var dynamicObject2 = System.Text.Json.JsonSerializer.Deserialize<dynamic>(s.Result)!;
var dynamicObject3 = JsonConvert.DeserializeAnonymousType(s.Result, new
{
    weather = new Dictionary<string, string>()
})!;

Console.WriteLine(dynamicObject.weather[0].id);
Console.WriteLine(dynamicObject2.weather[0].id);
Console.WriteLine(dynamicObject3);