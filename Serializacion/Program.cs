using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
// Add references to Soap and Binary formatters. 
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace Serializacion
{
    class Test
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();

            personas.Add(new Persona("Linus", "Torvalds", 12345678, new DateTime(1969,12,28)));
            personas.Add(new Persona("Richard", "Stallman", 56781234, new DateTime(1953, 3, 16)));

            // Nombre del archivo que crearemos
            string archivo = "datos.dat";

            IFormatter formatter = new BinaryFormatter();

            Persona aux;
            foreach (Persona p in personas)
            {
                Test.SerializeItem(archivo, formatter, p); // Serializamos un objeto.
                Console.WriteLine("Objeto serializado");

                aux = Test.DeserializeItem(archivo, formatter); // Deserializamos el mismo el objeto.
                //Imprimo la deserealización del objeto.
                Console.WriteLine(aux.recuperarDatos());
                Console.ReadKey();
            }

        }

        /// <summary>
        /// Serializamos un item
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="formatter">Interfaz de serialización</param>
        /// <param name="persona">Instancia del objeto que deseamos serializar</param>
        public static void SerializeItem(string archivo, IFormatter formatter, Persona persona)
        {
            FileStream s = new FileStream(archivo, FileMode.Create);
            formatter.Serialize(s, persona);
            s.Close();
        }

        /// <summary>
        /// Deserializamos un item
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="formatter">Interfaz de serialización</param>
        /// <returns>Retorna el objeto persona presente en el archivo</returns>
        public static Persona DeserializeItem(string archivo, IFormatter formatter)
        {
            FileStream s = new FileStream(archivo, FileMode.Open);
            Persona persona = (Persona)formatter.Deserialize(s);
            s.Close();
            return persona;
        }
    }
}
