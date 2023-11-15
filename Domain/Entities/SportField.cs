﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SportField : BaseEntity
    {
        public string SportFieldName { get; set; }
        public string SportFieldStatus { get; set; } = default!; // Enum status ? nah nah nah nah fk
        public int DisplayIndex { get; set; }

        public FieldCluster FieldCluster { get; set; }
        public Guid SportFieldClusterId { get; set; }

        public SportType SportType { get; set; }
        public Guid SportTypeId { get; set; }
    }
}
