using BlazorMultiHead.Shared;
using System;
using System.Threading.Tasks;

namespace BlazorMultiHead.Ui.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
