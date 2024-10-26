using Application.Contracts;
using Application.Mapper;
using Application.Sevices;
using Context;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ????? ????? CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookReposaitory, Reposaitores>();
            builder.Services.AddAutoMapper(typeof(AutoMapperClass));

            // ????? ??????? ??? ???????.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<BookContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // ????? Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ????? ???? ??? HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // ??????? CORS
            app.UseCors("AllowAllOrigins"); // ????? ??? ????? ?????? ????? CORS

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
