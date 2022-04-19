﻿namespace DataAnnotationsExample.Models;
public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int Age { get; set; }
    public string? Description { get; set; }
}

