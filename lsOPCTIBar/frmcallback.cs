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
    public partial class frmcallback : Form
    {
        public frmcallback()
        {
            InitializeComponent();
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


                //limite
                if (progressBar1.Value == progressBar1.Maximum )
                {
                    gerlourens obj = new gerlourens();
                    string ssql = "";

                    //REGISTRO
                    using (SqlConnection cn = obj.abre_cn())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.Connection = cn;
                            cmd.CommandText = "UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,CALLBACK_OPTOUFAZER=0,CALLBACK_OPTOUNAOFAZER=0,CALLBACK_NAOOPTOU=1,CALLBACK_ATENDIDO=0,CALLBACK_FALHA=0,CALLBACK_ENGANO=0,CALLBACK_DESCONECTADO=0,CALLBACK_OCUPADO=0,CALLBACK_NAOATENDE=0,CALLBACK_FAX=0,CALLBACK_CAIXAPOSTAL=0,CALLBACK_IMPCOMPLETAR=0,CALLBACK_NAOINFORMADO=0,CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();
                            cmd.CommandType = CommandType.Text;

                            cmd.ExecuteNonQuery();


                        }

                    }


                    //LOG CALLBACK
                    ssql = "insert into gatlogcallback (idcodusuario,idcodcliente,acao,dataagend,datainsercao) values (";
                    ssql = ssql + modulo.IDCodUsuario.ToString() + "," + modulo.idcodcliente.ToString() + ",3,null,getdate())";


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

                timer1.Enabled = true ;
            }
            catch (Exception err)
            {
                timer1.Enabled = false;
            }
        }


        /// <summary>
        /// frmcallback_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmcallback_Load(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();


                //max barra progresso
                progressBar1.Maximum = modulo.TempoTelaCallBack;



                //Log
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,CALLBACK_OPTOUFAZER=0,CALLBACK_OPTOUNAOFAZER=0,CALLBACK_NAOOPTOU=1,CALLBACK_ATENDIDO=0,CALLBACK_FALHA=0,CALLBACK_ENGANO=0,CALLBACK_DESCONECTADO=0,CALLBACK_OCUPADO=0,CALLBACK_NAOATENDE=0,CALLBACK_FAX=0,CALLBACK_CAIXAPOSTAL=0,CALLBACK_IMPCOMPLETAR=0,CALLBACK_NAOINFORMADO=0,CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();
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
        /// cmdnaorediscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdnaorediscar_Click(object sender, EventArgs e)
        {
            try
            {
                gerlourens obj = new gerlourens();
                string ssql = "";


                cmdnaorediscar.Enabled = false;

                //REGISTRO
                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand() )
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = "UPDATE GATCLIENTE SET CALLBACK_AUTOMATICO=0,CALLBACK_OPTOUFAZER=0,CALLBACK_OPTOUNAOFAZER=1,CALLBACK_NAOOPTOU=0,CALLBACK_ATENDIDO=0,CALLBACK_FALHA=0,CALLBACK_ENGANO=0,CALLBACK_DESCONECTADO=0,CALLBACK_OCUPADO=0,CALLBACK_NAOATENDE=0,CALLBACK_FAX=0,CALLBACK_CAIXAPOSTAL=0,CALLBACK_IMPCOMPLETAR=0,CALLBACK_NAOINFORMADO=0,CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();


                    }
                    
                }


                //LOG CALLBACK
                ssql = "insert into gatlogcallback (idcodusuario,idcodcliente,acao,dataagend,datainsercao) values (";
                ssql = ssql + modulo.IDCodUsuario.ToString() + "," + modulo.idcodcliente.ToString() + ",3,null,getdate())";


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
                cmdnaorediscar.Enabled = true;
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// cmdrediscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdrediscar_Click(object sender, EventArgs e)
        {
            try
            {
                cmdrediscar.Enabled = false;

                gerlourens obj = new gerlourens();
                string ssql = "";
                string sddd = "";
                string stelefone = "";

                //trata telefone
                if (modulo.Bina.Substring(0,2) =="11")
                {
                    sddd = "0";
                    stelefone = modulo.Bina.Substring(2);
                }
                else
                {
                    sddd = "00";
                    stelefone = modulo.Bina;
                }


                //LOG CALLBACK
                ssql = "insert into gatlogcallback (idcodusuario,idcodcliente,acao,dataagend,datainsercao) values (";
                ssql = ssql + modulo.IDCodUsuario.ToString() + "," + modulo.idcodcliente.ToString() + ",1,null,getdate())";


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


                //LOG
                if (modulo.CallBackAutomatico==1)
                {
                    ssql = "UPDATE GATCLIENTE SET TELEFONE_CALLBACK='" + sddd + stelefone + "', CALLBACK_AUTOMATICO=1,CALLBACK_OPTOUFAZER=1,CALLBACK_OPTOUNAOFAZER=0,CALLBACK_NAOOPTOU=0,CALLBACK_ATENDIDO=0,CALLBACK_FALHA=0,CALLBACK_ENGANO=0,CALLBACK_DESCONECTADO=0,CALLBACK_OCUPADO=0,CALLBACK_NAOATENDE=0,CALLBACK_FAX=0,CALLBACK_CAIXAPOSTAL=0,CALLBACK_IMPCOMPLETAR=0,CALLBACK_NAOINFORMADO=0,CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();
                }
                else
                {
                    ssql = "UPDATE GATCLIENTE SET TELEFONE_CALLBACK='" + sddd + stelefone + "', CALLBACK_AUTOMATICO=0,CALLBACK_OPTOUFAZER=1,CALLBACK_OPTOUNAOFAZER=0,CALLBACK_NAOOPTOU=0,CALLBACK_ATENDIDO=0,CALLBACK_FALHA=0,CALLBACK_ENGANO=0,CALLBACK_DESCONECTADO=0,CALLBACK_OCUPADO=0,CALLBACK_NAOATENDE=0,CALLBACK_FAX=0,CALLBACK_CAIXAPOSTAL=0,CALLBACK_IMPCOMPLETAR=0,CALLBACK_NAOINFORMADO=0,CALLBACK_NUMEROINEX=0 WHERE IDCODCLIENTE = " + modulo.idcodcliente.ToString();
                }


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



                //LOG Makecall
                ssql = "insert into gatlogcallback_Makecall ( idcodusuario,idcodcliente,SusErinfo_Avaya,DDD,Telefone,datainsercao,VDN) values ( ";
                ssql = ssql + modulo.IDCodUsuario.ToString() + "," + modulo.idcodcliente.ToString() + ",'" + modulo.sUUI + "','" + sddd + "','" + stelefone + "',getdate(),'" + modulo.Ramal + "')";

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

                
                //makecall
                //modulo.objFrmCTIBar.makecall(modulo.sUserid_Avaya, sddd + stelefone, modulo.sUUI);
                

                //abre tela de classificacao
                frmClassificacaoCallBack oclass = new frmClassificacaoCallBack();
                oclass.ShowDialog();



                obj = null;

                this.Close();


                cmdrediscar.Enabled = true;

            }
            catch (Exception err)
            {
                cmdrediscar.Enabled = true;
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



    }
}
