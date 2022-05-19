using MedidoresModel.DAL;
using MedidoresModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionBarriga.Hebra
{
    public class HebraServidor
    {
        public HebraServidor (int puerto)
        {

        }

        public HebraServidor()
        {
        }

        private static ILecturaDAL lecturadal = LecturaDALArchivos.GetInstancia();
        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);
            Console.WriteLine("S: Iniciando servidor en puerto {0}");
            
            
            DateTime fechamedicion = DateTime.Now;
            string convertirFecha = String.Format("{0:yyy-MM-dd-HH-mm-ss}", fechamedicion);

            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("S: Esperando Cliente...");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("S: Cliente Recibido");

                    ClienteCom clienteCom = new ClienteCom(cliente);
                    clienteCom.Escribir("Ingrese el numero del medidor: ");
                    int nromedidor = int.Parse(clienteCom.Leer());
                    clienteCom.Escribir("Ingrese el valor del consumo: ");
                    double valorconsumo = double.Parse(clienteCom.Leer());
                    Medidor medidor = new Medidor()
                    {
                        NroMedidor = nromedidor,
                        Fecha = convertirFecha,
                        ValorConsumo = valorconsumo
                    };
                    
                    lecturadal.AgregarMedidor(medidor);
                    clienteCom.Escribir("Los valores se han ingresado correctamente, satisfactoriamente, enhorabuenamente");
                    clienteCom.Desconectar();
                }
            }
            else
            {
                Console.WriteLine("F, no se puede conectar al server");
            }
        }
            
    }
}
