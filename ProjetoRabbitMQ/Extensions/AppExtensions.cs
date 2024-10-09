using MassTransit;

namespace ProjetoRabbitMQ.Extensions;

internal static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((context, configuration) =>
            {
                configuration.Host(new Uri("amqp://localhost:5672"), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
                
                configuration.ConfigureEndpoints(context);
            });
        });
    }
}