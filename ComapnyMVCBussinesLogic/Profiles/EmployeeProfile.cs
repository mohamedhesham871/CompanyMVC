using AutoMapper;
using ComapnyMVCBussinesLogic.Dto.EmployeeDtos;
using MVCCompanyDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapnyMVCBussinesLogic.Profiles
{
    public  class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            // CreateMap<Source,Destination>();

            // in this case Source is Employee and Destination is EmployeeDto
            //you should handle Missing properties
            CreateMap<Empolyee, EmployeeDto>()
                .ForMember(des => des.Gender, emp => emp.MapFrom(e => e.Gender))
                .ForMember(des => des.EmployeeType, emp => emp.MapFrom(e => e.EmployeeType))
                .ForMember(des => des.departmentName, emp => emp.MapFrom(e => e.department != null ? e.department.Name:null));

            // in this case Source is Employee and Destination is EmployeeDetailsDto
            CreateMap<Empolyee, EmployeeDetailsDto>()
               .ForMember(des => des.Gender, emp => emp.MapFrom(e => e.Gender))
                .ForMember(des => des.EmployeeType, emp => emp.MapFrom(e => e.EmployeeType))
                .ForMember(des => des.HiringDate, option => option.MapFrom(e => DateOnly.FromDateTime(e.HiringDate)))
                .ForMember(des => des.DepartmentName, emp => emp.MapFrom(e => e.department != null ? e.department.Name : null));

            // in this case Source is createEmployee and Destination is Employee
            CreateMap<CreateEmployeeDto, Empolyee>()
                .ForMember(des=>des.HiringDate,option=>option.MapFrom(e=>e.HiringDate.ToDateTime(TimeOnly.MinValue)));

            // in this case Source is updateEmployee and Destination is Employee
            CreateMap<UpdateEmployeeDto, Empolyee>()
                .ForMember(des=>des.HiringDate,option=>option.MapFrom(e=>e.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
