using System.Windows;
using System.Windows.Media;
using KursachTravel.Models;

namespace KursachTravel.Window;

public partial class LogWindow : System.Windows.Window
{
    public LogWindow()
    {
        InitializeComponent();
    }

    private void LogButton(object sender, RoutedEventArgs e)
    {
        string login = log.Text.Trim();
        string password = pas.Password.Trim();
        
        if (login.Length < 5)
        {
            log.ToolTip = "Поле логина введено не корректно!";
            log.Background = Brushes.DarkRed;
        }

        else
        {
            log.ToolTip = "Поле введено корректно!";
            log.Background = Brushes.White;
        }

        if (password.Length < 5)
        {
            pas.ToolTip = "Пароль введен не корректно!";
            pas.Background = Brushes.DarkRed;
        }

        else
        {
            pas.ToolTip = "Поле введено корректно!";
            pas.Background = Brushes.White;
        }

        Regist authUser = null;
        using (PostgresContext db = new PostgresContext())
        {
            authUser = db.registSet.Where((b => b.login == login && b.password == password)).FirstOrDefault( );
        }

        if (authUser != null)
        {
            MessageBox.Show("Авторизация прошла успешно!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль!");
        }
    }

    private void RegButton(object sender, RoutedEventArgs e)
    {
        RegWindow regWindow = new RegWindow();
        regWindow.Show();
        Hide();
    }
}