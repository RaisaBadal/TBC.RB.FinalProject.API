using RB.TBC.FinalProjectAPI.InterfaceServices;
using RB.TBC.FinalProjectAPI.Persistance;
using RB.TBC.FinalProjectAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SmtpService>();
builder.Services.AddScoped<IContactUsService,ContactUsService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
