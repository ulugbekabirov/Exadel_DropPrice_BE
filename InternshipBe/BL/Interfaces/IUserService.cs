using BL.DTO;
using DAL.Entities;

namespace BL.Interfaces
{
    public interface IUserService
    {
        UserDTO getUserInfo(User user);
    }
}
