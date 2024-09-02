using AutoMapper;
using Fornecedores.Data.Dtos;
using Fornecedores.Models;

namespace Fornecedores.Profiles;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<CreateFornecedorDto, Fornecedor>();
        CreateMap<UpdateFornecedorDto, Fornecedor>();
        CreateMap<Fornecedor, ReadFornecedorDto>();
    }
}
