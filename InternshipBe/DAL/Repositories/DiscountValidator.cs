using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Localization;
using Shared.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountValidator : Validator<Discount>, IDiscountValidatior
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IStringLocalizer<NotificationResource> _stringLocalizer;

        public DiscountValidator(IDiscountRepository discountRepository, IStringLocalizer<NotificationResource> stringLocalizer)
        {
            _discountRepository = discountRepository;
            _stringLocalizer = stringLocalizer;
        }

        public async Task CheckDiscountValidationAsync(int id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);

            var dateTimeNow = DateTime.Now;
            var startDate = discount.StartDate;
            var endDate = discount.EndDate;
            
            if (startDate > dateTimeNow || endDate < dateTimeNow)
            {
                throw new ValidationException(_stringLocalizer["Discount available from {0} to {1}", startDate.ToShortDateString(), endDate.ToShortDateString()]);
            }
        }
    }
}
