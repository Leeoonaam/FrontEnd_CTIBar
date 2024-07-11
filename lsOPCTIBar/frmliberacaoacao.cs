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
    public partial class frmliberacaoacao : Form
    {
        public frmliberacaoacao()
        {
            InitializeComponent();
        }

        /// <summary>
        /// cmdcancelar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdcancelar_Click(object sender, EventArgs e)
        {
            try
            {


               



                this.Close();
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// Liberacao
        /// </summary>
        public void Liberacao()
        {
            try
            {
                //valida campos
                if (txtcomentario.Text == "" || txtusuario.Text == "" || txtsenha.Text == "")
                {
                    modulo.Show_Mensagem_Alerta("Informe todos os Campos");
                    return;
                }

                bool bachou = false;
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = "select * from gatusuario (nolock) where idcodusuario in (";
                ssql = ssql + " select idcodusuario from gatusuarioperfil (nolock) where idcodperfil in (";
                ssql = ssql + " select idcodperfil from gatperfil (nolock) where idpermissao in (1,2,4,12)))";
                ssql = ssql + " and login = '" + txtusuario.Text.Replace("'", "") + "'";
                ssql = ssql + " and senha = '" + txtsenha.Text.Replace("'", "") + "'";
                ssql = ssql + " and habilitado = 1";

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            bachou = true;

                            LogLiberacoes(Convert.ToInt32(dr["idcodusuario"].ToString()), modulo.Funcao_Libecacao_Acao, modulo.IDCodUsuario, txtcomentario.Text);

                        }
                        dr.Close();

                        if (bachou == false)
                        {
                            modulo.Show_Mensagem_Alerta("Usuário Inválido");
                            return;
                        }
                        else
                        {
                            
                            //liberacao realizada
                            modulo.Retorno_Libecacao_Acao = 1;
                            this.Close();
                        }

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
        /// cmdok_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdok_Click(object sender, EventArgs e)
        {
            Liberacao();
        }


        /// <summary>
        /// LogLiberacoes
        /// </summary>
        /// <param name="codadm"></param>
        /// <param name="acao"></param>
        /// <param name="codoperador"></param>
        /// <param name="obs"></param>
        public void LogLiberacoes(int codadm, string acao, int codoperador, string obs)
        {
            try
            {
                gerlourens obj = new gerlourens();
                
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into GATLOGACOESADM (idcodusuario_acao,data,acao,idcodoperador,obs) values (" + codadm.ToString() + ",getdate(),'" + acao + "'," + codoperador.ToString() + ",'" + obs + "')";

                        cmd.ExecuteNonQuery();


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
        /// frmliberacaoacao_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmliberacaoacao_Load(object sender, EventArgs e)
        {
            try
            {

                //flag tela bloqueio
                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "update gatusuario set bloqueio_acao=1,data_bloqueio_acao=getdate() where IDCodUsuario=" + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;
                        

                        cmd.ExecuteNonQuery();
                        
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
        /// tmrLiberacao_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrLiberacao_Tick(object sender, EventArgs e)
        {
            try
            {

                tmrLiberacao.Enabled = false;


                gerlourens obj = new gerlourens();


                using (SqlConnection cn = obj.abre_cn())
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string ssql = "";


                        ssql = @"select	* 
                                    from gatusuario (nolock)
                                    where IDCodUsuario IN
                                    (
                                      select  idUser_Liberou_bloqueio_acao

                                      from GATUsuario (nolock)
                                      where IDCodUsuario = " + modulo.IDCodUsuario.ToString() + @"
                                      and bloqueio_acao = 1
                                    )";

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {

                            txtusuario.Text = dr["login"].ToString();
                            txtsenha.Text = dr["senha"].ToString();
                            txtcomentario.Text = "Liberação Realizada ADM - Portal";

                            Liberacao();

                        }
                        dr.Close();
                        dr = null;


                    }
                    
                }
                
                obj = null;

                tmrLiberacao.Enabled = true;


            }
            catch (Exception err)
            {
                tmrLiberacao.Enabled = true;
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// frmliberacaoacao_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmliberacaoacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //flag tela bloqueio
                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "update gatusuario set bloqueio_acao=0,data_bloqueio_acao=null,idUser_Liberou_bloqueio_acao=null where IDCodUsuario=" + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;


                        cmd.ExecuteNonQuery();

                    }

                }

                obj = null;
            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }
    }
}
