using Microsoft.EntityFrameworkCore;
using ZieDitAPI;
using ZieDitAPI.Data;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        corsBuilder => corsBuilder.WithOrigins("http://127.0.0.1:5500")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IPosterRepository, PosterRepository>();
builder.Services.AddScoped<IPresenterRepository, PresenterRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseCors("MyCorsPolicy");

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
