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
            var userDTO = _mapper.Map<UserDTO>(user);

            return _mapper.Map(await _repository.GetUserRolesAsync(user.Id), userDTO);
        }
    }
}
