using System;

namespace CRMService.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
