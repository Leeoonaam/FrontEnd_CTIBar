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
    public partial class frmClassificacaoCallBack : Form
    {
        public frmClassificacaoCallBack()
        {
            InitializeComponent();
        }



        private void button6_Click(object sender, EventArgs e)
        {

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

                //barra de progresso
                progressBar1.Value = progressBar1.Value + 1;
                
                if (progressBar1.Value == progressBar1.Maximum)
                {

                    NaoInformado();

                }

                timer1.Enabled = true;
            }
            catch (Exception err)
            {
                timer1.Enabled = true;
            }
        }

        /// <summary>
        /// frmClassificacaoCallBack_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmClassificacaoCallBack_Load(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Maximum = 5;

                gerlourens obj = new gerlourens();
                
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "UPDATE GATCLIENTE SET CALLBACK_ATENDIDO=0,CALLBACK_FALHA=0,CALLBACK_ENGANO=0,CALLBACK_DESCONECTADO=0,CALLBACK_OCUPADO=0,CALLBACK_NAOATENDE=0,CALLBACK_FAX=0,CALLBACK_CAIXAPOSTAL=0,CALLBACK_IMPCOMPLETAR=0,CALLBACK_NAOINFORMADO=1,CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();
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
        /// cmdatendido_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdatendido_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=1,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=0,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=0,
                CALLBACK_NAOATENDE=0,
                CALLBACK_FAX=0,
                CALLBACK_CAIXAPOSTAL=0,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=0,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();
                
            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdocupado_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdocupado_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=0,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=0,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=1,
                CALLBACK_NAOATENDE=0,
                CALLBACK_FAX=0,
                CALLBACK_CAIXAPOSTAL=0,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=0,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdnaoatende_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdnaoatende_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=0,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=0,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=0,
                CALLBACK_NAOATENDE=1,
                CALLBACK_FAX=0,
                CALLBACK_CAIXAPOSTAL=0,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=0,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdcaixapostal_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdcaixapostal_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=0,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=0,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=0,
                CALLBACK_NAOATENDE=0,
                CALLBACK_FAX=0,
                CALLBACK_CAIXAPOSTAL=1,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=0,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }

        /// <summary>
        /// cmdengano_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdengano_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=0,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=1,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=0,
                CALLBACK_NAOATENDE=0,
                CALLBACK_FAX=0,
                CALLBACK_CAIXAPOSTAL=0,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=0,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdfax_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdfax_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=0,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=0,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=0,
                CALLBACK_NAOATENDE=0,
                CALLBACK_FAX=1,
                CALLBACK_CAIXAPOSTAL=0,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=0,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();

            }
            catch (Exception err)
            {
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// NaoInformado
        /// </summary>
        public void NaoInformado()
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                ssql = @"UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,
                CALLBACK_OPTOUFAZER=1,
                CALLBACK_OPTOUNAOFAZER=0,
                CALLBACK_NAOOPTOU=0,
                CALLBACK_ATENDIDO=0,
                CALLBACK_FALHA=0,
                CALLBACK_ENGANO=0,
                CALLBACK_DESCONECTADO=0,
                CALLBACK_OCUPADO=0,
                CALLBACK_NAOATENDE=0,
                CALLBACK_FAX=0,
                CALLBACK_CAIXAPOSTAL=0,
                CALLBACK_IMPCOMPLETAR=0,
                CALLBACK_NAOINFORMADO=1,
                CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();


                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = ssql;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                    }

                }
                obj = null;
                this.Close();

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
        private void cmdnaoinformado_Click(object sender, EventArgs e)
        {
            NaoInformado();
        }
    }
}
