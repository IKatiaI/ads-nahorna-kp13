using System;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        int temp, year;
        Write("Рік: "); year = Convert.ToInt32(ReadLine());
        int y = year % 100;
        int c = year / 100;
        for (int m = 1; m <= 12; m++)
        {
            switch (m)
            {
                case 1:
                    Write("Березень ");
                    break;
                case 2:
                    Write("Квітень  ");
                    break;
                case 3:
                    Write("Травнь  ");
                    break;
                case 4:
                    Write("Червень ");
                    break;
                case 5:
                    Write("Липень ");
                    break;
                case 6:
                    Write("Српень ");
                    break;
                case 7:
                    Write("Вересень ");
                    break;
                case 8:
                    Write("Жовтень ");
                    break;
                case 9:
                    Write("Листопад ");
                    break;
                case 10:
                    Write("Грудень ");
                    break;
                case 11:
                    Write("Січень ");
                    break;

                default:
                    Write("Лютий ");
                    break;
            }
            temp = 4 - (int)(2.6 * m - 0.2) - y - y / 4 - c / 4 + 2 * c;
            if (temp > 31)
                while (temp > 31)
                    temp = temp - 7;
            else if (temp < 25)
            {
                while (temp < 25)
                    temp = temp + 7;
            }
            WriteLine(temp);
        }
    }
}