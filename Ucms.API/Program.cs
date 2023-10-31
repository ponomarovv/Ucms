using Ucms.DAL.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Add secrets configuration
builder.Configuration.AddUserSecrets<Program>();


// Add services to the container.
builder.Services.AddSingleton<DatabaseSeeder>();
builder.Services.InstallRepositories();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var serviceProvider = builder.Services.BuildServiceProvider();
var databaseSeeder = serviceProvider.GetRequiredService<DatabaseSeeder>();
databaseSeeder.SeedDatabase();
// builder.Services.SeedData();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
