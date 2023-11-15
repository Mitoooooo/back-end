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
    public class SportFieldRepository : GenericRepository<SportField>, ISportFieldRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICurrentTime _currentTime;
        private IClaimsService _claimsService;

        public SportFieldRepository(AppDbContext appDbContext, ICurrentTime timeService, IClaimsService claimsService) : base(appDbContext, timeService, claimsService)
        {
            _appDbContext = appDbContext;
            _currentTime = timeService;
            _claimsService = claimsService;
        }

        public async Task<List<SportField>> GetAllSportFields()
        {
            return await _appDbContext.SportFields.ToListAsync();
        }
    }
}
