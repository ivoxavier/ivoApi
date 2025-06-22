using System;
using System.Collections.Generic;

namespace ivoApi.Models;

public partial class TbConfigUtilizador
{
    public int Id { get; set; }

    public int? CNumero { get; set; }

    public string? CNome { get; set; }

    public bool? CConsultora { get; set; }

    public bool? CLiderEquipa { get; set; }

    public bool? CDiretoraIndependente { get; set; }

    public bool? CDiretoraNacional { get; set; }

    public int? CUnidade { get; set; }
}
