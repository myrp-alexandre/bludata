using api_bludata.application.webapi.Models;
using api_bludata.domain.domain.models;
using AutoMapper;

namespace api_bludata.application.webapi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<fornecedor, FornecedorViewModel>()
                .ForMember(x => x.nome_empresa, y => y.MapFrom(v => v.empresa.nome_fantasia));
            CreateMap<telefone, TelefoneViewModel>();
        }
    }
}
