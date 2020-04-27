namespace BlazorMultiHead.Ui.Services
{
  /// <summary>
  /// Available host types
  /// </summary>
  public enum HostTypes
  {
    Undefined,
    AspNetCore,
    WebAssembly,
    WebWindow,
    Electron
  }

  /// <summary>
  /// Service used to identify the
  /// current host type
  /// </summary>
  public interface IHostType
  {
    /// <summary>
    /// Gets the current host type for the app
    /// </summary>
    HostTypes HostType { get; }
  }
}
