using System;
using System.Collections.Generic;
using System.Text;
using Archivos;
using Excepciones;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }

        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }

        public Jornada this[int i]{ get { return this.jornada[i]; } }
        #endregion

        #region Métodos
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> exportar = new Xml<Universidad>();
            return exportar.Guardar("Universidad.xml", uni);
        }

        public static Universidad Leer(Universidad uni)
        {
            Xml<Universidad> importar = new Xml<Universidad>();
            Universidad UniversidadAux;
            importar.Leer("Universidad.txt", out UniversidadAux);
            return UniversidadAux;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada t in uni.jornada)
            {
                sb.Append(t);
            }
            return sb.ToString();
        }

        public static bool operator ==(Universidad g,Alumno a)
        {
            if (!Object.Equals(g, null)&&!Object.Equals(a,null))
            {
                if(g.Alumnos.Contains(a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }

        public static bool operator ==(Universidad g,Profesor i)
        {
            return g.Instructores.Contains(i);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }

        public static Profesor operator ==(Universidad u,EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                {
                    if (!Object.Equals(p, null))
                    {
                        return p;
                    }                    
                }
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            return null;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jor = new Jornada(clase, (g == clase));
            foreach (Alumno t in g.Alumnos)
            {
                if (t == clase)
                {
                    jor.Alumnos.Add(t);
                }
            }
            g.Jornadas.Add(jor);
            return g;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u!=i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u!=a)
            {
                u.Alumnos.Add(a);
                return u;
            }

            throw new AlumnoRepetidoException(); 
        }


        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        public enum EClases
        {
            Programacion = 0,
            Laboratorio = 1,
            Legislacion = 2,
            SPD = 3,
        }

        #endregion
    }
}
