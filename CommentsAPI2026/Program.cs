using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using CommentsAPI2026.Models;

namespace CommentsAPI2026;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<CommentContext>(opt =>
            opt.UseInMemoryDatabase("CommentList"));
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.Title = "Comments API";
                options.Theme = ScalarTheme.BluePlanet;
                options.Layout = ScalarLayout.Modern;
                options.HideClientButton = true;
            });

        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}