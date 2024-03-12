using NetAspireTest.ExternalWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisOutputCache("rediscache");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
var app = builder.Build();

app.MapDefaultEndpoints();

app.UseOutputCache();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.RegisterWebApi();

app.UseHttpsRedirection();

app.Run();
