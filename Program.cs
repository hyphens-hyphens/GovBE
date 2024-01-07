using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using GovBE.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UserLoginBE.Context;
using UserLoginBE.Services;
using UserLoginBE.Configures;
using Serilog.Events;
using Serilog;
using GovBE.Commons;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GovBE_Database")
    ?? throw new Exception("Can't not get connection string");
builder.Services.ConfigureIdentity();
builder.Services
    .AddDbContext<GovBE_DatabaseContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)))
    .AddDbContext<UserLoginContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Add services to the container.
//DI
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DA-PPLTHD",
        Version = "v1",
        Description = "DA-PPLTHD"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var jwt = builder.Configuration.GetSection("jwtBearer");
    o.TokenValidationParameters = new TokenValidationParameters
    {

        ValidIssuer = builder.Configuration["jwtBearer:Issuer"],
        ValidAudience = builder.Configuration["jwtBearer:Audience"],
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtBearer:SigningKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(op => op.AddPolicy(name: "angularApp", policy =>
{
    policy.WithOrigins("http://localhost:4200, http://localhost:4201").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    policy.SetIsOriginAllowedToAllowWildcardSubdomains();
}));



Serilog.Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    // Filter out ASP.NET Core infrastructre logs that are Information and below
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("my-logs/log.txt", rollingInterval: RollingInterval.Minute, rollOnFileSizeLimit: true)
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.MySQL(connectionString, "Logs")
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Host.UseSerilog();

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<UserLoginContext>();
    dbContext.Database.EnsureCreated();
    // Here is the migration executed
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging(opts
        => opts.EnrichDiagnosticContext = LogHelperr.EnrichFromRequest);
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("angularApp");

app.MapControllers();
app.Run();
