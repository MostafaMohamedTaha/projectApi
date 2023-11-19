#region imports

using core.repo;
using Microsoft.EntityFrameworkCore;
using projectApi.Helpers;
using repo.data;
#endregion

#region define builder

var builder = WebApplication.CreateBuilder(args);
#endregion

#region service

builder.Services.AddControllers();
#region db
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
});
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region scope
//builder.Services.AddScoped<IGenericRepo<Product>,GenericRepo<Product>>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
#endregion

#region mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

#region builder

var app = builder.Build();
#endregion

#region database auto update
//Context dbContext = new Context();
//await dbContext.MigrateAsync();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
//show exception when testing not in the package manager console
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{

    var dbContext = services.GetRequiredService<Context>();
    await dbContext.Database.MigrateAsync();
    await ContextSeed.SeedAsync(dbContext);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "error occured during the migration");
}
#endregion

#region environment

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#endregion


#region middle ware

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();
