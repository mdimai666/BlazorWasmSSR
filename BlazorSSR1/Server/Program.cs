using BlazorSSR1.Server.Data;
using BlazorSSR1.Server.Models;
using BlazorSSR1.Server.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();


// Заглушка для SSR
//builder.Services.AddOidcAuthentication<>();
//builder.Services.AddApiAuthorization();
builder.Services.AddRemoteAuthentication<RemoteAuthenticationState, RemoteUserAccount, OidcProviderOptions>();
builder.Services.AddScoped<AuthenticationStateProvider, RemoteAuthenticationService>()
    .AddScoped<SignOutSessionStateManager>()
    .AddTransient<IAccessTokenProvider, AccessTokenProvider>()
    .AddTransient<Microsoft.JSInterop.IJSRuntime, JSRuntime>();
//end Заглушка для SSR


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
//app.MapFallbackToFile("index.html");
app.MapFallbackToPage("/_Host");


app.Run();
