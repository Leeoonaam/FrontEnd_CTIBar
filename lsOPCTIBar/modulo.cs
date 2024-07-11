using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using lsautom;


namespace lsOPCTIBar
{
    public static class modulo
    {

        public static DateTime dttime;
        public static StatusAgente AgentState = new StatusAgente();
        public static gerlourens oger = new gerlourens();


        public static string sUserid_Avaya = "";
        public static string sPassword_Avaya = "";
        public static string sServer_Avaya = "";
        public static string sPort_Avaya = "";
        public static string sVersao_Avaya = "";
        public static string sNomeCliente_Avaya = "";
        public static string sSessionID_Avaya = "";
        public static string mac_adress = "";

        public static string scallid_chamada_ativa = "";
        public static string snumero_chamada_ativa = "";

        public static string scallid_chamada_espera = "";
        public static string snumero_chamada_espera = "";

        public static string scallid_make_call = "";
        public static string snumero_make_call = "";

        public static string scallid_chamada_transf = "";
        public static string snumero_chamada_transf = "";


        //USUARIO LOGADO
        public static string Versao = "";
        public static string Hostname = "";
        public static string Ramal = "";
        public static int IDCodRamal = 0;
        public static int IDCodUsuario = 0;
        public static string NomeOperador = "";
        public static int IDCodEquipe = 0;
        public static string Equipe = "";
        public static int IDCodPerfil = 0;
        public static string Perfil = "";
        public static string Skill = "";
        public static string Login_CTI = "";
        public static string Senha_CTI = "";
        public static TipoLogin TipoLogin = 0;
        public static string Inicio_Jornada = "";
        public static string Fim_Jornada = "";
        public static string Login_Zenddesk = "";
        public static string Senha_Zenddesk = "";


        //Atendimento
        public static long idcodcliente = 0;
        public static long idcodcampanha = 0;
        public static long idcodmailing = 0;
        public static string sUUI = "";
        public static string sSkill = "";
        public static string sVDN = "";
        public static string IDClienteAVAYA = "";
        public static string IDChamadas = "";
        public static DateTime DataInicioAtendimento;
        public static string Bina = "";

        public static string Ticket = "";
        public static string Ticket_SLA = "";
        public static string Ticket_Tipo = "";
        public static string Ticket_Tabulacao = "";
        public static string Ticket_Status = "";
        public static string Ticket_Playlist = "";
        public static string Status_User_Playlist = "";
        public static bool Hide_Function_ZenDesk = true;
        public static string Ticket_Filtro_Lupa = "";
        public static string Ticket_Filtro_Lupa_Configurado = "";
        public static string Resultado_Ticket_Filtro_Lupa_Configurado = "";
        public static string Ticket_Fila_Atendimento = "";

        public static bool bconsulta = false;
        public static Collection<ChamadaRamal> ChamadasRamal = new Collection<lsOPCTIBar.ChamadaRamal>();

        public static frmCTIBar objFrmCTIBar;

        public static string Motivo_Pausa_Selecionada = "";
        public static int ID_Pausa_Selecionada = 0;
        public static int Limite_Pausa_Selecionada = 0;
        public static int Limite_Dia_Pausa_Selecionada = 0;

        public static int TempoStatus = 0;

        public static int Retorno_Libecacao_Acao = 0;
        public static string  Funcao_Libecacao_Acao = "";
        public static Boolean PausaEmAtendimento = false;        

        public static int TempoEntreChamadas = 0;
        public static int TempoTabular = 0;
        public static int TempoTelaCallBack = 0;
        public static int PermitirRediscagem = 0;
        public static int CallBackAutomatico = 0;
        public static int OnCapturaTela = 0;
        public static int AbrirTelaCallBack = 0;


        public static int Atendimento_PlayList = 0;
        public static int Atendimento_Online = 0;
        public static int Atendimento_Offline = 0;
        public static string Fila_Zendesk = "";



        public static string Mensagem_Alerta = "";
        public static int Tipo_Mensagem_Alerta = 0;

        public enum StatusAgente
        {
            Logout = 0,
            Logado = 1,
            Ready = 2,
            NotReady = 3,
            EmAtendimento = 4,
            PosAtendimento = 5,
            Discando = 6
        }
        

        
        /// <summary>
        /// GravaLogApp
        /// </summary>
        /// <param name="slog"></param>
        public static void GravaLogApp(string slog)
        {
            try
            {
                return;

                string sfilename = System.IO.Directory.GetCurrentDirectory() + @"\lsCTI_" + Login_CTI + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                slog = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + slog;

                using (StreamWriter sw = new StreamWriter(sfilename, true))
                {
                    sw.WriteLine(slog);
                    sw.Close();
                }

            }
            catch (Exception err)
            {
            }
        }


        /// <summary>
        /// Show_Mensagem_Alerta
        /// </summary>
        /// <param name="smensagem"></param>
        public static void Show_Mensagem_Alerta(string smensagem)
        {
            try
            {

                modulo.Mensagem_Alerta = smensagem;
                ExecCommand("insert into lsLogMensagemAlerta ( idcodusuario,mensagem,data_mensagem) values (" + modulo.IDCodUsuario.ToString() + ",'" + smensagem.Replace("'", "") + "',GETDATE())");


                frmMensagemAlerta omsg = new frmMensagemAlerta();
                omsg.ShowDialog();


                //omsg.Dispose();
                omsg = null;

            }
            catch (Exception err)
            {
                ExecCommand("insert into lsLogMensagemAlerta ( idcodusuario,mensagem,data_mensagem) values (" + modulo.IDCodUsuario.ToString() + ",'" + err.Message + "',GETDATE())");

            }
        }


        /// <summary>
        /// CapturaTelaCliente
        /// </summary>
        public static void CapturaTelaCliente()
        {
            try
            {
                
                if (modulo.OnCapturaTela==1)
                {

                    //cliente
                    if (modulo.idcodcliente == 0 )
                    {
                        return;
                    }



                    gerlourens obj = new gerlourens();
                    lsautom.clsautom ols = new lsautom.clsautom();


                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd  = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandText = "SPGATCapturaTela_Cliente";
                            cmd.CommandType = CommandType.StoredProcedure;
                                
                            cmd.Parameters.Add("@iduser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                            cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = modulo.idcodcliente;
                            cmd.Parameters.Add("@tela", SqlDbType.Image).Value = ols.CaptureScreenFull("xx0000Y127858#xF");

                            cmd.ExecuteNonQuery();
                            
                        }


                    }

                    obj = null;
                    ols = null;

                }

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        /// <summary>
        /// CapturaTelaUsuario
        /// </summary>
        public static void CapturaTelaUsuario()
        {
            try
            {
                if (modulo.OnCapturaTela == 1)
                {
                    
                    gerlourens obj = new gerlourens();
                    lsautom.clsautom ols = new clsautom();

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandText = "SPGATCapturaTela";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@iduser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                            cmd.Parameters.Add("@tela", SqlDbType.Image).Value = ols.CaptureScreenFull("xx0000Y127858#xF");

                            cmd.ExecuteNonQuery();

                        }


                    }

                    obj = null;
                    ols = null;
                }
                

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        /// <summary>
        /// LogTempoDisponivel
        /// </summary>
        /// <param name="dtini"></param>
        public static void LogTempoDisponivel(DateTime dtini)
        {
            try
            {

                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "SPGATTME";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@IDCodUsuario", SqlDbType.Int).Value = IDCodUsuario;
                        cmd.Parameters.Add("@DataInicio", SqlDbType.DateTime).Value = dtini.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

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
        /// horacheia
        /// </summary>
        /// <param name="segundos"></param>
        /// <returns></returns>
        public static string horacheia(int segundos)
        {
            try
            {


                int hor = (int)(segundos / (60 * 60));

                int min = (int)((segundos - (hor * 60 * 60)) / 60);

                int seg = (int)(segundos - (hor * 60 * 60) - (min * 60));


                string sret = hor.ToString("00") + ":" + min.ToString("00") + ":" + seg.ToString("00");

                return sret;

            }
            catch (Exception err)
            {

                return "";
            }
        }




        /// <summary>
        /// ExecCommand
        /// </summary>
        /// <param name="scmd"></param>
        public static void ExecCommand(string scmd)
        {
            try
            {
                modulo.GravaLogApp("I.ExecCommand");


                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = scmd;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }

                obj = null;

                modulo.GravaLogApp("F.ExecCommand");
            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.ExecCommand");
            }
        }



    }



    public class ChamadaRamal
    {
        public StatusChamada status { get; set; }
        public string numero { get; set; }
        public string callid { get; set; }
        public string tipo { get; set; }
        public DateTime data { get; set; }

    }




    public enum StatusChamada
    {
        Atendida = 1,
        MakeCall = 2,
        Hold = 3,
        Falha = 4
    }


    public enum TipoLogin
    {
        Inbound = 0,
        Preview = 1,
        Outbound = 2,
        Blended = 3,
        Atend_Manual = 4
    }


}
