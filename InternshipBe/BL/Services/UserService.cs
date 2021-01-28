
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
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public UserDTO getUserInfo(User user)
        {
            var Office = _repository.GetUserOffice(user.OfficeId);

            var userRoles = _repository.GetUserRoles(user.Id);

            return new UserDTO()
            {
                Roles = userRoles.ToArray(),
                OfficeLatitude = Office.Latitude,
                OfficeLongitude = Office.Longitude,
            };
        }
    }
}
