using EnWord.Application.Services;
using EnWord.DataAccess;
using EnWord.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnWord
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WordDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(WordDbContext)));
                }
            );
            builder.Services.AddScoped<IEnWordService, EnWordService>();
            builder.Services.AddScoped<IWordRepository, WordRepository>();


            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty; // Делает UI доступным по корневому URL
            });

            app.Run();
        }
    }
}
