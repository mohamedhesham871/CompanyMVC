using Microsoft.AspNetCore.Mvc;
using ComapnyMVCBussinesLogic.Dto;
using PresntaionLayer.ViewModels.DepartmentViewModels;
using MVCCompanyDataAccess.Model;
using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
namespace PresntaionLayer.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices, ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
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
        #region Details [Get]
        //Just Get
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);

        }
        #endregion
        #region Update [Get/Post]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            // convert from Details to viewModels Edit class
            var UpdateDepartment = new DepartmentViewModelEdit()
            {

                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedDate = department.CreatedDate
            };
            return View(UpdateDepartment);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModelEdit departmentViewModelEdit)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    // Convert ViewModel to DTO
                    var updateDepartmentDto = new UpdateDepartmentDto
                    {
                        Id = id,
                        Name = departmentViewModelEdit.Name,
                        Code = departmentViewModelEdit.Code,
                        Description = departmentViewModelEdit.Description,
                        CreatedDate = departmentViewModelEdit.CreatedDate
                    };
                    int result = _departmentServices.UpdateDepartment(updateDepartmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Failed to update department");
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
            return View(departmentViewModelEdit);
        }
        #endregion
        #region Delete [Get/Post]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (id == 0) return BadRequest();

            try
            {
                var department = _departmentServices.GetDepartmentById(id);
                if (department == null) return NotFound();
                var result = _departmentServices.DeleteDepartment(id);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to delete department");
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


            return RedirectToAction("Delete", new { id });
        }
        #endregion
    }

}


