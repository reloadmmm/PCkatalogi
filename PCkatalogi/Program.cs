using Microsoft.EntityFrameworkCore;
using PCkatalogi.Data;

namespace PCkatalogi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Подключение к базе: {connectionString}");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.EnsureCreated(); 
                    SeedData.Initialize(services);    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при заполнении базы: {ex.Message}");
                }
            }

            app.Run();
        }
    }
}