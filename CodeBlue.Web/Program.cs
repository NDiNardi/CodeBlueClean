using CodeBlue.Data;
using CodeBlue.Web.Auth;
using CodeBlue.Web.Components;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;


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
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();
builder.Services.AddHttpClient("ServerAPI", client =>
{
	client.BaseAddress = new Uri("https://localhost:7164/");
});

builder.Services.AddScoped(sp =>
	sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));


var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();
app.MapPost("/auth/login", async (
	HttpContext http,
	AuthService auth,
	CodeBlue.Web.Auth.LoginRequest req ) =>
{
	var (ok, error) = await auth.LoginAsync(req.Username, req.Password);

	if (!ok)
		return Results.BadRequest(error);

	return Results.Ok();
});
app.Run();
