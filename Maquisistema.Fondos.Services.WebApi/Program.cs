using Maquisistema.Fondos.Services.WebApi.Modules.Mapper;
using Maquisistema.Fondos.Services.WebApi.Modules.Injection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddHttpClient("DiscountApi", (client) => {
    client.BaseAddress = new Uri("https://6384e0283fa7acb14f036f8c.mockapi.io");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Fernando
builder.Services.AddMapper();
builder.Services.AddInjection(builder.Configuration);





var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { };
