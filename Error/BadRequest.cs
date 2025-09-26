using System;

namespace LoginService.Error;

public class BadUserData
{
    public string? Error { get;  set; } 
    public string? Description { get; set; }
}
