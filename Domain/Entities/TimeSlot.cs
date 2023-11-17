using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        public int DayOfWeek { get; set; }
        public DateTime StartSlotTime {  get; set; }
        public DateTime EndSlotTime { get; set; }

        public SportType? SportType { get; set; }
        public int? SportTypeId { get; set; }
    }
}
