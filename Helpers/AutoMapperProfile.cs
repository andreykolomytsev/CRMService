using AutoMapper;
using CRMService.DTOModels.Request;
using CRMService.DTOModels.Response;
using CRMService.Entities;

namespace CRMService.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RequestContractor, ContractorModel>();
            CreateMap<ContractorModel, ResponseContractor>();

            CreateMap<RequestPayment, PaymentModel>();
            CreateMap<PaymentModel, ResponsePayment>();

            CreateMap<RequestContact, ContactModel>();
            CreateMap<ContactModel, ResponseContact>();

            CreateMap<RequestGroup, GroupModel>();
            CreateMap<GroupModel, ResponseGroup>();
        }
    }
}
