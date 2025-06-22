using System;
using System.Collections.Generic;

namespace ivoApi.Models;

public partial class TbConsultora
{
    public int Id { get; set; }

    public int? ConsultoraNum { get; set; }

    public string? ConsultoraNome { get; set; }

    public string? ConsultoraEmail { get; set; }

    public string? ConsultoraTelefone { get; set; }

    public DateOnly? DataInicio { get; set; }

    public string? RecrutadoraNum { get; set; }

    public string? ConsultoraRecrutadoraNome { get; set; }

    public int? NumeroUnidade { get; set; }

    public DateOnly? ExtractionDate { get; set; }
}
