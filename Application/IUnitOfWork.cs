using Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public ISportTypeRepository SportTypeRepository { get; }
        public ITimeSlotRepository TimeSlotRepository { get; }
        public IFieldClusterRepository FieldClusterRepository { get; }
        public ISportFieldRepository SportFieldRepository { get; }
        public IBookingRepository BookingRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
