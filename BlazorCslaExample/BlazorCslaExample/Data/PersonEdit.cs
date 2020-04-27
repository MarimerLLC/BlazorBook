using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Csla;

namespace BlazorCslaExample.Data
{
  [Serializable]
  public class PersonEdit : BusinessBase<PersonEdit>
  {
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(nameof(Id));
    public int Id
    {
      get => GetProperty(IdProperty);
      set => SetProperty(IdProperty, value);
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    [Required]
    public string Name
    {
      get => GetProperty(NameProperty);
      set => SetProperty(NameProperty, value);
    }

    public static readonly PropertyInfo<DateTime> BirthdateProperty = RegisterProperty<DateTime>(nameof(Birthdate));
    public DateTime Birthdate
    {
      get => GetProperty(BirthdateProperty);
      set => SetProperty(BirthdateProperty, value);
    }

    public static readonly PropertyInfo<int> AgeProperty = RegisterProperty<int>(nameof(Age));
    public int Age
    {
      get => GetProperty(AgeProperty);
      private set => LoadProperty(AgeProperty, value);
    }

    protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
      BusinessRules.AddRule(new CalculateAge(BirthdateProperty, AgeProperty));
      BusinessRules.AddRule(new NoSingleName(NameProperty));
    }

    [Create]
    [RunLocal]
    private void Create()
    {
      using (BypassPropertyChecks)
      {
        Id = -1;
        Birthdate = DateTime.Today;
      }
    }

    [Fetch]
    private void Fetch(int id)
    {
      using (BypassPropertyChecks)
      {
        Id = id;
        Name = "Andrea Rho";
        Birthdate = new DateTime(2003, 4, 22);
      }
      BusinessRules.CheckRules();
      MarkOld();
    }

    [Insert]
    [Update]
    private void InsertOrUpdate()
    {
      using (BypassPropertyChecks)
      {
        if (Id == -1)
          Id = 1; // simulate database creating primary key
      }
    }
  }
}
