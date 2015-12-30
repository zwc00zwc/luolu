using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Luolu.Common
{
    public class SqlHelper
    {
        public static readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public static DataTable Read (string sql,params SqlParameter[] parmters)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parmters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds=new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
    }
}