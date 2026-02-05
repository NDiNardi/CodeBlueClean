using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using CodeBlue.Data;

namespace CodeBlue.Web.Auth;

public class AuthService
{
	private readonly AppDbContext _db;
	private readonly IHttpContextAccessor _http;

	public AuthService( AppDbContext db, IHttpContextAccessor http )
	{
		_db = db;
		_http = http;
	}

	public async Task<(bool ok, string? error)> LoginAsync( string username, string password )
	{
		var user = await _db.Users
			.AsNoTracking()
			.FirstOrDefaultAsync(u => u.Username == username && u.IsActive);

		if (user == null)
			return (false, "Invalid username or password");

		// TEMP SIMPLE CHECK — replace with hash later
		if (user.PasswordHash != password)
			return (false, "Invalid username or password");

		var claims = new List<Claim>
		{
			new(ClaimTypes.Name, user.Username),
			new(ClaimTypes.Role, user.Role)
		};

		var identity = new ClaimsIdentity(
			claims, CookieAuthenticationDefaults.AuthenticationScheme);

		var principal = new ClaimsPrincipal(identity);

		await _http.HttpContext!.SignInAsync(
	CookieAuthenticationDefaults.AuthenticationScheme,
			principal,
			new AuthenticationProperties
			{
				IsPersistent = true
			});


		return (true, null);
	}

	public async Task LogoutAsync()
	{
		await _http.HttpContext!.SignOutAsync(
			CookieAuthenticationDefaults.AuthenticationScheme);
	}
}
