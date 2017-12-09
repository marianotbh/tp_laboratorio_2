using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        string _apellido;
        int _dni;
        ENacionalidad _nacionalidad;
        string _nombre;
                
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);
                }
                catch(DniInvalidoException e)
                {
                    throw e;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.StringToDNI = dni;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        #endregion

        #region Metodos
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato > 89999999 && dato < 100000000)
            {
                return dato;
            }
            else
                throw new NacionalidadInvalidaException();
        }

        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            dato.Replace("[^0-9]", "");
            if (dato.Length >= 7 && dato.Length <= 8 && int.TryParse(dato, out aux))
            {
                aux = ValidarDni(nacionalidad, aux);
                return aux;
            }
            else
                throw new DniInvalidoException();
        }

        string ValidarNombreApellido(string dato)
        {
            if (dato.Length > 0 && Regex.IsMatch(dato, @"^[a-zA-Záéíóú]+$"))
            {
                return dato;
            }
            else
                return "";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} \n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0} - DNI: {1}", this.Nacionalidad, this.DNI);
            return sb.ToString();
        }
        #endregion
    }
}
