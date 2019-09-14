using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain
{
    public class ConsoleOutputService : IOutputService
    {
        public void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public void PrintOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}
