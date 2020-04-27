using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csla.Core;
using Csla.Rules;

namespace BlazorCslaExample.Data
{
  public class NoSingleName : BusinessRule
  {
    public NoSingleName(IPropertyInfo property)
      : base(property)
    {
      InputProperties.Add(property);
    }

    protected override void Execute(IRuleContext context)
    {
      var name = (string)context.InputPropertyValues[PrimaryProperty];
      if (!name.Trim().Contains(" "))
        context.AddWarningResult("You should enter a full name");
    }
  }
}
