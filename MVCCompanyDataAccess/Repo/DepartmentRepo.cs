using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Update;
using MVCCompanyDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVCCompanyDataAccess.Repo
{
    internal class DepartmentRepo(Contexts.AppContext context) : IDepartmentRepo1
    {
        private readonly Contexts.AppContext _context = context;
        //Contain CRUP oprations
        //Create      [Add]
        //Read        [GetByID]
        //Update      [Edit]
        //Delete      [Delete]
        //GetAll      [GetAll]

        //GET ALL
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _context.Departments.ToList();
            }
            else
            {
                return _context.Departments.AsNoTracking().ToList();
            }
        }
        //GET BY ID
        public Department? GetByID(int id)
        {

            return _context.Departments.FirstOrDefault(x => x.Id == id);
        }

        //Add [Create]
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        //Update
        public int Edit(Department department)
        {
            _context.Departments.Update(department);

            return _context.SaveChanges();
        }
        //Delete
        public int Delete(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }
    }

}
