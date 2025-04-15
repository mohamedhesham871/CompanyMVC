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
    public  class DepartmentServices(IDepartmentRepo departmentRepo) : IDepartmentServices
    {
        //Make CRUD with DepartmentRepo make it more secure


        readonly private IDepartmentRepo _departmentRepo = departmentRepo;     // dependency Injection


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

            var DetailsDept = new DepartmentDetailsDto()
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
        //Create
        public int? CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var department = new Department()
            {
                Name = createDepartmentDto.Name,
                Code = createDepartmentDto.Code,
                Description = createDepartmentDto.Description,
                CreatedOn = createDepartmentDto.CreatedDate,
                CreatedBy = 1, // Assuming 1 is the ID of the user creating the department  
            };
            var res = _departmentRepo.Add(department);
            return res;
        }
        public int? UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            var department = new Department()
            {
                Name = updateDepartmentDto.Name,
                Code = updateDepartmentDto.Code,
                Description = updateDepartmentDto.Description,
                CreatedOn = updateDepartmentDto.CreatedDate,
            };
            var res = _departmentRepo.Edit(department);
            return res;
        }

    }
}
