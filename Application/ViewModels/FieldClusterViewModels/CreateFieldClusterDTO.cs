using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FieldClusterViewModels
{
    public class CreateFieldClusterDTO
    {
        public string FieldName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime OpeningTime { get; set; }

        public Guid AdminId { get; set; }
    }
}
