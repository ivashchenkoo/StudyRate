using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext context;

        public EFDepartmentRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Department GetDepartmentById(int Id)
        {
            return context.Departments.Include(c => c.Faculty).FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Department> GetDepartments()
        {
            return context.Departments.Include(c => c.Faculty);
        }

        public int GetDepartmentsCount()
        {
            return context.Departments.Count();
        }

        public void SaveDepartment(Department entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
