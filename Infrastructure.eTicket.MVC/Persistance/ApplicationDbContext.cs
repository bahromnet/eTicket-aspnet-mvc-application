using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.eTicket.MVC.Persistance;

public class ApplicationDbContext : IApplicationDbContext
{
    public DbSet<Actor> Actors { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Producer> Producers { get; set; }
}
