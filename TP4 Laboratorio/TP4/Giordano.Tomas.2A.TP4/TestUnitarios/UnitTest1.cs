using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaDePaquetesInstanciada()
        {
            Correo c = new Correo();
            Assert.AreNotEqual(c.Paquetes, null);
        }

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
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
