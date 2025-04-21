using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Repo.ClassRepo;
using MVCCompanyDataAccess.Repo.InterfaceRepo;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Repo.UintOfWork
{
    public  class UnitOfWork : IUnitOfWork
    {
        //use Lazy to laod class when needed
        private readonly Lazy<IEmployeeRepo> employeeRepo;
        private readonly Lazy<IDepartmentRepo>departmentRepo;
        private readonly Contexts.AppContext context;

        public UnitOfWork(IEmployeeRepo employeeRepo ,
                         IDepartmentRepo departmentRepo,
                         Contexts.AppContext _context)
        {
            context = _context;
           this.employeeRepo = new Lazy<IEmployeeRepo> (()=>new EmployeeRepo(_context) );
           this.departmentRepo =  new Lazy<IDepartmentRepo>(() => new DepartmentRepo(_context));

        }
       
        public IEmployeeRepo EmployeeRepo =>employeeRepo.Value;

        public IDepartmentRepo DepartmentRepo => departmentRepo.Value;

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }

}
