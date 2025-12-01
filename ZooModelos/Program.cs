using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZooModelos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddDbContext<ZooModelosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ZooModelosContext") ?? throw new InvalidOperationException("Connection string 'ZooModelosContext' not found.")));

            // Add services to the container.
            //fdgfdg  
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      // **IMPORTANTE**: CAMBIAR ESTAS URLS por las de tu front-end en Render
                                      policy.WithOrigins("http://localhost:3000", "https://tudominio.onrender.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services
               .AddControllers()
               .AddNewtonsoftJson(
                   options =>
                   options.SerializerSettings.ReferenceLoopHandling
                   = Newtonsoft.Json.ReferenceLoopHandling.Ignore
               );
            var app = builder.Build();
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ZooModelosContext>();
                    db.Database.Migrate(); // Aplica todas las migraciones pendientes
                }
            }
            catch (Exception ex)  
            {
                // Manejo de errores si la migración falla (generalmente por problemas de conexión a la DB)
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } 

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
