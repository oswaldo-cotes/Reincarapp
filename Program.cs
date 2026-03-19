using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Radzen;
using Reincarapp.Components;
using Reincarapp.Data;
using Reincarapp.Models;
using Reincarapp.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(options => options.MaximumReceiveMessageSize = 10 * 1024 * 1024);
builder.Services.AddControllers();
builder.Services.AddMatBlazor();
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "ReincarappTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<Reincarapp.reincardbService>();
builder.Services.AddScoped<Reincarapp.TodoItemService>();
builder.Services.AddScoped<DatoPersonaSyncService>();
builder.Services.AddScoped<ILogAppService, LogAppService>();
builder.Services.AddScoped<Reincarapp.Services.IUserMigrationService, Reincarapp.Services.UserMigrationService>();
builder.Services.AddScoped<Reincarapp.Services.IUsuarioClienteSyncService, Reincarapp.Services.UsuarioClienteSyncService>(); // ← nueva línea
// DbContextFactory para operaciones concurrentes (reemplaza AddDbContext)
builder.Services.AddDbContextFactory<Reincarapp.Data.reincardbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("reincardbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("reincardbConnection")));
}, ServiceLifetime.Scoped);
// DbContextFactory para reincardbContext2
builder.Services.AddDbContextFactory<Reincarapp.Data.reincardbContext2>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("reincardbConnection2"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("reincardbConnection2")));
}, ServiceLifetime.Scoped);
// Registrar DbContext como scoped usando el factory
builder.Services.AddScoped<Reincarapp.Data.reincardbContext>(provider => provider.GetRequiredService<IDbContextFactory<Reincarapp.Data.reincardbContext>>().CreateDbContext());
builder.Services.AddScoped<Reincarapp.Data.reincardbContext2>(provider => provider.GetRequiredService<IDbContextFactory<Reincarapp.Data.reincardbContext2>>().CreateDbContext());
builder.Services.AddHttpClient("Reincarapp").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseCookies = false }).AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<Reincarapp.SecurityService>();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("reincardbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("reincardbConnection")));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers().AddOData(o =>
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
    var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.Password)));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.ConfirmPassword)));
    oDataBuilder.EntitySet<ApplicationRole>("ApplicationRoles");
    o.AddRouteComponents("odata/Identity", oDataBuilder.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<AuthenticationStateProvider, Reincarapp.ApplicationAuthenticationStateProvider>();
builder.Services.AddDbContext<Reincarapp.Data.reincardbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("reincardbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("reincardbConnection")));
});
var app = builder.Build();
var forwardingOptions = new ForwardedHeadersOptions()
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
};
forwardingOptions.KnownNetworks.Clear();
forwardingOptions.KnownProxies.Clear();
app.UseForwardedHeaders(forwardingOptions);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found");
app.UseHttpsRedirection();
app.MapControllers();
app.UseHeaderPropagation();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
//app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>().Database.Migrate();
app.Run();