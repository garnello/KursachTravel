using System.Text.RegularExpressions;
using System.Windows;

namespace KursachTravel.Models.Helper;

public class ValidPas
{
    public bool ValidationPas(string password)
    {
        var inPas = password;

        if (string.IsNullOrWhiteSpace(inPas))
        {
            MessageBox.Show("Поле с паролем пустое!");
            return false;
        }

        Regex hasNum = new Regex(@"[0-9]+");
        Regex hasUpChar = new Regex(@"[A-Z]+");
        
        if (!hasUpChar.IsMatch(inPas))
        {
            MessageBox.Show("Пароль должен содержать одну заглавную букву", "Ошибка");
            return false;
        }
        else if (!hasNum.IsMatch(inPas))
        {
            MessageBox.Show("Пароль должен содержать одну цифру", "Ошибка");
            return false;
        }
        else return true;
    }
}