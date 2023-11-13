using Application.IRepositories;
using Application.IServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SportTypeRepository : GenericRepository<SportType>,ISportTypeRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICurrentTime _currentTime;
        private IClaimsService _claimsService;

        public SportTypeRepository(AppDbContext appDbContext, ICurrentTime timeService, IClaimsService claimsService) : base(appDbContext, timeService, claimsService)
        {
            _appDbContext = appDbContext;
            _currentTime = timeService;
            _claimsService = claimsService;
        }

        public async Task<List<SportType>> GetAllSportTypes()
        {
            return await _appDbContext.SportTypes.ToListAsync();
        }

        public async Task<SportType> GetSportTypeById(Guid sportTypeId)
        {
            return await _appDbContext.SportTypes.FindAsync(sportTypeId);
        }
    }
}
