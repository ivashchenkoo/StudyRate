using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFMarkRepository : IMarkRepository
    {
        private readonly AppDBContext context;

        public EFMarkRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Mark GetMarkById(int Id)
        {
            return context.Marks.Include(c => c.ControlType).Include(c => c.Subject)
                .Include(c => c.Student).ThenInclude(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty)
                .FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Mark> GetMarks()
        {
            return context.Marks.Include(c => c.ControlType).Include(c => c.Subject)
                .Include(c => c.Student).ThenInclude(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty);
        }

        public IQueryable<Mark> GetMarksByStudentID(int Id)
        {
            return context.Marks.Include(c => c.ControlType).Include(c => c.Subject)
                .Include(c => c.Student).ThenInclude(c => c.Group).ThenInclude(c => c.Specialty).ThenInclude(c => c.Faculty).Where(x => x.StudentID == Id);
        }

        public int GetMarksCount()
        {
            return context.Marks.Count();
        }

        public void SaveMark(Mark entity)
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
