using HolaMundoSocket.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);

            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                //Ok pude conectar
                Console.WriteLine("Sevidor iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Cliente");
                    Socket socketCliente = servidor.ObtenerCliente();
                    ClienteCom cliente = new ClienteCom(socketCliente);
                    cliente.Escribir("Hola Mundo cliente, dime tu nombre");
                    string respuesta = cliente.Leer();
                    Console.WriteLine("El cliente dice: {0}", respuesta);
                    cliente.Escribir("Chaoo lin " + respuesta);
                    cliente.Desconectar();
                }
            }
            else
            {
                Console.WriteLine("Error, el puerto {0} esta en uso", puerto);
            }
        }
    }
}
