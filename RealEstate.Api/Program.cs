using RealEstate.Application.Properties;
using RealEstate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<GetPropertyHandler>();
builder.Services.AddScoped<ListPropertiesHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("web", policy =>
        policy
            .WithOrigins(
                "http://localhost:3000",           
                "https://real-estate-million.netlify.app/"      
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            // .AllowCredentials() // solo si usas cookies/sesión; si no, quítalo
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

// Habilitar Swagger en todos los entornos
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstate API v1");
    c.RoutePrefix = "swagger"; // URL: /swagger
});


// Solo usar HTTPS redirection en producción
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("web");

app.MapGet("/", () => "API conectada a Mongo Atlas ✔️");

// Mapear controllers
app.MapControllers();

await app.RunAsync();
