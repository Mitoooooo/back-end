using Application.IServices;
using Application.ViewModels.FieldClusterViewModels;
using Application.ViewModels.TimeSlotViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FieldClusterService : IFieldClusterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FieldClusterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateFieldClusterAsync(CreateFieldClusterDTO createFieldClusterDTO)
        {
            FieldCluster fieldCluster = _mapper.Map<FieldCluster>(createFieldClusterDTO);
            fieldCluster.Id = Guid.NewGuid();

            await _unitOfWork.FieldClusterRepository.AddAsync(fieldCluster);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateFieldClusterAsync(UpdateFieldClusterDTO updateFieldClusterDTO)
        {
            FieldCluster fieldCluster = _mapper.Map<FieldCluster>(updateFieldClusterDTO);

            _unitOfWork.FieldClusterRepository.Update(fieldCluster);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<FieldCluster> GetFieldClusterByIdAsync(Guid fieldClusterId)
        {
            try
            {
                var _fieldClusterId = _mapper.Map<Guid>(fieldClusterId);
                FieldCluster fieldCluster = await _unitOfWork.FieldClusterRepository.GetByIdAsync(_fieldClusterId);
                return fieldCluster;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }

        public async Task<bool> SoftRemoveFieldClusterAsync(Guid fieldClusterId)
        {
            var fieldCluster = await GetFieldClusterByIdAsync(fieldClusterId);

            _unitOfWork.FieldClusterRepository.SoftRemove(fieldCluster);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<FieldCluster>> GetAllFieldClusters()
        {
            return await _unitOfWork.FieldClusterRepository.GetAllFieldClusters();
        }
    }
}
