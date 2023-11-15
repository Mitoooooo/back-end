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
        public Guid BookingId { get; set; }
        public string BookerName { get; set; }
        public string? Note { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }
        public string BookerPhone { get; set; }
        public double QuotaSpent { get; set; }

        public Guid SportFieldId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? TimeSlotId { get; set; }
    }
}
