using Microsoft.AspNetCore.Mvc;
using ComapnyMVCBussinesLogic.services;
using ComapnyMVCBussinesLogic.Dto;
namespace PresntaionLayer.Controllers
{
    public class DepartmentController (IDepartmentServices _departmentServices,ILogger<DepartmentController>_logger,IWebHostEnvironment _environment): Controller
    {
        public IActionResult Index()
        {//GEt all Departments
            var departments = _departmentServices.GetAllDepartment();
            return View(departments);
           
        }
        #region Create [Get / Post]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto createDepartmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentServices.CreateDepartment(createDepartmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Failed to create department");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {

                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while creating the department. Please try again later.");
                    }
                }


            }
            return View(createDepartmentDto);
        } 
        #endregion
    }
}
