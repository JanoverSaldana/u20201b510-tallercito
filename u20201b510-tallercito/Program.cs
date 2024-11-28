using Microsoft.EntityFrameworkCore;
using u20201b510_tallercito.SCM.Application.ACL;
using u20201b510_tallercito.SCM.Application.Internal.CommandServices;
using u20201b510_tallercito.SCM.Application.Internal.QueryServices;
using u20201b510_tallercito.SCM.Domain.Repositories;
using u20201b510_tallercito.SCM.Domain.Services;
using u20201b510_tallercito.SCM.Infrastructure.Persistence.EFC.Repositories;
using u20201b510_tallercito.SCM.Interfaces.ACL;
using u20201b510_tallercito.SD.Application.Internal.CommandServices;
using u20201b510_tallercito.SD.Application.Internal.QueryServices;
using u20201b510_tallercito.SD.Domain.Repositories;
using u20201b510_tallercito.SD.Domain.Services;
using u20201b510_tallercito.SD.Infrastructure.Persistence.EFC.Repositories;
using u20201b510_tallercito.Shared.Domain.Repositories;
using u20201b510_tallercito.Shared.Infrastructure.Interfaces.ASP.Configuration;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Configuration;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string not found.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {

        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWOrk, UnitOfWork>();

// Inventory Item Bounded Context
builder.Services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
builder.Services.AddScoped<IInventoryItemQueryService, InventoryItemQueryService>();
builder.Services.AddScoped<IInventoryItemCommandService, InventoryItemCommandService>();

// OrderItem Bounded Context
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemQueryService, OrderItemQueryService>();
builder.Services.AddScoped<IOrderItemCommandService, OrderItemCommandService>();

builder.Services.AddScoped<IInventoryItemContextFacade, InventoryItemContextFacade>();



var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

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