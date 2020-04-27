using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csla.Core;
using Csla.Rules;

namespace BlazorCslaExample.Data
{
  public class CalculateAge : BusinessRule
  {
    private IPropertyInfo AgeProperty;

    public CalculateAge(IPropertyInfo birthdateProperty, IPropertyInfo ageProperty)
      : base(birthdateProperty)
    {
      AgeProperty = ageProperty;
      InputProperties.Add(birthdateProperty);
      AffectedProperties.Add(ageProperty);
    }

    protected override void Execute(IRuleContext context)
    {
      var birthdate = (DateTime)context.InputPropertyValues[PrimaryProperty];
      int age = (int)(DateTime.Today - birthdate).TotalDays / 365;
      context.AddOutValue(AgeProperty, age);
    }
  }
}
