using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserDTO GetUserInfo(User user)
        {
            var userOffice = _repository.GetUserOffice(user.OfficeId);

            var userRoles = _repository.GetUserRoles(user.Id).ToArray();

            return new UserDTO()
            {
                Roles = userRoles,
                OfficeLatitude = userOffice.Latitude,
                OfficeLongitude = userOffice.Longitude,
            };
        }
    }
}
