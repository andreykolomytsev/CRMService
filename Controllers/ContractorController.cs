using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMService.Interfaces;
using CRMService.DTOModels.Response;
using CRMService.DTOModels.Request;
using CRMService.Wrappers;
using CRMService.Helpers;

namespace CRMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Контрагенты")]
    [Authorize]
    public class ContractorController : BaseController
    {
        private readonly IContractorService _contractorService;

        public ContractorController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        /// <summary>
        /// Получить список всех контрагентов
        /// </summary>
        /// <param name="filter">Параметры запроса</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<ResponseContractor>>>> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var pagedReponse = await _contractorService.GetAllContractorsAsync(filter, route);

            return Ok(pagedReponse);
        }

        /// <summary>
        /// Получить контрагента по ID
        /// </summary>
        /// <param name="id">ID контрагента</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<ResponseContractor>>> GetById(int id)
        {
            var response = await _contractorService.GetContractorByIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Создать нового контрагента
        /// </summary>
        /// <param name="model">Параметры контрагента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response<ResponseContractor>>> Create(RequestContractor model)
        {
            var response = await _contractorService.CreateContractorAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Обновить данные контрагента
        /// </summary>
        /// <param name="id">ID контрагента</param>
        /// <param name="model">Параметры контрагента</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response<ResponseContractor>>> Update(int id, RequestContractor model)
        {
            var response = await _contractorService.UpdateContractorAsync(id, model);
            return Ok(response);
        }

        /// <summary>
        /// Удалить контрагента
        /// </summary>
        /// <param name="id">ID контрагента</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<string>>> Delete(int id)
        {
            var response = await _contractorService.DeleteContractorAsync(id);
            return Ok(response);
        }
    }
}
