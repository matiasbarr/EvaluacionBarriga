using EvaluacionBarriga.Hebra;
using MedidoresModel.DAL;
using MedidoresModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvaluacionBarriga
{
    internal class Program
    {

        private static ILecturaDAL lecturadal = LecturaDALArchivos.GetInstancia();

        

        static bool menu()
        { 
            bool continuar = true;
            Console.WriteLine("¿Que quiere hacer?");
            Console.WriteLine(" 1. Ingresar Lectura \n 2. Mostrar Lectura \n 3. Ingresar Medidores \n 4.Mostrar Medidores \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1": IngresarMedidor();
                    break;
                case "2": MostrarMedidores();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "0":
                    continuar = false;
                    break;
                default: Console.WriteLine("Ingrese de nuevo");
                    break;
                    
            }
            return continuar;
            
        }

        static void Main(string[] args)
        {
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (menu()) ;
            
        }

        static void IngresarMedidor()
        {

            int nromedidor;
            double valorconsumo;
            bool esValido;
            DateTime fechamedicion = DateTime.Now;

            string convertirFecha = String.Format("{0:yyy-MM-dd-HH-mm-ss}", fechamedicion);
            do
            {
                Console.WriteLine("Ingrese numero de medidor");
                esValido = Int32.TryParse(Console.ReadLine().Trim(), out nromedidor);
            } while (!esValido);    

            do
            {
                Console.WriteLine("Ingrese el Valor del Consumo");
                esValido = double.TryParse(Console.ReadLine().Trim(), out valorconsumo);
            } while (!esValido);

            Medidor m = new Medidor()
            {
                NroMedidor = nromedidor,
                Fecha = convertirFecha,
                ValorConsumo = valorconsumo

            };

            Console.WriteLine("READY");
            lecturadal.AgregarMedidor(m);

        }

       static void MostrarMedidores()
        {
            List<Medidor> medidores = lecturadal.ObtenerMedidores();
            for(int i = 0; i < medidores.Count; i++)
            {
                Medidor actual = medidores[i];
                Console.WriteLine("Numero de Medidor:{0}, Fecha de medicion: {1}, y el valor de la medicion es: {2}", actual.NroMedidor, actual.Fecha, actual.ValorConsumo);
            }
        }

        static void AgregarLecturas()
        {

        }

        static void MostrarLecturas()
        {

        }


    }
}
