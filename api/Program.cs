using api.Data;
using api.Interfaces;
using api.Repository;
using api.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo{
        Version = "v1",
        Title= "ArtGalleryApi",
        Description= "An api for artgallery"
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Map the interfaces with its repo
builder.Services.AddScoped<IArtPieceRepository, ArtPieceRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IHarvardMuseuemApiRepository, HarvardMuseumService>();
builder.Services.AddHttpClient<IHarvardMuseuemApiRepository, HarvardMuseumService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ArtGalleryApi V1"); 
    });
}

app.UseHttpsRedirection();
//Map the controllers
app.MapControllers();

app.Run();
