using ComapnyMVCBussinesLogic.Dto.EmployeeDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}
