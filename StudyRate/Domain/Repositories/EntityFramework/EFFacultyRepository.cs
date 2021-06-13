using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFFacultyRepository : IFacultyRepository
    {
        private readonly AppDBContext context;

        public EFFacultyRepository(AppDBContext context)
        {
            this.context = context;
        }

        public int GetFacultiesCount()
        {
            return context.Faculties.Count();
        }

        public IQueryable<Faculty> GetFaculties()
        {
            return context.Faculties;
        }

        public Faculty GetFacultyById(int Id)
        {
            return context.Faculties.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveFaculty(Faculty entity)
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
