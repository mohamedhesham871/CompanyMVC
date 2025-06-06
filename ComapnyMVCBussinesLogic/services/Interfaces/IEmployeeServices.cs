﻿using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;
using ComapnyMVCBussinesLogic.Dto.EmployeeDtos;
using MVCCompanyDataAccess.Repo.UintOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapnyMVCBussinesLogic.services.Interfaces
{
    public interface IEmployeeServices
    {
        //IEnumerable<EmployeeDto> GetAllEmployees();  
        IEnumerable<EmployeeDto> GetAllEmployees(string? filter);
        public EmployeeDetailsDto? GetEmployeeById(int id);
        public int CreateEmployee(CreateEmployeeDto createEmployeeDto);
        public int UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        public bool DeleteEmployee(int id);
    }

}
