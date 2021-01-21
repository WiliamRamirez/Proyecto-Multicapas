using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Persistence.DapperConnection.Combos;
using Persistence.DapperConnection.Compras;
using Persistence.DapperConnection.DetallesCompras;
using Persistence.DapperConnection.Productos;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoModel,ProductoDTO>().ReverseMap();
            CreateMap<ComboModel, ComboDTO>().ReverseMap();
            
            CreateMap<CompraModel,CompraDTO>().ReverseMap();
            CreateMap<DetalleCompraModel,DetalleCompraDTO>().ReverseMap();
            CreateMap<Usuario,UsuarioDTO>();
        }
    }
}