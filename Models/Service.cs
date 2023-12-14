using System;
using System.Collections.Generic;

namespace KursachTravel.Models;

public partial class Service
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Cost { get; set; } = null!;
    public string? Duration { get; set; }
    
    public Service(string title, string cost, string duration)
    {
        this.Title = title;
        this.Cost = cost;
        this.Duration = duration;
    }
}
