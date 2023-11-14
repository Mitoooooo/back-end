using Application.IServices;
using Application.ViewModels.SportTypeViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SportTypeService : ISportTypeService   
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SportTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*public async Task<List<TrainingClassViewAllDTO>> SearchSportTypeByNameAsync(string className)
        {
            var listClass = _unitOfWork.TrainingClassRepository.SearchClassByName(className);
            return listClass;
        }*/

        public async Task<bool> CreateSportTypeAsync(CreateSportTypeDTO createSportTypeDTO)
        {
            SportType sportType = _mapper.Map<SportType>(createSportTypeDTO);
            sportType.Id = Guid.NewGuid();             
                     
            await _unitOfWork.SportTypeRepository.AddAsync(sportType);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateSportTypeAsync(UpdateSportTypeDTO updateSportTypeDTO)
        {
            SportType sportType = _mapper.Map<SportType>(updateSportTypeDTO);

            _unitOfWork.SportTypeRepository.Update(sportType);
            return (await _unitOfWork.SaveChangeAsync() > 0);
        }

        /*public async Task<SportType> GetSportTypeByIdAsync(string sportTypeId)
        {
            try
            {
                var _sportTypeId = _mapper.Map<Guid>(sportTypeId);
                var sportType = await _unitOfWork.SportTypeRepository.GetByIdAsync(_sportTypeId);
                return sportType ?? throw new NullReferenceException($"Incorrect Id: The sport type with id: {sportTypeId} doesn't exist or has been deleted!");
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }*/
        public async Task<SportType> GetSportTypeByIdAsync(Guid sportTypeId)
        {
            try
            {
                var _sportTypeId = _mapper.Map<Guid>(sportTypeId);
                SportType sportType = await _unitOfWork.SportTypeRepository.GetByIdAsync(_sportTypeId);
                return sportType;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }

        /* public async Task<SportType> GetSportTypeById(Guid sportTypeId)
         {
             return await _unitOfWork.SportTypeRepository.GetSportTypeById(sportTypeId);
         }*/

        public async Task<bool> SoftRemoveSportTypeAsync(Guid sportTypeId)
        {
            var sportType = await GetSportTypeByIdAsync(sportTypeId);

            _unitOfWork.SportTypeRepository.SoftRemove(sportType);
            return (await _unitOfWork.SaveChangeAsync() > 0);
        }

        public async Task<List<SportType>> GetAllSportTypes()
        {
            return await _unitOfWork.SportTypeRepository.GetAllSportTypes();
        }
    }
}
