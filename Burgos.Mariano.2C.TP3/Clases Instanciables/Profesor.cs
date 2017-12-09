using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Profesor : Universitario
    {
        Queue<Universidad.EClases> _clasesDelDia;
        static Random _random;

        #region Constructores
        static Profesor() 
        {
            _random = new Random();
        }

        public Profesor()
        { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }
        #endregion

        #region Metodos
        void _randomClase()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases clase in _clasesDelDia)
            {
                sb.AppendFormat("{0}\n", clase);
            }
            return String.Format("CLASES DEL DIA:\n{0}", sb.ToString());
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i._clasesDelDia)
                if (clase == c)
                    return true;
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
