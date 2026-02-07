using CodeBlue.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeBlue.Web;

public sealed class AppDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	public AppDbContext CreateDbContext( string[] args )
	{
		var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

		// hardcode localdb for design-time only (EF CLI)
		optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CodeBlue;Trusted_Connection=True;MultipleActiveResultSets=true");

		return new AppDbContext(optionsBuilder.Options);
	}
}
