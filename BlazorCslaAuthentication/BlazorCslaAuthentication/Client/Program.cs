using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Csla.Blazor.Client.Authentication;
using Csla.Configuration;
using System.Net.Http;

namespace BlazorCslaAuthentication.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      builder.Services.AddOptions();
      builder.Services.AddAuthorizationCore();
      builder.Services.AddSingleton
        <AuthenticationStateProvider, CslaAuthenticationStateProvider>();
      builder.Services.AddSingleton<CslaUserService>();

      builder.UseCsla(c =>
      {
        c.DataPortal()
              .DefaultProxy(typeof(Csla.DataPortalClient.HttpProxy), "https://localhost:44317/api/dataportaltext/");
      });

      await builder.Build().RunAsync();
    }
  }
}
