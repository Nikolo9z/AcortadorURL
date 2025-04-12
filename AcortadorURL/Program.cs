using AcortadorURL.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Cargar configuración desde JSON si está disponible
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// 🔐 Obtener cadena de conexión desde configuración o variable de entorno
var connectionString = builder.Configuration.GetConnectionString("MyDatabaseConnectionString") 
                       ?? Environment.GetEnvironmentVariable("MY_DATABASE_CONNECTION_STRING");

// ✅ Registrar servicios propios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<OriginalURL>();
builder.Services.AddScoped<InsertURL>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// 🔧 Configuración del middleware
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseCors("PoliticaCors");
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "API funcionando desde Docker! v1");

app.Run();
Console.WriteLine($"➡️  Entorno actual: {builder.Environment.EnvironmentName}");

