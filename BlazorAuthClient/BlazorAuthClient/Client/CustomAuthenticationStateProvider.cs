using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using static BlazorAuthClient.Client.CurrentUserService;

namespace BlazorAuthClient.Client
{
  public class CustomAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly CurrentUserService _currentUserService;

    public CustomAuthenticationStateProvider(CurrentUserService currentUserService)
    {
      _currentUserService = currentUserService;
      _currentUserService.CurrentUserChanged += (sender, e) =>
      {
        var authState = Task.FromResult(new AuthenticationState(e.NewUser));
        NotifyAuthenticationStateChanged(authState);
      };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      return Task.FromResult(new AuthenticationState(_currentUserService.CurrentUser));
    }
  }
}
