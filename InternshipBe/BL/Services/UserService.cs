using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDTO GetUserInfo(User user)
        {
            var userRoles = _repository.GetUserRoles(user.Id).ToArray();

            var userDTO = _mapper.Map<User, UserDTO>(user);

            userDTO.Roles = userRoles;

            return userDTO;
        }
    }
}
