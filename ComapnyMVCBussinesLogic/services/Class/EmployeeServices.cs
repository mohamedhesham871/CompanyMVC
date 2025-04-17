using AutoMapper;
using Azure;
using ComapnyMVCBussinesLogic.Dto.EmployeeDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVCCompanyDataAccess.Model;
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
    public class EmployeeServices(IEmployeeRepo employeeRepo,IMapper _mapper) : IEmployeeServices
    {

        // Has Two Ways to map
        // _mapper.Map<Destination>(source);
        // _mapper.map<Source,Destination>(source);


        //Get All
        IEnumerable<EmployeeDto> IEmployeeServices.GetAllEmployees()
        {
            var employees = employeeRepo.GetAll();
            if (employees == null) return null;

            //var result = employees.Select(x => new EmployeeDto()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Age = x.Age,
            //    Salary = x.Salary,
            //    Email = x.Email,
            //    IsActive = x.IsActive,
            //    EmployeeType = x.employeeType.ToString(),
            //    Gender = x.gender.ToString()
            //}).ToList();

           
            //Convert From IEnumerable<Employee> to IEnumerable<EmployeeDto>
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees) ;
        }

        //Get By ID
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var emp = employeeRepo.GetByID(id);
            if (emp == null) return null;

            // convert from Employee to EmployeeDetailsDto
            return _mapper.Map<EmployeeDetailsDto>(emp);
        }

        //Add Employee[Create Employee]
        public int CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            // convert from CreateEmployeeDto to Employee
            var emp = _mapper.Map<Empolyee>(createEmployeeDto);

            return employeeRepo.Add(emp); ;
        }

        //Update Employee
        public int UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
         
            // convert from UpdateEmployeeDto to Employee
           var  emp = _mapper.Map<Empolyee>(updateEmployeeDto);

            return employeeRepo.Edit(emp);
        }

        public bool DeleteEmployee(int id)
        {
            //[Soft Delete] 
            var emp = employeeRepo.GetByID(id);
            if (emp == null) return false;
             emp.IsDeleted = true;
            var res = employeeRepo.Edit(emp);//update
            return res> 0 ? true : false;
        }
    }

}
