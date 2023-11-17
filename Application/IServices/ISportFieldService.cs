using Application.ViewModels.SportFieldViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISportFieldService
    {
        public Task<bool> CreateSportFieldAsync(CreateSportFieldDTO createSportFieldDTO);
        public Task<bool> UpdateSportFieldAsync(UpdateSportFieldDTO updateSportFieldDTO);
        public Task<SportField> GetSportFieldByIdAsync(int sportFieldId);
        public Task<bool> SoftRemoveSportFieldAsync(int sportFieldId);
        public Task<List<SportField>> GetAllSportFields();
    }
}
