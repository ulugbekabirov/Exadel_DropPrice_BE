using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IQueryable<Discount> GetClosestDiscounts(int skip, int take, double latitude, double longitude);

        IQueryable<SavedDiscount> GetSavedDiscounts(User user);
    }
}
