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
            var startDate = discount.StartDate;
            var endDate = discount.EndDate;
            
            if (startDate > dateTimeNow || endDate < dateTimeNow)
            {
                throw new ValidationException(_stringLocalizer["Discount available from {0} to {1}", startDate, endDate]);
            }
        }
    }
}
