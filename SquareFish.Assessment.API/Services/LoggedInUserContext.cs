using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SquareFish.Assessment.Application.Interfaces;

namespace SquareFish.Assessment.API.Services
{
    public class LoggedInUserContext : ILoggedInUserContext
    {
        public LoggedInUserContext(IHttpContextAccessor httpContextAccessor)
        {
            Name = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            IsAuthenticated = Name != null;
        }

        public int Id { get; set; }
        public string Name { get; }
        public bool IsAuthenticated { get; }
    }
}
