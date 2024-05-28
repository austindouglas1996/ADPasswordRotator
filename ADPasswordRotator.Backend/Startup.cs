using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Backend.Settings;
using ADPasswordRotator.Backend;
using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.Options;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ADContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                   .UseLazyLoadingProxies());

        services.AddDefaultIdentity<Admin>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ADContext>()
                .AddDefaultUI();

        // Add logging services
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
        });

        // Register repositories with the interface
        services.AddScoped<ADWorker>();
        services.AddScoped<LocationRepository>();
        services.AddScoped<DomainControllerRepository>();
        services.AddScoped<ServiceAccountRepository>();
        services.AddScoped<SettingsOptionRepository>();
        services.AddScoped<NotificationRepository>();
        services.AddScoped<AdminRepository>();

        // Register other services
        services.AddScoped<LocationService>();
        services.AddScoped<DomainControllerService>();
        services.AddScoped<ServiceAccountService>();
        services.AddScoped<SettingsOptionService>();
        services.AddScoped<MailSettings>();
        services.AddScoped<PasswordSettings>();
        services.AddScoped<NotificationService>();
        services.AddScoped<UpdateService>();
        services.AddScoped<UserManager<Admin>>();
        services.AddScoped<AdminService>();
    }
}
