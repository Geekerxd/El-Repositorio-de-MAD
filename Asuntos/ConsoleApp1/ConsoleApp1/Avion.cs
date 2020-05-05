using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Avion
    {
        public int time=0;

        /// <summary>
        /// funcion para empezar a volar
        /// </summary>
        /// <param name="nombrePiloto"> Nombre del piloto </param>
        public void vuela(string nombrePiloto) {
            
            Console.WriteLine("\"empieza a volar\" con: "+nombrePiloto);
        }



    }
}
