using ECom.Application.Contracts;
using ECom.Application.Service;
using ECom.Data.Contracts;
using ECom.Data.EComRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerOrdersRepo, CustomerOrdersRepo>();
builder.Services.AddScoped<ICustomerOrder, CustomerOrder>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

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
