using System.Collections.Specialized;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace ProjetoRabbitMQ.Relatorios;

internal static  class Lista
{
    public static List<SolicitacaoRelatorio> Relatorios = new();
}

public class SolicitacaoRelatorio
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? ProcessedTime { get; set; }
}