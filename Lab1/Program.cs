using System;
using System.Collections.Generic;
using System.IO;
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
            public void ReusltFind()
            {
                if ((a == b) && (b == c))
                {
                    triangleResult = "Треугольник: равносторонний";
                    double cos_a = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
                    double sin_a = Math.Sqrt(1 - Math.Pow(cos_a, 2));
                    x_c = cos_a * a;
                    y_c = sin_a * b;
                }
                else if (((a==b)&&(a!=c))||((a==c)&&(a!=b)))
                {
                    triangleResult = "Треугольник: равнобедренный";
                    double cos_a = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
                    double sin_a = Math.Sqrt(1 - Math.Pow(cos_a, 2));
                    x_c = cos_a * a;
                    y_c = sin_a * b;
                }
                else
                {
                    if ((a >= b + c) || (b >= a + c) || (c >= a + b))
                    {
                        triangleResult = "Треугольник: это не треугольник";
                        x_a = -1;
                        y_a = -1;
                        x_b = -1;
                        y_b = -1;
                        x_c = -1;
                        y_c = -1;
                    }
                    else
                    {
                        triangleResult = "Треугольник: разносторонний треугольник";
                        double cos_a = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
                        double sin_a = Math.Sqrt(1 - Math.Pow(cos_a, 2));
                        x_c = cos_a * a;
                        y_c = sin_a * b;
                    }
                }
            }
        }
        static void LogGing(string s)
        {
            string path = "log.txt";
            string fullPath = Path.GetFullPath(path);
            if (File.Exists(fullPath))
            {
                File.AppendAllText(fullPath, s);
            }
            else
            {
                File.Create(fullPath).Close();
                File.AppendAllText(fullPath, s);
            }
        }

        static void Main()
        {
            while (true) 
            {
                List<string> list = new List<string>();
                double sideA, sideB, sideC;
                string result_mes;
                try
                {
                    list.Clear();
                    Console.Write("Введите длину стороны A: ");
                    sideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите длину стороны B: ");
                    sideB = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите длину стороны C: ");
                    sideC = Convert.ToDouble(Console.ReadLine());
                    Mathtriangle mt = new Mathtriangle(sideA, sideB, sideC);
                    mt.ReusltFind();
                    list.Add(mt.x_a + " , " + mt.y_a);
                    list.Add(mt.x_b + " , " + mt.y_b);
                    list.Add(mt.x_c + " , " + mt.y_c);
                    Console.WriteLine("___________________________________________");
                    DateTimeOffset dateTime = DateTimeOffset.Now;
                    Console.WriteLine(Convert.ToString(dateTime));
                    Console.WriteLine(mt.triangleResult);
                    Console.WriteLine("Введенные стороны: A = {0}; B = {1}; C = {2}", sideA, sideB, sideC);
                    Console.WriteLine("Координаты A: {0}\nКоординаты B: {1}\nКоординаты C: {2}", list[0], list[1], list[2]);
                    Console.WriteLine("___________________________________________");
                    result_mes = Convert.ToString(dateTime) + "\n" + mt.triangleResult + "\n" + "Введенные стороны: A = " + sideA + "; B = " + sideB + "; C = " + sideC + "\n" + "Координаты A: " + list[0] + "\nКоординаты B: " + list[1] + "\nКоординаты C: " + list[2] + "\n" + "___________________________________________" + "\n";
                    LogGing(result_mes);
                }
                catch (System.FormatException)
                {
                    System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
                    Console.WriteLine("___________________________________________");
                    DateTimeOffset dateTime = DateTimeOffset.Now;
                    Console.WriteLine(Convert.ToString(dateTime));
                    Console.WriteLine("Вы ввели данные не того формата.");
                    list.Add("-2,-2");
                    list.Add("-2,-2");
                    list.Add("-2,-2");
                    Console.WriteLine("Координаты A: {0}\nКоординаты B: {1}\nКоординаты C: {2}", list[0], list[1], list[2]);
                    Console.WriteLine("___________________________________________");
                    result_mes = Convert.ToString(dateTime) + "\nВы ввели данные не того формата.\n" + "Координаты A: " + list[0] + "\nКоординаты B: " + list[1] + "\nКоординаты C: " + list[2] + "\n"+ Convert.ToString(t) + "___________________________________________" + "\n";
                    LogGing(result_mes);
                    list.Clear();
                }
            }
        }
    }
}
