using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IUserRepository : IRepository<User>
    {
        Office GetUserOffice(int officeId);

    }
}
