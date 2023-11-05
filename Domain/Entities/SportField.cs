using System;
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

        public SportFieldType SportFieldType { get; set; }
        public Guid SportFieldTypeId { get; set; }
    }
}
