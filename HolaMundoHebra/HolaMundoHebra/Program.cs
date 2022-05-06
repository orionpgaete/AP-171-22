using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HolaMundoHebra
{
    class Program
    {
        static void ejecutar()
        {
            for (int i=0; i<10; i++)
            {
                Console.WriteLine("Hola desde hebra {0}", i);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Esto esta antes de la hebra");
            Thread t = new Thread(new ThreadStart(ejecutar));
            t.Start();
            Console.WriteLine("Esto se esta ejecutando despues de la hebra");
            Console.ReadKey();
        }
    }
}
