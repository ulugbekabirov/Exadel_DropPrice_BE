using BL.DTO;
using BL.Interfaces;
using DAL.Interfaces;
using Hangfire;
using Microsoft.Extensions.Localization;
using Shared.Infrastructure;
using Shared.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class HangfireService : IHangfireService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IStringLocalizer<NotificationResource> _stringLocalizer;

        public HangfireService(IDiscountRepository discountRepository, IConfigRepository configRepository, IStringLocalizer<NotificationResource> stringLocalizer)
        {
            _discountRepository = discountRepository;
            _configRepository = configRepository;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<HangfireDTO> BeginEditDiscountJobAsync(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            var discountEditTime = await _configRepository.GetDiscountEditTimeAsync((int)ConfigIdentifiers.DiscountEditTimeInMinutes);

            if (job.Key is null)
            {
                await _discountRepository.UpdateDiscountActivityStatusAsync(discountId, false);

                BackgroundJob.Schedule(() => _discountRepository.UpdateDiscountActivityStatusAsync(discountId, true), TimeSpan.FromMinutes(discountEditTime));

                return new HangfireDTO()
                {
                    Message = _stringLocalizer["A session for editing a discount has been created."],
                    IsEditingDisount = false,
                    EditTime = discountEditTime,
                };
            }

            BackgroundJob.Delete(job.Key);

            BackgroundJob.Schedule(() => _discountRepository.UpdateDiscountActivityStatusAsync(discountId, true), TimeSpan.FromMinutes(discountEditTime));

            return new HangfireDTO()
            {
                Message = _stringLocalizer["A session on editing a discount is open. Time has been updated."],
                IsEditingDisount = true,
                EditTime = discountEditTime,
            };
        }

        public async Task<string> EndEditDiscountJobAsync(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            if (job.Key is null)
            {
                return _stringLocalizer["There is no session to edit the discount."];
            }

            await _discountRepository.UpdateDiscountActivityStatusAsync(discountId, true);

            BackgroundJob.Delete(job.Key);

            return _stringLocalizer["The session on editing the discount is over."];
        }

        public void DeleteDiscountEditJob(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            if (job.Key is null)
            {
                return;
            }

            BackgroundJob.Delete(job.Key);
        }
    }
}
