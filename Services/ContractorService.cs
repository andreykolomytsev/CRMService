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
    public class ContractorService : IContractorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ContractorService(DataContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
        }

        #region CRUD
        public async Task<Response<ResponseContractor>> CreateContractorAsync(RequestContractor model)
        {
            //validate
            if (!ContractorType.CheckType(model.Type))
                throw new AppException("Указан некорректный тип контрагента");

            // validate
            if (model.Payments != null && model.Payments.GroupBy(x => x.IsDefault).Any(g => g.Count() > 1))
                throw new AppException($"Основной счет может быть только один");

            // validate
            if (model.Contacts != null && model.Contacts.GroupBy(x => x.IsDefault).Any(g => g.Count() > 1))
                throw new AppException($"Контакт по умолчанию может быть только один");

            // validate
            if (await _context.Contractors.AnyAsync(x => x.FullName == model.FullName))
                throw new AppException($"Контрагент с наименованием [{model.FullName}] уже существует");

            // validate         
            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == model.GroupId);

            if (group == null)
                throw new KeyNotFoundException($"Группа контрагентов с ID [{model.GroupId}] не найдена");

            if (model.Type == ContractorType.Type.IndividualPerson)
            {
                model.OGRN = string.Empty;
                model.KPP = string.Empty;
                model.OKPO = string.Empty;
                model.CertificateDate = null;
                model.CertificateNumber = string.Empty;
            }
            else if (model.Type == ContractorType.Type.LegalPerson)
            {
                model.CertificateDate = null;
                model.CertificateNumber = string.Empty;
            }
            else
            {
                model.KPP = string.Empty;
            }

            // map model to new query object
            var query = _mapper.Map<ContractorModel>(model);
            query.Group = group;

            await _context.Contractors.AddAsync(query);
            await _context.SaveChangesAsync();

            return new Response<ResponseContractor>(_mapper.Map<ResponseContractor>(query), $"Контрегент [{query.FullName}] добавлен");
        }

        public async Task<Response<ResponseContractor>> UpdateContractorAsync(int id, RequestContractor model)
        {
            //validate
            if (!ContractorType.CheckType(model.Type))
                throw new AppException("Указан некорректный тип контрагента");

            // validate
            if (model.Payments != null && model.Payments.GroupBy(x => x.IsDefault).Any(g => g.Count() > 1))
                throw new AppException($"Основной счет может быть только один");

            // validate
            if (model.Contacts != null && model.Contacts.GroupBy(x => x.IsDefault).Any(g => g.Count() > 1))
                throw new AppException($"Контакт по умолчанию может быть только один");

            var query = await GetQueryAsync(id);

            // validate
            if (model.FullName != query.FullName && await _context.Contractors.AnyAsync(x => x.FullName == model.FullName))
                throw new AppException($"Контрагент с наименованием [{model.FullName}] уже существует");

            // validate
            if (model.GroupId != query.GroupId)
            {
                var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == model.GroupId);

                if (group == null)
                    throw new KeyNotFoundException($"Группа контрагентов с ID [{model.GroupId}] не найдена");
            }

            if (model.Type == ContractorType.Type.IndividualPerson)
            {
                model.OGRN = string.Empty;
                model.KPP = string.Empty;
                model.OKPO = string.Empty;
                model.CertificateDate = null;
                model.CertificateNumber = string.Empty;
            }
            else if (model.Type == ContractorType.Type.LegalPerson)
            {
                model.CertificateDate = null;
                model.CertificateNumber = string.Empty;
            }
            else
            {
                model.KPP = string.Empty;
            }

            // copy model to query and save
            _mapper.Map(model, query);

            _context.Contractors.Update(query);
            await _context.SaveChangesAsync();

            return new Response<ResponseContractor>(_mapper.Map<ResponseContractor>(query), $"Контрегент [{query.FullName}] обновлен");
        }

        public async Task<Response<ResponseContractor>> GetContractorByIdAsync(int id)
        {
            var query = await GetQueryAsync(id);
            return new Response<ResponseContractor>(_mapper.Map<ResponseContractor>(query));
        }

        public async Task<Response<string>> DeleteContractorAsync(int id)
        {
            //На доработке
            throw new AppException("Удаление контрагентов временно недоступно");
        }

        public async Task<PagedResponse<List<ResponseContractor>>> GetAllContractorsAsync(PaginationFilter filter, string route)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Contractors.AsNoTracking()
                .Include(x => x.Group)
                .Include(x => x.Contacts)
                .Include(x => x.Payments)
                .OrderBy(x => x.Id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).AsSplitQuery().ToListAsync();
            var totalRecords = await _context.Contractors.AsNoTracking().CountAsync();

            return PaginationHelper.CreatePagedReponse<ResponseContractor>(_mapper.Map<List<ResponseContractor>>(pagedData), validFilter, totalRecords, _uriService, route);
        }
        #endregion

        #region Helpers
        private async Task<ContractorModel> GetQueryAsync(int id)
        {
            var query = await _context.Contractors.Include(x => x.Group).Include(x => x.Contacts).Include(x => x.Payments).FirstOrDefaultAsync(x => x.Id == id);
            if (query == null) throw new KeyNotFoundException("Запрошенная запись не найдена: Контрагент");
            return query;
        }
        #endregion
    }
}
