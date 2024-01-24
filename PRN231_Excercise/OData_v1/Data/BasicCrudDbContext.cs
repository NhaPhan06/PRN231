using Microsoft.EntityFrameworkCore;
using OData_v1.Models;

namespace OData_v1.Data;

public class BasicCrudDbContext : DbContext
{
    public BasicCrudDbContext(DbContextOptions<BasicCrudDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}