using ClientServices;
using ModelsLibrary.Configurations;

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

builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection(ApiConfiguration.SectionName));

builder.Services.AddScoped<IYouTubeClientService, YouTubeClientService>();

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
