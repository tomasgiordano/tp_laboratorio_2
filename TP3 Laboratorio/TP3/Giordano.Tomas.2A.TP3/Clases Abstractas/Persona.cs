using System;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido { get { return this.apellido; } set { this.apellido = ValidarNombreApellido(value); } }

        public int DNI { get { return this.dni; } set { this.dni = ValidarDni(this.nacionalidad, value); } }

        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set {this.nacionalidad=value; } }

        public string Nombre { get{ return this.nombre; } set { this.nombre=ValidarNombreApellido(value); } }

        public string StringToDNI {
            set
            {
                try
                {
                    this.dni = ValidarDni(this.Nacionalidad, value);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
        #endregion

        #region Constructores
        public Persona():this("","",ENacionalidad.Argentino)
        {
           
        }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos

        #region Sobrecargas
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.apellido + ", " + this.nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad);

            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param ENacionalidad="nacionalidad"></param>
        /// <param Dni="dato"></param>
        /// <returns>El dni en caso de ser valido</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            if(dato>99999999 || dato<1)
            {
                throw new DniInvalidoException();
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if(dato>=1&&dato<=89999999)
                    {
                        return dato;
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if(dato>=90000000&&dato<=99999999)
                    {
                        return dato;
                    }
                    break;
            }
            throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param ENacionalidad="nacionalidad"></param>
        /// <param dni="dato"></param>
        /// <returns>El dni en caso de ser valido</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxiliar;
            try
            {
                auxiliar = int.Parse(dato);
            }
            catch(Exception)
            {
                throw new DniInvalidoException();
            }
            auxiliar = int.Parse(dato);
            return ValidarDni(nacionalidad, auxiliar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param Nombre o apellido="dato"></param>
        /// <returns>El nombre/apellido en caso de ser valido</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[A-Za-z]+$");
            if (r.IsMatch(dato))
            {
                return dato;
            }
            else
            {
                return "";
            }
        }

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }
        #endregion

        #endregion
    }
}