using GlobalNotificationSystem.API.Default.Endpoints;
using Microsoft.Extensions.Options;

namespace GlobalNotificationSystem.API.Default
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddControllers();
            builder.Services.AddNotificationServices();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                    });
            });


            var app = builder.Build();

            //app.UseAuthorization();
            app.MapNotificationEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            //app.MapControllers();

            app.Run();
        }
    }
}