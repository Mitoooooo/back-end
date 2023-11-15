using Application.IServices;
using Application.ViewModels.SportTypeViewModels;
using Application.ViewModels.TimeSlotViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TimeSlotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateTimeSlotAsync(CreateTimeSlotDTO createTimeSlotDTO)
        {
            TimeSlot timeSlot = _mapper.Map<TimeSlot>(createTimeSlotDTO);
            timeSlot.Id = Guid.NewGuid();

            await _unitOfWork.TimeSlotRepository.AddAsync(timeSlot);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateTimeSlotAsync(UpdateTimeSlotDTO updateTimeSlotDTO)
        {
            TimeSlot timeSlot = _mapper.Map<TimeSlot>(updateTimeSlotDTO);

            _unitOfWork.TimeSlotRepository.Update(timeSlot);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<TimeSlot> GetTimeSlotByIdAsync(Guid timeSlotId)
        {
            try
            {
                var _timeSlotId = _mapper.Map<Guid>(timeSlotId);
                TimeSlot timeSlot = await _unitOfWork.TimeSlotRepository.GetByIdAsync(_timeSlotId);
                return timeSlot;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }

        public async Task<bool> SoftRemoveTimeSlotAsync(Guid timeSlotId)
        {
            var timeSlot = await GetTimeSlotByIdAsync(timeSlotId);

            _unitOfWork.TimeSlotRepository.SoftRemove(timeSlot);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<TimeSlot>> GetAllTimeSlots()
        {
            return await _unitOfWork.TimeSlotRepository.GetAllTimeSlots();
        }
    }
}
