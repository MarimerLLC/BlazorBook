using BlazorMultiHead.Ui.Services;

namespace BlazorMultiHead.Client.Services
{
  /// Service used to identify the
  /// current host type
  public class HostType : IHostType
  {
    /// <summary>
    /// Gets the current host type for the app
    /// </summary>
    HostTypes IHostType.HostType => HostTypes.WebAssembly;
  }
}
