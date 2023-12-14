using System;
using System.Collections.Generic;

namespace KursachTravel.Models;

public partial class Client
{
    public int Id { get; set; }
    public string Surname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Patronymic { get; set; }
    public string? Telephone { get; set; }
    public string? Preferences { get; set; }
    
    public string FIO
    {
        get { return $"{Surname} {Name} {Patronymic}"; }
    }
    
    public Client(string surname, string name, string patronymic, string telephone, string preferences)
    {
        this.Surname = surname;
        this.Name = name;
        this.Patronymic = patronymic;
        this.Telephone = telephone;
        this.Preferences = preferences;
    }
}
