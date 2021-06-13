using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFGroupRepository : IGroupRepository
    {
        private readonly AppDBContext context;

        public EFGroupRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Group GetGroupById(int Id)
        {
            return context.Groups.Include(c => c.Specialty).ThenInclude(c => c.Faculty)
                .FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Group> GetGroups()
        {
            return context.Groups.Include(c => c.Specialty).ThenInclude(c => c.Faculty);
        }

        public int GetGroupsCount()
        {
            return context.Groups.Count();
        }

        public void SaveGroup(Group entity)
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
