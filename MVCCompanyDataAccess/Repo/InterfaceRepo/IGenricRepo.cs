using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Model.Shaerd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Repo.InterfaceRepo
{
    public  interface IGenricRepo<TEnttiy> where TEnttiy : BaseClass
  
    {
        void Add(TEnttiy _TEnttiy);
        void Delete(TEnttiy _TEnttiy);
        void Edit(TEnttiy _TEnttiy);
        IEnumerable<TEnttiy> GetAll(bool WithTracking = false);
        IEnumerable<TEnttiy> GetAll(Expression<Func<TEnttiy ,bool>>filter);
        TEnttiy? GetByID(int id);
    }
}
