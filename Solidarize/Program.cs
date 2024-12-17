using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces;
using Solidarize.Application.Services;
using Solidarize.Infrastructure.Interfaces;
using Solidarize.Infrastructure.Mappers;
using Solidarize.Infrastructure.Repositories;
using Solidarize.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDonorServices, DonorServices>();
builder.Services.AddScoped<ISeasonServices, SeasonServices>();
builder.Services.AddScoped<IDonationServices, DonationServices>();
builder.Services.AddScoped<IReportServices, ReportServices>();

// Add repositories
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

//Add mappers
builder.Services.AddAutoMapper(typeof(DonorMapper));
builder.Services.AddAutoMapper(typeof(SeasonMapper));
builder.Services.AddAutoMapper(typeof(DonationMapper));

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SolidarizeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConectionStr")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
