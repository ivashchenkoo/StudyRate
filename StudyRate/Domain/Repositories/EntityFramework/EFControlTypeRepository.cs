using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFControlTypeRepository : IControlTypeRepository
    {
        private readonly AppDBContext context;

        public EFControlTypeRepository(AppDBContext context)
        {
            this.context = context;
        }

        public ControlType GetControlTypeById(int Id)
        {
            return context.ControlTypes.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<ControlType> GetControlTypes()
        {
            return context.ControlTypes;
        }

        public int GetControlTypesCount()
        {
            return context.ControlTypes.Count();
        }

        public void SaveControlType(ControlType entity)
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
