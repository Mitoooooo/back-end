using Application.ViewModels.BookingViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IBookingService
    {
        public Task<bool> CreateBookingAsync(CreateBookingDTO createBookingDTO);
        public Task<bool> UpdateBookingAsync(UpdateBookingDTO updateBookingDTO);
        public Task<Booking> GetBookingByIdAsync(int bookingId);
        public Task<bool> SoftRemoveBookingAsync(int bookingId);
        public Task<List<Booking>> GetAllBookings();
    }
}
