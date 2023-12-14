using System.ComponentModel;
using System.Text;
using System.Windows;
using KursachTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace KursachTravel.Window;

public partial class AddEditTur : System.Windows.Window
{
    PostgresContext db;
    Tur changeTur = new Tur("Название тура", "Описание", "Длительность");
    
    public AddEditTur()
    {
        InitializeComponent();
        db = new PostgresContext();
    }

    private void ButtonSave(object sender, RoutedEventArgs e)
    {
        changeTur.TitleTur = TurTitle.Text;
        changeTur.Description = DescriptionTur.Text;
        changeTur.Duration = DurationTur.Text;
    
        StringBuilder errors = new StringBuilder();

        if (string.IsNullOrWhiteSpace(changeTur.TitleTur))
            errors.AppendLine("Укажите название тура");

        if (string.IsNullOrWhiteSpace(changeTur.Description))
            errors.AppendLine("Укажите краткое описание тура");

        if (string.IsNullOrWhiteSpace(changeTur.Duration))
            errors.AppendLine("Укажите длительность тура");

        if (errors.Length > 0)
        {
            MessageBox.Show(errors.ToString());
            return;
        }
        else
        {
            db.turSet.Add(changeTur);
            db.SaveChanges();
            this.Close();
        }
    }

    private void CancelButton(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

}