using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ISportTypeRepository : IGenericRepository<SportType>
    {
        public Task<List<SportType>> GetAllSportTypes();
        public Task<SportType> GetSportTypeById(Guid sportTypeId);
    }
}
