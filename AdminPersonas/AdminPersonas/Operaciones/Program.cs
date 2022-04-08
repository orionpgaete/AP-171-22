﻿using AdminPersonasModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPersonas
{
    public partial class Program
    {
        static IPersonasDAL personasDAL = new PersonasDALArchivos();
        static void MostrarPersonas()
        {
            List<Persona> personas = personasDAL.ObtenerPersonas();
            for (int i=0; i < personas.Count(); i++)
            {
                Persona actual = personas[i];
                Console.WriteLine("{0}: Nombre : {1} Peso : {2}", i, actual.Nombre, actual.Peso);
            }
        }

        static void BuscarPersona()
        {
            Console.WriteLine("Ingrese nombre:");
            List<Persona> filtradas = personasDAL.FiltrarPersonas(Console.ReadLine().Trim());
            filtradas.ForEach(p => Console.WriteLine("Nombre: {0} Peso:{1}", p.Nombre, p.Peso));
        }
        static void IngresarPersona()
        {
            string nombre;
            uint telefono;
            double peso;
            double estatura;

            Console.WriteLine("Bienvenido al SW Ultradistinto y mas BKN");

            bool esValido;

            do
            {
                Console.WriteLine("Ingrese Telefono");
                //string tel = Console.ReadLine().Trim();
                //esValido = UInt32.TryParse(tel, out telefono);
                esValido = UInt32.TryParse(Console.ReadLine().Trim(), out telefono);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese Peso");
                esValido = Double.TryParse(Console.ReadLine().Trim(), out peso);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese estatura");
                esValido = Double.TryParse(Console.ReadLine().Trim(), out estatura);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese nombre");
                nombre = Console.ReadLine().Trim();

            } while (nombre.Equals(string.Empty));
            //nombre == string.Empty

            Persona p = new Persona() { 
            Nombre = nombre, Estatura = estatura, 
            Telefono = telefono, Peso = peso
            };
            /*  p.Nombre = nombre;
              p.Estatura = estatura;
              p.Peso = peso;
              p.Telefono = telefono;*/

            p.calcularImc();
            personasDAL.AgregarPersona(p);

            Console.WriteLine("Nombre : {0}", p.Nombre);
            Console.WriteLine("Telefono : {0}", p.Telefono);
            Console.WriteLine("Peso : {0}", p.Peso);
            Console.WriteLine("Estatura : {0}", p.Estatura);
            Console.WriteLine("IMC : {0}", p.IMC.Texto);
            Console.ReadKey();


        }
    }
}
