using MedidoresModel.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class LecturaDALArchivos : ILecturaDAL
    {
        //CONSTRUCTOR
        private LecturaDALArchivos()
        {

        }

        private static LecturaDALArchivos instancia;
        private static List<Medidor> medidores = new List<Medidor>();
        //IMPLEMENTANDO SINGLETON
        public static ILecturaDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new LecturaDALArchivos();
            }
            return instancia;
        }


        private static string archivo = "lectura.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;

        
        public void AgregarMedidor(Medidor m)
        {
           medidores.Add(m);
        }

        public List<Medidor> ObtenerMedidores()
        {
            return medidores;
        }

        public void AgregarLectura(Lectura lectura)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                 writer.WriteLine(
                }
               
            }catch (Exception ex)
            {
                Console.WriteLine("ERROR");
            }
        }

        public List<Lectura> ObtenerLecturas(Lectura lectura)
        {
            throw new NotImplementedException();
        }

       


        /*public List<Medidor> ObtenerMedidor() 
{

}*/
    }
    /* public List<Lectura> ObtenerLectura()
     {
         List<Lectura> lista = new List<Lectura>();
         try
         {
             using (StreamReader reader = new StreamReader(archivo))
             {
                 string texto = "";
                 do
                 {
                     texto = reader.ReadLine();
                     if (texto != null)
                     {
                         string[] arr = texto.Trim().Split(';');
                         Lectura mensaje = new Lectura()
                         {
                             NroMedidor = arr[0],
                             Fecha = arr[1],
                             ValorConsumo = arr[2]
                         };
                         lista.Add(mensaje);
                     }
                 } while (texto != null);
             }
         }
         catch (Exception ex)
         {

         }
     }*/
}
