using CodeBlue.Data;
using CodeBlue.Data.Entities;

namespace CodeBlue.Web.Data;

public static class SeedData
{
	public static void Seed( AppDbContext db )
	{
		if (db.Users.Any())
			return;

		db.Users.AddRange(
			new User
			{
				Username = "office",
				PasswordHash = "password", // TEMP
				Role = "Office",
				IsActive = true
			},
			new User
			{
				Username = "tech",
				PasswordHash = "password", // TEMP
				Role = "Technician",
				IsActive = true
			}
		);

		db.SaveChanges();
	}
}
