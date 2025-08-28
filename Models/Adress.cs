using System;
namespace LoginService.Models;

public class Adress : ModelBase
{
    public int UserID { get; set; }
    public string? Street { get; set; }
    public int Number { get; set; }
    public string? PostalCode { get; set; }
}
