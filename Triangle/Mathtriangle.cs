using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Triangle
{
    public class Mathtriangle
    {
        private List<float> sidesList = new List<float>();
        private List<string> coordList = new List<string>();

        public void ReusltFind()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/file_.txt")
                .CreateLogger();

            if ((sidesList[0] == sidesList[1]) && (sidesList[1]==sidesList[2]))
            {
                float cos_a = Convert.ToSingle((Math.Pow(sidesList[1], 2) + Math.Pow(sidesList[2], 2) - Math.Pow(sidesList[0], 2)) / (2 * sidesList[1] * sidesList[2]));
                float sin_a = Convert.ToSingle(Math.Sqrt(1 - Math.Pow(cos_a, 2)));
                coordList.Add("0, 0");
                coordList.Add(sidesList[0] + ", 0");
                coordList.Add(Convert.ToString(cos_a * sidesList[0])+Convert.ToString(sin_a*sidesList[1]));
                Log.Information("Треугольник: равносторонний\nКоординаты A: " + coordList[0] + "\nКоординаты B: " + coordList[1] + "\nКоординаты C: " + coordList[2] + "\n__________________________________________\n");
            }
            else if (((sidesList[0] == sidesList[1]) && (sidesList[0] != sidesList[2])) || ((sidesList[0] == sidesList[2]) && (sidesList[0] != sidesList[1])))
            {
                float cos_a = Convert.ToSingle((Math.Pow(sidesList[1], 2) + Math.Pow(sidesList[2], 2) - Math.Pow(sidesList[0], 2)) / (2 * sidesList[1] * sidesList[2]));
                float sin_a = Convert.ToSingle(Math.Sqrt(1 - Math.Pow(cos_a, 2)));
                coordList.Add("0, 0");
                coordList.Add(sidesList[0] + ", 0");
                coordList.Add(Convert.ToString(cos_a * sidesList[0]) + Convert.ToString(sin_a * sidesList[1]));
                Log.Information("Треугольник: равносторонний\nКоординаты A: " + coordList[0] + "\nКоординаты B: " + coordList[1] + "\nКоординаты C: " + coordList[2] + "\n__________________________________________\n");
            }
            else
            {
                if ((sidesList[0] >= sidesList[1] + sidesList[2]) || (sidesList[1] >= sidesList[0] + sidesList[2]) || (sidesList[2] >= sidesList[0] + sidesList[1]))
                {
                    coordList.Add("-1, -1");
                    coordList.Add("-1, -1");
                    coordList.Add("-1, -1");
                    Log.Information("Треугольник: равносторонний\nКоординаты A: " + coordList[0] + "\nКоординаты B: " + coordList[1] + "\nКоординаты C: " + coordList[2] + "\n__________________________________________\n");
                }
                else
                {
                    float cos_a = Convert.ToSingle((Math.Pow(sidesList[1], 2) + Math.Pow(sidesList[2], 2) - Math.Pow(sidesList[0], 2)) / (2 * sidesList[1] * sidesList[2]));
                    float sin_a = Convert.ToSingle(Math.Sqrt(1 - Math.Pow(cos_a, 2)));
                    coordList.Add("0, 0");
                    coordList.Add(sidesList[0] + ", 0");
                    coordList.Add(Convert.ToString(cos_a * sidesList[0]) + Convert.ToString(sin_a * sidesList[1]));
                    Log.Information("Треугольник: равносторонний\nКоординаты A: " + coordList[0] + "\nКоординаты B: " + coordList[1] + "\nКоординаты C: " + coordList[2] + "\n__________________________________________\n");
                }
            }
            Log.CloseAndFlush();
        }


        public void Start()
        {
            string template = "{Timestamp:HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: template)
                .WriteTo.File("logs/file_.txt", outputTemplate: template)
                .CreateLogger();
            while (true)
            {
                sidesList.Clear();
                coordList.Clear();
                try
                {
                    Console.Write("Введите длину стороны A: ");
                    sidesList.Add(float.Parse(Console.ReadLine()));
                    Console.Write("Введите длину стороны B: ");
                    sidesList.Add(float.Parse(Console.ReadLine()));
                    Console.Write("Введите длину стороны C: ");
                    sidesList.Add(float.Parse(Console.ReadLine()));
                    this.ReusltFind();
                }
                catch (Exception ex)
                {
                    coordList.Add("-2, -2");
                    coordList.Add("-2, -2");
                    coordList.Add("-2, -2");
                    Log.Information("Вы ввели данные не того формата.\nКоординаты A: " + coordList[0] + "\nКоординаты B: " + coordList[1] + "\nКоординаты C: " + coordList[2] + "\n");
                    Log.Error(ex, "Что-то пошло не так...");
                    Log.CloseAndFlush();
                }
            }
        }
    }
}
