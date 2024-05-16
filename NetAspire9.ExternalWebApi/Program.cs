using NetAspire9.ExternalWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisOutputCache("redis");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
    builder =>
    {
      builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();
//app.UseOutputCache();
app.UseCors("AllowAll");

app.UseOutputCache();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterWebApi();

app.Run();
