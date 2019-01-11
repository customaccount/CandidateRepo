using CandidateRepo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleInterface.Initialize();
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleInterface.StartInterface();
        }
    }
}
