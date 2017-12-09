using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region Constructores
        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO: " + this.legajo);
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public override bool Equals(object obj)
        {
            return (this == obj);
        }
        static public bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((pg1.GetType() == pg2.GetType()) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
                return true;
            else
                return false;
        }
        static public bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
