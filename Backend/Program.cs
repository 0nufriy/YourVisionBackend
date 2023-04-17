using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Backend.Infrastructure.Data;
using Backend.Core.Interfaces;
using Backend.Core.Services;


var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("Default");


// Add services to the container.
builder.Services.AddTransient<IAudienceService, AudienceService>();
builder.Services.AddTransient<IEmotionService, EmotionService>();
builder.Services.AddTransient<ISessionService, SessionService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(connection));


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

