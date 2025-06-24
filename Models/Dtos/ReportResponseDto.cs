// Dentro de /Models/Dtos/ReportResponseDto.cs (ou onde preferir)

public class ReportResponseDto
{
    /// <summary>
    /// Um nome de arquivo sugerido para o cliente.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// O conteúdo do arquivo em formato Base64.
    /// </summary>
    public string FileContentsBase64 { get; set; }
}