using AcortadorURL.Data;

var builder = WebApplication.CreateBuilder(args);

// Carga configuración desde archivos (opcional, para entorno local)
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Prioriza variable de entorno en producción, o usa config local en desarrollo
var connectionString =
    Environment.GetEnvironmentVariable("MY_DATABASE_CONNECTION_STRING") // Render
    ?? builder.Configuration.GetConnectionString("MyDatabaseConnectionString"); // Local

builder.Services.AddSingleton(connectionString);


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
app.MapGet("/env", () =>
{
    var envConn = Environment.GetEnvironmentVariable("MY_DATABASE_CONNECTION_STRING");
    return Results.Ok(new { connection = envConn });
});
app.Run();
Console.WriteLine($"➡️  Entorno actual: {builder.Environment.EnvironmentName}");

