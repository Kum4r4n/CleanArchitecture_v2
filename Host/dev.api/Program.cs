using dev.Application.Common.Interfaces.IRepos;
using dev.Application.Common.Interfaces.IServices;
using dev.Application.Common.Services;
using dev.Infrastructure;
using dev.Infrastructure.Presistence;
using dev.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPresistence(builder.Configuration);


//
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IFileStorageRepository<>), typeof(FileStoreRepository<>));
builder.Services.AddScoped(typeof(ApplicationJsonDataContext<>));
builder.Services.AddScoped<IAppSettingService, AppSettingService>();

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
