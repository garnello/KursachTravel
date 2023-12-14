using System.Text;
using System.Windows;
using KursachTravel.Models;

namespace KursachTravel.Window;

public partial class AddEditService : System.Windows.Window
{
    PostgresContext db;
    Service changeService = new Service("Название", "Цена", "Длительность");
    
    public AddEditService()
    {
        InitializeComponent();
        db = new PostgresContext();
    }

    private void ButtonSave(object sender, RoutedEventArgs e)
    {
        changeService.Title = ServiceTitle.Text;
        changeService.Cost = CostService.Text;
        changeService.Duration = DurationService.Text;
    
        StringBuilder errors = new StringBuilder();

        if (string.IsNullOrWhiteSpace(changeService.Title))
            errors.AppendLine("Укажите название тура");

        if (string.IsNullOrWhiteSpace(changeService.Cost))
            errors.AppendLine("Укажите краткое описание тура");

        if (string.IsNullOrWhiteSpace(changeService.Duration))
            errors.AppendLine("Укажите длительность тура");

        if (errors.Length > 0)
        {
            MessageBox.Show(errors.ToString());
            return;
        }
        else
        {
            db.serviceSet.Add(changeService);
            db.SaveChanges();
            this.Close();
        }
    }

    private void CancelButton(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}