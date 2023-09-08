using Application.eTicket.MVC.UseCases.Orders.Commands;
using Application.eTicket.MVC.UseCases.Orders.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;

namespace Application.eTicket.MVC.Commons.Mappings;
internal class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<OrderResponce, Order>().ReverseMap();
        CreateMap<CreateOrderCommand, Order>().ReverseMap();
    }
}
