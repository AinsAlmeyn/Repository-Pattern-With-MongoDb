using CrudSample.Core.IRepositories;
using CrudSample.Core.IServices;
using CrudSample.DataAccess.MongoSettings;
using CrudSample.DataAccess.Repositories;
using CrudSample.Services.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
    options.Database = builder.Configuration.GetSection("MongoConnection:Database").Value;
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IPersonRepository), typeof(PersonRepository));

builder.Services.AddScoped(typeof(IPersonService), typeof(PersonService));

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
