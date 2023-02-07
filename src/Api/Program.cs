using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

using Microsoft.IdentityModel.Tokens;
using ProductTracking.Api.Configuration;
using ProductTracking.Api.Utils;
using ProductTracking.Core.Configuration;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Infrastructure;
using ProductTracking.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddCoreServices(builder.Configuration);


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["AppConfig:Issuer"],
    ValidAudience = builder.Configuration["AppConfig:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppConfig:ApiKey"]))
};
//builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = tokenValidationParameters;
});



string AllowedOrigins = "APIOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowedOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:8000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();


app.Logger.LogInformation("PublicApi App created...");

app.Logger.LogInformation("Seeding Database...");



using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var financeDbContext = scopedProvider.GetRequiredService<ProductTrackingDbContext>();
        var userManager = scopedProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scopedProvider.GetRequiredService<RoleManager<Role>>();
        await ProductTrackingDbContextSeed.SeedAsync(financeDbContext, userManager, roleManager, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowedOrigins);
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:8000"));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
