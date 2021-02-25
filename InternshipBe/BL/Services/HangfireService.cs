using BL.Interfaces;
using DAL.Interfaces;
using Hangfire;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class HangfireService : IHangfireService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IConfigRepository _configRepository;

        public HangfireService(IDiscountRepository discountRepository, IConfigRepository configRepository)
        {
            _discountRepository = discountRepository;
            _configRepository = configRepository;
        }

        public async Task<string> BeginDiscountEditJobAsync(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            var discountEditTime = await _configRepository.GetDiscountEditTimeAsync((int)ConfigIdentifiers.DiscountEditTimeInMinutes);

            if (job.Key is null)
            {
                await _discountRepository.ArchiveDiscountAsync(discountId);

                BackgroundJob.Schedule(() => _discountRepository.UnArchiveDiscountAsync(discountId), TimeSpan.FromMinutes(discountEditTime));

                return "Создана сессия по редактированию скидки";
            }

            var leftTime = (job.Value.EnqueueAt - DateTime.UtcNow).TotalMinutes;

            BackgroundJob.Delete(job.Key);

            BackgroundJob.Schedule(() => _discountRepository.UnArchiveDiscountAsync(discountId), TimeSpan.FromMinutes(discountEditTime + leftTime));

            return $"Открыта сессия по редактированию скидки. Добавлено {discountEditTime} минут к редактированию. Оставалось {leftTime} минут";
        }

        public async Task<string> EndDiscountEditJobAsync(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            if (job.Key is null)
            {
                return "Сессия по редактированию скидки отсутствует.";
            }

            BackgroundJob.Delete(job.Key);

            return "Сессия по редактированию скидки завершена.";
        }
    }
}
