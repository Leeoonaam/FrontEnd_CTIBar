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
    public partial class frmtelefoniamanual : Form
    {



        //variaveis locais 
        bool bConsulta = false;


        public frmtelefoniamanual()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// cmddiscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmddiscar_Click(object sender, EventArgs e)
        {
            try
            {
                long iret;
                string sddd = "";
                string stelefone = "";

                cmddiscar.Enabled = false;
                string sid_A = "";
                string sid_H = "";

                //recupera chamada
                for (int i = 0; i < modulo.ChamadasRamal.Count; i++)
                {

                    if (modulo.ChamadasRamal[i].status == StatusChamada.Hold)
                    {
                        sid_H = modulo.ChamadasRamal[i].callid;

                    }


                    if (modulo.ChamadasRamal[i].status == StatusChamada.Atendida)
                    {
                        sid_A = modulo.ChamadasRamal[i].callid;

                    }
                    Application.DoEvents();

                }


                //verifica o telefone
                if (txtnumero_discar.Text.Length < 8)
                {
                    modulo.Show_Mensagem_Alerta("Informe Corretamente o Número para Discagem");
                    cmddiscar.Enabled = true;
                    return;
                }


                //valida somente numeros
                if (long.TryParse(txtnumero_discar.Text, out iret) == false)
                {
                    modulo.Show_Mensagem_Alerta("Informe Corretamente o Número para Discagem. Informe apenas números.");
                    cmddiscar.Enabled = true;
                    return;
                }


                


                //verifica chamada local
                if (txtnumero_discar.Text.Length <= 9)
                {
                    sddd = "0";
                    stelefone = txtnumero_discar.Text;
                }
                else
                {

                    sddd = "00";
                    stelefone = txtnumero_discar.Text;
                }
                

                //verifica se o operador esta disponivel
                if (modulo.AgentState == modulo.StatusAgente.Ready)
                {

                    //criacao cliente


                    //inicia o atendimento


                    //makecall
                    //modulo.objFrmCTIBar.makecall(modulo.sUserid_Avaya, sddd + stelefone, modulo.sUUI);

                }
                else
                {

                    //verifica se existe cliente criado
                    if (modulo.idcodcliente == 0)
                    {

                        //criacao cliente

                    }


                    //verifica se existe alguma chamada ativa
                    if (sid_A == "" && sid_H == "")
                    {

                        //make call
                        //modulo.objFrmCTIBar.makecall(modulo.sUserid_Avaya, sddd + stelefone, modulo.sUUI);

                    }
                    else
                    {

                        //consulta
                       // modulo.objFrmCTIBar.Consulta(sid_A, sddd + stelefone, modulo.sUUI);


                    }


                }


                cmddiscar.Enabled = true;



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

                if (modulo.ChamadasRamal.Count == 0)
                {
                    grp_linha1.Visible = false;
                    grp_linha2.Visible = false;
                }


                if (modulo.ChamadasRamal.Count == 1)
                {
                    grp_linha2.Visible = false;
                }


                //linha 1
                try
                {
                    if (modulo.ChamadasRamal[0].status.ToString() != "")
                    {


                        grp_linha1.Visible = true;


                        img_linha1.Visible = true;
                        lblnumero_linha1.Visible = true;
                        lblstatus_linha1.Visible = true;
                        lbltempo_linha1.Visible = true;

                        lblnumero_linha1.Text = modulo.ChamadasRamal[0].numero;
                        lblstatus_linha1.Text = modulo.ChamadasRamal[0].status.ToString();
                        lbltempo_linha1.Text = modulo.horacheia(Convert.ToInt32((DateTime.Now - modulo.ChamadasRamal[0].data).TotalSeconds));
                        lblcallid_linha1.Text = modulo.ChamadasRamal[0].callid;

                        //imagem
                        if (modulo.ChamadasRamal[0].status == StatusChamada.Atendida)
                        {
                            img_linha1.Image = Properties.Resources.connect;
                            lblnumero_linha1.ForeColor = Color.Green;
                            lblstatus_linha1.ForeColor = Color.Green;
                            lbltempo_linha1.ForeColor = Color.Green;

                        }

                        if (modulo.ChamadasRamal[0].status == StatusChamada.Hold)
                        {
                            img_linha1.Image = Properties.Resources.hold;
                            lblnumero_linha1.ForeColor = Color.Red;
                            lblstatus_linha1.ForeColor = Color.Red;
                            lbltempo_linha1.ForeColor = Color.Red;
                        }

                        if (modulo.ChamadasRamal[0].status == StatusChamada.MakeCall)
                        {
                            img_linha1.Image = Properties.Resources.makecall;
                            lblnumero_linha1.ForeColor = Color.Blue;
                            lblstatus_linha1.ForeColor = Color.Blue;
                            lbltempo_linha1.ForeColor = Color.Blue;
                        }

                    }

                }
                catch (Exception err)
                {
                }


                //linha 2
                try
                {
                    if (modulo.ChamadasRamal[1].status.ToString() != "")
                    {

                        grp_linha2.Visible = true;

                        img_linha2.Visible = true;
                        lblnumero_linha2.Visible = true;
                        lblstatus_linha2.Visible = true;
                        lbltempo_linha2.Visible = true;

                        lblnumero_linha2.Text = modulo.ChamadasRamal[1].numero;
                        lblstatus_linha2.Text = modulo.ChamadasRamal[1].status.ToString();
                        lbltempo_linha2.Text = modulo.horacheia(Convert.ToInt32((DateTime.Now - modulo.ChamadasRamal[1].data).TotalSeconds));
                        lblcallid_linha2.Text = modulo.ChamadasRamal[1].callid;


                        //imagem
                        if (modulo.ChamadasRamal[1].status == StatusChamada.Atendida)
                        {
                            img_linha2.Image = Properties.Resources.connect;
                            lblnumero_linha2.ForeColor = Color.Green;
                            lblstatus_linha2.ForeColor = Color.Green;
                            lbltempo_linha2.ForeColor = Color.Green;

                        }

                        if (modulo.ChamadasRamal[1].status == StatusChamada.Hold)
                        {
                            img_linha2.Image = Properties.Resources.hold;
                            lblnumero_linha2.ForeColor = Color.Red;
                            lblstatus_linha2.ForeColor = Color.Red;
                            lbltempo_linha2.ForeColor = Color.Red;
                        }

                        if (modulo.ChamadasRamal[1].status == StatusChamada.MakeCall)
                        {
                            img_linha2.Image = Properties.Resources.makecall;
                            lblnumero_linha2.ForeColor = Color.Blue;
                            lblstatus_linha2.ForeColor = Color.Blue;
                            lbltempo_linha2.ForeColor = Color.Blue;
                        }

                    }
                }
                catch (Exception err)
                {
                }





                Application.DoEvents();
                timer1.Enabled = true ;
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdconsultar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdconsultar_Click(object sender, EventArgs e)
        {
            try
            {

                cmdconsultar.Enabled = false;
                string sid_A = "";
                string sid_H = "";

                //recupera chamada
                for (int i = 0; i < modulo.ChamadasRamal.Count; i++)
                {

                    if (modulo.ChamadasRamal[i].status == StatusChamada.Hold)
                    {
                        sid_H = modulo.ChamadasRamal[i].callid;

                    }


                    if (modulo.ChamadasRamal[i].status == StatusChamada.Atendida)
                    {
                        sid_A = modulo.ChamadasRamal[i].callid;

                    }
                    Application.DoEvents();

                }



                //verifica se tem chamada ativa
                if (sid_A == "")
                {
                    modulo.Show_Mensagem_Alerta("Não Existe Chamada Ativa para Realizar a Consulta");
                    cmdconsultar.Enabled = true;

                    return;
                }


                //verifica se tem chamada ativa
                if (cmbvdn.Text == "")
                {
                    modulo.Show_Mensagem_Alerta("Selecione a VDN para realizar a Consulta.");
                    cmdconsultar.Enabled = true;
                    return;
                }


                

                //realizar a chamada de consulta
                modulo.bconsulta = true;
                modulo.scallid_chamada_transf = "";
                modulo.snumero_chamada_transf = "";


                //realiza a consulta
                //modulo.objFrmCTIBar.Consulta(sid_A, cmbvdn.Text, modulo.sUUI);

                DateTime dt = DateTime.Now;
                while (modulo.scallid_chamada_transf == "")
                {
                    Application.DoEvents();
                    //verifica time out
                    if ((DateTime.Now - dt).TotalSeconds > 15)
                    {
                        modulo.Show_Mensagem_Alerta("VDN Não Atendeu, Time Out");
                        cmdconsultar.Enabled = true;

                        modulo.bconsulta = false;
                        modulo.scallid_chamada_transf = "";
                        modulo.snumero_chamada_transf = "";

                        return;
                    }


                    toolStripStatusLabel1.Text = "Aguadando Atendimento... [" + Convert.ToInt32((DateTime.Now - dt).TotalSeconds).ToString() + "]";
                    Application.DoEvents();
                }
                toolStripStatusLabel1.Text = "";

                cmdconsultar.Enabled = true;

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// cmdTransferir_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmdTransferir_Click(object sender, EventArgs e)
        {

            try
            {
                cmdTransferir.Enabled = false;

                string sid_A = "";
                string sid_H = "";

                //recupera chamada
                for (int i = 0; i < modulo.ChamadasRamal.Count; i++)
                {

                    if (modulo.ChamadasRamal[i].status == StatusChamada.Hold)
                    {
                        sid_H = modulo.ChamadasRamal[i].callid;

                    }


                    if (modulo.ChamadasRamal[i].status == StatusChamada.Atendida)
                    {
                        sid_A = modulo.ChamadasRamal[i].callid;

                    }
                    Application.DoEvents();

                }


                //verifica se tem chamada ativa
                if (sid_A == "")
                {
                    modulo.Show_Mensagem_Alerta("Não Existe Chamada Ativa para Realizar a Transferência");
                    cmdTransferir.Enabled = true;
                    return;
                }


                //verifica se tem chamada ativa
                if (cmbvdn.Text == "")
                {
                    modulo.Show_Mensagem_Alerta("Selecione a VDN de Transferência.");
                    cmdTransferir.Enabled = true;
                    return;
                }

                
                

                if (sid_H =="" && sid_A !="")
                {
                    //transferencia direta
                   // modulo.objFrmCTIBar.SingleTransfer(sid_A, cmbvdn.Text);
                }
                else
                {
                    //transferencia assistida
                   // modulo.objFrmCTIBar.Transfer(sid_H, sid_A);
                }

                cmdTransferir.Enabled = true;

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// cmdOutraChamada_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmdOutraChamada_Click(object sender, EventArgs e)
        {
            try
            {

                cmdOutraChamada.Enabled = false;


                string sid_A = "";
                string sid_H = "";

                //recupera chamada
                for (int i = 0; i < modulo.ChamadasRamal.Count; i++)
                {

                    if (modulo.ChamadasRamal[i].status == StatusChamada.Hold)
                    {
                        sid_H = modulo.ChamadasRamal[i].callid;

                    }


                    if (modulo.ChamadasRamal[i].status == StatusChamada.Atendida)
                    {
                        sid_A = modulo.ChamadasRamal[i].callid;

                    }
                    Application.DoEvents();

                }


                //Hold
                //modulo.objFrmCTIBar.HoldCall(sid_A);

                //Ativa
                //modulo.objFrmCTIBar.RetrieveCall(sid_H);

                cmdOutraChamada.Enabled = true;

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// frmtelefoniamanual_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmtelefoniamanual_Load(object sender, EventArgs e)
        {
            try
            {

                //
                lblcampanha.Text = modulo.sSkill;


                if (modulo.bconsulta == true)
                {
                    modulo.Show_Mensagem_Alerta("Consulta em Execução. Aguarde até a conclusão da mesma para Consultar Novamente");
                    cmdconsultar.Enabled = false;
                }


            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdespera_linha1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdespera_linha1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdespera_linha1.Enabled = false;
                //modulo.objFrmCTIBar.HoldCall(lblcallid_linha1.Text);
                cmdespera_linha1.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdespera_linha2_Click(object sender, EventArgs e)
        {
            try
            {
                cmdespera_linha2.Enabled = false;
                //modulo.objFrmCTIBar.HoldCall(lblcallid_linha2.Text);
                cmdespera_linha2.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdretorna_linha1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdretorna_linha1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdretorna_linha1.Enabled = false;
                //modulo.objFrmCTIBar.RetrieveCall(lblcallid_linha1.Text);
                cmdretorna_linha1.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// cmdretorna_linha2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdretorna_linha2_Click(object sender, EventArgs e)
        {
            try
            {
                cmdretorna_linha2.Enabled = false;
                //modulo.objFrmCTIBar.RetrieveCall(lblcallid_linha2.Text);
                cmdretorna_linha2.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// cmddesliga_linha1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmddesliga_linha1_Click(object sender, EventArgs e)
        {
            try
            {
                cmddesliga_linha1.Enabled = false;
                //modulo.objFrmCTIBar.dropCall(lblcallid_linha1.Text);
                cmddesliga_linha1.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmddesliga_linha2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmddesliga_linha2_Click(object sender, EventArgs e)
        {
            try
            {
                cmddesliga_linha2.Enabled = false;
                //modulo.objFrmCTIBar.dropCall(lblcallid_linha2.Text);
                cmddesliga_linha2.Enabled = true;
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdtransfQualidade_Click(object sender, EventArgs e)
        {
            try
            {

                string sid_A = "";
                string sid_H = "";
                cmdtransfQualidade.Enabled = false;


                //recupera chamada
                for (int i = 0; i < modulo.ChamadasRamal.Count; i++)
                {

                    if (modulo.ChamadasRamal[i].status == StatusChamada.Hold)
                    {
                        sid_H = modulo.ChamadasRamal[i].callid;

                    }


                    if (modulo.ChamadasRamal[i].status == StatusChamada.Atendida)
                    {
                        sid_A = modulo.ChamadasRamal[i].callid;

                    }
                    Application.DoEvents();

                }


                //verifica se tem chamada ativa
                if (sid_A == "")
                {
                    modulo.Show_Mensagem_Alerta("Não Existe Chamada Ativa para Realizar a Transferência");
                    cmdtransfQualidade.Enabled = true;
                    return;
                }


                

                //modulo.objFrmCTIBar.SingleTransfer(sid_A, "8169");


                cmdtransfQualidade.Enabled = true ;


            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmtelefoniamanual_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (modulo.bconsulta == true)
                {
                    modulo.Show_Mensagem_Alerta("Consulta em Execução a tela não podera ser fechada" );
                    e.Cancel = true;
                }
                
            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }
    }
}
