using Application.eTicket.MVC.Commons.Interfaces;
using Application.eTicket.MVC.Commons.Models;
using Application.eTicket.MVC.UseCases.OrderItems.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;

namespace Application.eTicket.MVC.UseCases.OrderItems.Queries;
public record GetAllOrderItemsQuery : IRequest<PaginatedList<OrderItemResponce>>
{
    public int PageNumber { get; } = 1;
    public int PageSize { get; } = 10;
    public string? SearchingText { get; }
}

public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, PaginatedList<OrderItemResponce>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllOrderItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<PaginatedList<OrderItemResponce>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        int pageNumber = request.PageNumber;
        int pageSize = request.PageSize;
        string searchingText = request.SearchingText.Trim();

        IQueryable<OrderItem> allOrderItems = _context.OrderItems.AsQueryable();

        if (!string.IsNullOrEmpty(searchingText))
            allOrderItems = allOrderItems.Where(orderItems
                => orderItems.Movie.MovieName.ToLower().Contains(searchingText.ToLower())
                || orderItems.Movie.MovieCategory.ToString().ToLower().Contains(searchingText.ToLower())
                || orderItems.Movie.MoviePrice.ToString().Contains(searchingText)
                || orderItems.Movie.MovieDescription.ToLower().Contains(searchingText.ToLower())
                || orderItems.Movie.Producer.ProducerName.ToLower().Contains(searchingText.ToLower())
                || orderItems.Price.ToString().Contains(searchingText)
                || orderItems.SeatNumber.ToString().Contains(searchingText));

        PaginatedList<OrderItem> paginatedOrderItems = await PaginatedList<OrderItem>.CreateAsync(allOrderItems, pageNumber, pageSize, cancellationToken);

        List<OrderItemResponce> paginatedOrderItemsAfterMapping = _mapper.Map<List<OrderItemResponce>>(paginatedOrderItems.Items);

        return new PaginatedList<OrderItemResponce>(paginatedOrderItemsAfterMapping, paginatedOrderItems.TotalCount, pageNumber, pageSize);
    }
}
