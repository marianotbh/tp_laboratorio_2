using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDNIInvalidoException()
        {
            /* DNI muy largo Fuera de rango */
            try
            {
                Persona p = new Alumno(1, "Pepito", "Jones", "10000000000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            /* DNI muy corto fuera de rango */
            try
            {
                Persona p = new Alumno(1, "Pepito", "Jones", "", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            /* DNI invalido */
            try
            {
                Persona p = new Alumno(1, "Pepito", "Jones", "lalala no soy un dni" , Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }            
        }

        [TestMethod]
        public void TestNacionalidadInvalidaException()
        {
            /* DNI menor a lo aceptado para extranjero */
            try
            {
                Persona p = new Alumno(1, "Pepito", "Jones", "10000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            /* DNI mayor a lo aceptado para argentino */
            try
            {
                Persona p = new Alumno(1, "Pepito", "Jones", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestValorNumerico()
        {
            int intDNI = 10000000;
            string stringDNI = "10000000";

            Alumno a = new Alumno();
            a.DNI = intDNI;
            Assert.AreEqual<int>(intDNI, a.DNI);
            a.StringToDNI = stringDNI;
            Assert.AreEqual<int>(10000000, a.DNI);
        }

        [TestMethod]
        public void TestValoresNulos()
        {
            Persona p = new Profesor(1, "Profesor", "Girafales", "90000000", Persona.ENacionalidad.Extranjero);
            Assert.IsNotNull(p);
            Assert.AreEqual<string>("Profesor", p.Nombre);
            Assert.AreEqual<string>("Girafales", p.Apellido);
            Assert.AreEqual<int>(90000000, p.DNI);
            Assert.AreEqual<Persona.ENacionalidad>(Persona.ENacionalidad.Extranjero, p.Nacionalidad);
        }
    }
}
