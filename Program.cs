
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});


builder.Services.AddDbContext<BancoDeDados>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "APIs relacionadas com EF + Swagger");
app.MapClientesApi();
app.MapEnderecosApi();
app.MapPizzaApi();
app.MapPedidoApi();
app.MapItemPedidoApi();

app.Run();