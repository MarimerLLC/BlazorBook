using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorClientExample.Client
{
  public class PersonEdit
  {
    [Required]
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public int Age { get => (DateTime.Now - Birthday).Days / 365; }
  }
}
