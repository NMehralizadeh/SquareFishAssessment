using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SquareFish.Assessment.API.Services;
using SquareFish.Assessment.Application.CQRS.Queries;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Application.Mappings;
using SquareFish.Assessment.Domain.Entities;
using SquareFish.Assessment.Infrastructure.Persistence;

namespace SquareFish.Assessment.API
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecurityKey"]))
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SquareFish.Assessment.API", Version = "v1" });
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("squarefish"));
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddScoped<ILoggedInUserContext, LoggedInUserContext>();
            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMediatR(typeof(GetAllBookingQuery).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SquareFish.Assessment.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            Seed(context);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void Seed(ApplicationDbContext context)
        {
            context.Currencies.AddRange(new List<Currency> {
                new(){
                    Id=1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 110,
                    Name= "Euro"
                },
                new(){
                    Id=2,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 110,
                    Name= "Dollar"
                },
                new(){
                    Id=3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 110,
                    Name= "IRR"
                },
            });
            context.Bookings.AddRange(new List<Booking>{
                new(){
                    Name="Booking 1",
                    CreatedAt = DateTime.Now,//DateTimeOffset.Now.AddHours(-2),
                    StartDate = DateTime.Now,//DateTimeOffset.Now.AddDays(+2),
                    Status= BookingStatus.New,
                    CreatedBy = 110,
                    price = 150,
                    CurrencyId = 1
                }
            });

            
            context.SaveChanges();
        }
    }
}
