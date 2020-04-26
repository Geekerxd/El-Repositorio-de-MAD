using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace NameConsoleApp2
{
    class Program
    {
        static void WriteFile(string Filename)
        {
            File.WriteAllText(Filename, "Hello cruel World");
        }

        static void ReadFile(string Filename)
        {
            Console.WriteLine(File.ReadAllText(Filename));
        }


        static void Main(string[] args)
        {
            string Filename = @"C:\Users\Dell 66895\Desktop\Repositorio_MAD\SolutionConsoleApp2\NameConsoleApp2\mydoc.txt";

            WriteFile(Filename);

            ReadFile(Filename);

            Console.Read();
        }
    }
}
