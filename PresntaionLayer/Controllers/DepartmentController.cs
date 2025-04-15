using Microsoft.AspNetCore.Mvc;
using ComapnyMVCBussinesLogic.services;
namespace PresntaionLayer.Controllers
{
    public class DepartmentController (IDepartmentServices _departmentServices): Controller
    {
        public IActionResult Index()
        {//GEt all Departments
            var departments = _departmentServices.GetAllDepartment();
            return View(departments);
           
        }
    }
}
