﻿using MVCCompanyDataAccess.Model;

namespace MVCCompanyDataAccess.Repo
{
    public interface IDepartmentRepo
    {
        int Add(Department department);
        int Delete(Department department);
        int Edit(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetByID(int id);
    }
}