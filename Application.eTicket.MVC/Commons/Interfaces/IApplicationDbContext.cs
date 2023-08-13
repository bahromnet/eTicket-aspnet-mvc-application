using Domain.eTicket.MVC.Entities;
using Domain.eTicket.MVC.Entities.Identity;
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
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
