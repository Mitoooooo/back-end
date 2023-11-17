using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public int? CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public int? ModificationBy { get; set; }
    }
}
