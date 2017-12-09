using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        List<Alumno> _alumnos;
        Universidad.EClases _clase;
        Profesor _instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        #endregion

        #region Constructores
        Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            return text.Guardar("../../../Jornada.txt", jornada.ToString());          
        }

        public static string Leer()
        {
            string aux;
            Texto text = new Texto();
            text.Leer("../../../Jornada.txt", out aux);
            return aux;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this.Clase + " POR " + this.Instructor.ToString());
            if(this.Alumnos.Count > 0)
            {
                sb.AppendLine("ALUMNOS:");
                foreach (Alumno a in this.Alumnos)
                    sb.AppendLine(a.ToString());
            }            
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alu in j.Alumnos)
                if (alu == j.Clase)
                    return true;
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                throw new AlumnoRepetidoException();
            else
                j.Alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
