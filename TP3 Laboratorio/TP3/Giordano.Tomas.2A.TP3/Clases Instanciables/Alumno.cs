using System;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Text;

namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Métodos
        public Alumno():base()
        {

        }

        public Alumno(int id,string nombre, string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }       

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            return a.claseQueToma == clase;
        }

        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            return !(a == clase);
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TOMA CLASES DE " + this.claseQueToma);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado,
        }
        #endregion
    }
}
