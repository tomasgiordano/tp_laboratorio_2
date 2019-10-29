using System;
using System.Collections.Generic;
using System.Text;

namespace Clases_Abstractas
{
    public abstract class Universitario:Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Metodos
        public override bool Equals(object obj)
        {
            if(this.DNI==((Universitario)obj).DNI||this.legajo==((Universitario)obj).legajo)
            {
                return true;
            }
            return false;
        }

        protected string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.ToString());
            cadena.AppendLine("LEGAJO NUMERO: " + this.legajo);

            return cadena.ToString();
        }

        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1.Equals(pg2));
        }

        protected abstract string ParticiparEnClase();

        #endregion
    }
}
