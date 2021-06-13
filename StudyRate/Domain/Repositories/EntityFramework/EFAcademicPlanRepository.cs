using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFAcademicPlanRepository : IAcademicPlanRepository
    {
        private readonly AppDBContext context;

        public EFAcademicPlanRepository(AppDBContext context)
        {
            this.context = context;
        }

        public AcademicPlan GetAcademicPlanById(int Id)
        {
             return context.AcademicPlans.Include(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty)
                .Include(c => c.Professor).ThenInclude(c => c.Department).ThenInclude(c => c.Faculty)
                .Include(c => c.Subject)
                .FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<AcademicPlan> GetAcademicPlans()
        {
            return context.AcademicPlans.Include(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty)
                .Include(c => c.Professor).ThenInclude(c => c.Department).ThenInclude(c => c.Faculty)
                .Include(c => c.Subject);
        }

        public int GetAcademicPlansCount()
        {
            return context.AcademicPlans.Count();
        }

        public void SaveAcademicPlan(AcademicPlan entity)
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
