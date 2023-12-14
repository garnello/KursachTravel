using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace KursachTravel.Models;

public partial class Regist
{
    public int id { get; set; }
    public string login { get; set; } = null!;
    public string password { get; set; } = null!;
    
    public Regist(string login, string password)
    {
        this.login = login;
        this.password = password;
    }
}
