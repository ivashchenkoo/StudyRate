using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFSubjectRepository : ISubjectRepository
    {
        private readonly AppDBContext context;

        public EFSubjectRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Subject GetSubjectById(int Id)
        {
            return context.Subjects.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Subject> GetSubjects()
        {
            return context.Subjects;
        }

        public int GetSubjectsCount()
        {
            return context.Subjects.Count();
        }

        public void SaveSubject(Subject entity)
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
