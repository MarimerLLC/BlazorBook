using BlazorMultiHead.Ui.Data;
using System;
using System.Threading.Tasks;

namespace BlazorMultiHead.Ui.Services
{
  public interface IForecastService
  {
    Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
  }
}
