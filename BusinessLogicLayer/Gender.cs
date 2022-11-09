using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BusinessLogicLayer
{
    public class Gender
    {
        DataAccessLayer.Gender gen = new DataAccessLayer.Gender();

        public DataSet GetGender()
        {
            DataSet ds = gen.GetGender();
            return ds;
        }

    }
}
