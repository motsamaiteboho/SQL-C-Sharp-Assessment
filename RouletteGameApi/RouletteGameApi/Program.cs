using RouletteGameApi.Context;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Extensions;
using RouletteGameApi.Repository;

namespace RouletteGameApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
             builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
             builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<BetsDBContext>();
            builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

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

            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            app.ConfiqureExceptionHandler(logger);

            app.Services.GetService<IDatabaseBootstrap>().Setup();
            app.Run();
        }
    }
}