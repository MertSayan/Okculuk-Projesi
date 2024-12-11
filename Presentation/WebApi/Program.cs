
using Application.Interfaces.EventInterface;
using Application.Interfaces.EventUserInterface;
using Application.Interfaces.RoleInterface;
using Application.Interfaces.UserInterface;
using Application.Services;
using AutoMapper;
using Persistence.Context;
using Persistence.Repositories.EventRepositories;
using Persistence.Repositories.EventUserRepositories;
using Persistence.Repositories.RoleRepositories;
using Persistence.Repositories.UserRepositories;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<OkculukContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEventRepository,EventRepository>();
            builder.Services.AddScoped<IEventUserRepository,EventUseRRepository>();
            builder.Services.AddScoped<IRoleRepository,RoleRepository>();

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
