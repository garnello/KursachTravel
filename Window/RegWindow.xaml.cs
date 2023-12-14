using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using KursachTravel.Models;
using KursachTravel.Models.Helper;
using Microsoft.EntityFrameworkCore;

namespace KursachTravel.Window;

public partial class RegWindow : System.Windows.Window
{
    private PostgresContext db;

    public RegWindow()
    {
        InitializeComponent();

        db = new PostgresContext();
    }

    private void LogButton(object sender, RoutedEventArgs e)
    {
        LogWindow logWindow = new LogWindow();
        logWindow.Show();
        Hide();
    }

    private void RegButton(object sender, RoutedEventArgs e)
    {

        string login = log.Text.Trim();
        string password = pas.Password.Trim();
        string repeatingPassword = repeatingPas.Password.Trim();

        if (repeatingPassword != password)
        {
            MessageBox.Show("Пароли не совпадают!");
            repeatingPas.Background = Brushes.Red;
            return;
        }

        ValidPas vp = new ValidPas();
        if (vp.ValidationPas(password) == false)
        {
            return;
        }

        ValidLog vl = new ValidLog();
        if (vl.ValidationLog(login) == false)
        {
            return;
        }
        else
        {
            try
            {
                pas.Password = HashPasswordHelper.HashPassword(password);
                Regist regist = new Regist(log.Text, password);
                db.registSet.Add(regist);
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!");
            }
            finally
            {
                MessageBox.Show("Регистрация прошла успешно!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();
            }
        }
    }
}