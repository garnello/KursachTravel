using System.Text.RegularExpressions;
using System.Windows;

namespace KursachTravel.Models.Helper;

public class ValidLog
{
    public bool ValidationLog(string log)
    {
        var inLog = log;

        if (string.IsNullOrWhiteSpace(inLog))
        {
            MessageBox.Show("Поле с логином пустое", "Ошибка!");
            return false;
        }
        
        var hasNum = new Regex(@"[0-9]+");
        var hasUpChar = new Regex(@"[A-Z]+");
        var hasLowerChar = new Regex(@"[a-z]+");

        if (!hasNum.IsMatch(inLog))
        {
            MessageBox.Show("Логин должен содержать одну цифру", "Ошибка!");
            return false;
        }
        else if (!hasUpChar.IsMatch(inLog))
        {
            MessageBox.Show("Логин должен содержать одну заглавную букву", "Ошибка!");
            return false;
        }
        else if (!hasLowerChar.IsMatch(inLog))
        {
            MessageBox.Show("Логин должен содержать одну строчную букву", "Ошибка!");
            return false;
        }
        else return true;
    }
}