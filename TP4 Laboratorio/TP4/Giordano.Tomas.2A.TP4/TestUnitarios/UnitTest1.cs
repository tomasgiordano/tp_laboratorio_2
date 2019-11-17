using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Prueba si la lista de paquetes es instanciada cuando creamos un correo
        /// </summary>
        [TestMethod]
        public void ListaDePaquetesInstanciada()
        {
            Correo c = new Correo();
            Assert.AreNotEqual(c.Paquetes, null);
        }

        /// <summary>
        /// Prueba crear dos paquetes con el mismo TrackingID y que salte una excepcion especifica al hacerlo
        /// </summary>
        [TestMethod]
        public void PaquetesIgualesEnLista()
        {
            try
            {
                Correo c = new Correo();
                Paquete p1 = new Paquete("Paquete.1", "123456789");
                Paquete p2 = new Paquete("Paquete.2", "123456789");
                c += p1;
                c += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
