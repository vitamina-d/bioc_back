using Application;
using Domain;
using Infrastructure.Query;
using Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => {
                          policy
                          .WithOrigins("http://host.docker.internal:5173")
                          .WithOrigins("http://localhost:5173")
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
builder.Services.AddHttpClient<INcbiClient, NcbiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_URL:NCBI_BLAST"]);
});


builder.WebHost.UseUrls("http://0.0.0.0:8081");
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
