using Microsoft.AspNetCore.Identity;

namespace tellkoStories.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
