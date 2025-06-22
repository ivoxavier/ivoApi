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
            // Assumindo que o DbSet no seu MKReportsDbContext se chama "TbConfigApps"
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
        group.MapPost("/", async (CreateConfigAppDto configDto, MKReportsDbContext db) =>
        {
            
            if (!MiniValidator.TryValidate(configDto, out var errors))
            {
                return Results.ValidationProblem(errors);
            }

            // 4. Map the valid DTO to your database entity
            var newConfig = new TbConfigApp
            {
                ReportName = configDto.ReportName,
                PathIn = configDto.PathIn,
                PathOut = configDto.PathOut,
                FlagAtivo = configDto.FlagAtivo
            };

            db.TbConfigApps.Add(newConfig);
            await db.SaveChangesAsync();
            return Results.Created($"/api/TbConfigApp/{newConfig.ReportName}", newConfig);
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