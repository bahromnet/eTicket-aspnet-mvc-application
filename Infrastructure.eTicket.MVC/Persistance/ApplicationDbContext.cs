using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using Domain.eTicket.MVC.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.eTicket.MVC.Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Actor> Actors { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Producer> Producers { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Permission> Permissions { get; set; }
}
