using MongoDB.Driver;
using PhoneBook.Report.Application;
using PhoneBook.Report.Infrastructure;
using PhoneBook.Report.Infrastructure.Persistence.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDBSettings")
);

builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings =  builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
    var client = new MongoClient(settings.Connection);
    return client.GetDatabase(settings.DatabaseName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();