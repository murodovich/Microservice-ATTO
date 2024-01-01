using Microsoft.EntityFrameworkCore;
using School.Application;
using School.Application.Absreactions;
using School.Infrastructure;
using School.Infrastructure.Persistance;
class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication();


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMemoryCache();

        builder.Services.AddDbContext<ISchoolDbContext, SchoolDBContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefoultConnectionstring"));
        });
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}