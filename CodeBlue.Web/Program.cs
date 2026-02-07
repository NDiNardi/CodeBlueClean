using CodeBlue.Data;
using CodeBlue.Web.Components;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("ENV=" + builder.Environment.EnvironmentName);

// Be tolerant: you used both names during the project
var cs =
	builder.Configuration.GetConnectionString("DefaultConnection")
	?? builder.Configuration.GetConnectionString("DefaultConnectionString")
	?? builder.Configuration.GetConnectionString("Default")
	?? throw new InvalidOperationException("Missing connection string. Add ConnectionStrings:DefaultConnection to appsettings.json.");

Console.WriteLine("DbConnection=" + cs);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddMudServices();

//
// ✅ EF Core (Correct for InteractiveServer / Blazor Web App)
// Use ONE pooled factory, then create scoped contexts from it.
//
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
	options.UseSqlServer(cs));

// Optional but very useful: allows @inject AppDbContext (scoped) anywhere
builder.Services.AddScoped<AppDbContext>(sp =>
	sp.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());

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

// If you truly need a named HttpClient, you should also register it.
// Keeping your existing line, but adding the factory registration so it can resolve cleanly.
builder.Services.AddHttpClient("ServerAPI");

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
		return Results.Redirect("/login");

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
	await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
	return Results.Redirect("/login");
});

app.Run();
