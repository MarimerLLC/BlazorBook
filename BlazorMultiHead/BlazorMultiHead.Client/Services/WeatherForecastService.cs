using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorMultiHead.Ui.Data;
using BlazorMultiHead.Ui.Services;

public class WeatherForecastService : IForecastService
{
  private HttpClient Http;
  public WeatherForecastService(HttpClient httpClient)
  {
    Http = httpClient;
  }

  public async Task<WeatherForecast[]> GetForecastAsync(DateTime time)
  {
    return await Http.GetFromJsonAsync<WeatherForecast[]>(
      "sample-data/weather.json");
  }
}