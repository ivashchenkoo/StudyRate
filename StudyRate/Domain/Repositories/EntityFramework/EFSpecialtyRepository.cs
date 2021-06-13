using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFSpecialtyRepository : ISpecialtyRepository
    {
        private readonly AppDBContext context;

        public EFSpecialtyRepository(AppDBContext context)
        {
            this.context = context;
        }

        public IQueryable<Specialty> GetSpecialties()
        {
            return context.Specialties.Include(c => c.Faculty);
        }

        public int GetSpecialtiesCount()
        {
            return context.Specialties.Count();
        }

        public Specialty GetSpecialtyById(int Id)
        {
            return context.Specialties.Include(c => c.Faculty)
                .FirstOrDefault(x => x.Id == Id);
        }

        public void SaveSpecialty(Specialty entity)
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
