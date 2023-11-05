using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SportFieldType : BaseEntity
    {
        public string Name { get; set; }
        public int DisplayIndex { get; set; }
        public string SportFieldTypeStatus { get; set; } = default!; // enum status ?

        public SportType SportType { get; set; }
        public Guid SportTypeId { get; set; }

        public FieldCluster FieldCluster { get; set; }
        public Guid FieldClusterId { get; set; }
    }
}
