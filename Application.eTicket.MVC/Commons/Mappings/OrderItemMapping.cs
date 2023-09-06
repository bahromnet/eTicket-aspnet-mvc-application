using Application.eTicket.MVC.UseCases.OrderItems.Commands;
using Application.eTicket.MVC.UseCases.OrderItems.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;

namespace Application.eTicket.MVC.Commons.Mappings;
public class OrderItemMapping : Profile
{
    public OrderItemMapping()
    {
        CreateMap<OrderItemResponce, OrderItem>().ReverseMap();
        CreateMap<CreateOrderItemCommand, OrderItem>().ReverseMap();
    }
}
