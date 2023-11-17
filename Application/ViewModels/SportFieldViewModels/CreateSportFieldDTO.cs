using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SportFieldViewModels
{
    public class CreateSportFieldDTO
    {
        public string SportFieldName { get; set; }
        public string SportFieldStatus { get; set; }
        public int DisplayIndex { get; set; }

        public int SportFieldClusterId { get; set; }

        public int SportTypeId { get; set; }
    }
}
