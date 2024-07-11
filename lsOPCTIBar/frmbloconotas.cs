using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lsOPCTIBar
{
    public partial class frmbloconotas : Form
    {
        public frmbloconotas()
        {
            InitializeComponent();
        }


        /// <summary>
        /// frmbloconotas_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmbloconotas_Load(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "select BLOCO_NOTAS from gatusuario (nolock) where idcodusuario = " + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;


                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {
                            txtbloconotas.Text = dr["BLOCO_NOTAS"].ToString();
                        }

                        
                        dr.Close();
                        dr = null;

                    }


                }

                obj = null;

            }
            catch (Exception err)
            {
                
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// timer1_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                Salvar();

                timer1.Enabled = true ;

            }
            catch (Exception err)
            {
                timer1.Enabled = true;
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// Salvar
        /// </summary>
        public void Salvar()
        {
            try
            {
                gerlourens obj = new gerlourens();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "update gatusuario set BLOCO_NOTAS ='" + txtbloconotas.Text.Replace("'", "") + "' where idcodusuario=" + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;
                        
                        cmd.ExecuteNonQuery();
                        
                    }


                }
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }




        /// <summary>
        /// frmbloconotas_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmbloconotas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Salvar();
            }
            catch (Exception err)
            {
                
            }
            
        }




    }
}
