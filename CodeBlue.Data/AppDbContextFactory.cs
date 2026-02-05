using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeBlue.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	public AppDbContext CreateDbContext( string[] args )
	{
		var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

		optionsBuilder.UseSqlServer(
			"Server=(localdb)\\MSSQLLocalDB;Database=CodeBlue;Trusted_Connection=True;");

		return new AppDbContext(optionsBuilder.Options);
	}
}
