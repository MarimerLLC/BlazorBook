using BlazorMultiHead.Ui.Services;

namespace BlazorMultiHead.Server.Services
{
  public class HostType : IHostType
  {
    string IHostType.HostType => "ASP.NET";
  }
}
