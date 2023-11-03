using CarApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Context;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {}

    public DbSet<Car> Cars { get; set; } = null!;
}
