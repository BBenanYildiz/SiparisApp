using AutoMapper;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;

namespace SiparisApp.Service.MapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Order, OrderResponseDTOs>().ReverseMap();
            CreateMap<OrderResponseDTOs, Order>().ReverseMap();

            CreateMap<Order, OrderInsertDTOs>().ReverseMap();
            CreateMap<OrderInsertDTOs, Order>().ReverseMap();

            CreateMap<OrderListDTOs, Order>().ReverseMap();
            CreateMap<Order, OrderListDTOs>().ReverseMap();

            CreateMap<OrderStatusUpdateDTOs, Order>().ReverseMap();
            CreateMap<Order, OrderStatusUpdateDTOs>().ReverseMap();
        }
    }
}
