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
        private string triangleResult;

        private void ResultFind()
        {

            if ((sidesList[0] == sidesList[1]) && (sidesList[1]==sidesList[2]))
            {
                float cos_a = Convert.ToSingle((Math.Pow(sidesList[1], 2) + Math.Pow(sidesList[2], 2) - Math.Pow(sidesList[0], 2)) / (2 * sidesList[1] * sidesList[2]));
                float sin_a = Convert.ToSingle(Math.Sqrt(1 - Math.Pow(cos_a, 2)));
                coordList.Add("0, 0");
                coordList.Add(sidesList[0] + ", 0");
                coordList.Add(Convert.ToString(cos_a * sidesList[0])+Convert.ToString(sin_a*sidesList[1]));
                triangleResult = "Треугольник: равносторонний";
                Log.Information(triangleResult + "\n" + coordList + "\n__________________________________________\n");
            }
            else if (((sidesList[0] == sidesList[1]) && (sidesList[0] != sidesList[2])) || ((sidesList[0] == sidesList[2]) && (sidesList[0] != sidesList[1])))
            {
                float cos_a = Convert.ToSingle((Math.Pow(sidesList[1], 2) + Math.Pow(sidesList[2], 2) - Math.Pow(sidesList[0], 2)) / (2 * sidesList[1] * sidesList[2]));
                float sin_a = Convert.ToSingle(Math.Sqrt(1 - Math.Pow(cos_a, 2)));
                coordList.Add("0, 0");
                coordList.Add(sidesList[0] + ", 0");
                coordList.Add(Convert.ToString(cos_a * sidesList[0]) + Convert.ToString(sin_a * sidesList[1]));
                triangleResult = "Треугольник: равнобедренный";
                Log.Information(triangleResult + "\n" + coordList + "\n__________________________________________\n");
            }
            else
            {
                if ((sidesList[0] >= sidesList[1] + sidesList[2]) || (sidesList[1] >= sidesList[0] + sidesList[2]) || (sidesList[2] >= sidesList[0] + sidesList[1]))
                {
                    coordList.Add("-1, -1");
                    coordList.Add("-1, -1");
                    coordList.Add("-1, -1");
                    triangleResult = "Треугольник: это не треугольник";
                    Log.Information(triangleResult + "\n" + coordList + "\n__________________________________________\n");
                }
                else
                {
                    float cos_a = Convert.ToSingle((Math.Pow(sidesList[1], 2) + Math.Pow(sidesList[2], 2) - Math.Pow(sidesList[0], 2)) / (2 * sidesList[1] * sidesList[2]));
                    float sin_a = Convert.ToSingle(Math.Sqrt(1 - Math.Pow(cos_a, 2)));
                    coordList.Add("0, 0");
                    coordList.Add(sidesList[0] + ", 0");
                    coordList.Add(Convert.ToString(cos_a * sidesList[0]) + Convert.ToString(sin_a * sidesList[1]));
                    triangleResult = "Треугольник: равносторонний";
                    Log.Information(triangleResult + "\n" + coordList + "\n__________________________________________\n");
                }
            }

        }


        public (string,string) Start(string a, string b, string c)
        {
                sidesList.Clear();
                coordList.Clear();
                try
                {
                    sidesList.Add(float.Parse(a));
                    sidesList.Add(float.Parse(b));
                    sidesList.Add(float.Parse(c));
                    ResultFind();
                return (triangleResult, coordList[0]);
            }
                catch (Exception ex)
                {
                    triangleResult = "";
                    coordList.Add("-2, -2");
                    coordList.Add("-2, -2");
                    coordList.Add("-2, -2");
                    triangleResult = "";
                Log.Information(triangleResult + "\n" + coordList + "\n__________________________________________\n");
                    Log.Error(ex, "Что-то пошло не так...");
                return (triangleResult, coordList[0]);
            }
        }
    }
}
