using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lsOPCTIBar
{
    public partial class frmMensagemAlerta : Form
    {
        public frmMensagemAlerta()
        {
            InitializeComponent();
        }


        /// <summary>
        /// cdmfechar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdmfechar_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// timer1_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// frmMensagemAlerta_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMensagemAlerta_Load(object sender, EventArgs e)
        {
            try
            {
                txtmensagem.Text = Environment.NewLine + modulo.Mensagem_Alerta;

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }
    }
}
