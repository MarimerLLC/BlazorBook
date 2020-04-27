using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorMultiHead.Client.Services;
using System.Net.Http;
using System;

namespace BlazorMultiHead.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<Ui.App>("app");

      builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddSingleton<Ui.Services.IWeatherForecastService, ForecastService>();
      builder.Services.AddSingleton<Ui.Services.IHostType, HostType>();

      await builder.Build().RunAsync();
    }
  }
}
