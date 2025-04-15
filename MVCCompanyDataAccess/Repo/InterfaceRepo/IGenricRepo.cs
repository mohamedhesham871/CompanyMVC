using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Model.Shaerd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Repo.InterfaceRepo
{
    public  interface IGenricRepo<TEnttiy> where TEnttiy : BaseClass
  
    {
        int Add(TEnttiy _TEnttiy);
        int Delete(TEnttiy _TEnttiy);
        int Edit(TEnttiy _TEnttiy);
        IEnumerable<TEnttiy> GetAll(bool WithTracking = false);
        TEnttiy? GetByID(int id);
    }
}
