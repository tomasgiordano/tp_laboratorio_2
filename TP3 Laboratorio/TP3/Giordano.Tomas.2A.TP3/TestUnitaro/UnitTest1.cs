using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Archivos;
using EntidadesAbstractas;
using Clases_Instanciables;

namespace TestUnitaro
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba si se puede agregar dos alumos iguales a la misma universidad.
        /// </summary>
        [TestMethod]
        public void AlumnoRepetido()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "Ricardo", "Fort", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(1, "Ricardo", "Fort", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Universidad u = new Universidad();
                u += alumno1;
                u += alumno2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Pasa un dni invalido y comprueba si salta la excepcion.
        /// </summary>
        [TestMethod]
        public void DniInvalido()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "Tomas", "Gonzales", "99999999999999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Comprueba si un atributo de una instancia de Alumno es null 
        /// </summary>
        [TestMethod]
        public void AtributoNull()
        {
            Alumno alumno = new Alumno();
            Assert.IsNotNull(alumno.DNI);
        }

        /// <summary>
        /// Comprueba si se pasa de forma correcta el dni(string) a int
        /// </summary>
        [TestMethod]
        public void AtributosInt()
        {
            Alumno alumno1 = new Alumno(1234, "Franco", "Paez", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Assert.AreEqual(alumno1.DNI, 12345678);
        }
    }
}
