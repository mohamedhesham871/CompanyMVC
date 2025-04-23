using Microsoft.AspNetCore.Mvc;
using ComapnyMVCBussinesLogic.Dto;
using PresntaionLayer.ViewModels.DepartmentViewModels;
using MVCCompanyDataAccess.Model;
using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;
using ComapnyMVCBussinesLogic.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace PresntaionLayer.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices, ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
		[Authorize]

		public IActionResult Index()
        {//GEt all Departments
            ViewData["Test01"]= "this is Test on Viewdata";
            ViewBag.Test02 = "This is Test on ViewBag";
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
        public IActionResult Create(CreateEditViewModel createEditViewModel)
        {
            if (ModelState.IsValid)
            {
                //Convert ViewModel to DTO
                var createDepartmentDto = new CreateDepartmentDto
                {
                    Name = createEditViewModel.Name,
                    Code = createEditViewModel.Code,
                    Description = createEditViewModel.Description,
                    CreatedDate = createEditViewModel.CreatedDate
                };
                try
                {
                    int result = _departmentServices.CreateDepartment(createDepartmentDto);
                    var message = string.Empty;
                    //Best Practice 
                    //if (result > 0)
                    //{
                    //    return RedirectToAction("Index");
                    //}
                    //ModelState.AddModelError("", "Failed to create department");

                    //Wil test on TempView
                    if (result > 0) message = "Create Department Successfully";
                    else message = "Department Can't be Created";
                    TempData["messageToClient"] = message;

                    return RedirectToAction("Index");

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
            return View(createEditViewModel);
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
            var UpdateDepartment = new CreateEditViewModel()
            {

                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedDate = department.CreatedDate
            };
            return View(UpdateDepartment);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, CreateEditViewModel departmentViewModelEdit)
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


