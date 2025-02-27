using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.DataAccess.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyBlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=PC003BTX50\\SQLEXPRESS;Database=BlogProjectDb;integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true")));

// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
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
