using ComapnyMVCBussinesLogic.Dto.EmployeeDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVCCompanyDataAccess.Model.Enums;
using System.Runtime.InteropServices.Marshalling;

namespace PresntaionLayer.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices ,ILogger<EmployeesController>_logger,IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeeServices.GetAllEmployees();

            return View(employees);
        }
        #region Creat [Get /post]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult create(CreateEmployeeDto createEmployeeDto)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int emp = _employeeServices.CreateEmployee(createEmployeeDto);

                    if (emp > 0) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Can't Create Employee");
                    }
                }
                catch(Exception ex)
                {
                    if(_environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }

            }
            return View(createEmployeeDto);
        }
        #endregion
        #region Details [Get]

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var emp = _employeeServices.GetEmployeeById(id.Value);
            if (emp == null) return NotFound();

            return View(emp);

        }

        #endregion
        #region Edit[Get/Post]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var emp = _employeeServices.GetEmployeeById(id.Value);
            
            if (emp == null) return NotFound();
            //Convert From EmployeeDetailsDto to UpdateEmployeeDto
            var EditEmp = new UpdateEmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Address = emp.Address,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary,
                HiringDate = emp.HiringDate,
                Email = emp.Email,
                IsActive = emp.IsActive,
                Gender = Enum.Parse<Gender>(emp.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(emp.EmployeeType)
            };

            
            return View(EditEmp);
        }
        [HttpPost]
        // Recommed using ViewModel Not this Way
        public IActionResult Edit(int? id, UpdateEmployeeDto updateEmployeeDto)
        {
            if (!id.HasValue|| id!=updateEmployeeDto.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var emp = _employeeServices.UpdateEmployee( updateEmployeeDto);

                    if (emp > 0) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Can't Update Employee");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(updateEmployeeDto);
        }
        #endregion
        #region Delete [Post]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if(id==0)return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = _employeeServices.DeleteEmployee(id.Value);

                    if (emp) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Can't Delete Employee");
                        return RedirectToAction("Delete", new {id});
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View("Error");
        }
        #endregion
    }
}
