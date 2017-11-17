using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string path;

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
        
        public Texto(string archivo)
        {
            this.Path = archivo;
        }

        /// <summary>
        /// Guarda un dato del tipo string en un archivo de texto
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>true si lo guardó correctamente, false si tira exception</returns>
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(this.Path, true))
                {
                    writer.WriteLine(datos);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Lee linea por linea un archivo de texto y los guarda en una lista genérica
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>true si leyó correctamente el archivo, false si lanzó alguna excepción</returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(this.Path))
                {
                    while(!reader.EndOfStream)
                    {
                        datos.Add(reader.ReadLine());
                    }
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
