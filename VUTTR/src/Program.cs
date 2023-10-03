using Microsoft.EntityFrameworkCore;
using VUTTR.Endpoints.Tools;
using VUTTR.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:VUTTRDb"]);

Console.WriteLine("Done");

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

//TOOLS API
app.MapMethods(ToolsGetAll.Template, ToolsGetAll.Methods, ToolsGetAll.Handle);

// Create a scope to access services.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>(); // Replace 'YourDbContext' with your actual DbContext class
        dbContext.Database.Migrate();
        // You can also add code here to seed your database if needed.
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
    }
}

app.Run();