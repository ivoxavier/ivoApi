using System;
using System.Collections.Generic;

namespace ivoApi.Models;

public partial class TbMonthSalesSale
{
    public int Id { get; set; }

    public int? Consultora { get; set; }

    public string? MesVenda { get; set; }

    public decimal? ValorVenda { get; set; }

    public DateOnly? ExtractionDate { get; set; }
}
