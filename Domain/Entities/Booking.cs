using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string BookerName { get; set; }
        public string? Note { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? Status { get; set; }
        public string BookerPhone { get; set; }
        public double? QuotaSpent { get; set; }

        public SportField? SportField { get; set; }
        public int SportFieldId { get; set; }

        public User? User {  get; set; }
        public int? UserId { get; set; }

        public TimeSlot? TimeSlot { get; set; }
        public int? TimeSlotId { get; set; }
    }
}
