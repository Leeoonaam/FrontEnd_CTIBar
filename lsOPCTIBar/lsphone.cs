using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace lsOPCTIBar
{
    public static class lsphone
    {

        //delegate
        public delegate void lsAtender();
        public delegate void lsErro(string coderro);
        public delegate void lsResp(string codresp);

        //event
        public static event lsAtender OnAtendimento;
        public static event lsErro OnError;
        public static event lsResp OnResposta;

        static gerlourens obj = new gerlourens();

        public static long IDCodPausa = 0; //codigo identity gattempopausa
        public static bool NotReadyAuto = false;
        public static int MotivoPausaAuto = 0;


        public static bool LastCall = false;

        public static long IDLigacao;



        /// <summary>
        /// GravaLog
        /// </summary>
        /// <param name="slog"></param>
        public static void GravaLog(string slog)
        {
            try
            {

                string sfilename = System.IO.Directory.GetCurrentDirectory() + @"\lsPhone_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                slog = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - CodUser: " + modulo.IDCodUsuario.ToString() + " - CodCliente: " + modulo.idcodcliente.ToString() + " - " + slog;

                using (StreamWriter sw = new StreamWriter(sfilename,true))
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
        /// Login
        /// </summary>
        public static void Login()
        {
            try
            {
                string sretorno = "";

                if (modulo.AgentState != modulo.StatusAgente.EmAtendimento)
                {

                    GravaLog("Iniciando Login");
                    GravaLog("Logando Usuário");

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SPGATLoginUsuario";

                            cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                            cmd.Parameters.Add("@CodRamal", SqlDbType.Int).Value = modulo.IDCodRamal;
                            cmd.Parameters.Add("@EndSock", SqlDbType.VarChar, 50).Value = "1";
                            cmd.Parameters.Add("@TpAtend", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            sretorno = cmd.Parameters["@Status"].Value.ToString();

                            //trata retorno
                            switch (sretorno)
                            {

                                case "1":

                                    OnError("ERR0002");
                                    GravaLog("Usuário Inválido");
                                    break;

                                case "2":

                                    OnError("ERR0002");
                                    GravaLog("Ramal Inválido");
                                    break;

                                case "3":

                                    OnError("ERR0002");
                                    GravaLog("EndSock Invalido");
                                    break;

                                case "0":

                                    GravaLog("Login Completado");
                                    OnResposta("LS0002");

                                    break;


                                default:

                                    OnError("ERR0002");
                                    GravaLog("Erro ao Realizar SPGATLoginUsuario");

                                    break;
                            }


                        }

                    }

                }
                else
                {
                    GravaLog("LS0013 - Solicitação de Login com Usuário em Atendimento");
                    OnResposta("LS0013");
                }


            }
            catch (Exception err)
            {
                OnError("ERR9999");
                GravaLog(err.Message + " - Login");
            }
        }



        /// <summary>
        /// FimPausa
        /// </summary>
        /// <param name="lPausa"></param>
        public static void FimPausa(long lPausa)
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "SPGATFimPausa";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@IDCodTempPausa", SqlDbType.Int).Value = lPausa;
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                    }

                }

            }
            catch (Exception err)
            {
                OnError("ERR9999");
                GravaLog(err.Message + " - FimPausa");
            }

        }


        /// <summary>
        /// Logout
        /// </summary>
        public static void Logout()
        {
            try
            {
                string sretorno = "";

                if (modulo.AgentState != modulo.StatusAgente.EmAtendimento)
                {

                    GravaLog("Iniciando Logout");

                    //verifica se tem Pausa em aberto
                    if (lsphone.IDCodPausa > 0)
                    {
                        GravaLog("Finalizando Pausa ( Logout )");

                        FimPausa(lsphone.IDCodPausa);

                        lsphone.IDCodPausa = 0;
                    }


                    //verifica se esta em Ready
                    if (modulo.AgentState == modulo.StatusAgente.Ready)
                    {

                        using (SqlConnection cn = obj.abre_cn())
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {

                                cmd.Connection = cn;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "SPGATNotReadyUsuario";


                                cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                                cmd.Parameters.Add("@CodPausa", SqlDbType.Int).Value = 0;
                                cmd.Parameters.Add("@IDNewPausa", SqlDbType.Int).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                                cmd.ExecuteNonQuery();

                                sretorno = cmd.Parameters["@Status"].Value.ToString();


                                //trata retorno
                                switch (sretorno)
                                {

                                    case "1":

                                        OnError("ERR0003");
                                        GravaLog("Usuário Inválido");
                                        break;

                                    case "2":

                                        OnError("ERR0003");
                                        GravaLog("Pausa Inválido");
                                        break;

                                    case "0":

                                        GravaLog("Indisponibilizando Usuário ( Logout )");
                                        break;


                                    default:

                                        OnError("ERR0003");
                                        GravaLog("Erro ao Realizar SPGATNotReadyUsuario");

                                        break;
                                }


                            }


                        }



                    }

                    GravaLog("Deslogando Usuário");

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SPGATLogoutUsuario";

                            cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                            cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            sretorno = cmd.Parameters["@Status"].Value.ToString();

                            //trata retorno
                            switch (sretorno)
                            {

                                case "1":

                                    OnError("ERR0003");
                                    GravaLog("Usuário Inválido");
                                    break;

                                case "0":

                                    GravaLog("Logout Completado");
                                    OnResposta("LS0003");

                                    break;


                                default:

                                    OnError("ERR0003");
                                    GravaLog("Erro ao Realizar SPGATLogoutUsuario");

                                    break;
                            }


                        }

                    }

                }
                else
                {
                    GravaLog("LS0011 - Solicitação de Logout com Usuário em Atendimento");
                    OnResposta("LS0011");
                }


            }
            catch (Exception err)
            {
                OnError("ERR9999");
                GravaLog(err.Message + " - Logout");
            }
        }




        /// <summary>
        /// Ready
        /// </summary>
        public static void Ready()
        {
            try
            {
                string sretorno = "";

                if (modulo.AgentState != modulo.StatusAgente.EmAtendimento)
                {

                    GravaLog("Iniciando Ready");
                    GravaLog("Disponibilizando Usuário");

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SPGATReadyUsuario";

                            cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                            cmd.Parameters.Add("@IDCodPausa", SqlDbType.Int).Value = IDCodPausa;
                            cmd.Parameters.Add("@TpAtend", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            sretorno = cmd.Parameters["@Status"].Value.ToString();

                            //trata retorno
                            switch (sretorno)
                            {

                                case "1":

                                    OnError("ERR0004");
                                    GravaLog("Usuário Inválido");
                                    break;

                                case "2":

                                    OnError("ERR0004");
                                    GravaLog("Pausa Inválido");
                                    break;

                                case "0":


                                    if (IDCodPausa > 0)
                                    {
                                        GravaLog("Finalizando Pausa ( Ready )");
                                        IDCodPausa = 0;
                                    }

                                    GravaLog("Ready Completado");
                                    OnResposta("LS0004");

                                    break;


                                default:

                                    OnError("ERR0004");
                                    GravaLog("Erro ao Realizar SPGATReadyUsuario");

                                    break;
                            }


                        }

                    }

                }
                else
                {
                    GravaLog("LS0014 - Solicitação de Ready com Usuário em Atendimento");
                    OnResposta("LS0014");
                }


            }
            catch (Exception err)
            {
                OnError("ERR9999");
                GravaLog(err.Message + " - Ready");
            }
        }



        /// <summary>
        /// NotReady
        /// </summary>
        /// <param name="motivopausa"></param>
        public static void NotReady(int motivopausa)
        {
            try
            {
                string sretorno = "";

                //Valida Motivo
                if (motivopausa == 0 && MotivoPausaAuto == 0)
                {
                    OnError("ERR0005");
                    GravaLog("ERR0005 - Motivo de Pausa não selecionado");
                    return;
                }



                if (modulo.AgentState != modulo.StatusAgente.EmAtendimento)
                {

                    GravaLog("Iniciando Not Ready");
                    GravaLog("Indisponibilizando Usuário");


                    if (MotivoPausaAuto > 0)
                    {
                        motivopausa = MotivoPausaAuto;
                    }


                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SPGATNotReadyUsuario";

                            cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                            cmd.Parameters.Add("@CodPausa", SqlDbType.Int).Value = motivopausa;
                            cmd.Parameters.Add("@IDNewPausa", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            sretorno = cmd.Parameters["@Status"].Value.ToString();

                            //trata retorno
                            switch (sretorno)
                            {

                                case "1":

                                    OnError("ERR0005");
                                    GravaLog("Usuário Inválido");
                                    break;

                                case "2":

                                    OnError("ERR0005");
                                    GravaLog("Pausa Inválido");
                                    break;

                                case "0":

                                    IDCodPausa = Convert.ToInt32(cmd.Parameters["@IDNewPausa"].Value);

                                    if (IDCodPausa > 0)
                                    {
                                        GravaLog("Inicializando Pausa ( Not Ready )");
                                        motivopausa = 0;
                                    }


                                    NotReadyAuto = false;
                                    MotivoPausaAuto = 0;


                                    GravaLog("Not Ready Completado");
                                    OnResposta("LS0005");

                                    break;


                                default:

                                    OnError("ERR0005");
                                    GravaLog("Erro ao Realizar SPGATNotReadyUsuario");

                                    break;
                            }


                        }

                    }

                }
                else
                {

                    //pausa automatica apos atendimento
                    NotReadyAuto = true;
                    MotivoPausaAuto = motivopausa;

                    GravaLog("LS0012 - Solicitação de Not Ready com Usuário em Atendimento");
                    OnResposta("LS0012");
                }


            }
            catch (Exception err)
            {
                OnError("ERR9999");
                GravaLog(err.Message + " - NotReady");
            }

        }



        /// <summary>
        /// lsAtendimento
        /// </summary>
        /// <param name="codcliente"></param>
        public static void lsAtendimento(long codcliente)
        {
            try
            {

                string sretorno = "";
                
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPGATAtendUsuario";

                        cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                        cmd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = codcliente;
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        sretorno = cmd.Parameters["@Status"].Value.ToString();

                        //trata retorno
                        switch (sretorno)
                        {

                            case "1":

                                OnError("ERR0013");
                                GravaLog("Usuário Inválido");
                                break;

                            case "0":


                                GravaLog("Atendimento Realizado");
                                OnResposta("LS0006");

                                OnAtendimento();

                                break;


                            default:

                                OnError("ERR0002");
                                GravaLog("Erro ao Realizar SPGATAtendUsuario");

                                break;
                        }


                    }

                }
                
            }
            catch (Exception err)
            {
                OnError("ERR9999");
                GravaLog(err.Message + " - lsAtendimento");
            }
        }


        /// <summary>
        /// Agendamento_Ligacao
        /// </summary>
        /// <param name="TipoAgendamento"></param>
        /// <param name="DDD"></param>
        /// <param name="Telefone"></param>
        /// <param name="DataAgendamento"></param>
        /// <param name="MotivoTabulacao"></param>
        /// <param name="Observacao"></param>
        /// <param name="DataInicioAtend"></param>
        public static void Agendamento_Ligacao(TipoAgendamento TipoAgendamento,string DDD, string Telefone,DateTime DataAgendamento, int MotivoTabulacao,string Observacao,DateTime DataInicioAtend)
        {
            try
            {

                string sretorno = "";

                GravaLog("Realizando Agendamento");

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPGATAgendaCliente";

                        cmd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = modulo.idcodcliente;
                        cmd.Parameters.Add("@CodStatus", SqlDbType.Int).Value = Convert.ToInt32(TipoAgendamento);
                        cmd.Parameters.Add("@CodUser", SqlDbType.Int).Value = modulo.IDCodUsuario;
                        cmd.Parameters.Add("@CodCampanha", SqlDbType.Int).Value = modulo.idcodcampanha;
                        cmd.Parameters.Add("@DDDAgend", SqlDbType.VarChar, 3).Value = DDD;
                        cmd.Parameters.Add("@TelefoneAgend", SqlDbType.VarChar, 15).Value = Telefone;
                        cmd.Parameters.Add("@DataAgend", SqlDbType.DateTime).Value = DataAgendamento;
                        cmd.Parameters.Add("@CodOperador", SqlDbType.Int).Value = modulo.IDCodUsuario;
                        cmd.Parameters.Add("@CodCampOp", SqlDbType.Int).Value = modulo.idcodcampanha;
                        cmd.Parameters.Add("@CodMailOp", SqlDbType.Int).Value = modulo.idcodmailing;
                        cmd.Parameters.Add("@mMotivo", SqlDbType.Int).Value = MotivoTabulacao;
                        cmd.Parameters.Add("@TipoTelAgend", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@Obs", SqlDbType.NText).Value = Observacao;
                        cmd.Parameters.Add("@CodRamal", SqlDbType.Int).Value = modulo.IDCodRamal;
                        cmd.Parameters.Add("@DataIniAtend", SqlDbType.DateTime).Value = DataInicioAtend;
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        sretorno = cmd.Parameters["@Status"].Value.ToString();
                        
                        if (sretorno != "-1")
                        {
                            IDLigacao = Convert.ToInt32(sretorno);

                            //verifica se foi programada a pausa
                            if (NotReadyAuto==true )
                            {
                                NotReadyAuto = false;
                                NotReady(MotivoPausaAuto);
                            }


                            //ultima ligacao
                            if (LastCall==true )
                            {
                                LastCall = false;
                                Logout();
                            }


                            GravaLog("Agendamento Completado");
                            OnResposta("LS0009");


                        }
                        else
                        {

                            IDLigacao = Convert.ToInt32(sretorno);

                            OnError("ERR0009");
                            GravaLog("Erro ao Realizar SPGATAgendaCliente");
                        }


                    }
                }


            }
            catch (Exception err)
            {

                OnError("ERR9999");
                GravaLog(err.Message + " - Agendamento_Ligacao");
            }
        }




        /// <summary>
        /// Finalizar_Ligacao
        /// </summary>
        /// <param name="MotivoTabulacao"></param>
        /// <param name="Observacao"></param>
        /// <param name="DataInicioAtend"></param>
        public static void Finalizar_Ligacao(int MotivoTabulacao, string Observacao, DateTime DataInicioAtend)
        {
            try
            {

                string sretorno = "";

                GravaLog("Realizando Finalizacao");

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPGATFinalizaCliente3";

                        cmd.Parameters.Add("@CodCliente", SqlDbType.Int).Value = modulo.idcodcliente;
                        cmd.Parameters.Add("@CodOperador", SqlDbType.Int).Value = modulo.IDCodUsuario;
                        cmd.Parameters.Add("@CodCampOp", SqlDbType.Int).Value = modulo.idcodcampanha;
                        cmd.Parameters.Add("@CodMailOp", SqlDbType.Int).Value = modulo.idcodmailing;
                        cmd.Parameters.Add("@mMotivo", SqlDbType.VarChar,200).Value = modulo.Ticket_Tabulacao;
                        cmd.Parameters.Add("@mStatus", SqlDbType.VarChar, 200).Value = modulo.Ticket_Status;
                        cmd.Parameters.Add("@Obs", SqlDbType.NText).Value = Observacao;
                        cmd.Parameters.Add("@CodRamal", SqlDbType.Int).Value = modulo.IDCodRamal;
                        cmd.Parameters.Add("@DataIniAtend", SqlDbType.DateTime).Value = DataInicioAtend;
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;
                        
                        cmd.ExecuteNonQuery();

                        sretorno = cmd.Parameters["@Status"].Value.ToString();

                        if (sretorno != "-1")
                        {
                            IDLigacao = Convert.ToInt32(sretorno);
                            
                            //verifica se foi programada a pausa
                            if (NotReadyAuto == true)
                            {
                                modulo.AgentState = modulo.StatusAgente.Ready;
                                NotReadyAuto = false;
                                NotReady(MotivoPausaAuto);
                                modulo.AgentState = modulo.StatusAgente.NotReady;
                            }


                            //ultima ligacao
                            if (LastCall == true)
                            {
                                modulo.AgentState = modulo.StatusAgente.Ready;
                                LastCall = false;
                                Logout();
                            }


                            
                            GravaLog("Finalizacao Completada");
                            OnResposta("LS0009");
                            
                        }
                        else
                        {

                            IDLigacao = Convert.ToInt32(sretorno);

                            OnError("ERR0009");
                            GravaLog("Erro ao Realizar SPGATFinalizaCliente2");
                        }


                    }
                }


            }
            catch (Exception err)
            {

                OnError("ERR9999");
                GravaLog(err.Message + " - Finalizar_Ligacao");
            }
        }


    }



    





    public enum TipoAgendamento
    {
        Pessoal = 3,
        Publico = 4
    }


}
