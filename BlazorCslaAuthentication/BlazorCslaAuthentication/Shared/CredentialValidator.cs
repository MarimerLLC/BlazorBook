using System;
using Csla;

namespace BlazorCslaAuthentication.Shared
{
  /// <summary>
  /// Verifies the supplied user credentials and
  /// returns information about the verified user.
  /// </summary>
  [Serializable]
  public class CredentialValidator : ReadOnlyBase<CredentialValidator>
  {
    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    public string Name
    {
      get => GetProperty(NameProperty);
      private set => LoadProperty(NameProperty, value);
    }

    public static readonly PropertyInfo<string> AuthenticationTypeProperty = RegisterProperty<string>(nameof(AuthenticationType));
    public string AuthenticationType
    {
      get => GetProperty(AuthenticationTypeProperty);
      private set => LoadProperty(AuthenticationTypeProperty, value);
    }

    public static readonly PropertyInfo<Csla.Core.MobileList<string>> RolesProperty = RegisterProperty<Csla.Core.MobileList<string>>(nameof(Roles));
    public Csla.Core.MobileList<string> Roles
    {
      get => GetProperty(RolesProperty);
      private set => LoadProperty(RolesProperty, value);
    }

    [Fetch]
    private void Fetch(UserCredentials credentials)
    {
      // validate credentials here
      if (!string.IsNullOrWhiteSpace(credentials.Username))
      {
        Name = credentials.Username;
        AuthenticationType = "Custom";
        Roles = new Csla.Core.MobileList<string>
        {
          "StandardUser",
          "PersonCreator"
        };
      }
    }
  }
}
