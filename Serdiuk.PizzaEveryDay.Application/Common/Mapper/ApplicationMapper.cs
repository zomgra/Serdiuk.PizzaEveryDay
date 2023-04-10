using AutoMapper;
using Serdiuk.PizzaEveryDay.Application.Orders;
using Serdiuk.PizzaEveryDay.Domain;

namespace Serdiuk.PizzaEveryDay.Application.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(o => o.Status, d => d.MapFrom(d => d.Status))
                .ForMember(o => o.FinalCost, d => d.MapFrom(d => d.FinalCost))
                .ForMember(o => o.Products, d => d.MapFrom(d => d.Products))
                .ForMember(o => o.OrderId, d => d.MapFrom(d => d.OrderId))
                .ForMember(o => o.TotalCost, d => d.MapFrom(d=>d.TotalCost))
                .ForMember(o => o.StreetToDelivery, d => d.MapFrom(d => d.StreetToDelivery))
                .ForMember(o => o.Promocode, d => d.MapFrom(d => d.Promocode));
        }
    }
}
