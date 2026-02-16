using Microsoft.Extensions.DependencyInjection;
using Repository.Time;
using TrackingMyself.Domain.Entities;

namespace UseCases
{
    public class SingletonDomainAppService : ISingletonDomainAppService
    {
        private readonly IServiceProvider _serviceProvider;

        public SingletonDomainAppService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<TimeDomain> TimeDomainList()
        {
            using var scope = _serviceProvider.CreateScope();
            var timeRepository = scope.ServiceProvider.GetRequiredService<ITimeRepository>();
            return timeRepository.GetAllTimes();
        }
    }
}