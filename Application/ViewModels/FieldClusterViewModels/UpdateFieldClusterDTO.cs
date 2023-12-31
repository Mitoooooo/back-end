﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FieldClusterViewModels
{
    public class UpdateFieldClusterDTO
    {
        public int FieldClusterId { get; set; }
        public string FieldName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime OpeningTime { get; set; }

        public int AdminId { get; set; }
    }
}
