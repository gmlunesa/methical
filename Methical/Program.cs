using Methical.Services;
using Methical.Settings;
using Microsoft.Extensions.Configuration;

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var policyName = "AllowAllPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader();
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Methical API", Version = "v1" });
});

builder.Services.AddHttpClient();

if(builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

if(builder.Environment.IsProduction())
{
    Console.WriteLine("Production");
    var secretClient = new SecretClient(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new DefaultAzureCredential());
    builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
}
builder.Services.Configure<MLPlatformSettings>(builder.Configuration.GetSection("MLPlatform"));

builder.Services.AddScoped<IProfileService, ProfileService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Methical API v1");
    c.RoutePrefix = String.Empty;
});

app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
