using AppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static App.Program;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Mars mars = new Mars(new ConsoleInputService(),new ConsoleOutputService(),new Direction());
            mars.CreateMap();
            mars.GenerateRovers();
            mars.RunRovers();

        }

    }

}
