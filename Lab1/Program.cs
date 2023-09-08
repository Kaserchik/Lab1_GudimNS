using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        

        static void Main()
        {
            while (true) 
            {
                List<string> list = new List<string>();
                try
                {
                    Console.Write("Введите длину стороны A: ");
                    double sideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите длину стороны B: ");
                    double sideB = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите длину стороны C: ");
                    double sideC = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Координаты A: {0}\nКоординаты B: {1}\nКоординаты C: {2}", list[0], list[1], list[2]);
                    Console.WriteLine("___________________________________________");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine("Вы ввели данные не того формата.");
                    list.Add("-2,-2");
                    list.Add("-2,-2");
                    list.Add("-2,-2");
                    Console.WriteLine("Координаты A: {0}\nКоординаты B: {1}\nКоординаты C: {2}", list[0], list[1], list[2]);
                    Console.WriteLine("___________________________________________");
                    list.Clear();
                }
            }
        }
    }
}
