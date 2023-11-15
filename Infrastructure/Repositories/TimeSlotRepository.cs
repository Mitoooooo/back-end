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
    public class TimeSlotRepository : GenericRepository<TimeSlot>, ITimeSlotRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICurrentTime _currentTime;
        private IClaimsService _claimsService;

        public TimeSlotRepository(AppDbContext appDbContext, ICurrentTime timeService, IClaimsService claimsService) : base(appDbContext, timeService, claimsService)
        {
            _appDbContext = appDbContext;
            _currentTime = timeService;
            _claimsService = claimsService;
        }

        public async Task<List<TimeSlot>> GetAllTimeSlots()
        {
            return await _appDbContext.TimeSlots.ToListAsync();
        }
    }
}
