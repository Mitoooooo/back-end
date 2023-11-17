using Application.IServices;
using Application.ViewModels.BookingViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateBookingAsync(CreateBookingDTO createBookingDTO)
        {
            Booking booking = _mapper.Map<Booking>(createBookingDTO);

            await _unitOfWork.BookingRepository.AddAsync(booking);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateBookingAsync(UpdateBookingDTO updateBookingDTO)
        {
            Booking booking = _mapper.Map<Booking>(updateBookingDTO);

            _unitOfWork.BookingRepository.Update(booking);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                Booking booking = await _unitOfWork.BookingRepository.GetByIdAsync(bookingId);
                return booking;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }

        public async Task<bool> SoftRemoveBookingAsync(int bookingId)
        {
            var booking = await GetBookingByIdAsync(bookingId);

            _unitOfWork.BookingRepository.SoftRemove(booking);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _unitOfWork.BookingRepository.GetAllBookings();
        }
    }
}
