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
    public class DiscountValidator : Repository<Discount>, IDiscountValidation
    {
        private readonly IStringLocalizer<NotificationResource> _stringLocalizer;

        public DiscountValidator(ApplicationDbContext context, IStringLocalizer<NotificationResource> stringLocalizer) : base(context)
        {
            _stringLocalizer = stringLocalizer;
        }

        public async Task CheckDiscountStartDateAsync(int id)
        {
            var discount = await GetByIdAsync(id);

            var dateTimeNow = DateTime.Now;

            if (discount.StartDate > dateTimeNow || discount.EndDate < dateTimeNow)
            {
                throw new ValidationException($"{_stringLocalizer[$"Discount will only become available at"]} {discount.StartDate}");
            }
        }
    }
}
