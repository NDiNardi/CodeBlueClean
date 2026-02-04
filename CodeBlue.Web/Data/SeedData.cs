using CodeBlue.Data;
using CodeBlue.Data.Entities;

using Microsoft.AspNetCore.Identity;

namespace CodeBlue.Web.Data;

public static class SeedData
{
	public static void Seed( AppDbContext db )
	{
		if (db.Users.Any())
			return;

		var hasher = new PasswordHasher<User>();

		var office = new User
		{
			Id = Guid.NewGuid(),
			Email = "office@codeblue.local",
			Role = "Office"
		};
		office.PasswordHash = hasher.HashPassword(office, "password");

		var tech = new User
		{
			Id = Guid.NewGuid(),
			Email = "tech@codeblue.local",
			Role = "Technician"
		};
		tech.PasswordHash = hasher.HashPassword(tech, "password");

		db.Users.AddRange(office, tech);
		db.SaveChanges();
	}
}
