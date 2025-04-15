using ComapnyMVCBussinesLogic.Dto;

namespace ComapnyMVCBussinesLogic.services
{
    public interface IDepartmentServices
    {
        int CreateDepartment(CreateDepartmentDto createDepartmentDto);
        IEnumerable<DepartmentDto> GetAllDepartment();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto updateDepartmentDto);
    }
}