using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SportFieldViewModels
{
    public class UpdateSportFieldDTO
    {
        public Guid SportFieldId { get; set; }
        public string SportFieldName { get; set; }
        public string SportFieldStatus { get; set; }
        public int DisplayIndex { get; set; }

        public Guid SportFieldClusterId { get; set; }

        public Guid SportTypeId { get; set; }
    }
}
