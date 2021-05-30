using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryHouse.Areas.Identity.Data;
using BakeryHouse.Data;
using BakeryHouse.Data.Repository;
using BakeryHouse.Data.UnitOfWork;
using BakeryHouse.Helper;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace BakeryHouse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowAllOrigins = "_MyAllowAllOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSession();
            services.AddDbContext<BakeryHouseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BakeryHouseConnection")));
            services.AddDefaultIdentity<CustomUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BakeryHouseContext>();
           
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication().AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerGen();
            services.AddCors(c =>
           {
               c.AddPolicy(MyAllowAllOrigins, options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
           });
            services.AddRazorPages();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            CultureInfo cultureInfoDutchBelgium = new CultureInfo("nl-BE");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfoDutchBelgium;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfoDutchBelgium;

            app.UseCors(MyAllowAllOrigins);

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); //originally "./swagger/v1/swagger.json"
                });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //CreateUserRoles(serviceProvider).Wait();
        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
        //    RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    BakeryHouseContext Context = serviceProvider.GetRequiredService<BakeryHouseContext>();

        //    IdentityResult roleResult;
        //    // Adding Admin Role.
        //    bool roleCheck = await RoleManager.RoleExistsAsync("Admin");
        //    if (!roleCheck)
        //    {
        //        // create the roles and seed them to the database.
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
        //    }
        //    //Assign Admin role to the main user.
        //    IdentityUser user = Context.Users.FirstOrDefault(u => u.Email == "nieuw@hotmail.com");
        //    if (user != null)
        //    {
        //        DbSet<IdentityUserRole<string>> userRoles = Context.UserRoles;
        //        IdentityRole adminRole = Context.Roles.FirstOrDefault(r => r.Name == "Admin");
        //        if (adminRole != null)
        //        {
        //            if (!userRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == adminRole.Id))
        //            {
        //                userRoles.Add(new IdentityUserRole<string>() { UserId = user.Id, RoleId = adminRole.Id });
        //                Context.SaveChanges();
        //            }
        //        }
        //    }
        }

    }
}
