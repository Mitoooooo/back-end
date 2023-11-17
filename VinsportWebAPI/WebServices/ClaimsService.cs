using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace VinsportWebAPI.WebServices
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? 0 : Int32.Parse(Id);
        }

        public int GetCurrentUserId { get; }
    }
}
