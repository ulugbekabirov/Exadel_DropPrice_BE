using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    interface IUserService
    {
        UserDTO getUserInfo(User user);
    }
}
