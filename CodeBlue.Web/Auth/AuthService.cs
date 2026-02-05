namespace CodeBlue.Web.Auth;

using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AuthService
{
	private readonly IHttpContextAccessor _http;

	public AuthService( IHttpContextAccessor http )
	{
		_http = http;
	}

	public async Task<(bool ok, string? error)> LoginAsync( string username, string password )
	{
		// TODO: replace with DB check
		if (username != "admin" || password != "password")
			return (false, "Invalid username or password");

		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, username),
			new Claim(ClaimTypes.Role, "Admin")
		};

		var identity = new ClaimsIdentity(
			claims,
			CookieAuthenticationDefaults.AuthenticationScheme);

		var principal = new ClaimsPrincipal(identity);

		await _http.HttpContext!.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			principal);

		return (true, null);
	}

	public async Task LogoutAsync()
	{
		await _http.HttpContext!.SignOutAsync(
			CookieAuthenticationDefaults.AuthenticationScheme);
	}
}
