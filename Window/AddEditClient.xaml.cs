using System.Text;
using System.Windows;
using KursachTravel.Models;

namespace KursachTravel.Window;

public partial class AddEditClient : System.Windows.Window
{
    PostgresContext db;
    Client newClient = new Client("Фамилия", "Имя", "Отчество", "Телефон", "Пожелания");
    
    public AddEditClient()
    {
        InitializeComponent();
        db = new PostgresContext();
    }
    
    private void ButtonSave(object sender, RoutedEventArgs e)
    {
        
        newClient.Surname = Surname.Text;
        newClient.Name = Name.Text;
        newClient.Patronymic = Patronymic.Text;
        newClient.Telephone = Telephone.Text;
        newClient.Preferences = Preferences.Text;
    
        StringBuilder errors = new StringBuilder();

        if (string.IsNullOrWhiteSpace(newClient.Surname))
            errors.AppendLine("Укажите фамилию");

        if (string.IsNullOrWhiteSpace(newClient.Name))
            errors.AppendLine("Укажите имя");

        if (string.IsNullOrWhiteSpace(newClient.Name))
            errors.AppendLine("Укажите номер телефон");
        
        if (errors.Length > 0)
        {
            MessageBox.Show(errors.ToString());
            return;
        }
        else
        {
            db.clientsSet.Add(newClient);
            db.SaveChanges();
            this.Close();
        }
    }

    private void CancelButton(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}