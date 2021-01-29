using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
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
            var Office = _repository.GetUserOffice(user.OfficeId);

            var userRoles = _repository.GetUserRoles(user.Id).ToArray();

            return new UserDTO()
            {
                Id = user.Id,
                Roles = userRoles,
                OfficeLatitude = Office.Latitude,
                OfficeLongitude = Office.Longitude,
            };
        }
    }
}
