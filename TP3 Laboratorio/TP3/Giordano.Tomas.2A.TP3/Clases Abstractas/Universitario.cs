using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Metodos

        #region Sobrecargas
        public override bool Equals(object obj)
        {
            if(this.DNI==((Universitario)obj).DNI||this.legajo==((Universitario)obj).legajo)
            {
                return true;
            }
            return false;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo);

            return sb.ToString();
        }

        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1.Equals(pg2));
        }
        #endregion

        protected abstract string ParticiparEnClase();

        #region Constructores
        public Universitario():base()
        {

        }

        public Universitario(int legajo, string nombre,string apellido,string dni,ENacionalidad nacionalidad)
        {
            this.legajo = legajo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        #endregion

        #endregion
    }
}
