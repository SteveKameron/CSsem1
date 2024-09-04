string weatherApi = "https://api.openweathermap.org/data/2.5/weather?lat=20&lon=10&appid=9d5958537564201f56ca38e88aec15a8";
HttpClient client = new HttpClient();
string weather = await client.GetStringAsync(weatherApi);
Console.WriteLine(weather);