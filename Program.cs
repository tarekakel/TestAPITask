using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Presentation;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://example.com",
                          //                    "http://www.contoso.com");
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});
builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly); ;
builder.Services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr"),
      b => b.MigrationsAssembly(typeof(RepositoryDbContext).Assembly.FullName)
    ));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
