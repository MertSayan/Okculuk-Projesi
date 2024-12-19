
using Application.Interfaces.EventInterface;
using Application.Interfaces.EventUserInterface;
using Application.Interfaces.RegionInterface;
using Application.Interfaces.RoleInterface;
using Application.Interfaces.UserInterface;
using Application.Interfaces.VisibleEventInterface;
using Application.Services;
using Application.Tools;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repositories.EventRepositories;
using Persistence.Repositories.EventUserRepositories;
using Persistence.Repositories.RegionRepositories;
using Persistence.Repositories.RoleRepositories;
using Persistence.Repositories.UserRepositories;
using Persistence.Repositories.VisibleEventRepositories;
using System.Text;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false; //çok tavsiye edilen biþey deðil ama þimdilik güvenliði biraz yumuþattýk.
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = JwtTokenDefaults.ValidAudience,
                    ValidIssuer = JwtTokenDefaults.ValidIssuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<OkculukContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEventRepository,EventRepository>();
            builder.Services.AddScoped<IEventUserRepository,EventUseRRepository>();
            builder.Services.AddScoped<IRoleRepository,RoleRepository>();
            builder.Services.AddScoped<IRegionRepository,RegionRepository>();
            builder.Services.AddScoped<IVisibleEventRepository,VisibleEventRepository>();

            builder.Services.AddSaveApplicationService();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.MapperProfiles.MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
