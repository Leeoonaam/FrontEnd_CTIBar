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
    public partial class frmperformance : Form
    {
        public frmperformance()
        {
            InitializeComponent();
        }


        gerlourens obj = new gerlourens();


        /// <summary>
        /// frmperformance_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmperformance_Load(object sender, EventArgs e)
        {
            try
            {

                TotalChamadas();
                TMA();
                TotalPausas();
                TempoLogado();

                Chamadas();
                Pausas();

            }
            catch (Exception err)
            {

                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }


        /// <summary>
        /// TotalChamadas
        /// </summary>
        public void TotalChamadas()
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = @"select	count(1)
                                            from	gattelchamadas a (nolock)
                                            where	datagatchamada between left(convert(varchar(20),getdate(),120),10) + ' 00:00:00' and  left(convert(varchar(20),getdate(),120),10) + ' 23:59:59'
                                            and		a.idcodusuario = " + modulo.IDCodUsuario.ToString() ;

                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {

                            lbltotalatendimentos.Text = dr[0].ToString();

                        }
                        dr.Close();
                        
                    }
                    
                }



            }
            catch (Exception err)
            {
                //
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }



        /// <summary>
        /// TMA
        /// </summary>
        public void TMA()
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = @"select	isnull(avg(datediff(second,a.datainiatend,a.datagatchamada)),0)
                                            from	gattelchamadas a (nolock)
                                            where	datagatchamada between left(convert(varchar(20),getdate(),120),10) + ' 00:00:00' and  left(convert(varchar(20),getdate(),120),10) + ' 23:59:59'
                                            and		a.idcodusuario = " + modulo.IDCodUsuario.ToString();



                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {

                            lbltma.Text = modulo.horacheia(Convert.ToInt32(dr[0].ToString()));

                        }
                        dr.Close();

                    }

                }



            }
            catch (Exception err)
            {
                //
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }




        /// <summary>
        /// TotalPausas
        /// </summary>
        public void TotalPausas()
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = @"select	count(1)
                                            from	GATTempoPausa a (nolock)
                                            where	a.DataInicio  between left(convert(varchar(20),getdate(),120),10) + ' 00:00:00' and  left(convert(varchar(20),getdate(),120),10) + ' 23:59:59'
                                            and		a.IDCodUsuario = " + modulo.IDCodUsuario.ToString();


                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {

                            lbltotalpausa.Text = dr[0].ToString();

                        }
                        dr.Close();

                    }

                }



            }
            catch (Exception err)
            {
                //
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }




        /// <summary>
        /// TempoLogado
        /// </summary>
        public void TempoLogado()
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = @"select	isnull(DATEDIFF(second,min(a.datatempo),max(a.datatempo)),0)
                                            from	GATTempoUsuario a (nolock)
                                            where	a.DataTempo  between left(convert(varchar(20),getdate(),120),10) + ' 00:00:00' and  left(convert(varchar(20),getdate(),120),10) + ' 23:59:59'
                                            and		a.IDCodUsuario = " + modulo.IDCodUsuario.ToString() ;


                        cmd.CommandType = CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr.Read())
                        {

                            lbltempologado.Text = modulo.horacheia(Convert.ToInt32(dr[0].ToString()));

                        }
                        dr.Close();

                    }

                }



            }
            catch (Exception err)
            {
                //
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }





        /// <summary>
        /// Chamadas
        /// </summary>
        public void Chamadas()
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = @"select	b.ticket,
                                                    c.motivo,
                                                    d.motivo 'status',
                                                    b.TICKET_TIPO,
                                                    a.datainiatend 'Inicio',
                                                    a.datagatchamada 'Fim'                                                    

                                            from	gattelchamadas a (nolock)
                                                    inner join gatcliente b (nolock) on a.idcodcliente = b.idcodcliente
                                                    inner join gatmotivochamada c (nolock) on a.idcodmotivo = c.idcodmotivo
                                                    left outer join gatmotivochamada d (nolock) on a.idcodstatus = d.idcodmotivo

                                            where	a.datagatchamada between left(convert(varchar(20),getdate(),120),10) + ' 00:00:00' and  left(convert(varchar(20),getdate(),120),10) + ' 23:59:59'
                                            and		a.idcodusuario = " + modulo.IDCodUsuario.ToString() + " order by a.datagatchamada";

                        cmd.CommandType = CommandType.Text;
                        

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataTable ds = new DataTable();
                        da.Fill(ds);

                        gridview_atendimentos.DataSource = ds;
                        
                    }

                }

            }
            catch (Exception err)
            {
                //
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }




        /// <summary>
        /// Pausas
        /// </summary>
        public void Pausas()
        {
            try
            {

                using (SqlConnection cn = obj.abre_cn())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = cn;
                        cmd.CommandText = @"select	b.Pausa,
		                                            a.DataInicio,
		                                            a.DataFim,
		                                            cast(DATEADD(ms, datediff(second,a.DataInicio,a.DataFim) * 1000, 0) as time)  'Duracao'
                                            from	GATTempoPausa a (nolock),
		                                            gatmotivopausa b (nolock)
                                            where	a.DataInicio  between left(convert(varchar(20),getdate(),120),10) + ' 00:00:00' and  left(convert(varchar(20),getdate(),120),10) + ' 23:59:59'
                                            and		a.idcodpausa = b.idcodpausa
                                            and		a.IDCodUsuario = " + modulo.IDCodUsuario.ToString();


                        cmd.CommandType = CommandType.Text;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataTable ds = new DataTable();
                        da.Fill(ds);

                        gridview_pausas.DataSource = ds;

                    }

                }



            }
            catch (Exception err)
            {
                //
                modulo.Show_Mensagem_Alerta(err.Message);
            }
        }






    }
}
