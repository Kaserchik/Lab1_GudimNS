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
            Mathtriangle mathtriangle = new Mathtriangle();
            mathtriangle.Start();
        }
    }
}
