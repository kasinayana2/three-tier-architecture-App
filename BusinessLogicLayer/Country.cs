using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Country
    {
        DataAccessLayer.Country objcondal = new DataAccessLayer.Country();

        public DataSet GetCountry()
        {
            DataSet ds = objcondal.GetCountry();
            return ds;
        }
    }
}
