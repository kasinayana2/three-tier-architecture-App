using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public class Hobby
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
         public DataSet GetHobby()
        {
            SqlDataAdapter da = new SqlDataAdapter("uspGetHobby", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "hob");
            return ds;
        }
    }
}
