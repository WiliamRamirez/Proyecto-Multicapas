using Application.DTOs;
using AutoMapper;
using Persistence.DapperConnection.Combos;
using Persistence.DapperConnection.Productos;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoModel,ProductoDTO>().ReverseMap();
            CreateMap<ComboModel,ComboDTO>().ReverseMap();
        }
    }
}