using BL.Interfaces;
using DAL.Interfaces;
using Hangfire;
using Shared.Infrastructure;
using System;
using System.Linq;
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

        public async Task<string> BeginEditDiscountJobAsync(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            var discountEditTime = await _configRepository.GetDiscountEditTimeAsync((int)ConfigIdentifiers.DiscountEditTimeInMinutes);

            if (job.Key is null)
            {
                await _discountRepository.ArchiveOrUnArchiveDiscountAsync(discountId, false);

                BackgroundJob.Schedule(() => _discountRepository.ArchiveOrUnArchiveDiscountAsync(discountId, true), TimeSpan.FromMinutes(discountEditTime));

                return "Создана сессия по редактированию скидки.";
            }

            BackgroundJob.Delete(job.Key);

            BackgroundJob.Schedule(() => _discountRepository.ArchiveOrUnArchiveDiscountAsync(discountId, true), TimeSpan.FromMinutes(discountEditTime));

            return $"Открыта сессия по редактированию скидки. Время обновлено.";
        }

        public async Task<string> EndEditDiscountJobAsync(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            if (job.Key is null)
            {
                return "Сессия по редактированию скидки отсутствует.";
            }

            await _discountRepository.ArchiveOrUnArchiveDiscountAsync(discountId, true);

            BackgroundJob.Delete(job.Key);

            return "Сессия по редактированию скидки завершена.";
        }

        public void DeleteDiscountEditJob(int discountId)
        {
            var job = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue)
                .FirstOrDefault(j => j.Value.Job.Args.Contains(discountId));

            BackgroundJob.Delete(job.Key);
        }
    }
}
