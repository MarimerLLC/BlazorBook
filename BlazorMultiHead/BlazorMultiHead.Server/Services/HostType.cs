using BlazorMultiHead.Ui.Services;

namespace BlazorMultiHead.Server.Services
{
  /// <summary>
  /// Service used to identify the
  /// current host type
  /// </summary>
  public class HostType : IHostType
  {
    /// <summary>
    /// Gets the current host type for the app
    /// </summary>
    HostTypes IHostType.HostType => HostTypes.AspNetCore;
  }
}
