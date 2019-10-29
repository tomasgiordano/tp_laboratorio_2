using System;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace Clases_Abstractas
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
                catch
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("NOMBRE COMPLETO: " + this.apellido + ", " + this.nombre);
            cadena.AppendLine("NACIONALIDAD: " + this.nacionalidad);

            return cadena.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            if(dato >= 1 && dato <= 89999999)
            {
                if(nacionalidad==ENacionalidad.Argentino)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if(dato > 89999999 && dato <= 99999999)
            {
                if(nacionalidad==ENacionalidad.Extranjero)
                {
                    return dato;
                }
                else
                {
                    throw new ENacionalidadInvalidaException();
                }
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxiliar = int.Parse(dato);
            return ValidarDni(nacionalidad, auxiliar);
        }

        private string ValidarNombreApellido(string dato)
        {
            Regex reg = new Regex("^[A-Za-z]+$");
            if (reg.IsMatch(dato))
            {
                return dato;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
