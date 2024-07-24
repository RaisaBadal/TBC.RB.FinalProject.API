using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RB.TBC.FinalProject.API.CustomMiddlwares;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.MapperProfile;
using RB.TBC.FinalProject.Application.Persistance;
using RB.TBC.FinalProject.Application.Services;
using RB.TBC.FinalProject.Domain.Data;
using RB.TBC.FinalProject.Domain.Interface;
using RB.TBC.FinalProject.Domain.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "RB  Library API",
        Description = "RB Library API is a powerful RESTful API project developed for the optimization and management of Library.\r\nThis API provides multi-functional operations and facilitates the automation of data management and analysis processes.",
        TermsOfService = new Uri("https://github.com/RaisaBadal/TBC.RB.FinalProject.API.git"),
        Contact = new OpenApiContact
        {
            Name = "Contact Me",
            Url = new Uri("https://github.com/RaisaBadal/TBC.RB.FinalProject.API.git")
        },
        License = new OpenApiLicense
        {
            Name = "License, Source Code",
            Url = new Uri("https://github.com/RaisaBadal/TBC.RB.FinalProject.API.git")
        }
    });

    opt.AddSecurityDefinition("auth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        Name = "Authorization",
        In = ParameterLocation.Header,
        Description = "Enter token here"
    });
    opt.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "auth"
                }
            },
            Array.Empty<string>()
                }
            });
});


var tokenValidator = new TokenValidationParameters
{
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Secret").Value ?? throw new ArgumentException("Security key can not be null"))),
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{

    jwt.SaveToken = true;
    jwt.TokenValidationParameters = tokenValidator;
});

builder.Services.AddDbContext<TbcDbContext>(opt =>
{
    opt.UseSqlite("Data Source=LibraryProduction.db");
});

builder.Services.AddSingleton<SmtpService>();
builder.Services.AddScoped<IContactUsService,ContactUsService>();

builder.Services.AddScoped<IFeadbackRepository, FeadbackRepository>();
builder.Services.AddScoped<IFeadbackService, FeadbackService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfileClass));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.MapControllers();

app.Run();
