using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using Woz.BevragenMock.Logging;
using Woz.BevragenMock.ProblemJson;
using Woz.BevragenMock.Repositories;
using Woz.BevragenMock.Validators;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting WOZ Bevragen Mock");

    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseSerilog(SerilogHelpers.Configure(Log.Logger));

    // Add services to the container.

    builder.Services.AddHttpContextAccessor()
                    .AddControllers()
                    .ConfigureInvalidModelStateHandling()
                    .AddNewtonsoftJson();
    builder.Services.AddFluentValidationAutoValidation(options => options.DisableDataAnnotationsValidation = true)
                    .AddValidatorsFromAssemblyContaining<ZoekQueryValidator>();

    builder.Services.AddScoped<WozObjectRepository>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSerilogRequestLogging();

    app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "WOZ Bevragen Mock terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}