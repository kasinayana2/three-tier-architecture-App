using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Gender
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public DataSet GetGender()
        {
            SqlDataAdapter da = new SqlDataAdapter("uspGetGender", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "gen");
            return ds;
        }

    }
}
