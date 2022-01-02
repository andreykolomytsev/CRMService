using System.Collections.Generic;
using System.Threading.Tasks;
using CRMService.DTOModels.Request;
using CRMService.DTOModels.Response;
using CRMService.Helpers;
using CRMService.Wrappers;

namespace CRMService.Interfaces
{
    public interface IGroupService
    {
        Task<PagedResponse<List<ResponseGroup>>> GetAllGroupsAsync(PaginationFilter filter, string route);
        Task<Response<ResponseGroup>> GetGroupByIdAsync(int id);
        Task<Response<ResponseGroup>> CreateGroupAsync(RequestGroup model);
        Task<Response<ResponseGroup>> UpdateGroupAsync(int id, RequestGroup model);
        Task<Response<string>> DeleteGroupAsync(int id);
    }
}
