using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SubjectDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString2")));
builder.Services.AddTransient<ISubjectNofitication, SubjectNoficationRepository>();
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<ILessionRepository, LessionRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IAnswerRepository, AnswerRepository>();
builder.Services.AddTransient<IClassrepository, ClassRepository>();
builder.Services.AddTransient<IResourcesRepository,ResourcesRepostiory>();
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
