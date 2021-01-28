using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    interface IDiscountRepository : IRepository<Discount>
    {
        IEnumerable<Discount> GetDiscount(int skip, int take, double latitude, double longitude);

        IEnumerable<Discount> SearchDiscountsByDiscountName(int skip, int take, double latitude, double longitude, string DiscountName);

        IEnumerable<Discount> SearchDiscountsByTagName(int skip, int take, double latitude, double longitude, string TagName);
    }
}
