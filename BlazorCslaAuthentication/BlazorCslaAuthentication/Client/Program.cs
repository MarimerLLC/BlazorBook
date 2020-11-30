using Csla.Blazor.Client.Authentication;
using Csla.Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCslaAuthentication.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      builder.Services.AddOptions();
      builder.Services.AddAuthorizationCore();
      builder.Services.AddSingleton
        <AuthenticationStateProvider, CslaAuthenticationStateProvider>();
      builder.Services.AddSingleton<CslaUserService>();

      builder.UseCsla(c =>
      {
        c.DataPortal()
              .DefaultProxy(typeof(Csla.DataPortalClient.HttpProxy), "https://localhost:44345/api/dataportaltext/");
      });

      await builder.Build().RunAsync();
    }
  }
}
