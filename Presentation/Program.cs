using Application;
using Infrastructure.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => {
                          policy
                          .WithOrigins("http://host.docker.internal:5173")
                          .WithOrigins("http://localhost:5173")
                          //.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

//Agrego HTTP
builder.Services.AddHttpClient();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AddTransient: instancia cada vez que se solicita
//AddScoped: instancia por request
//AddSingleton: una sola instancia para toda la aplicación
builder.Services.AddScoped<IServicePublicApi, ServicePublicApi>();
builder.Services.AddScoped<IPublicApiClient, PublicApiClient>();

builder.Services.AddScoped<IServicePlumberApi, ServicePlumberApi>();
builder.Services.AddScoped<IPlumberApiClient, PlumberApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
