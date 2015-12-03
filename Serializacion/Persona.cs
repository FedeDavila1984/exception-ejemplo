using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Serialization;

namespace Serializacion
{
    [Serializable()]
    class Persona : ISerializable
    {
        private string nombre;
        private string apellido;
        private long dni;
        public DateTime fechaNacimiento;

        public Persona(string nombre, string apellido, long dni, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
        }

        /// <summary>
        /// Recupero y retorno los datos de la persona en formato de texto
        /// </summary>
        /// <returns>String formateado para imprimir por el medio que se desee</returns>
        public string recuperarDatos()
        {
            StringBuilder sb = new StringBuilder();

            string nombreApellido = String.Format("{0}, {1}", this.apellido, this.nombre);
            sb.AppendLine(nombreApellido);

            string dni = String.Format("D.N.I. Nº: {0}", this.dni.ToString());
            sb.AppendLine(dni);
 
            string fechaNacimiento = String.Format("Nacido el {0} del mes {1} del año {2}", this.fechaNacimiento.Day.ToString(),
                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.fechaNacimiento.Month), this.fechaNacimiento.Year.ToString());
            sb.AppendLine(fechaNacimiento);

            sb.AppendLine("< ------------------------------------------>");
            sb.AppendLine("");

            return sb.ToString();
        }

        /// <summary>
        /// Se implementa el método para serializar los datos.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("nombre", this.nombre, typeof(string));
            info.AddValue("apellido", this.apellido, typeof(string));
            info.AddValue("dni", this.dni, typeof(long));
            info.AddValue("fechaNacimiento", this.fechaNacimiento, typeof(DateTime));

        }

        // Este constructor especial toma los datos serializados
        public Persona(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            this.nombre = (string)info.GetValue("nombre", typeof(string));
            this.apellido = (string)info.GetValue("apellido", typeof(string));
            this.dni = (long)info.GetValue("dni", typeof(long));
            this.fechaNacimiento = (DateTime)info.GetValue("fechaNacimiento", typeof(DateTime));
        }
    }
}
