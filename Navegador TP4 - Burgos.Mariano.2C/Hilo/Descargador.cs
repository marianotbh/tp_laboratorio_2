using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        /// <summary>
        /// Crea un nuevo objeto del tipo WebClient y le asigna manejadores a sus eventos,
        /// luego lanza el método DownloadStringAsync pasándole la propiedad direccion como parámetro
        /// 
        /// Tira exception si no DownloadStringAsync falla
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public delegate void ProgresoDescargaCallback(int progreso);
        public event ProgresoDescargaCallback ProgresoDL;
        public delegate void FinDescargaCallback(string html);
        public event FinDescargaCallback FinDL;

        /// <summary>
        /// Lanza el evento ProgresoDL y le pasa como parámetro el porcentaje de progreso cargado en la propiedad ProgressPercentage del parámetro "e" de la función
        /// </summary>
        /// <param name="sender">el objeto que detona el manejador</param>
        /// <param name="e">los argumentos del evento manejado</param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgresoDL(e.ProgressPercentage);
        }
        /// <summary>
        /// Lanza el evento FinDL y le pasa como parámetro el string de html resultante cargado en la propiedad Result del parámetro "e" de la función
        /// </summary>
        /// <param name="sender">el objeto que detona el manejador</param>
        /// <param name="e">los argumentos del evento manejado</param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            FinDL(e.Result);
        }

    }
}
