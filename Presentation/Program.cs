using Application;
using Infrastructure.Query;
using Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

//secret
builder.Configuration.AddUserSecrets<Program>();

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
builder.Services.AddScoped<IServiceNcbi, ServiceNcbi>();
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

var NS_API_KEY = builder.Configuration["NeuroSnap:API_KEY"];

builder.Services.AddHttpClient<INeurosnapClient, NeurosnapClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["API_URL:NEUROSNAP"]);
    //client.DefaultRequestHeaders.Add("X-API-KEY", NS_API_KEY);
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
