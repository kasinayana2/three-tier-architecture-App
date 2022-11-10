using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class Employee
    {
        DataAccessLayer.Employee objempdal = new DataAccessLayer.Employee();
        public int SaveEmp(BusinessObjects.Employee objemp)
        {
            int i = objempdal.SaveEmp(objemp);
            return i;            
        }
        public int DeleteEmp(BusinessObjects.Employee objemp)
        {
            int i = objempdal.DeleteEmp(objemp);
            return i;
        }
        public int UpdateEmp(BusinessObjects.Employee objemp)
        {
            int i = objempdal.UpdateEmp(objemp);
            return i;
        }
        public DataSet GetEmp()
        {
            DataSet ds = objempdal.GetEmp();
            return ds;
        }
    }
}
