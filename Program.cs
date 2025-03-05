using FluentValidation;
using FluentValidation.AspNetCore;
using MediatorR.Commands;
using MediatorR.Data;
using MediatorR.Handlers;
using MediatorR.Repository.Implementaion;
using MediatorR.Repository.Interface;
using MediatorR.Services.Implementation;
using MediatorR.Services.Interface;
using MediatorR.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserDbContext>(option =>
option.UseSqlServer(connectionString));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommand>());


builder.Services.AddTransient<IRegisterUserService, RegisterUserService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRequestHandler<RegisterUserCommand, Guid>, RequestUserHandeler>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
