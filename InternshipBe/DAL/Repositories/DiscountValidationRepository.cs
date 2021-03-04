using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Localization;
using Shared.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountValidationRepository : Repository<Discount>, IDiscountValidationRepository
    {
        private readonly IStringLocalizer<NotificationResource> _stringLocalizer;

        public DiscountValidationRepository(ApplicationDbContext context, IStringLocalizer<NotificationResource> stringLocalizer) : base(context)
        {
            _stringLocalizer = stringLocalizer;
        }

        public async Task CheckDiscountStartDateAsync(int id)
        {
            var discount = await GetByIdAsync(id);

            if (discount.StartDate > DateTime.Now)
            {
                throw new ValidationException(_stringLocalizer["Discount is not started yet"]);
            }
        }
    }
}
