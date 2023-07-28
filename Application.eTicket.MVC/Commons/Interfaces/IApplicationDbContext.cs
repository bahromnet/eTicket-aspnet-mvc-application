using Domain.eTicket.MVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.eTicket.MVC.Commons.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Actor> Actors { get; }
    DbSet<Cinema> Cinemas { get; }
    DbSet<Movie> Movies { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Producer> Producers { get; }
    Task<int> SaveChangesAsybc(CancellationToken cancellationToken = default);
}
