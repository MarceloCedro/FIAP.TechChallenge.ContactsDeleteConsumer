using ContactsDeleteConsumer.Api.Events;
using ContactsDeleteConsumer.Api.IoC;
using MassTransit;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.Dev.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                         .AddJsonFile("appsettings.json", false, true)
                                                         .AddJsonFile($"appsettings.Dev.json", true, true)
                                                         .AddEnvironmentVariables()
                                                         .Build();

builder.Services.AddDependencyResolver(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddHealthChecks().ForwardToPrometheus();

var queue = configuration.GetSection("MassTransit:QueueName").Value ?? string.Empty;
var server = configuration.GetSection("MassTransit:Server").Value ?? string.Empty;
var user = configuration.GetSection("MassTransit:User").Value ?? string.Empty;
var password = configuration.GetSection("MassTransit:Password").Value ?? string.Empty;

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(server, "/", h =>
        {
            h.Username(user);
            h.Password(password);
        });

        cfg.ReceiveEndpoint(queue, e =>
        {
            e.ConfigureConsumer<ContactDeleteConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });

    x.AddConsumer<ContactDeleteConsumer>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");
app.UseHttpMetrics();
app.MapMetrics();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
