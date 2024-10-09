using Microsoft.AspNetCore.Http.HttpResults;
using ProjetoRabbitMQ.Relatorios;

namespace ProjetoRabbitMQ.Controllers;

internal static class ApiEndpoints
{
    public static void AddApiEndpoints(this WebApplication app)
    {
        app.MapPost("solicitar-relatorio/{name}", (string name) =>
        {
            var solicitacao = new SolicitacaoRelatorio()
            {
                Id = Guid.NewGuid(),
                Nome = name,
                Status = "Pendente",
                ProcessedTime = null
            };
            
            Lista.Relatorios.Add(solicitacao);

            return Results.Ok(solicitacao);
        });

        app.MapGet("relatorios", () => Lista.Relatorios);
    }
}