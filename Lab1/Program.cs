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
        class Mathtriangle(double a, double b, double c)
        {
            public double x_a = 0, y_a = 0, x_b = a, y_b = 0, x_c, y_c;
            public string triangleResult;

            public void cordinationFind()
            {
                double cos_a = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
                double sin_a = Math.Sqrt(1 - Math.Pow(cos_a, 2));
                x_c = cos_a * a;
                y_c = sin_a * b;
            }
            public void reusltFind()
            {
                if ((a == b) && (b == c))
                {
                    triangleResult = "Треугольник: равносторонний";
                }
                else if (((a==b)&&(a!=c))||((a==c)&&(a!=b)))
                {
                    triangleResult = "Треугольник: равнобедренный";
                }
                else
                {
                    if ((a >= b + c) || (b >= a + c) || (c >= a + b))
                    {
                        triangleResult = "Треугольник: это не треугольник";
                    }
                    else
                    {
                        triangleResult = "Треугольник: разносторонний треугольник";
                    }
                }
            }
        }

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
                    Mathtriangle mt = new Mathtriangle(sideA, sideB, sideC);
                    mt.cordinationFind();
                    mt.reusltFind();
                    list.Add(mt.x_a + " , " + mt.y_a);
                    list.Add(mt.x_b + " , " + mt.y_b);
                    list.Add(mt.x_c + " , " + mt.y_c);
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine(mt.triangleResult);
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
