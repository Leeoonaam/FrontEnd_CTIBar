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
    public partial class frmcofre_senhas : Form
    {
        public frmcofre_senhas()
        {
            InitializeComponent();
        }


        /// <summary>
        /// frmcofre_senhas_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmcofre_senhas_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaDados_Zendesk();
            }
            catch (Exception err)
            {
                
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// CarregaDados_Zendesk
        /// </summary>
        public void CarregaDados_Zendesk()
        {

            gerlourens obj = new gerlourens();

            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "select Login_Zendesk, Senha_Zendesk from gatusuario (nolock) where idcodusuario=" + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;
                        
                        SqlDataReader dr = cmd.ExecuteReader();
                        
                        if (dr.Read())
                        {
                            txtlogin_Zendesk.Text = dr["Login_Zendesk"].ToString();
                            txtsenha_Zendesk.Text = dr["Senha_Zendesk"].ToString();
                        }
                        dr.Close();


                    }

                }
                
                obj = null;
            }
            catch (Exception err)
            {
                obj = null;

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// cmdsalvar_Zendesk_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdsalvar_Zendesk_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtlogin_Zendesk.Text == "" || txtsenha_Zendesk.Text=="")
                {
                    modulo.Show_Mensagem_Alerta("Informe o Login e Senha do ZenDesk");
                    return;
                }
                
                //salva
                modulo.ExecCommand("update gatusuario set Login_Zendesk='" + txtlogin_Zendesk.Text.Replace("'","") + "',Senha_Zendesk='" + txtsenha_Zendesk.Text.Replace("'", "") + "' where idcodusuario=" + modulo.IDCodUsuario.ToString() );
                
                modulo.Show_Mensagem_Alerta("Login salvo com sucesso !");

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



    }
}
