using BL.DTO;
using DAL.Entities;

namespace BL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserInfo(User user);
    }
}
