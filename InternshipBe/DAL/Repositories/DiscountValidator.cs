using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Localization;
using Shared.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountValidator : IValidator<Discount>
    {
        private readonly IStringLocalizer<NotificationResource> _stringLocalizer;

        public DiscountValidator(IStringLocalizer<NotificationResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public Task ValidateAsync(Discount entity)
        {
            var dateTimeNow = DateTime.Now;
            var startDate = entity.StartDate;
            var endDate = entity.EndDate;

            if (!entity.ActivityStatus)
            {
                throw new ValidationException(_stringLocalizer["Discount is not available"]);
            }

            if (startDate > dateTimeNow || endDate < dateTimeNow)
            {
                throw new ValidationException(_stringLocalizer["Discount available from {0} to {1}", startDate.ToShortDateString(), endDate.ToShortDateString()]);
            }

            return Task.CompletedTask;
        }
    }
}
