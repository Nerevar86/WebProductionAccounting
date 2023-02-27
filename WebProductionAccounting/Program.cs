using Microsoft.EntityFrameworkCore;
using WebProductionAccounting;
using WebProductionAccounting.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services Localization
builder.Services.AddControllersWithViews()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();

// Get connection with pssql db
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Reg DbConext pssql
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(connection)
.UseSnakeCaseNamingConvention()
.EnableSensitiveDataLogging(true));

// Add Npgsql.EnableLegacyTimestampBehavior and Npgsql.DisableDateTimeInfinityConversions in DbContext
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

// Reg Services
builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
