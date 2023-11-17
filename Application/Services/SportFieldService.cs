using Application.IServices;
using Application.ViewModels.FieldClusterViewModels;
using Application.ViewModels.SportFieldViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SportFieldService : ISportFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SportFieldService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateSportFieldAsync(CreateSportFieldDTO createSportFieldDTO)
        {
            SportField sportField = _mapper.Map<SportField>(createSportFieldDTO);

            await _unitOfWork.SportFieldRepository.AddAsync(sportField);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateSportFieldAsync(UpdateSportFieldDTO updateSportFieldDTO)
        {
            SportField sportField = _mapper.Map<SportField>(updateSportFieldDTO);

            _unitOfWork.SportFieldRepository.Update(sportField);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<SportField> GetSportFieldByIdAsync(int sportFieldId)
        {
            try
            {
                SportField sportField = await _unitOfWork.SportFieldRepository.GetByIdAsync(sportFieldId);
                return sportField;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }

        public async Task<bool> SoftRemoveSportFieldAsync(int sportFieldId)
        {
            var sportField = await GetSportFieldByIdAsync(sportFieldId);

            _unitOfWork.SportFieldRepository.SoftRemove(sportField);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<SportField>> GetAllSportFields()
        {
            return await _unitOfWork.SportFieldRepository.GetAllSportFields();
        }
    }
}
