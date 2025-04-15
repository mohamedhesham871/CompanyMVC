using Azure;
using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;
using ComapnyMVCBussinesLogic.Dto.EmployeeDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVCCompanyDataAccess.Model.Enums;
using MVCCompanyDataAccess.Repo.ClassRepo;
using MVCCompanyDataAccess.Repo.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComapnyMVCBussinesLogic.services.Class
{
    public class EmployeeServices(IEmployeeRepo employeeRepo) : IEmployeeServices
    { 
        //Get All
        IEnumerable<EmployeeDto> IEmployeeServices.GetAllEmployees()
        {
            var employees = employeeRepo.GetAll();
            if (employees == null) return null;

            var result = employees.Select(x => new EmployeeDto()
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Salary = x.Salary,
                Email = x.Email,
                IsActive = x.IsActive,
                EmployeeType = x.employeeType.ToString(),
                Gender = x.gender.ToString()
            }).ToList();
            return result;
        }

        //Get By ID
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var emp = employeeRepo.GetByID(id);
            if (emp == null) return null;

            var EmpDetails = new EmployeeDetailsDto()
            {
                Id = emp.Id,

                Name= emp.Name,

                Age = emp.Age,

                Salary =emp.Salary,

                Email= emp.Email,

                IsActive = emp.IsActive,

                EmployeeType = emp.employeeType.ToString(),

                Gender = emp.gender.ToString(),

                Address= emp.Address,

                CreatedBy =emp.CreatedBy,

                LastModifiedBy = emp.LastModifiedBy,

                PhoneNumber = emp.PhoneNumber,

                LastModifiedOn = emp.LastModifiiedOn,

                CreatedOn =emp.CreatedOn,

                HiringDate = DateOnly.FromDateTime(emp.HiringDate)
            };
            return EmpDetails;
        }
    }

}
