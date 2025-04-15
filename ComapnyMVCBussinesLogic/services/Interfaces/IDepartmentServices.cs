using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;

namespace ComapnyMVCBussinesLogic.services.Interfaces
{
    public interface IDepartmentServices
    {
        int CreateDepartment(CreateDepartmentDto createDepartmentDto);
        IEnumerable<DepartmentDto> GetAllDepartment();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto updateDepartmentDto);
        bool DeleteDepartment(int id);

    }
}