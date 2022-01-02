using System;
using CRMService.Helpers;

namespace CRMService.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
