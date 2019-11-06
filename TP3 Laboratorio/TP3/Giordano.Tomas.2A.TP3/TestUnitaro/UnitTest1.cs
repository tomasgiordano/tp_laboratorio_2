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

        [TestMethod]
        public void AtributoNull()
        {
            Alumno alumno = new Alumno();
            Assert.IsNotNull(alumno.Nombre);
        }
    }
}
