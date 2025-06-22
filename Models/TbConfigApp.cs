using System;
using System.Collections.Generic;

namespace ivoApi.Models;

public partial class TbConfigApp
{
    public int Id { get; set; }

    public string? ReportName { get; set; }

    public string? PathIn { get; set; }

    public string? PathOut { get; set; }

    public int? FlagAtivo { get; set; }
}
