using Domain.Common;
using IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;

namespace WebApi.Extensions
{
    public static class ExtensionServices
    {
        public static void DependencyInjections(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            builder.JwtConfiguration();

            builder.Services.AddDependecies();
        }

        public static void JwtConfiguration(this WebApplicationBuilder builder)
        {
            #region configure strongly typed settings objects
            var appSettingsSection = builder.Configuration.GetSection("AppSetting");
            builder.Services.Configure<AppSetting>(appSettingsSection);
            #endregion

            #region Configure jwt authentication inteprete el token 
            var appSettings = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey!);

            builder.Services.AddAuthentication(x =>
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
            #endregion

            builder.Services.AddAuthorization();
        }
    }
}
