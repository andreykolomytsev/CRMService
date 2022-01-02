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
    [ApiExplorerSettings(GroupName = "Группы контрагентов")]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// Получить список всех групп контрагентов
        /// </summary>
        /// <param name="filter">Параметры запроса</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<ResponseGroup>>>> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var pagedReponse = await _groupService.GetAllGroupsAsync(filter, route);

            return Ok(pagedReponse);
        }

        /// <summary>
        /// Получить группу контрагента по ID
        /// </summary>
        /// <param name="id">ID группы контрагента</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<ResponseGroup>>> GetById(int id)
        {
            var response = await _groupService.GetGroupByIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Создать новую группу контрагента
        /// </summary>
        /// <param name="model">Параметры группы контрагента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response<ResponseGroup>>> Create(RequestGroup model)
        {
            var response = await _groupService.CreateGroupAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Обновить данные группы контрагента
        /// </summary>
        /// <param name="id">ID группы</param>
        /// <param name="model">Параметры группы</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response<ResponseGroup>>> Update(int id, RequestGroup model)
        {
            var response = await _groupService.UpdateGroupAsync(id, model);
            return Ok(response);
        }

        /// <summary>
        /// Удалить группу контрагента
        /// </summary>
        /// <param name="id">ID группы</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<string>>> Delete(int id)
        {
            var response = await _groupService.DeleteGroupAsync(id);
            return Ok(response);
        }
    }
}
