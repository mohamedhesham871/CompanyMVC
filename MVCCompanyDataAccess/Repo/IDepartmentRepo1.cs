using MVCCompanyDataAccess.Model;

namespace MVCCompanyDataAccess.Repo
{
    internal interface IDepartmentRepo1
    {
        int Add(Department department);
        int Delete(Department department);
        int Edit(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetByID(int id);
    }
}