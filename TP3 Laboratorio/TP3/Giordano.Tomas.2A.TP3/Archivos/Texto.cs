using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si se pudo guardar</returns>
        public bool Guardar(string archivo,string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);
                sw.WriteLine(datos);
                sw.Close();
                return true;
            }
            catch(ArchivosException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si lo pudo leer</returns>
        public bool Leer(string archivo,out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo,true);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch(ArchivosException e)
            {
                throw e.InnerException;
            }
        }
    }
}
