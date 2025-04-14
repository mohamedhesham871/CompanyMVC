using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapnyMVCBussinesLogic.Dto;
using MVCCompanyDataAccess.Repo;
using ComapnyMVCBussinesLogic.Factory;
using MVCCompanyDataAccess.Model;
namespace ComapnyMVCBussinesLogic.services
{
    internal class DepartmentServices
    {
        //Make CRUD with DepartmentRepo make it more secure


        readonly private IDepartmentRepo _departmentRepo;

        public DepartmentServices(IDepartmentRepo departmentRepo)// dependency Injection
        {
            _departmentRepo = departmentRepo;
            // DepartmentRepo   test two
        }

        //Get All 
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var departments = _departmentRepo.GetAll();
            var departmentsDto = departments.Select(x => new DepartmentDto()
            {
                DeptId = x.Id,
                Name = x.Name,
                Code = x.Code,
                Description = x.Description,
                CreatedDate = x.CreatedOn
            }).ToList();
            return departmentsDto;
        }

        //Get By ID
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepo.GetByID(id);
            if (department == null) return null;
    
            var DetailsDept =new DepartmentDetailsDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedDate = department.CreatedOn,
                CreatedBy = department.CreatedBy,
                Lastupdate = department.LastModifiiedOn,
                LastUpdateBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted
            };
            return DetailsDept;
        }

    }
}
