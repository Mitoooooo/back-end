using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? ExpireTokenTime { get; set; }

        public Role Role {  get; set; }
        public int RoleId { get; set; }

        public string? GoogleUserId { get; set; }
        public string? GoogleEmail { get; set; }
        public bool? IsGoogleUser { get; set; }
        public double BookingQuota { get; set; }
    }
}
