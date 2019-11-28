using System.Text;
using HamgoonAPI.DataContext;
using HamgoonAPI.Services;
using HamgoonAPI.Services.Users;
using HamgoonAPIV1.Services.RocketChat;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HamgoonAPIV1.Services
{
    public static class Bootstrap
    {
        public static IServiceCollection ConfigureHamgoon(this IServiceCollection services, IConfiguration Configuration)
        {
            services.ConfigureDatabase(Configuration);
            services.ConfigureStatelessObjects();
            services.ConfigureAuthentication(Configuration);
            return services;
        }
        private static IServiceCollection ConfigureStatelessObjects(this IServiceCollection services)
        {
            services.AddTransient<IUserRegisterService, UserRegisterService>();
            services.AddTransient<IUserLoginService, UserLoginService>();
            services.AddTransient<IPasswordHasher<HamgoonAPI.Models.User>, HashService>();
            services.AddTransient<IRocketChatService, RocketChatService>();
            services.AddHttpClient();
            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            return services.AddDbContext<HamgooonMySQLContext>(
                opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
        }

        private static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes("HANSZIMMER-TINAGAO");
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
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
            return services;
        }
        
    }
    
}