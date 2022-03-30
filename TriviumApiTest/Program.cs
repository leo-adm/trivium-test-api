using Microsoft.EntityFrameworkCore;
using TriviumApiTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IProductsRepository, MockProductsRepository>();
builder.Services.AddScoped<IPurchasesRepository, MockPurchasesRepository>();

builder.Services.AddDbContext<TriviumTestApiDbContext>(opt =>
    opt.UseSqlite("Filename=sqlite.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
