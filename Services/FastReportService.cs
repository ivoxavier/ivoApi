

using FastReport;
using FastReport.Export.PdfSimple; 
using System.IO; // 

public class FastReportService : IReportGeneratorService
{
    private readonly ILogger<FastReportService> _logger;

    public FastReportService(ILogger<FastReportService> logger)
    {
        _logger = logger;
    }

    // A assinatura do método foi atualizada
    public async Task<string> GenerateReportAsync(string reportName, string inputPath)
    {
        _logger.LogInformation("Iniciando geração de relatório em memória: {ReportName}", reportName);

        try
        {
            // O código do FastReport é síncrono, então mantemos o Task.Run
            return await Task.Run(() =>
            {
                var reportTemplatePath = Path.Combine(inputPath, $"{reportName}.frx");
                if (!File.Exists(reportTemplatePath))
                {
                    _logger.LogError("Arquivo de template do relatório não encontrado: {TemplatePath}", reportTemplatePath);
                    throw new FileNotFoundException("Arquivo de template do relatório não encontrado.", reportTemplatePath);
                }

                using var report = new Report();
                report.Load(reportTemplatePath);
                report.Prepare();

                var pdfExport = new PDFSimpleExport();
                
                // 1. Criar um MemoryStream para receber o PDF
                using var ms = new MemoryStream();
                
                // 2. Exportar o relatório para o MemoryStream em vez de um arquivo
                report.Export(pdfExport, ms);

                // 3. Converter os bytes do MemoryStream para uma string Base64
                var base64String = Convert.ToBase64String(ms.ToArray());
                
                _logger.LogInformation("Relatório gerado em Base64 com sucesso. Tamanho: {Length} caracteres.", base64String.Length);

                // 4. Retornar a string
                return base64String;
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Falha ao gerar relatório com FastReport para Base64.");
            throw;
        }
    }
}