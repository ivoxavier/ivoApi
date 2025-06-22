using System;
using System.Collections.Generic;

namespace ivoApi.Models;

public partial class TbMonthSalesConsultant
{
    public int Id { get; set; }

    public string? Filial { get; set; }

    public int? ConsultantNumber { get; set; }

    public string? Nome { get; set; }

    public string? Nivel { get; set; }

    public string? Status { get; set; }

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataUltimaEncomenda { get; set; }

    public string? RecrutadoraNum { get; set; }

    public DateOnly? ExtractionDate { get; set; }
}
