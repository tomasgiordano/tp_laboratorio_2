using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(archivo, true);
                ser.Serialize(sw, datos);

                sw.Close();
                return true;
            }
            catch(ArchivosException e)
            {
                throw e.InnerException;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivo, true);
                datos=(T)ser.Deserialize(sr);

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
