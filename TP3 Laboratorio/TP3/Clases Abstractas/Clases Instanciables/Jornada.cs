using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Archivos;

namespace Clases_Instanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }

        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }
        #endregion

        #region Métodos
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar("Jornada.txt", jornada.ToString());
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase,Profesor instructor)
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public string Leer()
        {
            Texto t = new Texto();
            string auxiliar = "";
            t.Leer("Jornada.txt", out auxiliar);
            return auxiliar;
        }

        public static bool operator ==(Jornada j,Alumno a)
        {
            if(j.Alumnos.Contains(a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j,Alumno a)
        {
            j.Alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.AppendLine("CLASE DE " + this.clase + " POR " + this.Instructor);
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno t in this.Alumnos)
            {
                sb.Append(t);
            }

            sb.AppendLine("----------------------------------------");
            return sb.ToString();
        }
        #endregion
    }
}
