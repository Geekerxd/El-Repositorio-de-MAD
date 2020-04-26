using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Avion ovni= new Avion();
            car cCar = new car();

            ovni.vuela("Adrian");
            cCar.GasLimit=25;

            Console.WriteLine("\nEl limite del gas es: " + cCar.GasLimit);
            string[] people = new string[5];
            people[0] = "\nSantiago";
            people[1] = "Leo";
            people[2] = "Pardo";
            people[3] = "Sandra";
            people[4] = "shaoun";

            
            foreach (string cliente in people) {
                Console.WriteLine(cliente);
            }
           
            string op = "";
            Console.WriteLine("\n¿estas con ganas?\n1. m\n2. n");
            op = Console.ReadLine();

            if (op == "m")
            {
                Console.WriteLine("Sí tienes ganas");

            }
            else if (op == "n")
            {
                Console.WriteLine("No tienes ganas");
            }
            else Console.WriteLine("opcion fuera de rango");
            
            
            string person = "";
            char[] apellidos=new char[20];
            Console.WriteLine("\nPorfavor ingresa tu nombre:");
            person = Console.ReadLine();
            Console.WriteLine("mucho gusto " + person);
            Console.Read();



        }
    }
}
