using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime;

namespace lsOPCTIBar
{
    public partial class frmCTIBar : Form
    {


        //CONEXÃO COM CHROME
        IWebDriver driver;



        //formulario
        frmbloconotas obj_frmbloconotas;
        frmtelefoniamanual obj_frmtelefoniamanual;
        frmperformance obj_frmperformance;
        frmpopup obj_frmpopup;
        frmcallback obj_frmcallback;
        frmcofre_senhas obj_frmcofre_senhas;

        bool bacaoindevia = false;


        bool blog_disponivel = false;
        DateTime dtIni_disponivel;




        /// <summary>
        /// Configuracoes_Atendimento
        /// </summary>
        public void Configuracoes_Atendimento()
        {
            try
            {

                modulo.GravaLogApp("I.Configuracoes_Atendimento");

                gerlourens obj = new gerlourens();

                //configuracoes no Perfil
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = @"select  *, 
                                                    isnull(tempoparatabular,0)  'tempoparatabular2', 
                                                    isnull(PERMITIR_REDISCAGEM,0)  'PERMITIR_REDISCAGEM2', 
                                                    isnull(CallBack_Automatico,0)  'CallBack_Automatico2', 
                                                    isnull(On_Captura_Tela,0)  'On_Captura_Tela2', 
                                                    isnull(iTempo_Tela_CallBack_Aberta,0) 'iTempo_Tela_CallBack_Aberta2',
                                                    isnull(Abrir_CallBack,0) 'Abrir_CallBack2'

                                            from    gatperfil (nolock) 
                                            where   idcodperfil = " + modulo.IDCodPerfil.ToString();

                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            modulo.TempoEntreChamadas = Convert.ToInt32(dr["tempoparatabular2"].ToString());
                            modulo.AbrirTelaCallBack = Convert.ToInt32(dr["Abrir_CallBack2"].ToString());
                            modulo.TempoTelaCallBack = Convert.ToInt32(dr["iTempo_Tela_CallBack_Aberta2"].ToString());

                            if (modulo.TempoTelaCallBack < 5)
                            {
                                modulo.TempoTelaCallBack = 5;
                            }

                            modulo.PermitirRediscagem = Convert.ToInt32(dr["PERMITIR_REDISCAGEM2"].ToString());
                            modulo.CallBackAutomatico = Convert.ToInt32(dr["CallBack_Automatico2"].ToString());
                            modulo.OnCapturaTela = Convert.ToInt32(dr["On_Captura_Tela2"].ToString());

                            dr.Close();

                        }


                    }

                }

                obj = null;


                modulo.GravaLogApp("F.Configuracoes_Atendimento");

            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.Configuracoes_Atendimento");
                modulo.Show_Mensagem_Alerta(err.Message);
            }



        }


        /// <summary>
        /// HabilitaCampos
        /// </summary>
        public void HabilitaCampos()
        {
            try
            {

                modulo.GravaLogApp("I.HabilitaCampos");

                cmdUltimaLigacao.Visible = true;

                modulo.GravaLogApp("F.HabilitaCampos");

            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.HabilitaCampos");
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// DesabilitaCampos
        /// </summary>
        public void DesabilitaCampos()
        {
            try
            {
                modulo.GravaLogApp("I.DesabilitaCampos");

                cmdUltimaLigacao.Visible = false;


                modulo.GravaLogApp("f.DesabilitaCampos");
            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.DesabilitaCampos");
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// LimpaDadosAtend
        /// </summary>
        public void LimpaDadosAtend()
        {
            try
            {

                modulo.GravaLogApp("I.LimpaDadosAtend");

                modulo.idcodcliente = 0;
                modulo.idcodcampanha = 0;
                modulo.idcodmailing = 0;
                modulo.sUUI = "";
                modulo.Motivo_Pausa_Selecionada = "";
                modulo.ID_Pausa_Selecionada = 0;
                modulo.Retorno_Libecacao_Acao = 0;
                modulo.Funcao_Libecacao_Acao = "";
                modulo.IDChamadas = "";
                modulo.sSkill = "";
                modulo.sVDN = "";
                modulo.Bina = "";

                modulo.Ticket = "";
                modulo.Ticket_SLA = "";
                modulo.Ticket_Tipo = "";
                modulo.Ticket_Tabulacao = "";
                modulo.Ticket_Status = "";
                modulo.IDClienteAVAYA = "";
                modulo.Hide_Function_ZenDesk = true;


                toolStripStatusLabel2.Text = ""; //idavaya
                toolStripStatusLabel3.Text = ""; //tempo tabular
                toolStripStatusLabel4.Text = ""; //skill


                lsphone.LastCall = false;
                cmdUltimaLigacao.Text = "Último Atend: Não";
                cmdUltimaLigacao.Image = null;

                modulo.GravaLogApp("F.LimpaDadosAtend");

            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.LimpaDadosAtend");
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        /// <summary>
        /// Carrega_Motivos_Pausa
        /// </summary>
        public void Carrega_Motivos_Pausa()
        {
            try
            {
                modulo.GravaLogApp("I.Carrega_Motivos_Pausa");

                gerlourens obj = new gerlourens();
                string ssql = "";
                cmbpausa.Items.Clear();
                ItemCombo oitem;


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        ssql = "Select A.*,isnull(a.SOLICITAR_SENHA,0) 'Block',isnull(a.limite,0) 'Limite2',isnull(a.Limite_Dia,0) 'LimiteDia2'  FROM GATMotivoPausa A (nolock) Where A.Habilitado = 1";
                        ssql = ssql + " AND A.IDCodPausa IN (SELECT X.IDCodPausa FROM GATPausaPerfil X (NOLOCK) WHERE X.IDCodPerfil IN (";
                        ssql = ssql + " SELECT Y.IDCodPerfil FROM GATUsuarioPerfil Y (NOLOCK) WHERE Y.IDCodUsuario = " + modulo.IDCodUsuario.ToString() + ")";
                        ssql = ssql + " )";
                        ssql = ssql + " Order by A.Pausa";

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            oitem = new ItemCombo();
                            oitem.Value = dr["idcodpausa"].ToString();
                            oitem.Text = dr["pausa"].ToString();
                            oitem.Limite = Convert.ToInt32(dr["Limite2"].ToString());
                            oitem.Limite_Dia = Convert.ToInt32(dr["LimiteDia2"].ToString());

                            //Block
                            if (dr["Block"].ToString() == "1")
                            {
                                oitem.Block = true;
                            }
                            else
                            {
                                oitem.Block = false;
                            }

                            cmbpausa.Items.Add(oitem);
                            Application.DoEvents();
                        }
                        dr.Close();

                    }

                }

                modulo.GravaLogApp("F.Carrega_Motivos_Pausa");
            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.Carrega_Motivos_Pausa");
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// GravaLog
        /// </summary>
        /// <param name="slog"></param>
        public void GravaLog(string slog)
        {
            try
            {
                toolStripStatusLabel1.Text = slog;
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        delegate void CadastraListaD(string smsg);

        /// <summary>
        /// CadastraLista
        /// </summary>
        /// <param name="scallid"></param>
        /// <param name="sdevice"></param>
        /// <param name="sevento"></param>
        public void CadastraLista(string smsg)
        {
            bool bachou = false;

            string scallid;
            string sdevice;
            string sevento;
            string sactiveID;
            string sheldID;
            string sansweringDevice;
            string suserData;
            string subjectOfCall;

            char sep = ';';


            try
            {

                if (InvokeRequired)
                {
                    CadastraListaD callback = CadastraLista;
                    Invoke(callback, smsg);
                }
                else
                {


                    string[] arr = smsg.Split(sep);
                    scallid = arr[0];
                    sdevice = arr[1];
                    sevento = arr[2];
                    sactiveID = arr[3];
                    sheldID = arr[4];
                    sansweringDevice = arr[5];
                    suserData = arr[6];
                    subjectOfCall = "";

                    try
                    {
                        subjectOfCall = arr[7];
                    }
                    catch (Exception err)
                    {
                    }


                    if (sevento == "establishedevent")
                    {


                        if (modulo.Bina == "")
                        {
                            modulo.IDClienteAVAYA = sansweringDevice;
                            modulo.sUUI = suserData;
                            modulo.sSkill = subjectOfCall;
                            modulo.sVDN = "";
                            modulo.Bina = sansweringDevice;
                            modulo.DataInicioAtendimento = DateTime.Now;

                            toolStripStatusLabel4.Text = subjectOfCall;


                            AbrePopUp();
                        }


                        AtendimentoSucesso();




                    }


                }

            }
            catch (Exception err)
            {
                //modulo.Show_Mensagem_Alerta(err.Message);
            }

        }






        /// <summary>
        /// CriaNodeFilhos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="node"></param>
        public void CriaNodeFilhos(XmlNode item, TreeNode node)
        {

            foreach (XmlNode itemx in item.ChildNodes)
            {

                if (itemx.HasChildNodes == true)
                {
                    CriaNodeFilhos(itemx, node.Nodes.Add(itemx.Name));
                }
                else
                {
                    node.Nodes.Add(itemx.InnerText);
                }
                Application.DoEvents();
            }

        }


        /// <summary>
        /// CriarTreeRetorno
        /// </summary>
        /// <param name="otree"></param>
        /// <param name="snome"></param>
        /// <param name="oxml"></param>
        public void CriarTreeRetorno(TreeView otree, string snome, XmlDocument oxml)
        {

            //otree.Nodes.Clear();
            string skey = snome + otree.Nodes.Count.ToString();

            otree.Nodes.Clear();

            otree.Nodes.Add(skey, snome);

            //cria treeview
            foreach (XmlNode item in oxml.ChildNodes[1].ChildNodes)
            {

                if (item.HasChildNodes == true)
                {
                    CriaNodeFilhos(item, otree.Nodes[skey].Nodes.Add(item.Name));
                }
                else
                {
                    otree.Nodes[skey].Nodes.Add(item.Name).Nodes.Add(item.InnerText);
                }
                Application.DoEvents();
            }

            otree.Nodes[skey].ExpandAll();


        }



        /// <summary>
        /// 
        /// </summary>
        public frmCTIBar()
        {
            InitializeComponent();


            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(-1, -1);

            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, this.Size.Height);

            //cria eventos
            lsphone.OnAtendimento += new lsphone.lsAtender(this.Lsphone_OnAtendimento);
            lsphone.OnResposta += new lsphone.lsResp(this.Lsphone_OnResposta);
            lsphone.OnError += new lsphone.lsErro(this.Lsphone_OnError);

        }


        /// <summary>
        /// Lsphone_OnError
        /// </summary>
        /// <param name="coderro"></param>
        private void Lsphone_OnError(string coderro)
        {
            try
            {
                modulo.GravaLogApp("Lsphone_OnError : " + coderro);
                switch (coderro)
                {

                    case "ERR0001": //Erro: Usuário não informado
                        GravaLog("Erro: Usuário não informado");
                        break;
                    case "ERR0002": //Erro Login
                        GravaLog("Erro Login");
                        break;
                    case "ERR0003": //Erro Logout
                        GravaLog("Erro Logout");
                        break;
                    case "ERR0004": //Erro Ready
                        GravaLog("Erro Ready");
                        break;
                    case "ERR0005": //Erro Not Ready
                        GravaLog("Erro Not Ready");
                        break;
                    case "ERR0006": //Erro Conectar no Voxway
                        GravaLog("Erro Conectar no Voxway");
                        break;
                    case "ERR0007": //Erro Agendamento
                        GravaLog("Erro Agendamento");
                        break;
                    case "ERR0008": //Erro Cancelar Agendamento
                        GravaLog("Erro Cancelar Agendamento");
                        break;
                    case "ERR0009": //Erro Finalização
                        GravaLog("Erro Finalização");
                        break;
                    case "ERR0010": //Erro Hora de agendamento inválida
                        GravaLog("Erro Hora de agendamento inválida");
                        break;
                    case "ERR0011": //Erro Fone de agendamento inválido
                        GravaLog("Erro Fone de agendamento inválido");
                        break;
                    case "ERR0012": //Erro Perda de conexão com o Voxway
                        GravaLog("Erro Perda de conexão com o Voxway");
                        break;
                    case "ERR0013": //Erro Atender
                        GravaLog("Erro Atender");
                        break;
                    case "ERR0014": //Erro Conectar ao Banco de Dados
                        GravaLog("Erro Conectar ao Banco de Dados");
                        break;
                    case "ERR0015": //Erro Sem acesso ao link da Base de Dados
                        GravaLog("Erro Sem acesso ao link da Base de Dados");
                        break;
                    case "ERR0099": //Erro de Sistema
                        GravaLog("Erro de Sistema");
                        break;

                    default:
                        GravaLog("Erro de Sistema");
                        break;
                }


            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }

        /// <summary>
        /// Lsphone_OnResposta
        /// </summary>
        /// <param name="codresp"></param>
        private void Lsphone_OnResposta(string codresp)
        {
            try
            {
                modulo.GravaLogApp("Lsphone_OnResposta : " + codresp);
                switch (codresp)
                {

                    case "LS0001": //Conecatado ao GAT Link
                        GravaLog("Conecatado ao GAT Link");
                        break;
                    case "LS0002": //Login Sucesso


                        LoginSucesso();
                        GravaLog("Login realizado com sucesso");

                        //verifica se esta disponivel
                        if (cmdready_notready.Text == "Disponível")
                        {
                            lsphone.Ready();
                        }


                        tmr_ZenDesk.Enabled = true;
                        tmr_verifica_jornada.Enabled = true;

                        break;
                    case "LS0003": //Logout Sucesso


                        LogoutSucesso();
                        GravaLog("Logout realizado com sucesso");


                        panel3.Enabled = false;

                        VerificaLogDisponivel();



                        try
                        {
                            Application.ExitThread();
                            this.Close();
                        }
                        catch (Exception err)
                        {

                            modulo.Show_Mensagem_Alerta(err.Message);
                        }


                        break;
                    case "LS0004": //Ready Sucesso

                        ReadySucesso();
                        GravaLog("Ready realizado com sucesso");


                        break;
                    case "LS0005": //Not Ready Sucesso

                        NotReadySucesso();
                        GravaLog("Not Ready realizado com sucesso");

                        break;
                    case "LS0006": //Atender Sucesso


                        //habilita campos
                        HabilitaCampos();

                        //captura configuracoes do atendimento
                        Configuracoes_Atendimento();


                        GravaLog("Atendimento realizado com sucesso");

                        break;
                    case "LS0007": //Agendamento Sucesso
                        GravaLog("Agendamento Sucesso");
                        break;
                    case "LS0008": //
                        GravaLog("Cancelar Agendamento Sucesso");
                        break;
                    case "LS0009": //Finalizacao Sucesso


                        ////salva IDs
                        gerlourens obj = new gerlourens();

                        //using (SqlConnection cn = obj.abre_cn())
                        //{
                        //    using (SqlCommand cmd = new SqlCommand())
                        //    {
                        //        cmd.Connection = cn;
                        //        cmd.CommandText = "update gatcliente set idchamadas = '" + modulo.IDChamadas + "' where idcodcliente=" + modulo.idcodcliente.ToString();
                        //        cmd.CommandType = CommandType.Text;

                        //        cmd.ExecuteNonQuery();

                        //    }
                        //}


                        //Verifica se não foi Selecionado LastCall ou Pausa
                        if (modulo.AgentState == modulo.StatusAgente.EmAtendimento || modulo.AgentState == modulo.StatusAgente.PosAtendimento)
                        {

                            //deixa operador disponivel
                            using (SqlConnection cn = obj.abre_cn())
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.Connection = cn;
                                    cmd.CommandText = "update gatusuario set codstatususer = 2, dataultstatus = getdate() where idcodusuario = " + modulo.IDCodUsuario;
                                    cmd.CommandType = CommandType.Text;

                                    cmd.ExecuteNonQuery();

                                }
                            }

                            ReadySucesso();

                        }


                        obj = null;


                        //zera campos atendimento
                        LimpaDadosAtend();


                        //desabilita campos
                        DesabilitaCampos();


                        //Pausa Em Atendimento
                        if (modulo.PausaEmAtendimento == true)
                        {
                            modulo.PausaEmAtendimento = false;
                        }
                        else
                        {

                            //CTI


                        }

                        break;
                    case "LS0010": //Conexao DB Sucesso
                        GravaLog("Conexao DB Sucesso");
                        break;
                    case "LS0011": //Solicitação de Logout com Usuário em Atendimento
                        GravaLog("Solicitação de Logout com Usuário em Atendimento");
                        break;
                    case "LS0012": //Solicitação de Not Ready com Usuário em Atendimento
                        GravaLog("Solicitação de Not Ready com Usuário em Atendimento");


                        //indica pausa em atendimento
                        modulo.PausaEmAtendimento = true;


                        break;
                    case "LS0013": //Solicitação de Login com Usuário em Atendimento
                        GravaLog("Solicitação de Login com Usuário em Atendimento");
                        break;
                    case "LS0014": //Solicitação de Ready com Usuário em Atendimento
                        GravaLog("Solicitação de Ready com Usuário em Atendimento");
                        break;

                    default:
                        break;
                }



                modulo.GravaLogApp("F.Lsphone_OnResposta : " + codresp);
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// Lsphone_OnAtendimento
        /// </summary>
        private void Lsphone_OnAtendimento()
        {
            try
            {

                //carrega campos

                //habilita campos

                //captura tela

                //carrega motivo

                //atendimento sucesso
                AtendimentoSucesso();

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }



        /// <summary>
        /// frmCTIBar_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCTIBar_Load(object sender, EventArgs e)
        {

            try
            {
                gerlourens obj = new gerlourens();


                //verifica se ja existe aberto
                Process aProcess = Process.GetCurrentProcess();
                string aProcName = aProcess.ProcessName;

                //if (Process.GetProcessesByName(aProcName).Length > 1)
                //{

                //    modulo.Show_Mensagem_Alerta("CTI Bar já está aberto nessa máquina.[ process : " + aProcName + " ] ");

                //    Application.ExitThread();
                //    this.Close();
                //    return;
                //}


                //titulo aplicacao
                this.Text = "GAT Link FrontEnd - iFood ";
                this.Text = this.Text + "[ ";
                this.Text = this.Text + modulo.TipoLogin.ToString() + " - ";
                this.Text = this.Text + modulo.Versao + " - ";
                this.Text = this.Text + "Login: " + modulo.Login_Zenddesk + " - ";
                this.Text = this.Text + "HostName: " + modulo.Hostname;
                this.Text = this.Text + " ] ";


                //nome operador
                lbloperador.Text = modulo.Login_Zenddesk + " - " + modulo.NomeOperador;


                //atualiza versao do usuario logado
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "update gatusuario  set Versao_GAT='" + modulo.Versao + "', sversao='" + modulo.Versao + "' where idcodusuario=" + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }


                modulo.AgentState = modulo.StatusAgente.Logout;

                modulo.objFrmCTIBar = this;


                //lista as pausas
                Carrega_Motivos_Pausa();

                LimpaDadosAtend();

                Configuracoes_Atendimento();

                obj = null;




                //abre zendesk
                Zendesk_Abrir();

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// cmdtelefonia_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdtelefonia_Click(object sender, EventArgs e)
        {
            if (obj_frmtelefoniamanual != null)
            {
                obj_frmtelefoniamanual.Close();
                obj_frmtelefoniamanual.Dispose();
                obj_frmtelefoniamanual = null;
            }

            obj_frmtelefoniamanual = new frmtelefoniamanual();
            obj_frmtelefoniamanual.Show();
        }


        /// <summary>
        /// cmdbloconotas_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdbloconotas_Click(object sender, EventArgs e)
        {
            if (obj_frmbloconotas != null)
            {
                obj_frmbloconotas.Close();
                obj_frmbloconotas.Dispose();
                obj_frmbloconotas = null;
            }

            obj_frmbloconotas = new frmbloconotas();
            obj_frmbloconotas.Show();
        }


        /// <summary>
        /// cmdperformance_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdperformance_Click(object sender, EventArgs e)
        {

            if (obj_frmperformance != null)
            {
                obj_frmperformance.Close();
                obj_frmperformance.Dispose();
                obj_frmperformance = null;
            }

            obj_frmperformance = new frmperformance();
            obj_frmperformance.Show();
        }


        /// <summary>
        /// cmdpopup_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdpopup_Click(object sender, EventArgs e)
        {
            AbrePopUp();
        }


        /// <summary>
        /// AbrePopUp
        /// </summary>
        public void AbrePopUp()
        {
            try
            {

                return;

                if (obj_frmpopup != null)
                {
                    obj_frmpopup.Close();
                    obj_frmpopup.Dispose();
                    obj_frmpopup = null;
                }

                obj_frmpopup = new frmpopup();
                obj_frmpopup.Show();
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdlogin_logout_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdlogin_logout_Click(object sender, EventArgs e)
        {

            int ihora_server = 0;
            int ihora_conf_ini = 0;
            int ihora_conf_fim = 0;
            bool bok;

            cmdlogin_logout.Enabled = false;


            //validacao de jornada
            if (int.TryParse(modulo.Inicio_Jornada.Replace(":", ""), out ihora_conf_ini) == true)
            {
            }

            if (int.TryParse(modulo.Fim_Jornada.Replace(":", ""), out ihora_conf_fim) == true)
            {
            }


            if (ihora_conf_ini > 0 && ihora_conf_fim > 0)
            {

                //seleciona hora server
                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "select CAST(REPLACE(left(CONVERT(varchar(20), getdate(), 114), 5), ':', '') AS INT)";
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {
                            ihora_server = Convert.ToInt32(dr[0].ToString());
                        }
                        dr.Close();
                        dr = null;

                    }
                }
                obj = null;



                //verifica   
                //if (ihora_server >= ihora_conf_ini && ihora_server  <= ihora_conf_fim)
                if (ihora_server >= ihora_conf_ini)
                {
                    bok = true;
                }
                else
                {
                    bok = false;
                }




                if (bok == false)
                {
                    modulo.Show_Mensagem_Alerta("Atenção ! Usuário Fora da Jornada de Trabalho. Para executar essa ação será necessário a Liberação do seu Supervisor.");


                    //solicitacao de senha
                    modulo.Retorno_Libecacao_Acao = 0;
                    modulo.Funcao_Libecacao_Acao = "Liberacao_Jornada_Fora_Horario";

                    frmliberacaoacao ofrm = new frmliberacaoacao();
                    ofrm.ShowDialog();


                    if (modulo.Retorno_Libecacao_Acao == 0)
                    {
                        GravaLog("Ação Não Autorizada");
                        modulo.Show_Mensagem_Alerta("Ação Não Autorizada");
                        cmdlogin_logout.Enabled = true;
                        return;
                    }

                }



            }



            modulo.GravaLogApp("I.cmdlogin_logout_Click");

            if (cmdlogin_logout.Text == "Login")
            {


                //verifica   
                if (ihora_server > (ihora_conf_ini + 5))
                {
                    bok = true;
                }
                else
                {
                    bok = false;
                }



                if (bok == false)
                {
                    modulo.Show_Mensagem_Alerta("Atenção ! Você esta tentando se Logar Depois do Horário Inicial da sua Jornada de Trabalho. Para executar essa ação será necessário a Liberação do seu Supervisor.");


                    //solicitacao de senha
                    modulo.Retorno_Libecacao_Acao = 0;
                    modulo.Funcao_Libecacao_Acao = "Liberacao_Logout_Fora_Horario";

                    frmliberacaoacao ofrm = new frmliberacaoacao();
                    ofrm.ShowDialog();


                    if (modulo.Retorno_Libecacao_Acao == 0)
                    {
                        GravaLog("Ação Não Autorizada");
                        modulo.Show_Mensagem_Alerta("Ação Não Autorizada");
                        cmdlogin_logout.Enabled = true;
                        return;
                    }

                }



                ////
                //// Login ZenDesk
                ////
                //if (ZenDesk_Login() == false)
                //{
                //    modulo.Show_Mensagem_Alerta("Erro ao realizar Login no Zendesk");
                //    cmdlogin_logout.Enabled = true;
                //    return;
                //}




                //Login
                lsphone.Login();

            }
            else
            {

                //verifica   
                if (ihora_server < ihora_conf_fim)
                {
                    bok = false;
                }
                else
                {
                    bok = true;
                }


                if (bok == false)
                {
                    modulo.Show_Mensagem_Alerta("Atenção ! Você esta tentando se Deslogar Antes do Horário Final da sua Jornada de Trabalho. Para executar essa ação será necessário a Liberação do seu Supervisor.");


                    //solicitacao de senha
                    modulo.Retorno_Libecacao_Acao = 0;
                    modulo.Funcao_Libecacao_Acao = "Liberacao_Logout_Fora_Horario";

                    frmliberacaoacao ofrm = new frmliberacaoacao();
                    ofrm.ShowDialog();


                    if (modulo.Retorno_Libecacao_Acao == 0)
                    {
                        GravaLog("Ação Não Autorizada");
                        modulo.Show_Mensagem_Alerta("Ação Não Autorizada");
                        cmdlogin_logout.Enabled = true;
                        return;
                    }

                }



                //logout
                lsphone.Logout();

            }

            cmdlogin_logout.Enabled = true;

            modulo.GravaLogApp("F.cmdlogin_logout_Click");

        }



        /// <summary>
        /// Ready_NotReady
        /// </summary>
        public void Ready_NotReady()
        {
            modulo.GravaLogApp("I.cmdready_notready_Click");


            //
            if (modulo.AgentState == modulo.StatusAgente.Logout)
            {
                return;
            }

            cmdready_notready.Enabled = false;



            if (cmdready_notready.Text == "Disponível")
            {

                //Ready
                lsphone.Ready();

            }
            else
            {

                if (modulo.ID_Pausa_Selecionada == 0)
                {
                    modulo.Show_Mensagem_Alerta("Selecione a Pausa");
                }
                else
                {
                    //NotReady
                    lsphone.NotReady(modulo.ID_Pausa_Selecionada);
                }

            }

            cmdready_notready.Enabled = true;

            modulo.GravaLogApp("F.cmdready_notready_Click");
        }

        /// <summary>
        /// cmdready_notready_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdready_notready_Click(object sender, EventArgs e)
        {
            Ready_NotReady();
        }


        /// <summary>
        /// LoginSucesso
        /// </summary>
        public void LoginSucesso()
        {
            try
            {
                modulo.GravaLogApp("I.LoginSucesso");


                cmdlogin_logout.Text = "Logout";

                modulo.dttime = DateTime.Now;
                txttimer.Text = "00:00:00";

                modulo.AgentState = modulo.StatusAgente.Logado;
                txtstatus.Text = "LOGADO";
                txtstatus.BackColor = Color.Yellow;
                txtstatus.ForeColor = Color.Black;

                modulo.GravaLogApp("F.LoginSucesso");

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        /// <summary>
        /// LogoutSucesso
        /// </summary>
        public void LogoutSucesso()
        {
            try
            {
                modulo.GravaLogApp("I.LogoutSucesso");

                cmdlogin_logout.Text = "Login";

                modulo.dttime = DateTime.Now;
                txttimer.Text = "00:00:00";

                modulo.AgentState = modulo.StatusAgente.Logout;
                txtstatus.Text = "DESLOGADO";
                txtstatus.BackColor = Color.White;
                txtstatus.ForeColor = Color.Black;

                modulo.GravaLogApp("F.LogoutSucesso");


                try
                {
                    driver.Close();
                }
                catch (Exception err)
                {
                }

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// ReadySucesso
        /// </summary>
        public void ReadySucesso()
        {
            try
            {
                //item selecionado
                ItemCombo osel = (ItemCombo)cmbpausa.SelectedItem;

                if (osel != null)
                {
                    //Formata tempo contabilizado e tempo limite da pausa em segundo para verificação
                    var tempo = TimeSpan.Parse(txttimer.Text).TotalSeconds;
                    var tempolimite = TimeSpan.Parse("00:" + osel.Limite + ":00").TotalSeconds;

                    //verifica se o tempo contado é menos que o limite - 
                    // Não permitir ficar disponivel se for menor
                    if (Convert.ToInt32(tempo) < Convert.ToInt32(tempolimite))
                    {
                        modulo.Show_Mensagem_Alerta("Não é permitido retirar a Pausa antes do limite!");
                        frmliberacaoacao ofrm = new frmliberacaoacao();
                        ofrm.ShowDialog();
                    }
                }


                modulo.GravaLogApp("I.ReadySucesso");

                cmdready_notready.Text = "Pausa";

                modulo.dttime = DateTime.Now;
                txttimer.Text = "00:00:00";
                modulo.AgentState = modulo.StatusAgente.Ready;

                txtstatus.Text = "DISPONÍVEL";
                txtstatus.BackColor = Color.Green;
                txtstatus.ForeColor = Color.White;

                modulo.ID_Pausa_Selecionada = 0;


                modulo.GravaLogApp("F.ReadySucesso");

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// AtendimentoSucesso
        /// </summary>
        public void AtendimentoSucesso()
        {
            try
            {
                modulo.GravaLogApp("I.AtendimentoSucesso");

                modulo.dttime = DateTime.Now;
                txttimer.Text = "00:00:00";
                modulo.AgentState = modulo.StatusAgente.EmAtendimento;
                modulo.Hide_Function_ZenDesk = true;


                txtstatus.Text = "EM ATENDIMENTO";
                txtstatus.BackColor = Color.DarkBlue;
                txtstatus.ForeColor = Color.White;


                //deixa operador EM ATENDIMENTO
                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "update gatusuario set logado=1,CodStatusUser=4,DataUltStatus=getdate() where idcodusuario=" + modulo.IDCodUsuario.ToString() + " and CodStatusUser <> 4 ";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }


                modulo.GravaLogApp("F.AtendimentoSucesso");
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// PosAtendimentoSucesso
        /// </summary>
        public void PosAtendimentoSucesso()
        {
            try
            {

                modulo.GravaLogApp("I.PosAtendimentoSucesso");

                modulo.dttime = DateTime.Now;
                txttimer.Text = "00:00:00";
                modulo.AgentState = modulo.StatusAgente.PosAtendimento;

                txtstatus.Text = "PÓS ATENDIMENTO";
                txtstatus.BackColor = Color.DarkOrange;
                txtstatus.ForeColor = Color.Black;

                modulo.TempoTabular = modulo.TempoEntreChamadas;


                //deixa operador POS ATENDIMENTO
                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "update gatusuario set logado=1,CodStatusUser=8,DataUltStatus=getdate() where idcodusuario=" + modulo.IDCodUsuario.ToString() + " and CodStatusUser <> 8";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }



                //callback
                //if (obj_frmcallback != null)
                //{
                //    obj_frmcallback.Close();
                //    obj_frmcallback.Dispose();
                //    obj_frmcallback = null;
                //}


                //verifica se a aberta da tela de callback esta ativada
                //if (modulo.AbrirTelaCallBack == 1)
                //{
                //    //desativa timer avaya
                //    tmr_Avaya.Enabled = false;

                //    obj_frmcallback = new frmcallback();
                //    obj_frmcallback.ShowDialog();

                //    tmr_Avaya.Enabled = true;

                //}



                modulo.GravaLogApp("F.PosAtendimentoSucesso");

            }
            catch (Exception err)
            {
                tmr_Avaya.Enabled = true;

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }

        /// <summary>
        /// NotReadySucesso
        /// </summary>
        public void NotReadySucesso()
        {
            try
            {
                modulo.GravaLogApp("I.NotReadySucesso");

                cmdready_notready.Text = "Disponível";

                modulo.dttime = DateTime.Now;
                txttimer.Text = "00:00:00";
                modulo.AgentState = modulo.StatusAgente.NotReady;

                txtstatus.Text = "PAUSA";
                txtstatus.BackColor = Color.Red;
                txtstatus.ForeColor = Color.White;

                modulo.GravaLogApp("F.NotReadySucesso");

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }



        /// <summary>
        /// frmCTIBar_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCTIBar_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {

                if (modulo.AgentState == modulo.StatusAgente.Logout)
                {



                    gerlourens obj = new gerlourens();

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = cn;
                            cmd.CommandText = "update gatusuario set emuso = 0, hab_captura_tela=0 where idcodusuario = " + modulo.IDCodUsuario.ToString(); ;
                            cmd.CommandType = CommandType.Text;

                            cmd.ExecuteNonQuery();

                        }

                    }


                    Application.ExitThread();

                }
                else
                {

                    if (bacaoindevia == false)
                    {

                        modulo.Show_Mensagem_Alerta("Usuário precisa estar Deslogado para Fechar a Aplicação");
                        e.Cancel = true;

                    }


                }

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }


        }


        /// <summary>
        /// cmdselpausa_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdselpausa_Click(object sender, EventArgs e)
        {
            try
            {

                //verifica se foi selecionado o motivo
                if (cmbpausa.SelectedIndex == -1)
                {
                    GravaLog("Selecione o Motivo da Pausa");
                    modulo.Show_Mensagem_Alerta("Selecione o Motivo da Pausa");
                    return;
                }

                cmdselpausa.Enabled = false;

                //item selecionado
                ItemCombo osel = (ItemCombo)cmbpausa.SelectedItem;


                //abre tela de liberacao
                if (osel.Block == true)
                {

                    modulo.Retorno_Libecacao_Acao = 0;
                    modulo.Funcao_Libecacao_Acao = "Liberacao_Motivo_Pausa";

                    frmliberacaoacao ofrm = new frmliberacaoacao();
                    ofrm.ShowDialog();


                    if (modulo.Retorno_Libecacao_Acao == 0)
                    {
                        modulo.ID_Pausa_Selecionada = 0;
                        GravaLog("Pausa Não Autorizada");
                        modulo.Show_Mensagem_Alerta("Pausa Não Autorizada");
                        cmdselpausa.Enabled = true;
                        return;
                    }


                }


                //
                // Limite Pausa Dia
                //
                if (osel.Limite_Dia > 0)
                {
                    int totpausadia = 0;

                    //seleciona total da pausa no dia
                    gerlourens obj = new gerlourens();

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandText = "select count(1) from gattempopausa (nolock) where idcodpausa = " + osel.Value + " and cast(datainicio as date) = cast(getdate() as date) and idcodusuario = " + modulo.IDCodUsuario.ToString();
                            cmd.CommandType = CommandType.Text;

                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                totpausadia = Convert.ToInt32(dr[0].ToString());
                            }
                            dr.Close();
                            dr = null;

                        }

                    }
                    obj = null;


                    if (totpausadia >= osel.Limite_Dia)
                    {


                        modulo.Retorno_Libecacao_Acao = 0;
                        modulo.Funcao_Libecacao_Acao = "Liberacao_Motivo_Pausa_Limite_Dia";

                        frmliberacaoacao ofrm = new frmliberacaoacao();
                        ofrm.ShowDialog();


                        if (modulo.Retorno_Libecacao_Acao == 0)
                        {
                            modulo.ID_Pausa_Selecionada = 0;
                            GravaLog("Pausa Não Autorizada");
                            modulo.Show_Mensagem_Alerta("Pausa Não Autorizada");
                            cmdselpausa.Enabled = true;
                            return;
                        }



                    }

                }



                //define dados pausa
                modulo.ID_Pausa_Selecionada = Convert.ToInt32(osel.Value);
                modulo.Motivo_Pausa_Selecionada = osel.Text;
                modulo.Limite_Pausa_Selecionada = Convert.ToInt32(osel.Limite);
                modulo.Limite_Dia_Pausa_Selecionada = Convert.ToInt32(osel.Limite_Dia);


                Ready_NotReady();


                GravaLog("Pausa Selecionada com Sucesso !");

                cmdselpausa.Enabled = true;

            }
            catch (Exception err)
            {
                cmdselpausa.Enabled = true;
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// VerificaLogDisponivel
        /// </summary>
        public void VerificaLogDisponivel()
        {
            try
            {
                //log disponivel - salva a data de inicio disponivel
                if (modulo.AgentState == modulo.StatusAgente.Ready && blog_disponivel == false)
                {
                    blog_disponivel = true;
                    dtIni_disponivel = DateTime.Now;
                }


                if (modulo.AgentState != modulo.StatusAgente.Ready && blog_disponivel == true)
                {

                    //funcao q grava o log
                    modulo.LogTempoDisponivel(dtIni_disponivel);

                    blog_disponivel = false;

                }
            }
            catch (Exception err)
            {

            }
        }

        /// <summary>
        /// tmr_status_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_status_Tick(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.tmr_status_Tick");

                tmr_status.Enabled = false;


                VerificaLogDisponivel();


                Application.DoEvents();



                //contador no relogio
                if (modulo.AgentState != modulo.StatusAgente.Logout)
                {

                    modulo.TempoStatus = Convert.ToInt32((DateTime.Now - modulo.dttime).TotalSeconds);

                    txttimer.Text = modulo.horacheia(Convert.ToInt32((DateTime.Now - modulo.dttime).TotalSeconds));
                }

                Application.DoEvents();

                if (modulo.ChamadasRamal.Count == 0)
                {

                    grp_linha1.Visible = false;
                    grp_linha2.Visible = false;

                    img_linha1.Visible = false;
                    img_linha2.Visible = false;
                    img_linha3.Visible = false;
                    img_linha4.Visible = false;

                    lblnumero_linha1.Visible = false;
                    lblnumero_linha2.Visible = false;
                }

                Application.DoEvents();
                if (modulo.ChamadasRamal.Count == 1)
                {

                    grp_linha2.Visible = false;

                    img_linha2.Visible = false;
                    img_linha3.Visible = false;
                    img_linha4.Visible = false;

                    lblnumero_linha2.Visible = false;
                }

                Application.DoEvents();
                if (modulo.ChamadasRamal.Count == 2)
                {
                    img_linha3.Visible = false;
                    img_linha4.Visible = false;

                }

                Application.DoEvents();

                //linha 1
                try
                {
                    if (modulo.ChamadasRamal[0].status.ToString() != "")
                    {
                        grp_linha1.Visible = true;

                        img_linha1.Visible = true;
                        lblnumero_linha1.Visible = true;

                        lblnumero_linha1.Text = modulo.ChamadasRamal[0].numero;

                        imghold_linha1.Visible = true;
                        imgretorna_linha1.Visible = true;
                        imgdesliga_linha1.Visible = true;

                        //imagem
                        if (modulo.ChamadasRamal[0].status == StatusChamada.Atendida)
                        {
                            img_linha1.Image = Properties.Resources.connect;
                            lblnumero_linha1.ForeColor = Color.Green;

                        }

                        if (modulo.ChamadasRamal[0].status == StatusChamada.Hold)
                        {
                            img_linha1.Image = Properties.Resources.hold;
                            lblnumero_linha1.ForeColor = Color.Red;
                        }

                        if (modulo.ChamadasRamal[0].status == StatusChamada.MakeCall)
                        {
                            img_linha1.Image = Properties.Resources.makecall;
                            lblnumero_linha1.ForeColor = Color.Blue;
                        }

                    }

                }
                catch (Exception err)
                {
                }

                Application.DoEvents();
                //linha 2
                try
                {
                    if (modulo.ChamadasRamal[1].status.ToString() != "")
                    {
                        grp_linha1.Visible = true;


                        img_linha2.Visible = true;
                        lblnumero_linha2.Visible = true;
                        lblnumero_linha2.Text = modulo.ChamadasRamal[1].numero;

                        imghold_linha2.Visible = true;
                        imgretorna_linha2.Visible = true;
                        imgdesliga_linha2.Visible = true;

                        //imagem
                        if (modulo.ChamadasRamal[1].status == StatusChamada.Atendida)
                        {
                            img_linha2.Image = Properties.Resources.connect;
                            lblnumero_linha2.ForeColor = Color.Green;

                        }

                        if (modulo.ChamadasRamal[1].status == StatusChamada.Hold)
                        {
                            img_linha2.Image = Properties.Resources.hold;
                            lblnumero_linha2.ForeColor = Color.Red;
                        }

                        if (modulo.ChamadasRamal[1].status == StatusChamada.MakeCall)
                        {
                            img_linha2.Image = Properties.Resources.makecall;
                            lblnumero_linha2.ForeColor = Color.Blue;
                        }

                    }
                }
                catch (Exception err)
                {
                }

                Application.DoEvents();
                //linha 3
                try
                {
                    if (modulo.ChamadasRamal[2].status.ToString() != "")
                    {
                        img_linha3.Visible = true;
                    }
                }
                catch (Exception err)
                {
                }

                Application.DoEvents();

                //linha 4
                try
                {
                    if (modulo.ChamadasRamal[3].status.ToString() != "")
                    {
                        img_linha4.Visible = true;
                    }
                }
                catch (Exception err)
                {
                }

                tmr_status.Enabled = true;

                Application.DoEvents();


                modulo.GravaLogApp("F.tmr_status_Tick");

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// imghold_linha1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imghold_linha1_Click(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.imghold_linha1_Click");

                imghold_linha1.Enabled = false;


                imghold_linha1.Enabled = true;


                modulo.GravaLogApp("F.imghold_linha1_Click");


            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        private void imgretorna_linha1_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// imgretorna_linha1_Click_1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgretorna_linha1_Click_1(object sender, EventArgs e)
        {
            try
            {

                modulo.GravaLogApp("I.imgretorna_linha1_Click_1");

                imgretorna_linha1.Enabled = false;

                imgretorna_linha1.Enabled = true;


                modulo.GravaLogApp("F.imgretorna_linha1_Click_1");

            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// imghold_linha2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imghold_linha2_Click(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.imghold_linha2_Click");

                imghold_linha2.Enabled = false;

                imghold_linha2.Enabled = true;

                modulo.GravaLogApp("F.imghold_linha2_Click");
            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// imgretorna_linha2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgretorna_linha2_Click(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.imgretorna_linha2_Click");

                imgretorna_linha2.Enabled = false;

                imgretorna_linha2.Enabled = true;

                modulo.GravaLogApp("F.imgretorna_linha2_Click");

            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        private void grp_linha1_Enter(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// imgdesliga_linha1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgdesliga_linha1_Click(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.imgdesliga_linha1_Click");

                imgdesliga_linha1.Enabled = false;

                imgdesliga_linha1.Enabled = true;

                modulo.GravaLogApp("F.imgdesliga_linha1_Click");

            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// imgdesliga_linha2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgdesliga_linha2_Click(object sender, EventArgs e)
        {
            try
            {

                modulo.GravaLogApp("I.imgdesliga_linha2_Click");

                imgdesliga_linha2.Enabled = false;

                imgdesliga_linha2.Enabled = true;


                modulo.GravaLogApp("F.imgdesliga_linha2_Click");

            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// cmdUltimaLigacao_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUltimaLigacao_Click(object sender, EventArgs e)
        {
            int ihora_server = 0;
            int ihora_conf_ini = 0;
            int ihora_conf_fim = 0;
            bool bok;

            return;


            //validacao de jornada
            if (int.TryParse(modulo.Inicio_Jornada.Replace(":", ""), out ihora_conf_ini) == true)
            {
            }

            if (int.TryParse(modulo.Fim_Jornada.Replace(":", ""), out ihora_conf_fim) == true)
            {
            }

            if (ihora_conf_ini > 0 && ihora_conf_fim > 0)
            {

                //seleciona hora server
                gerlourens obj = new gerlourens();

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "select CAST(REPLACE(left(CONVERT(varchar(20), getdate(), 114), 5), ':', '') AS INT)";
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {
                            ihora_server = Convert.ToInt32(dr[0].ToString());
                        }
                        dr.Close();
                        dr = null;

                    }
                }
                obj = null;

            }





            try
            {

                if (cmdUltimaLigacao.Text == "Último Atend: Sim")
                {
                    lsphone.LastCall = false;
                    cmdUltimaLigacao.Text = "Último Atend: Não";

                    cmdUltimaLigacao.Image = null;

                }
                else
                {

                    //verifica   
                    if (ihora_server < ihora_conf_fim)
                    {
                        bok = false;
                    }
                    else
                    {
                        bok = true;
                    }


                    if (bok == false)
                    {
                        modulo.Show_Mensagem_Alerta("Atenção ! Você esta tentando se Deslogar Antes do Horário Final da sua Jornada de Trabalho. Para executar essa ação será necessário a Liberação do seu Supervisor.");


                        //solicitacao de senha
                        modulo.Retorno_Libecacao_Acao = 0;
                        modulo.Funcao_Libecacao_Acao = "Liberacao_Logout_Fora_Horario";

                        frmliberacaoacao ofrm = new frmliberacaoacao();
                        ofrm.ShowDialog();


                        if (modulo.Retorno_Libecacao_Acao == 0)
                        {
                            GravaLog("Ação Não Autorizada");
                            modulo.Show_Mensagem_Alerta("Ação Não Autorizada");
                            return;
                        }

                    }


                    lsphone.LastCall = true;
                    cmdUltimaLigacao.Text = "Último Atend: Sim";


                    cmdUltimaLigacao.Image = Properties.Resources.sair;

                }



            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }




        /// <summary>
        /// tmr_Avaya_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_Avaya_Tick(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.tmr_Avaya_Tick");

                tmr_Avaya.Enabled = false;

                string sretorno = "";
                string ssql = "";
                int imotivo = 0;


                gerlourens obj = new gerlourens();



                //
                // INICIA ATENDIMENTO
                //
                //IniciaAtendimento();



                //
                // POS ATENDIMENTO
                //
                if (modulo.AgentState == modulo.StatusAgente.PosAtendimento)
                {

                    if (modulo.TempoEntreChamadas > 0)
                    {

                        toolStripStatusLabel3.Text = "Tempo para Tabular : " + modulo.TempoTabular.ToString();


                        modulo.TempoTabular = modulo.TempoTabular - 1;

                        if (modulo.TempoTabular <= 0)
                        {

                            //callback --- fecha o callback

                            //tabula automatico o callback

                            //printa  tela


                            //verifica se foi selecionado o motivo
                            imotivo = 1;

                            //registro da ligacao
                            lsphone.Finalizar_Ligacao(imotivo, "", modulo.DataInicioAtendimento);

                        }


                    }
                    else
                    {
                        //encerramento imediato


                        //verifica se foi selecionado o motivo
                        imotivo = 1;

                        //registro da ligacao
                        lsphone.Finalizar_Ligacao(imotivo, "", modulo.DataInicioAtendimento);

                    }

                }




                //
                // DISPONIVEL .... GETTICKET
                //
                //if (modulo.AgentState == modulo.StatusAgente.Ready)
                //{

                //    if (ZenDesk_GetTicket() == false)
                //    {
                //        GravaLog("Erro ao Capturar Ticket");
                //    }
                //    else
                //    {
                //        //Inicia Atendimento
                //        IniciaAtendimento();
                //    }

                //}

                Application.DoEvents();

                obj = null;



                modulo.GravaLogApp("F.tmr_Avaya_Tick");

                tmr_Avaya.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.tmr_Avaya_Tick");
                Application.DoEvents();
                tmr_Avaya.Enabled = true;
                GravaLog("Erro tmr_Avaya : " + err.Message);
            }
        }

        /// <summary>
        /// cmdtarefas_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdtarefas_Click(object sender, EventArgs e)
        {
            try
            {

                //modulo.Show_Mensagem_Alerta("Atenção ! Será necessário informar a Justificativa para liberação da Ação no ZenDesk", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //solicitacao de senha
                //modulo.Retorno_Libecacao_Acao = 0;

                //frmliberacao_zendesk ofrm = new frmliberacao_zendesk();
                //ofrm.ShowDialog();


                //if (modulo.Retorno_Libecacao_Acao == 0)
                //{
                //GravaLog("Ação Não Autorizada");
                //modulo.Hide_Function_ZenDesk = true;

                //return;
                //}
                //else
                //{



                //printa a tela


                //gera log
                try
                {
                    string sdml = "";
                    sdml = "insert into GATLogLiberacaoZenDesk (idcodcliente,idcodusuario,idcodjustificativa,justificativa,ticket,ticket_sla,ticket_tipo,data_liberacao,idcodperfil,idcodequipe) values (" + modulo.idcodcliente.ToString() + "," + modulo.IDCodUsuario.ToString() + ",2,'Liberação Zendesk','" + modulo.Ticket + "','" + modulo.Ticket_SLA + "','" + modulo.Ticket_Tipo + "',getdate()," + modulo.IDCodPerfil.ToString() + "," + modulo.IDCodEquipe.ToString() + ")";

                    modulo.ExecCommand(sdml);
                }
                catch (Exception err)
                {
                }


                modulo.CapturaTelaCliente();
                modulo.Hide_Function_ZenDesk = false;


                //}

            }
            catch (Exception err)
            {



                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// tmr_capturatela_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_capturatela_Tick(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.tmr_capturatela_Tick");

                tmr_capturatela.Enabled = false;

                modulo.CapturaTelaCliente();

                Application.DoEvents();


                modulo.GravaLogApp("F.tmr_capturatela_Tick");

                tmr_capturatela.Enabled = true;



            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.tmr_capturatela_Tick");
                tmr_capturatela.Enabled = true;
            }
        }


        /// <summary>
        /// tmr_capturatelausuario_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_capturatelausuario_Tick(object sender, EventArgs e)
        {
            try
            {
                modulo.GravaLogApp("I.tmr_capturatelausuario_Tick");

                tmr_capturatelausuario.Enabled = false;


                if (modulo.OnCapturaTela == 1)
                {
                    gerlourens obj = new gerlourens();


                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandText = "select isnull(hab_captura_tela,0) 'hab_captura_tela' from gatusuario (nolock) where idcodusuario=" + modulo.IDCodUsuario.ToString();
                            cmd.CommandType = CommandType.Text;


                            SqlDataReader dr = cmd.ExecuteReader();


                            if (dr.Read())
                            {

                                if (dr["hab_captura_tela"].ToString() == "1")
                                {
                                    modulo.CapturaTelaUsuario();
                                }

                            }
                            dr.Close();



                        }

                    }


                    obj = null;
                }


                Application.DoEvents();

                modulo.GravaLogApp("F.tmr_capturatelausuario_Tick");
                tmr_capturatelausuario.Enabled = true;
            }
            catch (Exception err)
            {

                modulo.GravaLogApp("E.tmr_capturatelausuario_Tick");
                tmr_capturatelausuario.Enabled = true;

            }
        }





        /// <summary>
        /// tmr_bloqueio_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_bloqueio_Tick(object sender, EventArgs e)
        {
            try
            {
                tmr_bloqueio.Enabled = false;
                modulo.GravaLogApp("I.tmr_bloqueio_Tick");
                string ssql = "";

                //
                // PAUSA
                //
                if (modulo.AgentState == modulo.StatusAgente.NotReady)
                {

                    //verifica pausa
                    if (modulo.Limite_Pausa_Selecionada > 0)
                    {
                        int temp = Convert.ToInt32((modulo.TempoStatus / 60));
                        //verifica de excedeu
                        if (temp >= modulo.Limite_Pausa_Selecionada)
                        {

                            //bloqueia usuario
                            ExecCommand("update gatusuario set bloqueado = 1,Bloq_Estouro_Pausa = 1, idusuario_liberou_bloq_pausa = null where idcodusuario = " + modulo.IDCodUsuario.ToString());


                            //log
                            ssql = " insert into gattempousuario";
                            ssql = ssql + " (idcodusuario,idcodtempo,datatempo,";
                            ssql = ssql + " idcodturno,idcodperfil,idpermissao)";
                            ssql = ssql + " values (" + modulo.IDCodUsuario.ToString();
                            ssql = ssql + " ,7,getdate(),";
                            ssql = ssql + " (select top 1 idcodturno from gatusuario (nolock)";
                            ssql = ssql + " where idcodusuario=" + modulo.IDCodUsuario.ToString() + "),";
                            ssql = ssql + " (select top 1 idcodperfil from gatusuarioperfil(nolock)";
                            ssql = ssql + " where idcodusuario=" + modulo.IDCodUsuario.ToString() + "),";
                            ssql = ssql + " 3)";

                            ExecCommand(ssql);



                            //tela de bloqueio
                            frmbloqueiotela oblock = new frmbloqueiotela();
                            oblock.ShowDialog();

                        }

                    }

                }


                Application.DoEvents();

                modulo.GravaLogApp("F.tmr_bloqueio_Tick");

                tmr_bloqueio.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.tmr_bloqueio_Tick");
                tmr_bloqueio.Enabled = true;
            }
        }


        /// <summary>
        /// ExecCommand
        /// </summary>
        /// <param name="scmd"></param>
        public void ExecCommand(string scmd)
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

        /// <summary>
        /// tmr_garbage_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_garbage_Tick(object sender, EventArgs e)
        {
            try
            {
                tmr_garbage.Enabled = false;

                //modulo.GravaLogApp("I.tmr_garbage_Tick");

                //GC.Collect();

                //modulo.GravaLogApp("F.tmr_garbage_Tick");
                //Application.DoEvents();
                //tmr_garbage.Enabled = true;


            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.tmr_garbage_Tick");

                tmr_garbage.Enabled = true;
            }
        }



        /// <summary>
        /// pictureBox1_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {
            modulo.IDClienteAVAYA = "7722454";
        }






        /// <summary>
        /// cmdzendesk_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdzendesk_Click(object sender, EventArgs e)
        {
            Zendesk_Abrir();
        }






        /// <summary>
        /// tmr_driver_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_driver_Tick(object sender, EventArgs e)
        {
            try
            {
                tmr_driver.Enabled = false;


                //atualiza status ticket
                ExecCommand("update gatusuario set Retrato_Tickets_Playlist='" + modulo.Ticket_Playlist + "' where idcodusuario = " + modulo.IDCodUsuario.ToString());

                //atualiza status user playlist
                ExecCommand("update gatusuario set Status_User_Playlist='" + modulo.Status_User_Playlist + "' where idcodusuario = " + modulo.IDCodUsuario.ToString());


                //atualiza Lupa
                ExecCommand("update gatusuario set Resultado_Ticket_Filtro_Lupa_Configurado='" + modulo.Resultado_Ticket_Filtro_Lupa_Configurado + "', Ticket_Filtro_Lupa='" + modulo.Ticket_Filtro_Lupa + "' where idcodusuario = " + modulo.IDCodUsuario.ToString());


                if (isBrowserClosed((ChromeDriver)driver) == true)
                {
                    toolStripStatusLabel5.Text = "Chrome_Close";
                    toolStripStatusLabel5.ForeColor = Color.Red;

                    //
                    LogFechamentoZenDesk();

                }
                else
                {
                    toolStripStatusLabel5.Text = "Chrome_Run";
                    toolStripStatusLabel5.ForeColor = Color.Blue;
                }

                Application.DoEvents();

                tmr_driver.Enabled = true;

            }
            catch (Exception err)
            {
                tmr_driver.Enabled = true;
            }
        }


        /// <summary>
        /// LogFechamentoZenDesk
        /// </summary>
        public void LogFechamentoZenDesk()
        {
            try
            {

                gerlourens obj = new gerlourens();

                //fechamento
                if (modulo.idcodcliente > 0)
                {
                    //registro da ligacao
                    lsphone.Finalizar_Ligacao(31, "", modulo.DataInicioAtendimento);
                }



                //log
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into GATLogFechamentoZendesk (idcodusuario,idcodcliente,datalog ) values  (" + modulo.IDCodUsuario.ToString() + ", " + modulo.idcodcliente.ToString() + ", GETDATE() )";


                        cmd.ExecuteNonQuery();

                    }
                }


                //desloga usuario
                lsphone.Logout();


            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }




        /// <summary>
        /// tmr_getticket_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_getticket_Tick(object sender, EventArgs e)
        {
            try
            {

                tmr_ZenDesk.Enabled = false;

                string sURL = "";



                #region URL
                try
                {
                    toolStripStatusLabel6.Text = driver.Url;
                    sURL = driver.Url;
                }
                catch (Exception err)
                {
                }

                #endregion

                Application.DoEvents();




                #region LOGIN

                try
                {
                    ZenDesk_Login();
                }
                catch (Exception err)
                {
                }

                #endregion


                //Application.DoEvents();



                #region GET_STATUS_USER

                toolStripStatusLabel7.Text = ZendDesk_GetStatusUser();
                modulo.Status_User_Playlist = toolStripStatusLabel7.Text;

                /*
                if (modulo.AgentState == modulo.StatusAgente.Ready && toolStripStatusLabel7.Text != "Online" && toolStripStatusLabel7.Text != "")
                {
                    ZenDesk_SetStatus("Online");
                }


                if (modulo.AgentState == modulo.StatusAgente.NotReady && modulo.ID_Pausa_Selecionada != 1009 && toolStripStatusLabel7.Text != "Away" && toolStripStatusLabel7.Text != "")
                {
                    ZenDesk_SetStatus("Away");
                }


                if (modulo.AgentState == modulo.StatusAgente.NotReady && modulo.ID_Pausa_Selecionada == 1009 && toolStripStatusLabel7.Text != "Invisible" && toolStripStatusLabel7.Text != "")
                {
                    ZenDesk_SetStatus("Invisible");
                }
                */

                #endregion


                //Application.DoEvents();



                #region GET_TICKETS_PLAYLIST

                modulo.Ticket_Playlist = ZendDesk_GetStatusTicketsPlayList();
                toolStripStatusLabel8.Text = modulo.Ticket_Playlist;
                #endregion


                //Application.DoEvents();



                #region GET_RESULTA_LUPA

                if (sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/search") > -1)
                {
                    modulo.Resultado_Ticket_Filtro_Lupa_Configurado = ZendDesk_GetResultadoTicketLupa();
                }

                #endregion



                //Application.DoEvents();

                #region FILTRO_LUPA

                try
                {
                    if (sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/search") > -1)
                    {

                        //captura filtro
                        string sfiltro_lupa = ZenDesk_Get_Filtro_Lupa();


                        if (sfiltro_lupa == "")
                        {
                            sfiltro_lupa = "[sem filtro]";
                        }

                        modulo.Ticket_Filtro_Lupa = sfiltro_lupa;

                    }
                    else
                    {
                        //zera o campo
                        modulo.Ticket_Filtro_Lupa = "";

                    }
                }
                catch (Exception)
                {

                }


                #endregion



                //Application.DoEvents();


                #region  GET_PEDIDOS
                if (modulo.AgentState != modulo.StatusAgente.NotReady)
                {
                    if (sURL == @"https://ifood-cons-br.zendesk.com/agent/filters/assigned")
                    {
                        ZenDesk_ClickEmAtendimento();
                    }

                }

                #endregion




                //Application.DoEvents();


                #region  ATENDIMENTO_DE_PEDIDO

                try
                {
                    if (sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/tickets/") > -1)
                    {

                        string sdados_ticket = "";
                        string stipo_ticket = "";
                        string sticket = "";
                        string sdados_ticket_sla = "";
                        bool bexec = true;



                        //verifica se a URL permance a mesma
                        if (modulo.Ticket.Trim() != "")
                        {
                            if (sURL.IndexOf(modulo.Ticket) > -1)
                            {
                                bexec = false;
                            }

                        }



                        if (bexec == true)
                        {

                            //Dados do Ticket
                            sdados_ticket = ZenDesk_Get_Ticket_Dados();
                            sdados_ticket_sla = ZenDesk_Get_Ticket_SLA();

                            if (sdados_ticket != "")
                            {
                                sdados_ticket = sdados_ticket.ToUpper();
                                sdados_ticket = sdados_ticket.Replace(("Incidente ").ToUpper(), "");

                                string[] arr = sdados_ticket.Split('#');

                                //captura dados
                                stipo_ticket = arr[0].Trim();
                                sticket = arr[1].Trim();


                                if (stipo_ticket == "ABERTO")
                                {
                                    stipo_ticket = "REABERTURA";
                                }

                            }

                            toolStripStatusLabel2.Text = sticket + " - " + stipo_ticket + " - " + sdados_ticket_sla + " - " + modulo.Ticket_Tabulacao + " - " + modulo.Ticket_Status;


                            //compara o ticket q esta em atendimento
                            if (modulo.Ticket != sticket)
                            {


                                //finaliza o cliente em tela
                                if (modulo.idcodcliente > 0)
                                {
                                    //registro da ligacao
                                    lsphone.Finalizar_Ligacao(32, "", modulo.DataInicioAtendimento);
                                }


                                //variaveis
                                modulo.Ticket = sticket;
                                modulo.Ticket_Tipo = stipo_ticket;
                                modulo.Ticket_SLA = sdados_ticket_sla;
                                modulo.Ticket_Tabulacao = ZenDesk_GetTabulacao();
                                modulo.Ticket_Status = ZenDesk_GetStatus();
                                modulo.IDClienteAVAYA = sticket;

                                //Inicia o Atendimento
                                ZenDesk_IniciaAtendimento();

                            }
                        }
                        else
                        {
                            modulo.Ticket_Tabulacao = ZenDesk_GetTabulacao();
                            modulo.Ticket_Status = ZenDesk_GetStatus();

                            toolStripStatusLabel2.Text = modulo.Ticket + " - " + modulo.Ticket_Tipo + " - " + modulo.Ticket_SLA + " - " + modulo.Ticket_Tabulacao + " - " + modulo.Ticket_Status;

                        }


                    }
                }
                catch (Exception err)
                {
                }

                #endregion



                //Application.DoEvents();


                #region EM_ATENDIMENTO___URL_INVALIDA

                if (modulo.idcodcliente > 0 && (sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/tickets/") == -1 || sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/tickets/new") > -1))
                {

                    //registro da ligacao
                    lsphone.Finalizar_Ligacao(32, "", modulo.DataInicioAtendimento);

                }

                #endregion



                //Application.DoEvents();


                #region DISPONIVEL_FORCA_PAGINA_DE_PEDIDOS

                //if (modulo.AgentState == modulo.StatusAgente.Ready && sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/filters") == -1 && sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/search") == -1 && sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/dashboard") == -1 && sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/apps/playlist-ticket-assignment") == -1) //&& (sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/search") == -1 ||  sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/tickets/") == -1 || sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/tickets/new") > -1))
                //{

                //    //abre 
                //    driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com/agent/filters/assigned");

                //}

                #endregion



                //Application.DoEvents();


                #region PAUSA


                //if (modulo.AgentState == modulo.StatusAgente.NotReady && sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/dashboard") == -1 && sURL.IndexOf(@"https://ifood-cons-br.zendesk.com/agent/filters/") == -1)
                //{
                //    //abre 
                //    driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com/agent/dashboard");

                //}


                #endregion


                //Application.DoEvents();


                Application.DoEvents();

                tmr_ZenDesk.Enabled = true;

            }
            catch (Exception err)
            {
                tmr_ZenDesk.Enabled = true;
            }
        }




        #region SELENIUM



        /// <summary>
        /// isBrowserClosed
        /// </summary>
        /// <param name="drv"></param>
        /// <returns></returns>
        public bool isBrowserClosed(ChromeDriver drv)
        {
            bool isClosed = false;
            try
            {
                string o = drv.CurrentWindowHandle;

            }
            catch (Exception err)
            {
                isClosed = true;
            }

            return isClosed;
        }





        /// <summary>
        /// FindElementByOBJ
        /// </summary>
        /// <param string xElementOBJ, string Tipo
        /// <returns></returns>
        private IWebElement FindElementByOBJ(string xElementOBJ, string Tipo)
        {
            IWebElement element = null;
            DateTime dt = DateTime.Now;

            while (element == null)
            {
                try
                {
                    if (Tipo == "ID")
                    {
                        List<IWebElement> obj = new List<IWebElement>();
                        obj.AddRange(driver.FindElements(By.Id(xElementOBJ)));

                        if (obj.Count > 0)
                        {
                            element = obj[0];
                            break;
                        }
                        else
                        {
                            element = null;
                        }

                    }

                    if (Tipo == "TAGNAME")
                    {
                        List<IWebElement> obj = new List<IWebElement>();
                        obj.AddRange(driver.FindElements(By.TagName(xElementOBJ)));

                        if (obj.Count > 0)
                        {
                            element = obj[0];
                            break;
                        }
                        else
                        {
                            element = null;
                        }


                    }



                    if (Tipo == "NAME")
                    {
                        List<IWebElement> obj = new List<IWebElement>();
                        obj.AddRange(driver.FindElements(By.Name(xElementOBJ)));

                        if (obj.Count > 0)
                        {
                            element = obj[0];
                            break;
                        }
                        else
                        {
                            element = null;
                        }


                    }

                }
                catch (NoSuchElementException)
                {
                }

                if ((DateTime.Now - dt).TotalSeconds > 20)
                {
                    return null;
                }

                Application.DoEvents();
            }

            return element;
        }



        /// <summary>
        /// FindElementByXPath
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        private IWebElement FindElementByXPath(string xPath)
        {
            IWebElement element = null;
            DateTime dt = DateTime.Now;

            while (element == null)
            {
                try
                {
                    List<IWebElement> obj = new List<IWebElement>();
                    obj.AddRange(driver.FindElements(By.XPath(xPath)));

                    if (obj.Count > 0)
                    {
                        element = obj[0];
                        break;
                    }
                    else
                    {
                        element = null;
                    }
                }
                catch (NoSuchElementException)
                {
                }


                if ((DateTime.Now - dt).TotalSeconds > 45)
                {
                    return null;
                }

                Application.DoEvents();
            }

            return element;
        }



        /// <summary>
        /// WaitObject
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="stipo"></param>
        /// <param name="drv"></param>
        /// <returns></returns>
        public bool WaitObject(string valor, string stipo, ChromeDriver drv)
        {

            try
            {

                DateTime dt;
                bool exec = true;
                List<IWebElement> conta;
                bool bok = false;
                int sec = 0;

                dt = DateTime.Now;

                while (exec == true)
                {
                    Application.DoEvents();

                    conta = new List<IWebElement>();

                    //tipo
                    if (stipo.ToLower() == "id")
                    {
                        conta.AddRange(drv.FindElements(By.Id(valor)));
                    }

                    if (stipo.ToLower() == "name")
                    {
                        conta.AddRange(drv.FindElements(By.Name(valor)));
                    }

                    if (stipo.ToLower() == "xpath")
                    {
                        conta.AddRange(drv.FindElements(By.XPath(valor)));
                    }

                    if (stipo.ToLower() == "CssSelector")
                    {
                        conta.AddRange(drv.FindElements(By.CssSelector(valor)));
                    }


                    if (conta.Count > 0)
                    {
                        bok = true;
                        exec = false;
                    }
                    else
                    {

                        sec = Convert.ToInt32((DateTime.Now - dt).TotalSeconds);

                        //time out
                        if (sec > 10)
                        {
                            bok = false;
                            exec = false;
                        }

                    }

                    conta = null;

                    //Thread.Sleep(250);
                    Application.DoEvents();
                }

                return bok;


            }
            catch (Exception err)
            {
                return false;
            }
        }





        /// <summary>
        /// WaitInnerText
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="stipo"></param>
        /// <param name="texto"></param>
        /// <param name="drv"></param>
        /// <returns></returns>
        public bool WaitInnerText(string valor, string stipo, string texto, ChromeDriver drv)
        {

            try
            {

                DateTime dt;
                bool exec = true;
                List<IWebElement> conta;
                bool bok = false;
                int sec = 0;

                dt = DateTime.Now;

                while (exec == true)
                {
                    Application.DoEvents();

                    conta = new List<IWebElement>();

                    //tipo
                    if (stipo.ToLower() == "id")
                    {
                        conta.AddRange(drv.FindElements(By.Id(valor)));
                    }

                    if (stipo.ToLower() == "name")
                    {
                        conta.AddRange(drv.FindElements(By.Name(valor)));
                    }

                    if (stipo.ToLower() == "tagname")
                    {
                        conta.AddRange(drv.FindElements(By.TagName(valor)));
                    }

                    if (stipo.ToLower() == "xpath")
                    {
                        conta.AddRange(drv.FindElements(By.XPath(valor)));
                    }

                    if (stipo.ToLower() == "CssSelector")
                    {
                        conta.AddRange(drv.FindElements(By.CssSelector(valor)));
                    }


                    if (conta.Count > 0)
                    {

                        //achou o elemento
                        if (conta[0].GetAttribute("innerText").IndexOf(texto) == -1)
                        {
                            sec = Convert.ToInt32((DateTime.Now - dt).TotalSeconds);

                            //time out
                            if (sec > 12)
                            {
                                bok = false;
                                exec = false;
                            }
                        }
                        else
                        {
                            bok = true;
                            exec = false;
                        }

                    }
                    else
                    {

                        //nao existe o objeto
                        bok = false;
                        exec = false;

                    }

                    conta = null;

                    //Thread.Sleep(250);
                    Application.DoEvents();
                }

                return bok;


            }
            catch (Exception err)
            {
                return false;
            }
        }




        /// <summary>
        /// ExistsObject
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="stipo"></param>
        /// <param name="drv"></param>
        /// <returns></returns>
        public bool ExistsObject(string valor, string stipo, ChromeDriver drv)
        {

            try
            {


                List<IWebElement> conta;
                bool bok = false;

                Application.DoEvents();

                conta = new List<IWebElement>();

                //tipo
                if (stipo.ToLower() == "id")
                {
                    conta.AddRange(drv.FindElements(By.Id(valor)));
                }

                if (stipo.ToLower() == "name")
                {
                    conta.AddRange(drv.FindElements(By.Name(valor)));
                }

                if (stipo.ToLower() == "xpath")
                {
                    conta.AddRange(drv.FindElements(By.XPath(valor)));
                }

                if (stipo.ToLower() == "CssSelector")
                {
                    conta.AddRange(drv.FindElements(By.CssSelector(valor)));
                }


                if (conta.Count > 0)
                {
                    bok = true;
                }
                else
                {
                    bok = false;
                }

                conta = null;

                //Thread.Sleep(250);
                Application.DoEvents();


                return bok;


            }
            catch (Exception err)
            {
                return false;
            }
        }



        /// <summary>
        /// WaitSecond
        /// </summary>
        /// <param name="iSeconds"></param>
        public void WaitSecond(int iSeconds)
        {
            try
            {
                DateTime dt;
                int sec = 0;

                Application.DoEvents();

                dt = DateTime.Now;
                sec = Convert.ToInt32((DateTime.Now - dt).TotalSeconds);

                while (sec < iSeconds)
                {
                    Application.DoEvents();

                    sec = Convert.ToInt32((DateTime.Now - dt).TotalSeconds);
                }

                return;
            }
            catch (Exception err)
            {
                return;
            }
        }



        #endregion








        #region ZENDESK




        /// <summary>
        /// ZenDesk_IniciaAtendimento
        /// </summary>
        public void ZenDesk_IniciaAtendimento()
        {
            try
            {
                string sretorno = "";
                string ssql = "";
                int imotivo = 0;


                gerlourens obj = new gerlourens();

                // 
                // iniciando atendimento
                // 
                if (modulo.IDClienteAVAYA != "")
                {

                    toolStripStatusLabel2.Text = modulo.IDClienteAVAYA + " - " + modulo.Ticket_Tipo + " - " + modulo.Ticket_SLA;


                    //verifica se existe cliente em tela
                    if (modulo.idcodcliente == 0)
                    {

                        //Atendimento BLENDED ou INBOUND
                        if (modulo.TipoLogin == TipoLogin.Blended || modulo.TipoLogin == TipoLogin.Inbound)
                        {

                            //cria o cliente
                            modulo.idcodcampanha = 1; //campanha padrao

                            using (SqlConnection cn = obj.abre_cn())
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {

                                    cmd.Connection = cn;
                                    cmd.CommandText = "SPGATCadClienteInbound3";
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = modulo.IDCodUsuario;
                                    cmd.Parameters.Add("@IDCodCampanha", SqlDbType.Int).Value = modulo.idcodcampanha;
                                    cmd.Parameters.Add("@TICKET", SqlDbType.VarChar, 150).Value = modulo.IDClienteAVAYA;
                                    cmd.Parameters.Add("@TICKET_TIPO", SqlDbType.VarChar, 150).Value = modulo.Ticket_Tipo;
                                    cmd.Parameters.Add("@TICKET_SLA", SqlDbType.VarChar, 150).Value = modulo.Ticket_SLA;

                                    cmd.Parameters.Add("@IDCodCliente", SqlDbType.Int).Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add("@IDCodMailing", SqlDbType.Int).Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                                    cmd.ExecuteNonQuery();

                                    //captura retorno
                                    sretorno = cmd.Parameters["@Status"].Value.ToString();


                                    if (sretorno == "0")
                                    {

                                        //data inicio
                                        modulo.DataInicioAtendimento = DateTime.Now;

                                        //captura cliente cliente
                                        modulo.idcodcliente = Convert.ToInt32(cmd.Parameters["@IDCodCliente"].Value.ToString());
                                        modulo.idcodmailing = Convert.ToInt32(cmd.Parameters["@IDCodMailing"].Value.ToString());


                                        //validacao de status : LOGOUT
                                        if (modulo.AgentState == modulo.StatusAgente.Logout)
                                        {
                                            lsphone.Login();
                                        }

                                        //validacao de status : LOGADO
                                        if (modulo.AgentState == modulo.StatusAgente.Logado)
                                        {
                                            lsphone.Ready();
                                        }

                                        //validacao de status : PAUSA
                                        if (modulo.AgentState == modulo.StatusAgente.NotReady)
                                        {
                                            lsphone.Ready();
                                        }

                                        //Inicia Atendimento
                                        lsphone.lsAtendimento(modulo.idcodcliente);

                                        modulo.IDClienteAVAYA = "";

                                    }
                                    else
                                    {
                                        GravaLog("Erro ao Criar o Cliente");
                                    }


                                }

                            }

                        }
                        else
                        {

                            //OUT
                            //To do...
                            modulo.IDClienteAVAYA = "";
                        }

                    }
                    else
                    {
                        modulo.IDClienteAVAYA = "";
                    }

                }
            }
            catch (Exception err)
            {
            }
        }



        /// <summary>
        /// Zendesk_Abrir
        /// </summary>
        public void Zendesk_Abrir()
        {
            try
            {

                cmdzendesk.Enabled = false;

                toolStripStatusLabel1.Text = "Abrindo Zendesk...";

                if (driver == null)
                {
                    //CONEXÃO COM CHROME
                    driver = new ChromeDriver();

                    //abre site da nike
                    driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com");


                    //driver.Navigate().GoToUrl(@"http://www.lourenssolutions.com.br");


                    //abre
                    driver.Manage().Window.Maximize();
                }
                else
                {

                    if (isBrowserClosed((ChromeDriver)driver) == true)
                    {

                        //CONEXÃO COM CHROME
                        driver = new ChromeDriver();

                        //abre site da nike
                        driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com");

                        //driver.Navigate().GoToUrl(@"http://www.lourenssolutions.com.br");


                        //abre
                        driver.Manage().Window.Maximize();

                    }
                    else
                    {

                        modulo.Show_Mensagem_Alerta("Zendesk encontra-se Aberto!");

                    }


                }

                toolStripStatusLabel1.Text = "";
                cmdzendesk.Enabled = true;

                

            }
            catch (Exception err)
            {
                cmdzendesk.Enabled = false;
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        /// <summary>
        /// ZenDesk_Login
        /// </summary>
        /// <returns></returns>
        public bool ZenDesk_Login()
        {
            try
            {

                ////verifica se o chrome esta aberto
                //if (isBrowserClosed((ChromeDriver)driver) == true)
                //{
                //    return false;
                //}
                

                #region AKAMAI

                ////
                //// AKAMAI
                ////

                ////abre 
                //driver.Navigate().GoToUrl(@"https://ifoodxt.login.go.akamai-access.com/");


                ////aguarda login
                //if (ExistsObject("loginForm:username", "id", (ChromeDriver)driver) == true)
                //{


                //    //Login
                //    ZenDesk_SendText("loginForm:username", "claudio.kaguia@csu.com.br");

                //    //senha
                //    ZenDesk_SendText("loginForm:password", "Debor@898900");

                //    //Click Login
                //    ZenDesk_ClickObject("loginForm:loginButton");

                //}

                //bool bexec = true;
                
                //string sbody = "";
                //DateTime dt = DateTime.Now;
                //sbody = driver.FindElement(By.TagName("body")).GetAttribute("innerText");


                //while (bexec==true)
                //{

                //    //verifica se abriu
                //    if (sbody.IndexOf("Zendesk") > -1)
                //    {
                //        bexec = false;
                //    }


                //    if ((DateTime.Now - dt).TotalMinutes > 7)
                //    {
                //        bexec = false;
                //    }


                //    Application.DoEvents();
                //    sbody = driver.FindElement(By.TagName("body")).GetAttribute("innerText");
                //}



                ////verifica se existe ZENDESK
                //if (sbody.IndexOf("Zendesk") > -1)
                //{

                //    //clica zendesk
                //    foreach (IWebElement item in driver.FindElements(By.TagName("div")))
                //    {

                //        string sval = item.GetAttribute("innerText");
                //        string sval2 = "";

                //        try
                //        {
                //            sval2 = item.GetAttribute("ng-click");
                //        }
                //        catch (Exception)
                //        {
                            
                //        }
                        

                //        if (sval.IndexOf("Zendesk Drivers") >-1 && sval2 == "runApp()")
                //        {
                //            item.Click();
                //            break;
                //        }

                //    }

                //}


                #endregion


                //seleciona o frame de login
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame(0);

                //verifica se esta logado
                if (ExistsObject("user_password", "id", (ChromeDriver)driver) == true)
                {

                    //Login
                    ZenDesk_SendText("user_email", modulo.Login_Zenddesk);

                    //senha
                    ZenDesk_SendText("user_password", modulo.Senha_Zenddesk);


                    //Click Login
                    ZenDesk_ClickObject("sign-in-submit-button");


                    //abre 
                    driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com/agent/filters/assigned");


                    //verifica se logou
                    try
                    {
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame(0);

                        if (ExistsObject("user_password", "id", (ChromeDriver)driver) == true)
                        {
                            return false;
                        }

                    }
                    catch (Exception err)
                    {
                    }

                    tmr_driver.Enabled = true;

                    //sucesso
                    return true;

                }
                else
                {
                    tmr_driver.Enabled = true;

                    //sucesso
                    return true;
                }


            }
            catch (Exception err)
            {
                return false;
            }

        }



        /// <summary>
        /// ZenDesk_Get_Ticket_Dados
        /// </summary>
        /// <returns></returns>
        public string ZenDesk_Get_Ticket_Dados()
        {
            try
            {

                string sval = "";
                string sdados_ticket = "";
                bool bachou = false;

                driver.SwitchTo().DefaultContent();


                bachou = false;
                foreach (var item in driver.FindElements(By.TagName("header")))
                {

                    if (item.Displayed == true)
                    {


                        foreach (var item2 in item.FindElements(By.TagName("span")))
                        {
                            sval = "";

                            try
                            {
                                sval = item2.GetAttribute("data-tracking-id");
                            }
                            catch (Exception err)
                            {
                            }


                            if (sval == "tabs-section-nav-item-ticket" && item2.Displayed == true)
                            {
                                sdados_ticket = item2.GetAttribute("innerText");
                                bachou = true;
                                break;
                            }

                        }


                    }



                    if (bachou == true)
                    {
                        break;
                    }

                }


                return sdados_ticket;


            }
            catch (Exception err)
            {
                return "";
            }
        }



        /// <summary>
        /// ZenDesk_Get_Ticket_SLA
        /// </summary>
        /// <returns></returns>
        public string ZenDesk_Get_Ticket_SLA()
        {
            try
            {

                string sval = "";
                string sdados_ticket_sla = "";
                bool bachou = false;

                driver.SwitchTo().DefaultContent();


                bachou = false;
                foreach (var item in driver.FindElements(By.TagName("section")))
                {

                    if (item.Displayed == true)
                    {

                        foreach (var item2 in item.FindElements(By.TagName("button")))
                        {
                            sval = "";

                            try
                            {
                                sval = item2.GetAttribute("data-test-id");
                            }
                            catch (Exception err)
                            {
                            }

                            if (sval == "sla-policy-metric" && item2.Displayed == true)
                            {
                                sdados_ticket_sla = item2.GetAttribute("innerText");
                                bachou = true;
                                break;
                            }

                        }

                    }


                    if (bachou == true)
                    {
                        break;
                    }
                }

                return sdados_ticket_sla;

            }
            catch (Exception err)
            {
                return "";
            }
        }




        /// <summary>
        /// ZenDesk_GetTicket
        /// </summary>
        /// <returns></returns>
        public bool ZenDesk_GetTicket()
        {

            try
            {
                bool blogado = false;
                string sdados_ticket = "";
                string sdados_ticket_sla = "";
                string sval = "";

                string stipo_ticket = "";
                string sticket = "";


                GravaLog("Verifica se o Zendesk esta ativo...");
                //verifica se o chrome esta aberto
                if (isBrowserClosed((ChromeDriver)driver) == true)
                {
                    return false;
                }




                // TICKETS
                GravaLog("Acessando Tickets...");
                driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com/agent/filters/assigned");





                // VERIFICA SESSAO LOGADA
                GravaLog("Verifica sessão ativa...");
                ZenDesk_Login();





                //AGUARDA
                driver.SwitchTo().DefaultContent();
                GravaLog("Aguardando... [-- Atendimento]");
                if (WaitInnerText("body", "tagname", "-- Atendimento", (ChromeDriver)driver) == false)
                {
                    return false;
                }





                //-- ATENDIMENTO
                GravaLog("Acessando -- Atendimento...");
                foreach (var item in driver.FindElements(By.TagName("a")))
                {
                    string scont = item.Text;

                    if (scont.ToUpper().IndexOf(("-- Atendimento").ToUpper()) > -1)
                    {
                        item.Click();
                        break;
                    }
                }




                //AGUARDA
                GravaLog("Aguardando... [Incidente]");
                if (WaitInnerText("body", "tagname", "Incidente", (ChromeDriver)driver) == false)
                {
                    return false;
                }




                //CAPTURA DADOS
                GravaLog("Capturando Dados...");
                driver.SwitchTo().DefaultContent();

                foreach (var item in driver.FindElements(By.TagName("span")))
                {
                    sval = item.GetAttribute("data-tracking-id");
                    if (sval == "tabs-section-nav-item-ticket")
                    {
                        sdados_ticket = item.GetAttribute("innerText");
                        break;
                    }

                }


                //SLA
                foreach (var item in driver.FindElements(By.TagName("button")))
                {

                    sval = item.GetAttribute("data-test-id");
                    if (sval == "sla-policy-metric")
                    {
                        sdados_ticket_sla = item.GetAttribute("innerText");
                        break;
                    }

                }


                GravaLog("Dados Capturados [ " + sdados_ticket + " ]");


                //verifica se achou dados
                if (sdados_ticket != "")
                {

                    //remover o nome Incidente
                    sdados_ticket = sdados_ticket.ToUpper();
                    sdados_ticket = sdados_ticket.Replace(("Incidente ").ToUpper(), "");

                    string[] arr = sdados_ticket.Split('#');

                    //captura dados
                    stipo_ticket = arr[0].Trim();
                    sticket = arr[1].Trim();


                    if (stipo_ticket == "ABERTO")
                    {
                        stipo_ticket = "REABERTURA";
                    }

                    GravaLog("Captura Concluída.");

                    //variaveis

                    modulo.Ticket = sticket;
                    modulo.Ticket_Tipo = stipo_ticket;
                    modulo.Ticket_SLA = sdados_ticket_sla;



                    modulo.IDClienteAVAYA = sticket;


                    return true;

                }
                else
                {
                    GravaLog("Dados Não Capturados");
                    return false;
                }

            }
            catch (Exception err)
            {
                GravaLog("Error : " + err.Message);
                return false;
            }

        }




        /// <summary>
        /// ZenDesk_ClickEmAtendimento
        /// </summary>
        public void ZenDesk_ClickEmAtendimento()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                bool bachou = false;
                string stable = "";

                //conf user
                gerlourens obj = new gerlourens();
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "select Ticket_Filtro_Lupa_Configurado,isnull(Atendimento_PlayList,0) 'Atendimento_PlayList_',isnull(Atendimento_Online,0) 'Atendimento_Online_',isnull(Atendimento_Offline,0) 'Atendimento_Offline_', Fila_Zendesk from gatusuario  (nolock) where idcodusuario = " + modulo.IDCodUsuario.ToString();
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            modulo.Atendimento_Offline = Convert.ToInt32(dr["Atendimento_Offline_"].ToString());
                            modulo.Atendimento_Online = Convert.ToInt32(dr["Atendimento_Online_"].ToString());
                            modulo.Atendimento_PlayList = Convert.ToInt32(dr["Atendimento_PlayList_"].ToString());
                            modulo.Ticket_Filtro_Lupa_Configurado = dr["Ticket_Filtro_Lupa_Configurado"].ToString();
                            modulo.Fila_Zendesk = dr["Fila_Zendesk"].ToString();

                        }
                        dr.Close();

                    }

                }
                obj = null;


                //
                // LUPA
                //
                if (modulo.Ticket_Filtro_Lupa_Configurado != "")
                {

                    string[] arr = modulo.Ticket_Filtro_Lupa_Configurado.Split('|');
                    string sfiltro = "";

                    Random rnd = new Random();

                    int iitem = rnd.Next(0, arr.Length);

                    sfiltro = arr[iitem];
                    
                    //ABRIR PAGINA DE PESQUISA
                    ZenDesk_Set_Filtro_Lupa(sfiltro);

                }
                else
                {
                    //
                    // SELECIONA TICKET
                    //

                    //dados do ticket -- loop
                    string sstatus = "";
                    string sticket = "";
                    string stempo = "";
                    int itempo = 0;


                    string sticket_final = "";
                    int itempo_final = 0;


                    //
                    // LISTA DE TICKETS
                    //

                    try
                    {
                        var otable = driver.FindElement(By.Id("table2"));

                        //tr
                        var otr = otable.FindElements(By.TagName("tr"));

                        foreach (var item in otr)
                        {


                            //zera
                            sstatus = "";
                            sticket = "";
                            stempo = "";
                            itempo = 0;


                            //status
                            try
                            {
                                sstatus = item.FindElements(By.TagName("td"))[3].Text;
                            }
                            catch (Exception err)
                            {
                            }


                            //ticket
                            try
                            {
                                sticket = item.FindElements(By.TagName("td"))[4].Text.Replace("#", "");
                            }
                            catch (Exception err)
                            {
                            }


                            //tempo
                            try
                            {
                                stempo = item.FindElements(By.TagName("td"))[8].Text;
                            }
                            catch (Exception err)
                            {
                            }


                            //identica numero tempo
                            try
                            {
                                if (stempo != "")
                                {
                                    string[] arr = stempo.Split(new char[0]);

                                    try
                                    {
                                        itempo = Convert.ToInt32(arr[0].ToString());
                                    }
                                    catch (Exception err)
                                    {
                                        itempo = 1;
                                    }


                                }
                            }
                            catch (Exception err)
                            {

                            }



                            //analisa linha
                            if (sstatus.Trim().ToUpper() == "A")
                            {
                                if (itempo > itempo_final)
                                {

                                    itempo_final = itempo;
                                    sticket_final = sticket;

                                }


                            }

                        }
                    }
                    catch (Exception)
                    {
                        
                    }

                    


                    //verifica se tem playlist
                    if (modulo.Status_User_Playlist == "" || modulo.Atendimento_PlayList == 0)
                    {
                        sticket_final = "";
                    }






                    //verifica se achou ticket
                    if (sticket_final != "")
                    {
                        driver.Navigate().GoToUrl(@"https://ifood-cons-br.zendesk.com/agent/tickets/" + sticket_final);
                    }
                    else
                    {


                        //FILA ZENDESK
                        if (modulo.Fila_Zendesk.Trim() != "")
                        {
                            //click
                            foreach (var item in driver.FindElements(By.TagName("a")))
                            {
                                string scont = item.Text;

                                if (scont.ToUpper().IndexOf((modulo.Fila_Zendesk.Trim()).ToUpper()) > -1)
                                {
                                    item.Click();
                                    break;
                                }
                            }
                        }



                        //if (modulo.Atendimento_Offline == 1)
                        //{

                        //    //click
                        //    foreach (var item in driver.FindElements(By.TagName("a")))
                        //    {
                        //        string scont = item.Text;

                        //        if (scont.ToUpper().IndexOf(("- Offline").ToUpper()) > -1)
                        //        {
                        //            item.Click();
                        //            break;
                        //        }
                        //    }


                        //}
                        //else
                        //{

                        //    //click
                        //    foreach (var item in driver.FindElements(By.TagName("a")))
                        //    {
                        //        string scont = item.Text;

                        //        if (scont.ToUpper().IndexOf(("Atendimento").ToUpper()) > -1)
                        //        {
                        //            item.Click();
                        //            break;
                        //        }
                        //    }


                        //}





                    }

                }



            }
            catch (Exception err)
            {
            }
        }



        /// <summary>
        /// ZenDesk_SendText
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="svalor"></param>
        public void ZenDesk_SendText(string sid, string svalor)
        {
            try
            {

                //campo login
                IWebElement otxtlogin = driver.FindElement(By.Id(sid));

                if (otxtlogin != null)
                {
                    otxtlogin.SendKeys(svalor);
                }
                otxtlogin = null;

            }
            catch (Exception err)
            {

            }

        }




        /// <summary>
        /// ZenDesk_ClickObject
        /// </summary>
        /// <param name="sid"></param>
        public void ZenDesk_ClickObject(string sid)
        {
            try
            {
                //clica no botao login
                IWebElement osubmit = driver.FindElement(By.Id(sid));

                if (osubmit != null)
                {
                    osubmit.Click();
                }
                osubmit = null;
            }
            catch (Exception err)
            {
            }
        }



        /// <summary>
        /// ZenDesk_GetTabulacao
        /// </summary>
        public string ZenDesk_GetTabulacao()
        {
            try
            {

                driver.SwitchTo().DefaultContent();

                string sbody = driver.FindElements(By.TagName("body"))[0].GetAttribute("innerText");
                string[] arr = sbody.Split(Environment.NewLine.ToCharArray());

                int pos = Array.IndexOf(arr, "Tabulação Pós-Análise*");

                if (pos > -1)
                {
                    string stab = arr[(pos + 2)].ToString();

                    return stab;

                }
                else
                {
                    return "";
                }

            }
            catch (Exception err)
            {
                return "";
            }
        }


        /// <summary>
        /// ZenDesk_GetStatus
        /// </summary>
        public string ZenDesk_GetStatus()
        {
            try
            {

                bool bachou;
                string acao_final = "";

                driver.SwitchTo().DefaultContent();

                bachou = false;
                foreach (var item in driver.FindElements(By.TagName("footer")))
                {
                    string sval = item.GetAttribute("data-garden-id");


                    if (sval == "chrome.footer" && item.Displayed == true)
                    {

                        foreach (var item2 in item.FindElements(By.TagName("button")))
                        {
                            string sval2 = item2.GetAttribute("data-tracking-id");


                            if (sval2 == "submit_button-button")
                            {


                                acao_final = item2.GetAttribute("innerText");

                                bachou = true;
                                break;
                            }


                        }

                    }


                    if (bachou == true)
                    {
                        break;
                    }

                }

                return acao_final;

            }
            catch (Exception err)
            {
                return "";
            }
        }



        /// <summary>
        /// ZendDesk_GetStatusUser
        /// </summary>
        /// <returns></returns>
        public string ZendDesk_GetStatusUser()
        {
            try
            {
                string sstatus = "";

                bool bachou = false;

                driver.SwitchTo().DefaultContent();

                foreach (var item in driver.FindElements(By.TagName("a")))
                {
                    foreach (var item2 in item.FindElements(By.TagName("circle")))
                    {

                        //ONLINE
                        if (item2.GetAttribute("fill") == "#1EB848")
                        {
                            sstatus = "Online";
                        }

                        //AWAY
                        if (item2.GetAttribute("fill") == "#FFB24D")
                        {
                            sstatus = "Away";
                        }

                        //INVISIBLE
                        if (item2.GetAttribute("fill") == "#BBBBBB")
                        {
                            sstatus = "Invisible";
                        }

                        bachou = true;
                        break;

                    }

                    if (bachou == true)
                    {
                        break;
                    }

                }


                return sstatus;


            }
            catch (Exception err)
            {
                return "";

            }
        }





        /// <summary>
        /// ZenDesk_SetStatus_Online
        /// </summary>
        /// <returns></returns>
        public void ZenDesk_SetStatus(string sstatus)
        {

            try
            {

                DateTime dt;
                string sbody = "";

                //abre URL
                driver.Navigate().GoToUrl("https://ifood-cons-br.zendesk.com/agent/apps/playlist-ticket-assignment");
                driver.SwitchTo().DefaultContent();


                //aguarda a tela carregar
                bool bexec = true;

                bool bachou = false;
                string sname_frame = "";
                string sname_frame_modal = "";

                bexec = true;
                dt = DateTime.Now;
                bachou = false;

                while (bexec == true)
                {

                    foreach (var item in driver.FindElements(By.TagName("iframe")))
                    {

                        sname_frame = "";
                        try
                        {
                            sname_frame = item.GetAttribute("name");
                        }
                        catch (Exception err)
                        {
                        }


                        if (sname_frame != "")
                        {

                            driver.SwitchTo().Frame(item.GetAttribute("name"));

                            var obody = driver.FindElement(By.TagName("body"));

                            sbody = obody.Text;

                            if (sbody.ToUpper().IndexOf("SAVE") > -1)
                            {

                                bachou = true;
                                bexec = false;
                                break;
                            }

                        }

                        driver.SwitchTo().DefaultContent();

                    }

                    //time out
                    if ((DateTime.Now - dt).TotalSeconds > 10)
                    {

                        return;
                    }

                }



                //verifica se a tela carregou
                if (bachou == true)
                {

                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(sname_frame);

                    //clica para abrir a lista
                    var ocmb = driver.FindElement(By.CssSelector("*[data-garden-id='forms.faux_input']"));

                    try
                    {
                        ocmb.Click();
                    }
                    catch (Exception err)
                    {

                        //verifica se tem frame modal
                        driver.SwitchTo().DefaultContent();

                        //idenfica frame
                        bexec = true;
                        dt = DateTime.Now;
                        bachou = false;
                        sname_frame_modal = "";
                        while (bexec == true)
                        {

                            foreach (var item in driver.FindElements(By.TagName("iframe")))
                            {

                                sname_frame_modal = "";

                                try
                                {
                                    sname_frame_modal = item.GetAttribute("name");
                                }
                                catch (Exception)
                                {
                                }


                                if (sname_frame_modal != "")
                                {


                                    driver.SwitchTo().Frame(item.GetAttribute("name"));

                                    var obody = driver.FindElement(By.TagName("body"));

                                    sbody = obody.Text;

                                    if (sbody.ToUpper().IndexOf(("No thanks").ToUpper()) > -1)
                                    {
                                        bachou = true;
                                        bexec = false;
                                        break;
                                    }


                                }

                                driver.SwitchTo().DefaultContent();

                            }

                            //time out
                            if ((DateTime.Now - dt).TotalSeconds > 10)
                            {
                                return;
                            }

                        }


                        //clica no botao no thanks
                        if (bachou == true)
                        {
                            driver.SwitchTo().DefaultContent();
                            driver.SwitchTo().Frame(sname_frame_modal);

                            //clica no save
                            foreach (var itembt in driver.FindElements(By.TagName("button")))
                            {

                                if (itembt.Text.ToUpper() == ("No thanks").ToUpper())
                                {
                                    itembt.Click();
                                    break;
                                }

                            }

                            driver.SwitchTo().DefaultContent();
                            driver.SwitchTo().Frame(sname_frame);

                            ocmb.Click();

                        }

                    }


                    //aguarda --- carrega lista
                    bexec = true;
                    dt = DateTime.Now;
                    bachou = false;

                    while (bexec == true)
                    {

                        sbody = driver.FindElement(By.TagName("body")).Text.ToUpper();

                        if (sbody.IndexOf("AWAY") > -1 && sbody.IndexOf("ONLINE") > -1 && sbody.IndexOf("INVISIBLE") > -1)
                        {

                            bexec = false;
                            bachou = true;
                        }

                        //time out
                        if ((DateTime.Now - dt).TotalSeconds > 10)
                        {
                            return;
                        }

                    }


                    //verifica se achou
                    if (bachou == true)
                    {

                        //clica na lista
                        foreach (var itemli in driver.FindElements(By.TagName("li")))
                        {

                            if (itemli.Text.ToUpper() == sstatus.ToUpper())
                            {
                                itemli.Click();
                                break;
                            }

                        }




                        //desmarca flag
                        foreach (var itemchk in driver.FindElements(By.TagName("input")))
                        {
                            string stype = "";

                            try
                            {
                                stype = itemchk.GetAttribute("type");
                            }
                            catch (Exception err)
                            {

                            }


                            if (stype == "checkbox")
                            {

                                if (itemchk.Selected == true)
                                {
                                    try
                                    {

                                        IJavaScriptExecutor exec = (IJavaScriptExecutor)driver;
                                        exec.ExecuteScript("arguments[0].click()", itemchk);

                                    }
                                    catch (Exception err)
                                    {

                                    }

                                }

                            }


                        }


                        //clica no save
                        foreach (var itembt in driver.FindElements(By.TagName("button")))
                        {

                            if (itembt.Text.ToUpper() == ("Save").ToUpper())
                            {
                                itembt.Click();
                                break;
                            }

                        }


                    }

                }


            }
            catch (Exception err)
            {
                GravaLog("Error : " + err.Message);

            }

        }




        /// <summary>
        /// ZenDesk_Get_Filtro_Lupa
        /// </summary>
        /// <returns></returns>
        public string ZenDesk_Get_Filtro_Lupa()
        {
            try
            {

                string sval = "";
                string sdados_ticket = "";
                bool bachou = false;

                driver.SwitchTo().DefaultContent();


                bachou = false;
                foreach (var item in driver.FindElements(By.TagName("input")))
                {

                    if (item.Displayed == true)
                    {
                        sval = "";

                        try
                        {
                            sval = item.GetAttribute("data-garden-id");
                        }
                        catch (Exception err)
                        {
                        }


                        if (sval == "forms.media_input" && item.Displayed == true)
                        {
                            sdados_ticket = item.GetAttribute("value");
                            bachou = true;
                            break;
                        }





                    }



                    if (bachou == true)
                    {
                        break;
                    }

                }


                return sdados_ticket;


            }
            catch (Exception err)
            {
                return "";
            }
        }




        /// <summary>
        /// ZenDesk_Set_Filtro_Lupa
        /// </summary>
        /// <param name="sfiltro"></param>
        /// <returns></returns>
        public void ZenDesk_Set_Filtro_Lupa(string sfiltro)
        {
            try
            {

                //abre url
                driver.Navigate().GoToUrl("https://ifood-cons-br.zendesk.com/agent/search/1?type=ticket&q=" + sfiltro);
                driver.SwitchTo().DefaultContent();


            }
            catch (Exception err)
            {
            }
        }



        /// <summary>
        /// Wait_Text
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public Boolean Wait_Text(string valor)
        {
            DateTime dt;
            bool exec = false;
            int sec = 0;
            string sbody = "";

            try
            {
                dt = DateTime.Now;

                //TEXTO DO MODAL 
                sbody = driver.FindElement(By.TagName("body")).GetAttribute("innerText");

                while (exec == false)
                {

                    //VERIFICA TEXTO NA TELA SE CARREGOU
                    if (sbody.IndexOf(valor) > 0)
                    {
                        exec = true;
                    }
                    else
                    {

                        sec = Convert.ToInt32((DateTime.Now - dt).TotalSeconds);

                        //time out
                        if (sec > 2)
                        {
                            exec = true;
                        }

                    }

                }
                return exec;

            }
            catch (Exception err)
            {
                return exec;
            }


        }


        /// <summary>
        /// WaitObjectFrame_Modal
        /// </summary>
        /// <returns></returns>
        public string WaitObjectFrame_Modal()
        {

            DateTime dt;
            bool exec = true;
            List<IWebElement> conta;
            bool bok = false;
            int sec = 0;
            string Frame = "";
            string NameFrameModal = "";
            Boolean Frame_modal = false;
            string sbody = "";

            driver.SwitchTo().DefaultContent();

            try
            {

                dt = DateTime.Now;

                while (exec == true)
                {
                    Application.DoEvents();

                    foreach (var item in driver.FindElements(By.TagName("iframe")))
                    {
                        Frame = item.GetAttribute("name").ToString();

                        if (Frame.ToUpper().IndexOf(("app_Playlist-Ticket-Assignment_modal").ToUpper()) > -1)
                        {
                            NameFrameModal = item.GetAttribute("name").ToString();
                            Frame_modal = true;
                        }
                    }

                    if (Frame_modal == true)
                    {
                        bok = true;
                        exec = false;
                    }
                    else
                    {

                        sec = Convert.ToInt32((DateTime.Now - dt).TotalSeconds);

                        //time out
                        if (sec > 1)
                        {
                            bok = false;
                            exec = false;
                        }

                    }

                    conta = null;
                    Application.DoEvents();
                }

                return NameFrameModal;

            }
            catch (Exception err)
            {
                return NameFrameModal;
            }

        }



        /// <summary>
        /// tmr_ZenDesk_HideFunc_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_ZenDesk_HideFunc_Tick(object sender, EventArgs e)
        {
            try
            {
                tmr_ZenDesk_HideFunc.Enabled = false;
                // return;

                Application.DoEvents();

                //HIDEEEEE
                if (modulo.Hide_Function_ZenDesk == true)
                {

                    driver.SwitchTo().DefaultContent();


                    foreach (var item in driver.FindElements(By.TagName("footer")))
                    {
                        string sval = item.GetAttribute("data-garden-id");


                        if (sval == "chrome.footer" && item.Displayed == true)
                        {

                            foreach (var item2 in item.FindElements(By.TagName("button")))
                            {
                                string sval2 = item2.GetAttribute("data-tracking-id");


                                if (sval2 == "ticket-footer-post-save-actions-menu-button" || sval2 == "ticket-footer-play-skip-next")
                                {

                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    js.ExecuteScript("arguments[0].setAttribute('style', 'visibility: hidden;')", item2);

                                }


                                Application.DoEvents();
                            }

                        }


                        Application.DoEvents();
                    }



                }
                else
                {

                    driver.SwitchTo().DefaultContent();

                    foreach (var item in driver.FindElements(By.TagName("footer")))
                    {
                        string sval = item.GetAttribute("data-garden-id");


                        if (sval == "chrome.footer")
                        {

                            foreach (var item2 in item.FindElements(By.TagName("button")))
                            {
                                string sval2 = item2.GetAttribute("data-tracking-id");


                                if (sval2 == "ticket-footer-post-save-actions-menu-button" || sval2 == "ticket-footer-play-skip-next")
                                {

                                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                    js.ExecuteScript("arguments[0].setAttribute('style', 'visibility: visible;')", item2);

                                }

                                Application.DoEvents();
                            }

                        }
                        Application.DoEvents();
                    }


                }


                tmr_ZenDesk_HideFunc.Enabled = true;
            }
            catch (Exception err)
            {
                tmr_ZenDesk_HideFunc.Enabled = true;
            }
        }


        /// <summary>
        /// ZendDesk_GetStatusTicketsPlayList
        /// </summary>
        /// <returns></returns>
        public string ZendDesk_GetStatusTicketsPlayList()
        {
            try
            {
                string sstatus = "";

                string sretorno = "";
                string sep = "";

                driver.SwitchTo().DefaultContent();

                var otable = driver.FindElement(By.Id("table2"));


                string stable = otable.GetAttribute("innerText");
                string[] arrs = stable.Split(Environment.NewLine.ToCharArray());
                List<string> arrR = new List<string> { };

                for (int i = 0; i < arrs.Length; i++)
                {
                    if (arrs[i].Replace("\t", "").Length == 1)
                    {
                        arrR.Add(arrs[i]);
                    }

                }

                var result = arrR.GroupBy(x => x)
                      .Select(x => new { Value = x.Key, Count = x.Count() });

                sretorno = "";
                sep = "";
                foreach (var item in result)
                {
                    sretorno = sretorno + sep + item.Value + " = " + item.Count.ToString();
                    sep = " | ";

                }

                return sretorno;

            }
            catch (Exception err)
            {
                return "";
            }
        }



        /// <summary>
        /// ZendDesk_GetResultadoTicketLupa
        /// </summary>
        /// <returns></returns>
        public string ZendDesk_GetResultadoTicketLupa()
        {
            try
            {
                string sstatus = "";

                string sretorno = "";
                string sep = "";

                driver.SwitchTo().DefaultContent();

                var otable = driver.FindElement(By.TagName("table"));


                string stable = otable.GetAttribute("innerText");
                string[] arrs = stable.Split(Environment.NewLine.ToCharArray());
                List<string> arrR = new List<string> { };

                for (int i = 0; i < arrs.Length; i++)
                {
                    if (arrs[i].Replace("\t", "").Length == 1)
                    {
                        arrR.Add(arrs[i]);
                    }

                }

                var result = arrR.GroupBy(x => x)
                      .Select(x => new { Value = x.Key, Count = x.Count() });

                sretorno = "";
                sep = "";
                foreach (var item in result)
                {
                    sretorno = sretorno + sep + item.Value + " = " + item.Count.ToString();
                    sep = " | ";

                }

                return sretorno;

            }
            catch (Exception err)
            {
                return "";
            }
        }




        #endregion


        /// <summary>
        /// cmdcofre_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdcofre_Click(object sender, EventArgs e)
        {
            try
            {
                if (obj_frmcofre_senhas != null)
                {
                    obj_frmcofre_senhas.Close();
                    obj_frmcofre_senhas.Dispose();
                    obj_frmcofre_senhas = null;
                }

                obj_frmcofre_senhas = new frmcofre_senhas();
                obj_frmcofre_senhas.ShowDialog();


            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// tmr_verifica_jornada_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_verifica_jornada_Tick(object sender, EventArgs e)
        {
            try
            {
                int ihora_server = 0;
                int ihora_conf_ini = 0;
                int ihora_conf_fim = 0;
                bool bok;


                tmr_verifica_jornada.Enabled = false;


                //validacao de jornada
                if (int.TryParse(modulo.Inicio_Jornada.Replace(":", ""), out ihora_conf_ini) == true)
                {
                }

                if (int.TryParse(modulo.Fim_Jornada.Replace(":", ""), out ihora_conf_fim) == true)
                {
                }

                if (ihora_conf_ini > 0 && ihora_conf_fim > 0)
                {

                    //seleciona hora server
                    gerlourens obj = new gerlourens();

                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = cn;
                            cmd.CommandText = "select CAST(REPLACE(left(CONVERT(varchar(20), getdate(), 114), 5), ':', '') AS INT)";
                            cmd.CommandType = CommandType.Text;

                            SqlDataReader dr = cmd.ExecuteReader();


                            if (dr.Read())
                            {
                                ihora_server = Convert.ToInt32(dr[0].ToString());
                            }
                            dr.Close();
                            dr = null;

                        }
                    }
                    obj = null;

                }


                try
                {

                    //verifica   
                    if (ihora_server > ihora_conf_fim)
                    {
                        bok = true;
                    }
                    else
                    {
                        bok = false;
                    }


                    if (bok == true)
                    {
                        modulo.Show_Mensagem_Alerta("Atenção ! Sua Jornada de Trabalho se Encerrou. Para continuar Trabalhando será necessário a Liberação do seu Supervisor.");


                        //solicitacao de senha
                        modulo.Retorno_Libecacao_Acao = 0;
                        modulo.Funcao_Libecacao_Acao = "Liberacao_Hora_Extra";

                        frmliberacaoacao ofrm = new frmliberacaoacao();
                        ofrm.ShowDialog();


                        if (modulo.Retorno_Libecacao_Acao == 0)
                        {
                            GravaLog("Ação Não Autorizada");
                            modulo.Show_Mensagem_Alerta("Ação Não Autorizada");


                            //desloga
                            driver.Close();
                            Application.ExitThread();

                            return;
                        }
                        else
                        {
                            tmr_verifica_jornada.Enabled = false;
                        }

                    }

                }
                catch (Exception err)
                {

                    modulo.Show_Mensagem_Alerta(err.Message);
                }



            }
            catch (Exception err)
            {



                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



    }



    public class ItemCombo
    {

        public string Text { get; set; }
        public object Value { get; set; }

        public bool Block { get; set; }

        public int Limite { get; set; }

        public int Limite_Dia { get; set; }

        public override string ToString()
        {
            return Text;
        }

    }


}
