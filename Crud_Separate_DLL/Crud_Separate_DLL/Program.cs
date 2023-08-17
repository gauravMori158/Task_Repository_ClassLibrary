using AutoMapperLayer;
using BusinessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using MigrationLayer.Database;
using RepositoryLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
builder.Services.AddAutoMapper(x=>x.AddProfile<Mapper>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IBankAccountRepo, BankAccountRepo>();
builder.Services.AddScoped<IBankTransactionRepo, BankTransactionRepo>();
builder.Services.AddScoped<IPaymentMethodRepo, PaymentMethodRepo>();
builder.Services.AddScoped<ITransactionTypeRepo, TransactionTypeRepo>();
builder.Services.AddScoped<ApplicationDbContext>();

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
