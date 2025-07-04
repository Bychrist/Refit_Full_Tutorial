using Refit;
using Refit_tutorial.Model_Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var jsonSettings = new Newtonsoft.Json.JsonSerializerSettings
{
    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
    Formatting = Newtonsoft.Json.Formatting.Indented
};

builder.Services.AddRefitClients();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();
