using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IDiscountRepository : IRepository<Discount>
    {
        IEnumerable<Discount> GetDiscount(int skip, int take, double latitude, double longitude);

        IEnumerable<Discount> SearchDiscountsByDiscountName(int skip, int take, double latitude, double longitude, string DiscountName);

        IEnumerable<Discount> SearchDiscountsByTagName(int skip, int take, double latitude, double longitude, string TagName);
    }
}
