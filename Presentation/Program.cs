using Application.UseCase;
using Domain.Interfaces;
using Infrastructure.Query;
using Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => {
                          policy
                          .WithOrigins("https://vitamina-d.github.io")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceNcbi, ServiceNcbi>();
builder.Services.AddScoped<IServiceUniprot, ServiceUniprot>();
builder.Services.AddScoped<IServicePlumberApi, ServicePlumberApi>();
builder.Services.AddScoped<IServiceBlast, ServiceBlast>();
builder.Services.AddScoped<IServiceFolding, ServiceFolding>();
builder.Services.AddScoped<IServicePython, ServicePython>();

builder.Services.AddHttpClient<IPublicApiClient, PublicApiClient>();
builder.Services.AddHttpClient<IPlumberApiClient, PlumberApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_URL:PLUMBER"]);
});
builder.Services.AddHttpClient<IBlastClient, BlastClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_URL:BLAST"]);
});
builder.Services.AddHttpClient<IPythonClient, PythonClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_URL:BIOPYTHON"]);
});

builder.Services.AddHttpClient<INeurosnapClient, NeurosnapClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_URL:NEUROSNAP"]);
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
