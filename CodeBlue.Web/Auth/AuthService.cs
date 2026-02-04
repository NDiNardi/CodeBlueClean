using CodeBlue.Data;
using CodeBlue.Data.Entities;

using Microsoft.AspNetCore.Identity;

namespace CodeBlue.Web.Auth;

public class AuthService
{
	private readonly AppDbContext _db;
	private readonly PasswordHasher<User> _hasher = new();

	public AuthService( AppDbContext db )
	{
		_db = db;
	}

	public User? Validate( string email, string password )
	{
		var user = _db.Users.SingleOrDefault(u => u.Email == email);
		if (user == null)
			return null;

		var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
		return result == PasswordVerificationResult.Success ? user : null;
	}
}
