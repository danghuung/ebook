using Microsoft.EntityFrameworkCore;
using MyEBook.Models;
using MyEBook.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectString = builder.Configuration.GetConnectionString("e-book");
builder.Services.AddDbContext<EBookDbContext>(options =>
{
    options.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
});


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IBookRepository, BookRepository>();

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
