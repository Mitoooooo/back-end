using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IFieldClusterRepository : IGenericRepository<FieldCluster>
    {
        public Task<List<FieldCluster>> GetAllFieldClusters();     
    }
}
