using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Hobby
    {
        DataAccessLayer.Hobby objhobdll = new DataAccessLayer.Hobby();
        public DataSet GetHobby()
        {
            DataSet ds = objhobdll.GetHobby();

            return ds;
        }
    }
}
