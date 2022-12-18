using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Data;
using TSVoteWeb.Helpers.Gene;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();

builder.Services.AddScoped<IApiServiceHelper, ApiServiceHelper>();
builder.Services.AddScoped<ICityHelper,CityHelper>();
builder.Services.AddScoped<ICommuneTownshipHelper,CommuneTownshipHelper>();
builder.Services.AddScoped<ICountryHelper,CountryHelper>();
builder.Services.AddScoped<IGenderHelper,GenderHelper>();
builder.Services.AddScoped<INeighborhoodSidewalkHelper,NeighborhoodSidewalkHelper>();
builder.Services.AddScoped<IUserHelper,UserHelper>();
builder.Services.AddScoped<IZoneHelper,ZoneHelper>();


builder.Services.AddTransient<SeedDb>();

builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews();

var app = builder.Build();

SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope scope = scopedFactory.CreateScope())
    {
        SeedDb service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();