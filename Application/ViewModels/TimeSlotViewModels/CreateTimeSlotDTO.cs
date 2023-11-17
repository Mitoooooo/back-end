using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.TimeSlotViewModels
{
    public class CreateTimeSlotDTO
    {
        public int DayOfWeek { get; set; }
        public DateTime StartSlotTime { get; set; }
        public DateTime EndSlotTime { get; set; }

        public int SportTypeId { get; set; }
    }
}
