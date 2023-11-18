using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.BookingViewModels
{
    public class UpdateBookingDTO
    {
        public int BookingId { get; set; }
        public string BookerName { get; set; }
        public string? Note { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? Status { get; set; }
        public string BookerPhone { get; set; }
        public double QuotaSpent { get; set; }

        public int SportFieldId { get; set; }

        public int? UserId { get; set; }

        public int? TimeSlotId { get; set; }
    }
}
