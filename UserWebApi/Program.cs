using UserWebApi.Data;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Service;
using UserWebApi.Controllers;
using UserWebApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Exchange.WebServices.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddTransient<IUser,UserRepository>();
builder.Services.AddTransient<IRefreshToken, RefreshTokenService>();

builder.Services.AddTransient<IRole, RoleRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<UserDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString2")));
builder.Services.AddSwaggerGen(options =>
{ 
      options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
      {
          Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
          In = ParameterLocation.Header,
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey
      });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:SecretKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
builder.Services.AddDistributedMemoryCache(); // Cấu hình bộ nhớ cache cho phiên làm việc
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "YourSessionCookieName"; // Tên cookie phiên làm việc
    options.IdleTimeout = TimeSpan.FromMinutes(500000000); // Thời gian phiên làm việc không hoạt động trước khi hết hạn
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

app.UseSession();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
