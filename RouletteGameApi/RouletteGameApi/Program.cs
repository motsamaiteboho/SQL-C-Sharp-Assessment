using RouletteGameApi.Context;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Repository;

namespace RouletteGameApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
             // Add services to the container.

             builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddSingleton(new DatabaseConfig { Name ="DatabaseName" });
            builder.Services.AddSingleton<BetsDBContext>();
            builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
            builder.Services.AddSingleton<IPlaceBetRepository, PlaceBetRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();
            app.Services.GetService<IDatabaseBootstrap>().Setup();
            app.Run();
        }
    }
}