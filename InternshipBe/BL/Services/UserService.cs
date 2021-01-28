
using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserService : Profile, IUserService
    {
        private readonly Repository<User> _repository;

        public UserService(Repository<User> repository)
        {
            _repository = repository;
        }

        public UserDTO getUserInfo(User user)
        {
            CreateMap<User, UserDTO>();

            throw new NotImplementedException();
        }
    }
}
