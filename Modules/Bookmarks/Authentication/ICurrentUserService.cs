using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Authentication
{
    public interface ICurrentUserService
    {
        Task<CurrentUser> Retrieve();
    }
}

