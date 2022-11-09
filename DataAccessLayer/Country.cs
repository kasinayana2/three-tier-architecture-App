using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DataAccessLayer
{
    public class Country
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public DataSet GetCountry()
        {
            SqlDataAdapter da = new SqlDataAdapter("uspGetCountry", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "cont");
            return ds;
        }
    }
}
