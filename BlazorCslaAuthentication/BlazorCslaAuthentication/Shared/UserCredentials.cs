﻿using System;
using System.ComponentModel.DataAnnotations;
using Csla;

namespace BlazorCslaAuthentication.Shared
{
  /// <summary>
  /// Responsible for getting user credentials
  /// from the user and acting as criteria for
  /// the CredentialValidator type.
  /// </summary>
  [Serializable]
  public class UserCredentials : BusinessBase<UserCredentials>
  {
    public static readonly PropertyInfo<string> UsernameProperty = RegisterProperty<string>(nameof(Username));
    [Required]
    public string Username
    {
      get => GetProperty(UsernameProperty);
      set => SetProperty(UsernameProperty, value);
    }

    public static readonly PropertyInfo<string> PasswordProperty = RegisterProperty<string>(nameof(Password));
    [Required]
    public string Password
    {
      get => GetProperty(PasswordProperty);
      set => SetProperty(PasswordProperty, value);
    }

    [Create]
    [RunLocal]
    private void Create()
    { }
  }
}
