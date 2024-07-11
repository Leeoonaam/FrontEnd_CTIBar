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
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace lsOPCTIBar
{
    public partial class frmlogin : Form
    {


        private bool mouseDown;
        private Point lastLocation;
        

        public frmlogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// frmlogin_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmlogin_Load(object sender, EventArgs e)
        {

            try
            {

                GetMACAddress();

                //Valida PA
                ValidaPA();

                //versao
                modulo.Versao = Application.ProductVersion;
                lblversao.Text = "Versão: " + modulo.Versao;
                lblramal.Text = "Ramal: " + modulo.Ramal;
                
                //cloud
                //APP_CLOUD();
                

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// ValidaPA
        /// </summary>
        public void ValidaPA()
        {
            try
            {

                gerlourens obj = new gerlourens();
                string shost = Dns.GetHostName();
                bool bachou = false;

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "SELECT IDCodRamal, NumRamal, DscRamal FROM VOXRamal (nolock) WHERE habilitado = 1 and IDCodRamal > 0 and HostName = '" + shost + "'";
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {
                            bachou = true;

                            modulo.IDCodRamal = Convert.ToInt32(dr["IDCodRamal"].ToString());
                            modulo.Ramal = dr["NumRamal"].ToString();
                            modulo.Hostname = shost;
                        }
                        dr.Close();

                    }
                    
                    if (bachou == false)
                    {
                        using (SqlCommand cmd2 = new SqlCommand())
                        {

                            cmd2.Connection = cn;
                            cmd2.CommandText = "insert into voxramal (NumRamal,DscRamal,HostName,Habilitado,DataInsercao,DataAlteracao) values (0,'" + shost + "','" + shost + "',1,getdate(),getdate())";
                            cmd2.CommandType = CommandType.Text;


                            cmd2.ExecuteNonQuery();

                            ValidaPA();

                        }
                        
                    }

                }


            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }
        

        private void frmlogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmlogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void frmlogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// cmdlogin_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdlogin_Click(object sender, EventArgs e)
        {

            try
            {

                //consistencias
                if (txtusuario.Text == "" || txtsenha.Text == "")
                {
                    modulo.Show_Mensagem_Alerta("Informe o Usuário e Senha.");
                    return;
                }

                gerlourens obj = new gerlourens();
                string ssql = "";
                bool bachou = false;

                using (SqlConnection cn = obj.abre_cn())
                {

                    //select
                    ssql = "select *,isnull(Atendimento_PlayList,0) 'Atendimento_PlayList_',isnull(Atendimento_Online,0) 'Atendimento_Online_',isnull(Atendimento_Offline,0) 'Atendimento_Offline_' from gatusuario  (nolock) where idcodusuario in (";
                    ssql = ssql + " select idcodusuario from gatusuarioperfil (nolock) where idcodperfil in (";
                    ssql = ssql + " select idcodperfil from gatperfil (nolock) where idpermissao = 3))";
                    ssql = ssql + " and login = '" + txtusuario.Text.Replace("'", "") + "'";
                    ssql = ssql + " and senha = '" + txtsenha.Text.Replace("'", "") + "'";
                    ssql = ssql + " and habilitado = 1 ";

                    
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;


                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {
                            
                            bachou = true;

                            string sMAC = dr["mac_address"].ToString() + "";


                            if (sMAC != modulo.mac_adress && sMAC != "")
                            {
                                
                                //em uso
                                if (dr["emuso"].ToString() == "1")
                                {
                                    modulo.Show_Mensagem_Alerta("Seu usuário encontra-se conectado na aplicação");
                                    return;
                                }

                            }

                            


                            ////bloqueio RH
                            //if (dr["BLOCKRH"].ToString() == "1")
                            //{
                            //    modulo.Show_Mensagem_Alerta("Seu usuário foi bloqueado pelo RH. Entre em contato com o responsável do RH para liberação");
                            //    return;
                            //}

                            ////reciclagem
                            //if (dr["RECICLAGEM"].ToString() == "1")
                            //{
                            //    modulo.Show_Mensagem_Alerta("Atenção! você encontra-se com status de RECICLAGEM. Entre em contato com seu supervisor.");
                            //    return;
                            //}


                            //login fora do horario
                            // .....


                            //dados do operador
                            modulo.IDCodUsuario = Convert.ToInt32(dr["idcodusuario"].ToString());
                            modulo.NomeOperador = dr["nome"].ToString();

                            modulo.Login_CTI = dr["USUARIO_AVAYA"].ToString();
                            modulo.Senha_CTI = dr["senha_AVAYA"].ToString();

                            modulo.Login_Zenddesk = dr["Login_Zendesk"].ToString();
                            modulo.Senha_Zenddesk = dr["Senha_Zendesk"].ToString();
                            
                            modulo.Atendimento_Offline = Convert.ToInt32(dr["Atendimento_Offline_"].ToString());
                            modulo.Atendimento_Online = Convert.ToInt32(dr["Atendimento_Online_"].ToString());
                            modulo.Atendimento_PlayList = Convert.ToInt32(dr["Atendimento_PlayList_"].ToString());
                            modulo.Ticket_Filtro_Lupa_Configurado= dr["Ticket_Filtro_Lupa_Configurado"].ToString();

                            //verifica se o usuario possui login ZenDesk
                            if (modulo.Login_Zenddesk == "" || modulo.Senha_Zenddesk == "")
                            {
                                modulo.Show_Mensagem_Alerta("Atenção ! Usuário sem Login Zendesk cadastrado no Cofre de Senhas." + Environment.NewLine + "Realize o cadastro de sua senha para logar na ferramenta." );


                                frmcofre_senhas obj_cofre = new frmcofre_senhas();
                                obj_cofre.ShowDialog();
                                obj_cofre = null;

                                return;

                            }


                            modulo.Inicio_Jornada = dr["Inicio_Jornada"].ToString();
                            modulo.Fim_Jornada = dr["Fim_Jornada"].ToString();


                            if (Convert.ToInt32(dr["tplogin"].ToString()) == 0) modulo.TipoLogin = TipoLogin.Inbound;
                            if (Convert.ToInt32(dr["tplogin"].ToString()) == 1) modulo.TipoLogin = TipoLogin.Preview;
                            if (Convert.ToInt32(dr["tplogin"].ToString()) == 2) modulo.TipoLogin = TipoLogin.Outbound;
                            if (Convert.ToInt32(dr["tplogin"].ToString()) == 3) modulo.TipoLogin = TipoLogin.Blended;
                            if (Convert.ToInt32(dr["tplogin"].ToString()) == 4) modulo.TipoLogin = TipoLogin.Atend_Manual;




                            //seleciona EQUIPE
                            using (SqlConnection cn2 = obj.abre_cn())
                            {
                                using (SqlCommand cmd2 = new SqlCommand())
                                {

                                    ssql = "SELECT TOP 1 * FROM GATPERFIL (NOLOCK) WHERE IDPERMISSAO = 10 AND ";
                                    ssql = ssql + " IDCODPERFIL IN (SELECT IDCODPERFIL FROM ";
                                    ssql = ssql + " GATUSUARIOPERFIL (NOLOCK) WHERE IDCODUSUARIO = " + modulo.IDCodUsuario.ToString() + ")";

                                    cmd2.Connection = cn2;
                                    cmd2.CommandText = ssql;
                                    cmd2.CommandType = CommandType.Text;


                                    SqlDataReader dr2 = cmd2.ExecuteReader();


                                    if (dr2.Read())
                                    {

                                        modulo.IDCodEquipe = Convert.ToInt32(dr2["idcodperfil"].ToString());
                                        modulo.Equipe = dr2["perfil"].ToString();

                                    }
                                    dr2.Close();

                                }

                            }



                            //seleciona PERFIL
                            using (SqlConnection cn3 = obj.abre_cn())
                            {
                                using (SqlCommand cmd3 = new SqlCommand())
                                {

                                    ssql = "SELECT TOP 1 *, isnull(tempoparatabular,0) 'tempoparatabular2' FROM GATPERFIL (NOLOCK) WHERE IDPERMISSAO = 3 AND ";
                                    ssql = ssql + " IDCODPERFIL IN (SELECT IDCODPERFIL FROM ";
                                    ssql = ssql + " GATUSUARIOPERFIL (NOLOCK) WHERE IDCODUSUARIO = " + modulo.IDCodUsuario.ToString() + ")";

                                    cmd3.Connection = cn3;
                                    cmd3.CommandText = ssql;
                                    cmd3.CommandType = CommandType.Text;


                                    SqlDataReader dr3 = cmd3.ExecuteReader();


                                    if (dr3.Read())
                                    {

                                        modulo.IDCodPerfil = Convert.ToInt32(dr3["idcodperfil"].ToString());
                                        modulo.Perfil = dr3["perfil"].ToString();

                                        modulo.Skill = dr3["GRUPO_AVAYA"].ToString();

                                    }
                                    dr3.Close();

                                }
                            }

                            //seleciona EQUIPE
                            using (SqlConnection cn3 = obj.abre_cn())
                            {
                                using (SqlCommand cmd3 = new SqlCommand())
                                {

                                    cmd3.Connection = cn3;
                                    cmd3.CommandText = "update gatusuario set emuso=1, mac_address='" + modulo.mac_adress + "' where idcodusuario = " + modulo.IDCodUsuario.ToString();
                                    cmd3.CommandType = CommandType.Text;

                                    cmd3.ExecuteNonQuery();

                                }

                            }

                        }
                        dr.Close();

                    }

                }


                //valida retorno
                if (bachou == false)
                {
                    modulo.Show_Mensagem_Alerta("Usuário Inválido !");
                }
                else
                {
                    frmCTIBar obj1 = new frmCTIBar();
                    this.Hide();

                   obj1.ShowDialog();

                    this.Close();
                    this.Dispose();
                }


            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }


        }






        /// <summary>
        /// APP_CLOUD
        /// </summary>
        public void APP_CLOUD()
        {
            try
            {

                return;
                //
                // LOG
                //
                using (SqlConnection cn = new SqlConnection())
                {

                    cn.ConnectionString = "Password=Sllf007700;Persist Security Info=True;User ID=lourenssol1;Initial Catalog=lourenssol1;Data Source=dbsq0017.whservidor.com";
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string sdml = "";

                        sdml = "select count(1) from ls_control_active (nolock) where ativo = 1 and idcodregistro = 13";

                        cmd.Connection = cn;
                        cmd.CommandText = sdml;
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {

                            if (Convert.ToInt32(dr[0].ToString()) == 0)
                            {

                                Application.ExitThread();
                                this.Close();
                            }



                        }
                        dr.Close();

                    }

                }


            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message + "_cloud");
                
            }

        }


        /// <summary>
        /// GetMACAddress
        /// </summary>
        public void GetMACAddress()
        {
            try
            {

                string macAddresses = string.Empty;
                string sv = "";

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        string sval = nic.GetPhysicalAddress().ToString();
                        if (sval != "")
                        {
                            macAddresses = macAddresses + sv + nic.GetPhysicalAddress().ToString();
                            sv = ",";
                        }

                    }
                }

                modulo.mac_adress = macAddresses;

            }
            catch (Exception)
            {



            }
        }








    }
}
