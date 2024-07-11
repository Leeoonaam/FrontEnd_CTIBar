using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace lsOPCTIBar
{
    public partial class frmpopup : Form
    {



        public enum TipoFiltro
        {
            CodigoAssociado = 0,
            CPF = 1,
            Telefone = 2
        }



        public frmpopup()
        {
            InitializeComponent();
        }




        /// <summary>
        /// frmpopup_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmpopup_Load(object sender, EventArgs e)
        {
            try
            {


                txttelefone.Text = modulo.Bina;
                txtgrupo.Text = modulo.sSkill;


                LimpaCampos();


                //busca inicial
                //BuscaCliente(TipoFiltro.Telefone, txttelefone.Text);
                

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// LimpaCampos
        /// </summary>
        public void LimpaCampos()
        {
            try
            {
                txtnome.Text = "";
                txtcpf.Text = "";
                txtdatanascimento.Text = "";
                txtemail.Text = "";
                txtplano.Text = "";
                txtnomeplano.Text = "";
                txtstatus.Text = "";
                txtstatus.BackColor = Color.White;
                txtmotivo.Text = "";

                lblstatuscarencia.Text = "";
                lblstatuscarencia.BackColor = Color.White;
                txtdataliberacao.Text = "";

                lswfaturas.Items.Clear();
                txtcodigobarra.Text = "";

                txtendereco.Text = "";
            }
            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }


        }


        /// <summary>
        /// BuscaCliente
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="svalor"></param>
        public void BuscaCliente(TipoFiltro tipo, string svalor)
        {
            try
            {


                string sfiltro = "";
                LimpaCampos();

                if (svalor == "")
                {
                    return;
                }


                if (tipo == TipoFiltro.CodigoAssociado)
                {
                    sfiltro = "codigoAssociado=" + svalor;
                }
                else if (tipo == TipoFiltro.CPF)
                {
                    sfiltro = "cpf=" + svalor;
                }
                else
                {
                    sfiltro = "telefone=" + svalor;
                }
                

                var client = new RestClient("https://aliancaweb.azurewebsites.net/AliancaNet/services/CallCenter.php?" + sfiltro);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "54c5c8229e22ee49bdde3ac3652206f3");
                request.AddHeader("Cookie", "ARRAffinity=463fb81e1154a95d75802e765a651879cef9e1ea0ac958c149cf947b01558581; ARRAffinitySameSite=463fb81e1154a95d75802e765a651879cef9e1ea0ac958c149cf947b01558581; PHPSESSID=i1er3hbqha3miofjn0064r9po3");
                IRestResponse response = client.Execute(request);

                string sretorno = response.Content;


                string sendereco = "";
                string sbairro = "";
                string scidade = "";
                string sestado = "";

                string svencimento = "";
                string spagamento = "";
                string valor_pago = "";
                string linhadigitavel = "";

                //trata o JSON
                XmlDocument doc = JsonArrayToXml(sretorno);

                foreach (XmlNode item in doc.ChildNodes[0].ChildNodes[0].ChildNodes)
                {
                    
                    if (item.Name.ToUpper() == ("Nome").ToUpper()) txtnome.Text = item.InnerText;
                    if (item.Name.ToUpper() == ("cpf").ToUpper()) txtcpf.Text = item.InnerText;
                    if (item.Name.ToUpper() == ("nascimento").ToUpper()) txtdatanascimento.Text = item.InnerText;
                    if (item.Name.ToUpper() == ("PlanoFamiliar").ToUpper()) txtplano.Text = item.InnerText;
                    if (item.Name.ToUpper() == ("nomePlano").ToUpper()) txtnomeplano.Text = item.InnerText;
                    if (item.Name.ToUpper() == ("email").ToUpper()) txtemail.Text = item.InnerText;

                    if (item.Name.ToUpper() == ("elegivel").ToUpper())
                    {

                        txtstatus.Text = item.InnerText;

                        if (txtstatus.Text == "false")
                        {
                            txtstatus.Text = "DESATIVADO";
                            txtstatus.BackColor = Color.Red;
                        }
                        else
                        {
                            txtstatus.Text = "ATIVO";
                            txtstatus.BackColor = Color.Green;
                        }

                    }


                    if (item.Name.ToUpper() == ("ultimasFaturasPagas").ToUpper())
                    {

                        svencimento = item.ChildNodes[0].InnerText;
                        spagamento = item.ChildNodes[1].InnerText;
                        valor_pago = item.ChildNodes[2].InnerText;



                        ListViewItem obj = lswfaturas.Items.Add("Paga", 0);
                        obj.SubItems.Add(svencimento);
                        obj.SubItems.Add(spagamento);
                        obj.SubItems.Add( "$ " + valor_pago);
                        obj.SubItems.Add("");

                    }


                    if (item.Name.ToUpper() == ("FaturasEmAberto").ToUpper()) //FaturasEmAberto
                    {

                        svencimento = item.ChildNodes[0].InnerText;
                        valor_pago = item.ChildNodes[1].InnerText;
                        linhadigitavel = item.ChildNodes[2].InnerText;

                        
                        ListViewItem obj = lswfaturas.Items.Add("Em Aberto", 2);
                        obj.SubItems.Add(svencimento);
                        obj.SubItems.Add("");
                        obj.SubItems.Add("$ " + valor_pago);
                        obj.SubItems.Add(linhadigitavel);

                    }


                    if (item.Name.ToUpper() == ("motivo").ToUpper()) txtmotivo.Text = item.InnerText;

                    if (item.Name.ToUpper() == ("endereco").ToUpper()) sendereco = item.InnerText;
                    if (item.Name.ToUpper() == ("bairro").ToUpper()) sbairro = item.InnerText;
                    if (item.Name.ToUpper() == ("cidade").ToUpper()) scidade = item.InnerText;
                    if (item.Name.ToUpper() == ("estado").ToUpper()) sestado = item.InnerText;
                    

                }


                txtendereco.Text = sendereco + " - " + sbairro + " - " + scidade + " - " + sestado;





            }
            catch (Exception err)
            {

                //modulo.Show_Mensagem_Alerta(err.Message);

                //modulo.Show_Mensagem_Alerta(err.Message);
                
            }

        }



        public XmlDocument JsonArrayToXml(string json)
        {
            var wrappedDocument = string.Format("{{ item: {0} }}", json);
            var xDocument = JsonConvert.DeserializeXmlNode(wrappedDocument, "collection");
            return xDocument;
        }

        /// <summary>
        /// cmdbuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdbuscar_Click(object sender, EventArgs e)
        {
            try
            {

                cmdbuscar.Enabled = false;

                if (cmbtipo.Text== "Código" && txtvalorbusca.Text !="")
                {
                    BuscaCliente(TipoFiltro.CodigoAssociado, txtvalorbusca.Text);                    
                }

                if (cmbtipo.Text == "CPF" && txtvalorbusca.Text != "")
                {
                    BuscaCliente(TipoFiltro.CPF, txtvalorbusca.Text);
                }


                if (cmbtipo.Text == "Telefone" && txtvalorbusca.Text != "")
                {
                    BuscaCliente(TipoFiltro.Telefone, txtvalorbusca.Text);
                }

                cmdbuscar.Enabled = true;

            }
            catch (Exception err)
            {



                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// lswfaturas_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lswfaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

               

            }
            catch (Exception err)
            {
                
                //modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        private void lswfaturas_Click(object sender, EventArgs e)
        {
            try
            {

                if (lswfaturas.SelectedItems.Count > 0)
                {

                    txtcodigobarra.Text = "";


                    txtcodigobarra.Text = lswfaturas.SelectedItems[0].SubItems[4].Text;
                    
                }


            }

            catch (Exception err)
            {


                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// cmdcopiar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdcopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcodigobarra.Text !="")
                {

                    Clipboard.SetText(txtcodigobarra.Text);
                }
            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }
    }
}
