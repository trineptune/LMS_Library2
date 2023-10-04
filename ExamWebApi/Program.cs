using ExamWebApi.Data;
using ExamWebApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IExamRepository,ExamRepository>();
builder.Services.AddTransient<IExamEssayRepository,ExamEssayRepository>();
builder.Services.AddTransient<IExamContentRepository,ExamContentRepository>();
builder.Services.AddTransient<IExamAnswerRepository,ExamAnswerRepository>();


builder.Services.AddDbContext<ExamDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString2")));

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
