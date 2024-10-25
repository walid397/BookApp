
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
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookReposaitory, Reposaitores>();
            builder.Services.AddAutoMapper(typeof(AutoMapperClass));


            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BookContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.Run();
        }
    }
}
