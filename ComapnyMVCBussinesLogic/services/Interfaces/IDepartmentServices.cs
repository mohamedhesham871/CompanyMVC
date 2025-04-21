using ComapnyMVCBussinesLogic.Dto.DepartmentDtos;
using MVCCompanyDataAccess.Repo.UintOfWork;
namespace ComapnyMVCBussinesLogic.services.Interfaces
{
    public interface IDepartmentServices
    {
       
         IEnumerable<DepartmentDto> GetAllDepartment();
       public  DepartmentDetailsDto? GetDepartmentById(int id);
       public int CreateDepartment(CreateDepartmentDto createDepartmentDto);
       public int UpdateDepartment(UpdateDepartmentDto updateDepartmentDto);
       public bool DeleteDepartment(int id);

    }
}