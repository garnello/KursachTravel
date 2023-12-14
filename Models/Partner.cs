using System;
using System.Collections.Generic;

namespace KursachTravel.Models;

public partial class Partner
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string? Email { get; set; }
    
    public Partner(string title, string telephone, string email)
    {
        this.Title = title;
        this.Telephone = telephone;
        this.Email = email;
    }
}
