using System;
using CRMService.Interfaces;


namespace CRMService.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
