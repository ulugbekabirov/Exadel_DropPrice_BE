using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TownRepository : Repository<Town>, ITownRepository
    {
        public TownRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
