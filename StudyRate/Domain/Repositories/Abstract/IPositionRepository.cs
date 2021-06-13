using StudyRate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IPositionRepository
    {
        IQueryable<Position> GetPositions();
        int GetPositionsCount();
        Position GetPositionById(int Id);
        void SavePosition(Position entity);
    }
}
