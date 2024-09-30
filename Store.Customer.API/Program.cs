
using Microsoft.EntityFrameworkCore;
using Store.Customer.Repository.Contexts;
using Store.Customer.Repository.Data;

namespace Store.Customer.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDBContext>(
                op=>op.UseSqlServer(builder.Configuration.GetConnectionString("conn")));



           
            var app = builder.Build();


            using var servicesscope= app.Services.CreateScope();

           var serviceprovider= servicesscope.ServiceProvider;

            var context= serviceprovider.GetRequiredService<StoreDBContext>();

            //Loger
            var logger= serviceprovider.GetRequiredService<ILoggerFactory>();
            //Aplay In DB

            try
            {
                await context.Database.MigrateAsync();
               await StoreDBContextSeed.SeedAsync(context);

            }
            catch (Exception ex)
            {
                var log = logger.CreateLogger<Program>();

                log.LogError(ex,"error in Migration");
            }



            // Configure the HTTP request pipeline.
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
}
