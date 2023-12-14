using System.Text;
using System.Windows;
using KursachTravel.Models;

namespace KursachTravel.Window;

public partial class AddEditPartner : System.Windows.Window
{
    PostgresContext db;
    Partner changePartner = new Partner("Название", "Телефон", "Почта");
    
    public AddEditPartner()
    {
        InitializeComponent();
        db = new PostgresContext();
    }

    private void ButtonSave(object sender, RoutedEventArgs e)
    {
        changePartner.Title = PartnerTitle.Text;
        changePartner.Telephone = TelephonePartner.Text;
        changePartner.Email = EmailPartner.Text;
    
        StringBuilder errors = new StringBuilder();

        if (string.IsNullOrWhiteSpace(changePartner.Title))
            errors.AppendLine("Укажите название");

        if (string.IsNullOrWhiteSpace(changePartner.Telephone))
            errors.AppendLine("Укажите телефон партнера");

        if (errors.Length > 0)
        {
            MessageBox.Show(errors.ToString());
            return;
        }
        else
        {
            db.partnerSet.Add(changePartner);
            db.SaveChanges();
            this.Close();
        }
    }

    private void CancelButton(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}