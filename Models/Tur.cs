using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Windows.Controls;

namespace KursachTravel.Models;

public class Tur
{
    public int Id { get; set; }
    public  string TitleTur { get; set; } = null!;
    public  string? Description { get; set; }
    public  string? Duration { get; set; }
    
    public Tur(string titleTur, string description, string duration)
    {
        this.TitleTur = titleTur;
        this.Description = description;
        this.Duration = duration;
    }
    
}
