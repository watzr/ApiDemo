using ClientServices;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using ModelsLibrary.Configurations;
using ModelsLibrary.YouTubeModels;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IYouTubeClientService, YouTubeClientService>("YouTubeApi", client =>
{
    client.BaseAddress = new Uri(@"https://www.googleapis.com/youtube/v3");
    client.Timeout = TimeSpan.FromSeconds(60);
});

RegisterCustomLibrary(builder);

builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection(ApiConfiguration.SectionName));
builder.Services.AddScoped<IYouTubeClientService, YouTubeClientService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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


static void RegisterCustomLibrary(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<YouTubeAnalyzerContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["Connection:ConnectionString"]);
    });
    var serviceProvider = builder.Services.BuildServiceProvider();
    var youTubeAnalyzerContext = serviceProvider.GetService<YouTubeAnalyzerContext>();

    if (youTubeAnalyzerContext == null)
    {
        throw new ArgumentNullException(nameof(youTubeAnalyzerContext));
    }

    builder.Services.AddScoped<IDbContext, CustomDbContext>(_ => new CustomDbContext(youTubeAnalyzerContext));
}