using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapnyMVCBussinesLogic.Factory;
using MVCCompanyDataAccess.Model;
using System.ComponentModel.DataAnnotations;
using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
using MVCCompanyDataAccess.Repo.UintOfWork;
namespace ComapnyMVCBussinesLogic.services.Class
{
    public class DepartmentServices(IUnitOfWork unitOfWork) : IDepartmentServices
    {
        //Make CRUD with DepartmentRepo make it more secure


      ///  readonly private IDepartmentRepo _departmentRepo = departmentRepo;     // dependency Injection
     //   private readonly IUnitOfWork unitOfWork = unitOfWork;                     // dependency Injection


        //Get All 
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
           
            var departments = unitOfWork.DepartmentRepo.GetAll();
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
            var department = unitOfWork.DepartmentRepo.GetByID(id);
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
        public int CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var department = new Department()
            {
                Name = createDepartmentDto.Name,
                Code = createDepartmentDto.Code,
                Description = createDepartmentDto.Description,
                CreatedOn = createDepartmentDto.CreatedDate,
                CreatedBy = 1, // Assuming 1 is the ID of the user creating the department  
            };
               unitOfWork.DepartmentRepo.Add(department);
            return unitOfWork.SaveChanges();
        }
        public int UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            var department = new Department()
            {
                Id = updateDepartmentDto.Id,
                Name = updateDepartmentDto.Name,
                Code = updateDepartmentDto.Code,
                Description = updateDepartmentDto.Description,
                CreatedOn = updateDepartmentDto.CreatedDate,
            };
          unitOfWork.DepartmentRepo.Edit(department);
            return unitOfWork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            if (id == 0) return false;

            var department = unitOfWork.DepartmentRepo.GetByID(id);
            if (department == null) return false;

            else
            {
                 unitOfWork.DepartmentRepo.Delete(department);
                return unitOfWork.SaveChanges()> 0 ? true : false;
            }

        }
    }
}
