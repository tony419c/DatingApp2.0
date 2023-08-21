using DatingApp2._0.Entities;

namespace DatingApp2._0.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
