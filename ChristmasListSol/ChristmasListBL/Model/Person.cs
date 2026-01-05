using ChristmasListBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasListBL.Model;

public class Person
{
    private string _name;
    private string? _lastName;

    public int Id { get; set; } = 0;
    public string Name 
    { 
        get => _name; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ChristmasException("Name cannot be empty.");
            _name = value;
        }
    }
    public string? LastName 
    { 
        get => _lastName; 
        set
        {
            if(value.Any(char.IsDigit))
                throw new ChristmasException("Last name cannot contain numbers.");
            _lastName = value;
        }
    }

    public Person()
    {
        Name = string.Empty;
        LastName = string.Empty;
    }
    public Person(string name, string? lastName)
    {
        Name = name;
        LastName = lastName;
    }
}
