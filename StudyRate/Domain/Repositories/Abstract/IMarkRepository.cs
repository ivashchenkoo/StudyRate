using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IMarkRepository
    {
        IQueryable<Mark> GetMarks();
        IQueryable<Mark> GetMarksByStudentID(int Id);
        int GetMarksCount();
        Mark GetMarkById(int Id);
        void SaveMark(Mark entity);
    }
}
