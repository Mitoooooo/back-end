﻿using Application.ViewModels.FieldClusterViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IFieldClusterService
    {
        public Task<bool> CreateFieldClusterAsync(CreateFieldClusterDTO createFieldClusterDTO);
        public Task<bool> UpdateFieldClusterAsync(UpdateFieldClusterDTO updateFieldClusterDTO);
        public Task<FieldCluster> GetFieldClusterByIdAsync(int fieldClusterId);
        public Task<bool> SoftRemoveFieldClusterAsync(int fieldClusterId);
        public Task<List<FieldCluster>> GetAllFieldClusters();
    }
}
