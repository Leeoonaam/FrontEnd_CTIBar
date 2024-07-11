using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace lsOPCTIBar
{

    public class gerlourens
    {


        public gerlourens()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        /// <summary>
        /// abre_cn
        /// </summary>
        /// <returns></returns>
        public SqlConnection abre_cn()
        {
            try
            {
                string sconn = "";

                //DB -- PRODUCAO
                sconn = "Password=XSa32k#25Bb@17;Persist Security Info=True;User ID=USR_STTGATCSU_IFOOD;Initial Catalog=STTGATCSU_IFOOD;Data Source=10.171.2.24";


                //DB -- DESENV
                //sconn = "Password=sttfnd007;Persist Security Info=True;User ID=gatfnduser;Initial Catalog=STTGATCSU_IFOOD;Data Source=.";


                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = sconn;
                cn.Open();

                return cn;
            }
            catch (Exception err)
            {
                return null;
            }
        }



    }
}
