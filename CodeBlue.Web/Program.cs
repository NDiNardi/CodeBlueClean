using CodeBlue.Data;
using CodeBlue.Web.Components;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("Default")));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/login";
		options.LogoutPath = "/logout";
		options.AccessDeniedPath = "/login";
		options.ExpireTimeSpan = TimeSpan.FromHours(8);
		options.SlidingExpiration = true;
	});


builder.Services.AddAuthorization();


builder.Services.AddHttpContextAccessor();



builder.Services.AddScoped(sp =>
	sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));


var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();
app.MapPost("/auth/login", async ( HttpContext http ) =>
{
	var form = await http.Request.ReadFormAsync();

	var username = form["Username"].ToString();
	var password = form["Password"].ToString();

	if (username != "admin" || password != "password")
	{
		return Results.Redirect("/login");
	}

	var claims = new List<Claim>
	{
		new Claim(ClaimTypes.Name, username)
	};

	var identity = new ClaimsIdentity(
		claims,
		CookieAuthenticationDefaults.AuthenticationScheme);

	var principal = new ClaimsPrincipal(identity);

	await http.SignInAsync(
		CookieAuthenticationDefaults.AuthenticationScheme,
		principal);

	return Results.Redirect("/office");
});
app.MapPost("/auth/logout", async ( HttpContext http ) =>
{
	await http.SignOutAsync(
		CookieAuthenticationDefaults.AuthenticationScheme);

	return Results.Redirect("/login");
});


app.Run();
