using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set 
            {
                this.alumnos = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set 
            {
                this.jornada = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                if (!object.ReferenceEquals(this.jornada[i], null) && i >= 0 && i <= this.jornada.Count)
                    return this.Jornadas[i];
                else
                    return null;
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion        

        #region Metodos
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("../../../Universidad.xml", gim);
        }

        public static string Leer()
        {
            Universidad aux;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("../../../Universidad.xml", out aux);
            return aux.ToString();
        }

        static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("JORNADA:");
            foreach (Jornada j in gim.Jornadas)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<------------------------------------------------------------------->\n");
            }                
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            if(!object.ReferenceEquals(g.Alumnos, null))
                foreach (Alumno alu in g.Alumnos)
                    if (!object.ReferenceEquals(alu,null) && alu == a)
                        return true;
            return false;
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
                if (p == clase)
                    return p;
            throw new SinProfesorException();
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profe in g.Instructores)
                if (profe == i)
                    return true;
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
                if (p != clase)
                    return p;
            throw new SinProfesorException();
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();
            else
                g.Alumnos.Add(a);
            return g;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada j = new Jornada(clase, g == clase);
                g.Jornadas.Add(j);
                foreach (Alumno a in g.Alumnos)
                    if (a == clase)
                        j.Alumnos.Add(a);
                return g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.Instructores.Add(i);
            return g;
        }
        #endregion
    }
}
