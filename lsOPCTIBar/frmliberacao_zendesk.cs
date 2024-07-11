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
    public partial class frmliberacao_zendesk : Form
    {
        public frmliberacao_zendesk()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// cmdok_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdok_Click(object sender, EventArgs e)
        {
            try
            {
                string sdml = "";

                //verifica se selecionou o motivo
                if (cmbmotivo.SelectedIndex ==-1)
                {
                    modulo.Show_Mensagem_Alerta("Selecione o Motivo");
                    return;
                }

                cmdok.Enabled = false;

                //item selecionado
                ItemCombo osel = (ItemCombo)cmbmotivo.SelectedItem;

                //gera log
                sdml = "insert into GATLogLiberacaoZenDesk (idcodcliente,idcodusuario,idcodjustificativa,justificativa,ticket,ticket_sla,ticket_tipo,data_liberacao,idcodperfil,idcodequipe) values (" + modulo.idcodcliente.ToString() + "," + modulo.IDCodUsuario.ToString() + "," + osel.Value.ToString() + ",'" + txtmotivo.Text.Replace("'","") + "','" + modulo.Ticket + "','" + modulo.Ticket_SLA + "','" + modulo.Ticket_Tipo + "',getdate()," + modulo.IDCodPerfil.ToString() + "," + modulo.IDCodEquipe.ToString() + ")";
                
                modulo.ExecCommand(sdml);
                
                modulo.Retorno_Libecacao_Acao = 1;
                cmdok.Enabled = true;
                this.Close();

            }
            catch (Exception err)
            {



                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdcancelar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdcancelar_Click(object sender, EventArgs e)
        {
            modulo.Retorno_Libecacao_Acao = 0;
            this.Close();
        }



        /// <summary>
        /// Carrega_Motivos_Liberacao
        /// </summary>
        public void Carrega_Motivos_Liberacao()
        {
            try
            {
                modulo.GravaLogApp("I.Carrega_Motivos_Liberacao_Zendesk");

                gerlourens obj = new gerlourens();
                string ssql = "";
                cmbmotivo.Items.Clear();
                ItemCombo oitem;


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        ssql = "select * from GATMotivoJustificativaZendDesk (nolock) where habilitado=1 order by motivo ";

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            oitem = new ItemCombo();
                            oitem.Value = dr["idcodjustificativa"].ToString();
                            oitem.Text = dr["motivo"].ToString();
                            oitem.Limite = 0;
                            oitem.Limite_Dia = 0;
                            oitem.Block = false;

                            cmbmotivo.Items.Add(oitem);
                            Application.DoEvents();
                        }
                        dr.Close();

                    }

                }

                modulo.GravaLogApp("F.Carrega_Motivos_Liberacao_Zendesk");
            }
            catch (Exception err)
            {
                modulo.GravaLogApp("E.Carrega_Motivos_Liberacao_Zendesk");
                modulo.Show_Mensagem_Alerta(err.Message);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmliberacao_zendesk_Load(object sender, EventArgs e)
        {
            try
            {
                Carrega_Motivos_Liberacao();
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }
    }
}
