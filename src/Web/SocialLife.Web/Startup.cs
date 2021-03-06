namespace SocialLife.Web
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SocialLife.Data;
    using SocialLife.Data.Common;
    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;
    using SocialLife.Data.Repositories;
    using SocialLife.Data.Seeding;
    using SocialLife.Services.Data;
    using SocialLife.Services.Data.Attachments;
    using SocialLife.Services.Data.Gallery;
    using SocialLife.Services.Data.Pictures;
    using SocialLife.Services.Data.Post;
    using SocialLife.Services.Data.Profile;
    using SocialLife.Services.Mapping;
    using SocialLife.Services.Messaging;
    using SocialLife.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton(this.configuration);

            services.AddCors();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender("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"));
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IPostLikesService, PostLikesService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<IGalleryService, GalleryService>();

            services.AddAuthentication()
                .AddFacebook(opt =>
                {
                    opt.AppId = "717020885943162";
                    opt.AppSecret = "fc3c7ffed898301ff9910d42277cd505";
                })
                .AddGoogle(opt =>
                {
                    opt.ClientId = "792709849348-ofdmsto54r0o5n6v5j8pi60mma6ucouv.apps.googleusercontent.com";
                    opt.ClientSecret = "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";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                       // endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=UserTimeline}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
