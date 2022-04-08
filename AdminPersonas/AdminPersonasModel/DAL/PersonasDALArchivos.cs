using AdminPersonas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPersonasModel.DAL
{
    public class PersonasDALArchivos : IPersonasDAL
    {
        private static string archivo = "personas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;
        //C:/users/sistema/visual/......./personas.txt
        public void AgregarPersona(Persona persona)
        {
            //1. crear el archivo con Streamwriter
            //2. agreagr una linea al archivo
            //3. Cerrar el archivo
            try
            {
                using (StreamWriter write = new StreamWriter(ruta, true))
                {
                    string texto = persona.Nombre + ";" + persona.Estatura + ";" //CSV
                                 + persona.Telefono + ";" + persona.Peso + ";";
                    write.WriteLine(texto);
                    write.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al escribir el archivo" + ex.Message);
            }
        }

        public List<Persona> FiltrarPersonas(string nombre)
        {
            return ObtenerPersonas().FindAll(p => p.Nombre == nombre);
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();
            using (StreamReader reader = new StreamReader(ruta))
            {
                //Leer desde el archivo hasta que no haya nada
                string texto;
                do
                {
                    texto = reader.ReadLine();
                    if (texto != null)
                    {
                        string[] textoArr = texto.Trim().Split(';');
                        string nombre = textoArr[0];
                        double estatura = Convert.ToDouble(textoArr[1]);
                        uint telefono = Convert.ToUInt32(textoArr[2]);
                        double peso = Convert.ToDouble(textoArr[3]);

                        //crear persona
                        Persona p = new Persona()
                        {
                            Nombre = nombre,
                            Estatura = estatura,
                            Peso = peso,
                            Telefono = telefono
                        };
                        //calcular IMC
                        p.calcularImc();

                        //agregar a la lista
                        personas.Add(p);
                    }           

                } while (texto != null);
               
            }
            return personas;
        }
    }
}
