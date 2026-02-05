using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Security.Claims;

namespace CodeBlue.Web.Auth;

public static class AuthEndpoints
{
	public static void MapAuthEndpoints( this WebApplication app )
	{
		app.MapPost("/auth/login", async (
			LoginRequest request,
			HttpContext http ) =>
		{
			if (request.Username != "admin" || request.Password != "password")
				return Results.Unauthorized();

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, request.Username),
				new Claim(ClaimTypes.Role, "Office")
			};

			var identity = new ClaimsIdentity(
				claims,
				CookieAuthenticationDefaults.AuthenticationScheme);

			await http.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(identity));

			return Results.Ok();
		});

		app.MapPost("/auth/logout", async ( HttpContext http ) =>
		{
			await http.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme);

			return Results.Ok();
		});
	}
}
