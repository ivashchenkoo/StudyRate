using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Service;
using StudyRate.Domain.Repositories.Abstract;
using StudyRate.Domain.Repositories.EntityFramework;
using StudyRate.Domain;
using Microsoft.EntityFrameworkCore;

namespace StudyRate
{    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // binding config with appsettings
            Configuration.Bind("Project", new Config());

            // connecting necessary app functions as services
            services.AddTransient<IFacultyRepository, EFFacultyRepository>();
            services.AddTransient<IDepartmentRepository, EFDepartmentRepository>();
            services.AddTransient<IProfessorRepository, EFProfessorRepository>();
            services.AddTransient<ISpecialtyRepository, EFSpecialtyRepository>();
            services.AddTransient<IGroupRepository, EFGroupRepository>();
            services.AddTransient<IStudentRepository, EFStudentRepository>();
            services.AddTransient<ISubjectRepository, EFSubjectRepository>();
            services.AddTransient<IAcademicPlanRepository, EFAcademicPlanRepository>();
            services.AddTransient<IControlTypeRepository, EFControlTypeRepository>();
            services.AddTransient<IMarkRepository, EFMarkRepository>();
            services.AddTransient<IPositionRepository, EFPositionRepository>();
            services.AddTransient<DataManager>();

            // connecting DBContext
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(Config.ConnectionString));

            // setting up cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "studyRateAuth";
                options.Cookie.HttpOnly = true;
                options.SlidingExpiration = true;
            });

            // adding controllers and views (MVC) support
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // detailed information about exceptions and errors in development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            // adding  static files (css, js etc.) support
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // registering the necessary routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                   name: "adminlogin",
                   pattern: "{controller=Admin}/{action=Login}/{id?}");
            });
        }
    }
}
