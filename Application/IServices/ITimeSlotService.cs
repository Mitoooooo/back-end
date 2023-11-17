using Application.ViewModels.TimeSlotViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITimeSlotService
    {
        public Task<bool> CreateTimeSlotAsync(CreateTimeSlotDTO createTimeSlotDTO);
        public Task<bool> UpdateTimeSlotAsync(UpdateTimeSlotDTO updateTimeSlotDTO);
        public Task<TimeSlot> GetTimeSlotByIdAsync(int timeSlotId);
        public Task<bool> SoftRemoveTimeSlotAsync(int timeSlotId);
        public Task<List<TimeSlot>> GetAllTimeSlots();
    }
}
