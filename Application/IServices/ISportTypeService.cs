using Application.ViewModels.SportTypeViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISportTypeService
    {
        public Task<bool> CreateSportTypeAsync(CreateSportTypeDTO createSportTypeDTO);
        public Task<bool> UpdateSportTypeAsync(UpdateSportTypeDTO updateSportTypeDTO);
        public Task<SportType> GetSportTypeByIdAsync(Guid sportTypeId);
        public Task<bool> SoftRemoveSportTypeAsync(Guid sportTypeId);
        public Task<List<SportType>> GetAllSportTypes();
    }
}
