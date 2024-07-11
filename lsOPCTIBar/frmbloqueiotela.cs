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
    public partial class frmbloqueiotela : Form
    {

        DateTime dt = DateTime.Now;
        gerlourens obj = new gerlourens();

        public frmbloqueiotela()
        {
            InitializeComponent();
        }


        /// <summary>
        /// frmbloqueiotela_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmbloqueiotela_Load(object sender, EventArgs e)
        {
            try
            {

                dt = DateTime.Now;
                lbldata.Text = "Data Bloqueio : " +  dt.ToString("dd/MM/yyyy HH:mm:ss");
                lblusuario.Text = "Usuário : " + modulo.NomeOperador;

            }
            catch (Exception err)
            {
                
                ///
            }
        }


        /// <summary>
        /// tmr_contador_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_contador_Tick(object sender, EventArgs e)
        {
            try
            {
                int idusuarioliberou = 0;
                string ssql = "";

                tmr_contador.Enabled = false;

                lbltempo.Text = modulo.horacheia(Convert.ToInt32((DateTime.Now - dt).TotalSeconds));


                //
                // verifica se houve liberaca
                //
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "select isnull(idusuario_liberou_bloq_pausa,0) 'idusuario_liberou_bloq_pausa' from gatusuario (nolock) where idcodusuario = " + modulo.IDCodUsuario.ToString() ;
                        cmd.CommandType = CommandType.Text;
                        
                        SqlDataReader dr = cmd.ExecuteReader();
                        
                        if (dr.Read())
                        {
                            idusuarioliberou = Convert.ToInt32(dr["idusuario_liberou_bloq_pausa"].ToString());
                        }
                        dr.Close();
                    }
                    
                }


                if (idusuarioliberou > 0 )
                {

                    //liberacao
                    modulo.objFrmCTIBar.ExecCommand("update gatusuario set bloqueado = 0,Bloq_Estouro_Pausa=0,idusuario_liberou_bloq_pausa=null where idcodusuario = " + modulo.IDCodUsuario.ToString());


                    //log
                    ssql = " insert into gattempousuario";
                    ssql = ssql + " (idcodusuario,idcodtempo,datatempo,";
                    ssql = ssql + " idcodturno,idcodperfil,idpermissao)";
                    ssql = ssql + " values (" + modulo.IDCodUsuario.ToString();
                    ssql = ssql + " ,8,getdate(),";
                    ssql = ssql + " (select top 1 idcodturno from gatusuario (nolock)";
                    ssql = ssql + " where idcodusuario=" + modulo.IDCodUsuario.ToString() + "),";
                    ssql = ssql + " (select top 1 idcodperfil from gatusuarioperfil(nolock)";
                    ssql = ssql + " where idcodusuario=" + modulo.IDCodUsuario.ToString() + "),";
                    ssql = ssql + " 3)";

                    modulo.objFrmCTIBar.ExecCommand(ssql);

                    lsphone.Ready();

                    this.Close();
                    Close();
                    this.Dispose();
                    
                }



                tmr_contador.Enabled = true;
            }
            catch (Exception err)
            {
                tmr_contador.Enabled = true;
            }
        }



    }
}
