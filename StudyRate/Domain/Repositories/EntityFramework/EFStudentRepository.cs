using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly AppDBContext context;

        public EFStudentRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Student GetStudentById(int Id)
        {
            return context.Students.Include(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty)
                .FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Student> GetStudents()
        {
            return context.Students.Include(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty);
        }

        public int GetStudentsCount()
        {
            return context.Students.Count();
        }

        public void SaveStudent(Student entity)
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
