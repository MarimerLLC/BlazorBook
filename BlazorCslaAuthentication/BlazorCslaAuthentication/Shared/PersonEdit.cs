using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Csla;
using Csla.Rules;

namespace BlazorCslaAuthentication.Shared
{
  [Serializable]
  public class PersonEdit : BusinessBase<PersonEdit>
  {
    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    public string Name
    {
      get => GetProperty(NameProperty);
      set => SetProperty(NameProperty, value);
    }

    [ObjectAuthorizationRules]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void AddPerTypeRules()
    {
      Csla.Rules.BusinessRules.AddRule(
        typeof(PersonEdit),
        new Csla.Rules.CommonRules.IsInRole(
          Csla.Rules.AuthorizationActions.CreateObject,
          "PersonCreator"));
    }

    protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
      BusinessRules.AddRule(
        new Csla.Rules.CommonRules.IsInRole(
          Csla.Rules.AuthorizationActions.ReadProperty, 
          NameProperty, 
          "NameViewer"));
    }
  }
}
