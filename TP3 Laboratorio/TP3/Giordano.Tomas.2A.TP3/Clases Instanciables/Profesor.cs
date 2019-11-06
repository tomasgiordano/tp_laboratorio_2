using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    [Serializable]
    public sealed class Profesor:Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Métodos
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0,4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0,4));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            foreach(Universidad.EClases c in i.clasesDelDia)
            {
                if(c==clase)
                {
                    return true;
                }                              
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DEL DIA ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }

        public Profesor()
        {

        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
