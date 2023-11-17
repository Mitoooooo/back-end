using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime? OpeningTime {  get; set; }

        public User? Admin { get; set; }
        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
    }
}
