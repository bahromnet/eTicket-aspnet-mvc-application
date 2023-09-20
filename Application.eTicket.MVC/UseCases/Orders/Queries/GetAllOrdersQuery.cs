using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.Commons.Models;
using Application.eTicket.MVC.UseCases.Orders.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.Orders.Queries;
public record GetAllOrdersQuery : IRequest<PaginatedList<OrderResponce>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchingText { get; set; }
}

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PaginatedList<OrderResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OrderResponce>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;
        string searchingText = request.SearchingText.Trim();

        IQueryable<Order> allOrders = _context.Orders.AsQueryable();

        if (!string.IsNullOrEmpty(searchingText))
            allOrders = allOrders.Where(order 
                => order.OrderDate.ToString().Contains(searchingText) ||
                   order.OrderItems.Any(orderItem 
                        => orderItem.SeatNumber.ToString().Contains(searchingText) ||
                           orderItem.ScreeningTime.ToString().Contains(searchingText) ||
                           orderItem.Price.ToString().Contains(searchingText) ||
                           orderItem.Movie.MovieName.ToLower().Contains(searchingText.ToLower()) ||
                           orderItem.Movie.Actors.Any(actor 
                                => actor.ActorName.ToLower().Contains(searchingText.ToLower()))));

        PaginatedList<Order> paginatedOrders = await PaginatedList<Order>.CreateAsync(allOrders, pageNumber, pageSize, cancellationToken);
        List<OrderResponce> afterMappingOrders = _mapper.Map<List<OrderResponce>>(paginatedOrders);
        return new PaginatedList<OrderResponce>(afterMappingOrders, paginatedOrders.TotalCount, pageNumber, pageSize);
    }
}
