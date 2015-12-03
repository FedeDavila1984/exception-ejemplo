using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ruta de la carpeta. Uso el escritorio del usuario.
            string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Agrego una subcarpeta a la ruta
            string ruta = System.IO.Path.Combine(carpeta, "Sub Carpeta");

            // Creo el directorio, si no existe.
            System.IO.Directory.CreateDirectory(ruta);

            // Creo un nombre de archivo.
            string archivo = "Mi Primer Archivo.txt";

            // Agrego el archivo a la ruta
            ruta = System.IO.Path.Combine(ruta, archivo);

            // Imprimo la ruta de mi primer archivo
            Console.WriteLine("Ruta del archivo: {0}\n", ruta);

            // Compruebo que el archivo no exista.
            // Si el archivo no existe, agrego datos
            if (!System.IO.File.Exists(ruta))
            {
                StreamWriter outfile = new StreamWriter(ruta);
                outfile.Write("NUEVO ARCHIVO DE TEXTO");
                outfile.Close();
            }
            else
            {
                Console.WriteLine("El archivo \"{0}\" ya existe.", archivo);
            }

            // Leo y muestro el contenido de mi primer archivo
            try
            {
                StreamReader infile = new StreamReader(ruta);
                Console.Write(infile.ReadToEnd());
                infile.Close();

                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Presiones una tecla para finalizar...");
            System.Console.ReadKey();
        }
    }
}
