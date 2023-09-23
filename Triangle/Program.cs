using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Triangle
{
    
    internal class Program
    {
        static void Main()
        {
            string template = "{Timestamp:HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: template)
                .WriteTo.File("logs/file_.txt", outputTemplate: template)
                .CreateLogger();

            string a = "3";
            string b = "4";
            string c = "5";
            Mathtriangle mathtriangle = new Mathtriangle();
            mathtriangle.Start(a, b, c);
            Console.ReadKey();
            Log.CloseAndFlush();
        }
    }
}
