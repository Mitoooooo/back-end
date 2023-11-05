using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FieldCluster : BaseEntity
    {
        public string FieldName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime OpeningTime {  get; set; }

        public User User { get; set; }
        public Guid AdminId { get; set; }
    }
}
