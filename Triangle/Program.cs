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

            Mathtriangle mathtriangle = new Mathtriangle();
            string a = "2";
            string b = "2";
            string c = "26";
            mathtriangle.Start(a, b, c);

            Log.CloseAndFlush();
        }
    }
}
