using IdentityManagementPoc.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityManagementPoc.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");
        

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("GameStore");
        
        builder.Services.AddDbContext<GameStoreContext>(options => options.UseNpgsql(connectionString));
        // builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlServer(connectionString));
        
        builder.Services.AddIdentityApiEndpoints<GameStoreUser>()
            .AddEntityFrameworkStores<GameStoreContext>();

        builder.Services.AddHealthChecks();

        var app = builder.Build();

        try
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GameStoreContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            logger.LogInformation("Migrations applied succesfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
        }

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapHealthChecks("/healthz");

        app.MapGroup("/identity")
            .MapIdentityApi<GameStoreUser>();

        app.MapControllers();

        app.Run();
    }
}
