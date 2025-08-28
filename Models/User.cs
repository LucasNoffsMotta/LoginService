using System;

namespace LoginService.Models;

public class User : ModelBase
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public DateOnly Birth { get; set; }
    public Adress? Adress { get; set; }

    public int AdressId { get; set; }
}
