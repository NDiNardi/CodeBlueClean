using Microsoft.EntityFrameworkCore;
using CodeBlue.Data.Entities;

namespace CodeBlue.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions<AppDbContext> options )
		: base(options)
	{
	}

	public DbSet<User> Users => Set<User>();
	public DbSet<Customer> Customers => Set<Customer>();
}
