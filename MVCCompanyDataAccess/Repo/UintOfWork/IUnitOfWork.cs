using MVCCompanyDataAccess.Repo.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Repo.UintOfWork
{
    public interface IUnitOfWork
    {
        public IEmployeeRepo EmployeeRepo { get; }
        public IDepartmentRepo DepartmentRepo { get; }
        public int SaveChanges();
    }

}
