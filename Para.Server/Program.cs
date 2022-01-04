global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Para.Server.Contracts;
using Para.Server.Data;
using Para.Shared;
using System.Text;
using Para.Server.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Para.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var persistenceSettings = builder.Configuration.GetSection("RavenDbSettings");
var jwtToke = builder.Configuration.GetSection("TokenSettings:Token").Value;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddSingleton<IRavenDbContext, RavenDbContext>();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped(typeof(IStoryRepository<>), typeof(StoryRepository<>));

//builder.Services.Configure<PersistenceSettings>(persistenceSettings);
//builder.Services.AddSingleton(typeof(IRepository<>), typeof(DbContext));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUtilityService, UtilityService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtToke)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                });
// other code omitted for brevity
//builder.Services.AddOidcAuthentication(options =>
//{
//    builder.Configuration.Bind("Auth0", options.ProviderOptions);
//    options.ProviderOptions.ResponseType = "code";
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        //builder.AllowAnyOrigin();
        builder.WithOrigins("https://localhost:7054", "http://localhost:5054", "https://localhost:7267", "http://localhost:5267", "https://youtu.be/J1kTt0eTiwA");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();
//app.UseAuthentication();

app.MapControllers();

app.Run();
