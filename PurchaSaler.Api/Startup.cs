using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using PurchaSaler.Infrastructure.Repositories;
using System;
using System.Text;

namespace PurchaSaler.Api
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
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IShoppingCartsRepository, ShoppingCartsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddControllers();
            //jwt验证
            var key = Encoding.UTF8.GetBytes(Configuration["JwtSetting:secretkey"]);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //注册Cors服务
            services.AddCors(option =>
            {
                option.AddPolicy("any", buider =>
                 {
                     buider.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
 
                 });
            });


            services.AddDbContext<PurchaSalerDbContext>(option => option.UseSqlServer(
                Configuration.GetConnectionString("constr"),b=>b.MigrationsAssembly("PurchaSaler.Api")));

            services.AddSwaggerGen(option => 
            {
                option.SwaggerDoc("v1.1", new OpenApiInfo
                {
                    Title="PurchaSaler",
                    Version="v1.1"
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(option => 
            {
                option.SwaggerEndpoint("/swagger/v1.1/swagger.json", "PurchaSaler");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
