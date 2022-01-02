using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMService.DTOModels.Request;
using CRMService.DTOModels.Response;
using CRMService.Entities;
using CRMService.Helpers;
using CRMService.Interfaces;
using CRMService.Wrappers;

namespace CRMService.Services
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public GroupService(DataContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
        }

        #region CRUD
        public async Task<Response<ResponseGroup>> CreateGroupAsync(RequestGroup model)
        {
            // validate
            if (await _context.Groups.AnyAsync(x => x.FullName == model.FullName))
                throw new AppException($"Группа контрагентов с наименованием [{model.FullName}] уже существует");

            // map model to new query object
            var query = _mapper.Map<GroupModel>(model);

            // save
            await _context.Groups.AddAsync(query);
            await _context.SaveChangesAsync();

            return new Response<ResponseGroup>(_mapper.Map<ResponseGroup>(query), $"Группа контрагентов [{query.FullName}] добавлена");
        }

        public async Task<Response<ResponseGroup>> UpdateGroupAsync(int id, RequestGroup model)
        {
            var query = await GetQueryAsync(id);

            // validate
            if (query.FullName != model.FullName && await _context.Groups.AnyAsync(x => x.FullName == model.FullName))
                throw new AppException($"Группа контрагентов с наименованием [{model.FullName}] уже существует");

            // copy model to query and save
            _mapper.Map(model, query);

            _context.Groups.Update(query);
            await _context.SaveChangesAsync();

            return new Response<ResponseGroup>(_mapper.Map<ResponseGroup>(query), $"Группа контрагентов [{query.FullName}] обновлена");
        }

        public async Task<Response<ResponseGroup>> GetGroupByIdAsync(int id)
        {
            var query = await GetQueryAsync(id);
            return new Response<ResponseGroup>(_mapper.Map<ResponseGroup>(query));
        }

        public async Task<Response<string>> DeleteGroupAsync(int id)
        {
            var check = await _context.Contractors.AnyAsync(x => x.GroupId == id);

            if (check) throw new AppException("Нельзя удалить группу контрагентов. Имеются связанные записи");

            var query = await GetQueryAsync(id);

            _context.Groups.Remove(query);
            await _context.SaveChangesAsync();

            return new Response<string>($"Група контрагентов [{query.FullName}] удалена");
        }

        public async Task<PagedResponse<List<ResponseGroup>>> GetAllGroupsAsync(PaginationFilter filter, string route)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Groups.AsNoTracking().OrderBy(x => x.Id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            var totalRecords = await _context.Groups.AsNoTracking().CountAsync();

            return PaginationHelper.CreatePagedReponse<ResponseGroup>(_mapper.Map<List<ResponseGroup>>(pagedData), validFilter, totalRecords, _uriService, route);
        }
        #endregion

        #region Helpers
        private async Task<GroupModel> GetQueryAsync(int id)
        {
            var query = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (query == null) throw new KeyNotFoundException("Запрашенная запись не найдена: Группа контрагентов");
            return query;
        }
        #endregion
    }
}
