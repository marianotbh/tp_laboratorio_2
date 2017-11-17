using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "../../../historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lee linea por linea desde el archivo que se le pasa al constructor y los guarda en una lista auxiliar,
        /// luego se los pasa a la lista de lstHistorial, si leer retorna "false" detona un MessageBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<string> dat;
            if (archivos.leer(out dat))
            {
                foreach(string i in dat)
                {
                    lstHistorial.Items.Add(i);
                }                
            }
            else
                MessageBox.Show("(!) Error de lectura de historial");                               
        }
    }
}
