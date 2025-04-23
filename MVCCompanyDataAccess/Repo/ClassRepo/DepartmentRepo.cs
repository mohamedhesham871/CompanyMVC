using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Update;
using MVCCompanyDataAccess.Model;
using MVCCompanyDataAccess.Repo.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVCCompanyDataAccess.Repo.ClassRepo
{
    public class DepartmentRepo(Contexts.ApplicationDBContext context) :GenricRepo<Department>(context), IDepartmentRepo
    {
        
    }

}
