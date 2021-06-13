using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain.Entities;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain.Repositories.EntityFramework
{
    public class EFProfessorRepository : IProfessorRepository
    {
        private readonly AppDBContext context;

        public EFProfessorRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Professor GetProfessorByEmailPassword(string Email, string Password)
        {
            string password = new PasswordHasher<IdentityUser>().HashPassword(null, Password);
            return context.Professors.Include(c => c.Department).ThenInclude(c => c.Faculty).Include(c => c.Position)
                .FirstOrDefault(x => x.Email == Email && x.PasswordHash == password);
        }
        
        public Professor GetProfessorById(int Id)
        {
            return context.Professors.Include(c => c.Department).ThenInclude(c => c.Faculty).Include(c => c.Position)
                .FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<Professor> GetProfessors()
        {
            return context.Professors.Include(c => c.Department).ThenInclude(c => c.Faculty).Include(c => c.Position);
        }

        public int GetProfessorsCount()
        {
            return context.Professors.Count();
        }

        public void SaveProfessor(Professor entity)
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
