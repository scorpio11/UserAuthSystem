using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAuthSystem.Areas.Identity.Data;
using UserAuthSystem.Data;

[assembly: HostingStartup(typeof(UserAuthSystem.Areas.Identity.IdentityHostingStartup))]
namespace UserAuthSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename ="+ Startup._contentRootPath+"\\APP_DATA\\data.mdf; Integrated Security = True; Connect Timeout = 30"));


                //context.Configuration.GetConnectionString("AuthDbContextConnection")

            services.AddDefaultIdentity<ApplicationUser>(
                options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}