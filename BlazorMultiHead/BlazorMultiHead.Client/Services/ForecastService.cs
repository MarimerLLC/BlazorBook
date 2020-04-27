using BlazorMultiHead.Shared;
using BlazorMultiHead.Ui.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMultiHead.Client.Services
{
  public class ForecastService : IWeatherForecastService
  {
    private HttpClient Http;
    public ForecastService(HttpClient httpClient)
    {
      Http = httpClient;
    }

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime time)
    {
      return await Http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }
  }
}
