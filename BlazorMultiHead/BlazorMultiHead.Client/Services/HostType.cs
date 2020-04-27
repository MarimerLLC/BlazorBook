using BlazorMultiHead.Ui.Services;

namespace BlazorMultiHead.Client.Services
{
  public class HostType : IHostType
  {
    string IHostType.HostType => "WebAssembly";
  }
}
