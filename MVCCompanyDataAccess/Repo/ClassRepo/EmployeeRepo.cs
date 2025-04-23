using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Repo.ClassRepo;
using MVCCompanyDataAccess.Repo.InterfaceRepo;
namespace MVCCompanyDataAccess.Repo.ClassRepo
{
    public class EmployeeRepo(Contexts.ApplicationDBContext context) : GenricRepo<Empolyee>(context), IEmployeeRepo
    {
    }
}
