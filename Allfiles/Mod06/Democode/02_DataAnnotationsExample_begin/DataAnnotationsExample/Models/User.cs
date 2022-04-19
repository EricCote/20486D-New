﻿namespace DataAnnotationsExample.Models;

public class User
{
    public int UserId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public DateTime Birthdate { get; set; }
    public string? Password { get; set; }
}

