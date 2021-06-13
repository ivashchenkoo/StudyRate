using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFPositionRepository : IPositionRepository
    {
        private readonly AppDBContext context;

        public EFPositionRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Position GetPositionById(int Id)
        {
            return context.Positions.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Position> GetPositions()
        {
            return context.Positions;
        }

        public int GetPositionsCount()
        {
            return context.Positions.Count();
        }

        public void SavePosition(Position entity)
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
