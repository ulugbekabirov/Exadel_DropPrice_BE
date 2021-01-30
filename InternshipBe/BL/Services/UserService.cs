using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<UserDTO> GetUserInfoAsync(User user)
        {
            var userRoles = await _repository.GetUserRolesAsync(user.Id);

            var userDTO = _mapper.Map<User, UserDTO>(user);

            userDTO.Roles = userRoles.ToArray();

            return userDTO;
        }
    }
}
