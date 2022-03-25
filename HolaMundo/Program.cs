using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola Mundo");
            Console.WriteLine("Ingrese nombre");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese edad");
            string edadTx = Console.ReadLine().Trim();
            int edad = -1;
            bool esValido = Int32.TryParse(edadTx, out edad);
            if (!esValido)
            {
                Console.WriteLine("Ingrese bien la edad");
            }
            else
            {
                Console.WriteLine("Su nombre es : {0} su edad es {1}", nombre, edad);
            }
   
/*
            try
            {
                string num = "12";
                int num2 = Convert.ToInt32(num);
                return true;
            }catch(Exception ex)
            {
                return false;
            }

            string num = "12";
            int num2;
            bool esValido = int.TryParse(num, out num2);
*/



            
            Console.ReadKey();
        }
    }
}
