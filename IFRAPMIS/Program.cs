using BAL.IRepository.BeneficiaryVerification;
using BAL.IRepository.MasterSetup;
using BAL.IRepository.SocialMobilization;
using BAL.Services.BeneficiaryVerification;
using BAL.IRepository.Damage;
using BAL.Services.Damage;
using BAL.Services.MasterSetup;
using BAL.Services.SocialMobilization;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PermissionPro.Permission;
using DotNetEnv;

namespace IFRAPMIS
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load environment variables from .env file
            Env.Load();

            // Add environment variables to configuration
            builder.Configuration.AddEnvironmentVariables();

            builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var envConnectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING")?.Trim(); ;
            if (!string.IsNullOrEmpty(envConnectionString))
            {
                builder.Configuration["ConnectionStrings:DefaultConnection"] = envConnectionString;
            }

            // For debugging, print out the resolved connection string
            var resolvedConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Resolved Connection String: {resolvedConnectionString}");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(resolvedConnectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddTransient<IVillage, VillageService>();
            builder.Services.AddTransient<IDistrict, DistrictService>();
            builder.Services.AddTransient<IDivision, DivisionService>();
            builder.Services.AddTransient<IProvience, ProvienceService>();
            builder.Services.AddTransient<ITehsil, TehsilService>();
            builder.Services.AddTransient<IUnionCouncil, UnionCouncilService>();
            builder.Services.AddTransient<ITrainingHead, TrainingHeadService>();

            builder.Services.AddTransient<IBeneficiaryIP, BeneficiaryIPService>();
            builder.Services.AddTransient<IBeneficiaryPDMA, BeneficiaryPDMAService>();
            builder.Services.AddTransient<ICICIG, CICIGService>();

            builder.Services.AddTransient<IDamageAssessmentLivestock, DamageAssessmentLivestockService>();
            builder.Services.AddTransient<IDamageAssessmentHTS, DamageAssessmentHTSService>();
            builder.Services.AddTransient<IDamageIP, DamageIPService>();

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64; // Increase depth if needed
            });


            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("app");
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await PermissionPro.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await PermissionPro.Seeds.DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
                    await PermissionPro.Seeds.DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
                    logger.LogInformation("Finished Seeding Default Data");
                    logger.LogInformation("Application Starting");
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "An error occurred seeding the DB");
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
        }
    }
}
