// Dentro de /Services/IReportGeneratorService.cs (ATUALIZADO)

public interface IReportGeneratorService
{
    /// <summary>
    /// Gera um relatório Jasper e o retorna como uma string Base64.
    /// </summary>
    /// <param name="reportName">O nome do arquivo de relatório .frx (sem a extensão).</param>
    /// <param name="inputPath">O caminho onde o arquivo .frx está localizado.</param>
    /// <returns>Uma string contendo o PDF em formato Base64.</returns>
    Task<string> GenerateReportAsync(string reportName, string inputPath);
}