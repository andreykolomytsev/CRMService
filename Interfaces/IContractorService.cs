using System.Collections.Generic;
using System.Threading.Tasks;
using CRMService.DTOModels.Request;
using CRMService.DTOModels.Response;
using CRMService.Helpers;
using CRMService.Wrappers;

namespace CRMService.Interfaces
{
    public interface IContractorService
    {
        Task<PagedResponse<List<ResponseContractor>>> GetAllContractorsAsync(PaginationFilter filter, string route);
        Task<Response<ResponseContractor>> GetContractorByIdAsync(int id);
        Task<Response<ResponseContractor>> CreateContractorAsync(RequestContractor model);
        Task<Response<ResponseContractor>> UpdateContractorAsync(int id, RequestContractor model);
        Task<Response<string>> DeleteContractorAsync(int id);
    }
}
