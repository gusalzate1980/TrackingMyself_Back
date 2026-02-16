using System;
using System.Collections.Generic;
using System.Text;
using TrackingMyself.Domain.Entities;

namespace UseCases
{
    public interface ISingletonDomainAppService
    {
        List<TimeDomain> TimeDomainList();
    }
}
