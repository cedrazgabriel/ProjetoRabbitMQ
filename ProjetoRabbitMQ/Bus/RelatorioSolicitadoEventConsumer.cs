using MassTransit;
using ProjetoRabbitMQ.Relatorios;

namespace ProjetoRabbitMQ.Bus;

internal sealed class RelatorioSolicitadoEventConsumer : IConsumer<RelatorioSolicitadoEvent>
{
    private readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;
    
    public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
    {
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("Processando relatório solicitado {Id}, Nome: {Nome}", context.Message.Id, context.Message.Name); 
      
        await Task.Delay(10000);

        var relatorio = Lista.Relatorios.FirstOrDefault(x => x.Id == message.Id);

        if (relatorio != null)
        {
            relatorio.Status = "Processado";
            relatorio.ProcessedTime = DateTime.Now;
        }
        
       _logger.LogInformation("Relatório {Id} processado com sucesso", context.Message.Id);
    }
}