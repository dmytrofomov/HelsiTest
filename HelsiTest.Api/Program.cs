using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HelsiTest.Infrastructure.DataAccess.Repositories.Implementations;
using HelsiTest.Core.Services;
using HelsiTest.Core.Services.Implementations;
using HelsiTest.Core.Repositories;
using HelsiTest.Api.Middleware;
using HelsiTest.Infrastructure.DataAccess.DatabaseContext;
using HelsiTest.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IListRepository, ListRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IListService, ListService>();

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

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
