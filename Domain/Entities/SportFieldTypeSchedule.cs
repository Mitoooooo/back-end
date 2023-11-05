using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SportFieldTypeSchedule : BaseEntity
    {
        public int DayOfWeek { get; set; }
        public DateTime OpeningTime {  get; set; }
        public DateTime ClosingTime { get; set; }
        public double PricePerHour { get; set; }

        public SportFieldType SportFieldType { get; set; }
        public Guid SportFieldTypeId { get; set; }
    }
}
