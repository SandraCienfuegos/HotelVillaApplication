using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Hubs;
using API.Infrastructure;
using API.Persistence.Contexts;
using API.Persistence.Repositories;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new DateTimeConverter()); })
                .AddNewtonsoftJson(x =>
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IExtraRepository, ExtraRepository>();
            services.AddScoped<IFormulaRepository, FormulaRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IVillaMediaRepository, VillaMediaRepository>();
            services.AddScoped<IVillaRepository, VillaRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IExtraService, ExtraService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IVillaService, VillaService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(@"server=.;database=HotelDatabase;trusted_connection=true;");
                /* .UseSqlServer(
                    @"Server=tcp:hotel-project.database.windows.net,1433;" +
                    "Initial Catalog=HotelDatabase;Persist Security Info=False;Customer ID=login;" +
                    "Password=p@r@Project1#;MultipleActiveResultSets=False;Encrypt=True;" +
                    "TrustServerCertificate=False;Connection Timeout=30;");
                */
            });

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var customerService =
                                context.HttpContext.RequestServices.GetRequiredService<ICustomerService>();
                            var customerId = int.Parse(context.Principal.Identity.Name);
                            var customer = customerService.FindByIdAsync(customerId);
                            if (customer == null)
                                context.Fail("Unauthorized");

                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(JWTProvider.SecretKeyBytes),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VillaHotel.API",
                    Version = "v0.9",
                    Description = "VillaHotel.API",
                    Contact = new OpenApiContact
                    {
                        Name = "Sandra Cienfuegos",
                        Email = "sandra.cienfuegos@helb-prigogine.be;",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache license 2.0",
                        Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0"),
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("ar"),
                new CultureInfo("en"),
                new CultureInfo("es"),
                new CultureInfo("fr"),
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en" /* "en-US" */),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            app.UseRequestLocalization(localizationOptions);
            localizationOptions.RequestCultureProviders.Insert(0, new UrlRequestCultureProvider());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "VillaHotel.API"); });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Media", "Icons")),
                RequestPath = "/media/icons"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Media", "Pictures")),
                RequestPath = "/media/pictures"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ReservationHub>("/reservations_hub");
                endpoints.MapControllers();
            });
        }
    }
}