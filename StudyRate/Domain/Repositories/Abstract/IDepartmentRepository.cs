using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetDepartments();
        int GetDepartmentsCount();
        Department GetDepartmentById(int Id);
        void SaveDepartment(Department entity);
    }
}
