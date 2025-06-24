// Dentro de /Endpoints/TbConfigAppEndpoints.cs

using Microsoft.EntityFrameworkCore;
using ivoApi.Models.Dtos;
using ivoApi.Models;
using MiniValidation;

public static class TbConfigAppEndpoints
{
    public static void MapTbConfigAppEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/TbConfigApp").WithTags("TbConfigApp");

        // GET /api/TbConfigApp
        group.MapGet("/", async (MKReportsDbContext db) =>
        {
            
            return await db.TbConfigApps.ToListAsync();
        })
        .WithName("GetAllTbConfigApps");

        // GET /api/TbConfigApp/{id}
        group.MapGet("/{id}", async (int id, MKReportsDbContext db) =>
        {
            return await db.TbConfigApps.FindAsync(id)
                is TbConfigApp model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetTbConfigAppById");

        // POST /api/TbConfigApp
        group.MapPost("/", async (
    CreateConfigAppDto configDto, 
    MKReportsDbContext db, 
    IReportGeneratorService reportGenerator) =>
{
    if (!MiniValidator.TryValidate(configDto, out var errors))
    {
        return Results.ValidationProblem(errors);
    }

    // A lógica de salvar no banco continua a mesma
    var newConfig = new TbConfigApp
    {
        ReportName = configDto.ReportName,
        PathIn = configDto.PathIn,
        PathOut = configDto.PathOut, // Pode ser nulo/vazio agora se não for mais usado
        FlagAtivo = configDto.FlagAtivo
    };

    db.TbConfigApps.Add(newConfig);
    await db.SaveChangesAsync();

    //logger.LogInformation("Configuração de relatório salva com ID: {Id}", newConfig.Id);

    try
    {
        // 1. Chama o serviço e obtém a string Base64
        var base64Pdf = await reportGenerator.GenerateReportAsync(
            newConfig.ReportName, 
            newConfig.PathIn
            // O outputPath não é mais necessário aqui
        );

        // 2. Prepara o objeto de resposta
        var responseDto = new ReportResponseDto
        {
            FileName = $"{newConfig.ReportName}.pdf",
            FileContentsBase64 = base64Pdf
        };

        // 3. Retorna '200 OK' com o JSON contendo o arquivo
        return Results.Ok(responseDto);
    }
    catch (Exception ex)
    {
        //logger.LogError(ex, "A configuração foi salva, mas a geração do relatório em Base64 falhou para '{ReportName}'.", newConfig.ReportName);
        
        return Results.Problem(
            detail: $"A configuração foi salva (ID: {newConfig.Id}), mas a geração do relatório falhou. Erro: {ex.Message}",
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
})
.WithName("CreateTbConfigApp");

        // PUT /api/TbConfigApp/{id}
        group.MapPut("/{id}", async (int id, CreateConfigAppDto inputDto, MKReportsDbContext db) =>
        {

            // We can reuse the same DTO for updating
            if (!MiniValidator.TryValidate(inputDto, out var errors))
            {
                return Results.ValidationProblem(errors);
            }

            var configApp = await db.TbConfigApps.FindAsync(id);

            if (configApp is null) return Results.NotFound();

            // Update the properties of the existing entity
            configApp.ReportName = inputDto.ReportName;
            configApp.PathIn = inputDto.PathIn;
            configApp.PathOut = inputDto.PathOut;
            configApp.FlagAtivo = inputDto.FlagAtivo;

            await db.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithName("UpdateTbConfigApp");

        // DELETE /api/TbConfigApp/{id}
        group.MapDelete("/{id}", async (int id, MKReportsDbContext db) =>
        {
            if (await db.TbConfigApps.FindAsync(id) is TbConfigApp configApp)
            {
                db.TbConfigApps.Remove(configApp);
                await db.SaveChangesAsync();
                return Results.Ok(configApp);
            }

            return Results.NotFound();
        })
        .WithName("DeleteTbConfigApp");
    }
}