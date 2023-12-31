﻿using Application;
using Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ISportTypeRepository _sportTypeRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IFieldClusterRepository _fieldClusterRepository;
        private readonly ISportFieldRepository _sportFieldRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext appDbContext, ISportTypeRepository sportTypeRepository, ITimeSlotRepository timeSlotRepository
            , IFieldClusterRepository fieldClusterRepository, ISportFieldRepository sportFieldRepository, IBookingRepository bookingRepository,
            IUserRepository userRepository)
        {
            _appDbContext = appDbContext;   
            _sportTypeRepository = sportTypeRepository;
            _timeSlotRepository = timeSlotRepository;
            _fieldClusterRepository = fieldClusterRepository;
            _sportFieldRepository = sportFieldRepository;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
        }

        public ISportTypeRepository SportTypeRepository => _sportTypeRepository;
        public ITimeSlotRepository TimeSlotRepository => _timeSlotRepository;
        public IFieldClusterRepository FieldClusterRepository => _fieldClusterRepository;
        public ISportFieldRepository SportFieldRepository => _sportFieldRepository;
        public IBookingRepository BookingRepository => _bookingRepository;
        public IUserRepository UserRepository => _userRepository;
        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
