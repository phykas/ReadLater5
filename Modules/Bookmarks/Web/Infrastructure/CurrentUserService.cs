using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReadLater.Bookmarks.Authentication;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Web.Infrastructure
{

    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CurrentUser> Retrieve()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return new CurrentUser(user.Id, user.UserName);
        }
    }
}
