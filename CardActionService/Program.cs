using CardActionService.Interfaces.Rules;
using CardActionService.Interfaces.Services;
using CardActionService.Rules;
using CardActionService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IAllowedActionService, AllowedActionService>();
builder.Services.AddSingleton<IActionRule, BlockedNoPinRule>();
builder.Services.AddSingleton<IActionRule, RemoveAction6IfNoPinRule>();
builder.Services.AddSingleton<IActionRule, RemoveAction7IfNoPinRule>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
