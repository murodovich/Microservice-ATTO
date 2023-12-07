using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Infrastructure.Persistance;

class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddInfrastructure

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

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}