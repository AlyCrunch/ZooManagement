using Microsoft.OpenApi.Models;
using ZooManagement;
using ZooAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var zoo = new ZooManager(new FSDataSource());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zoo API", Description = "Zoo management that's pawsitively profitable", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zoo API V1");
});

app.MapGet("/", () => new ZooModel(zoo));

app.MapGet("/species", (string? diet) 
    => SpeciesHelper.GetListSpecies(zoo, diet));
app.MapGet("/species/{species}", (string species) 
    => SpeciesHelper.GetListAnimalsBySpecies(zoo, species));
app.MapGet("/species/{species}/animals/{name}", (string species, string name) 
    => SpeciesHelper.GetListAnimalsBySpecies(zoo, species));

app.Run();
