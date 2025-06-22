using System;
using System.Collections.Generic;

namespace ivoApi.Models;

public partial class TbEscadaSucesso
{
    public int Id { get; set; }

    public int? EscadaSucessoNumConsultora { get; set; }

    public string? EscadaSucessoNomeConsultora { get; set; }

    public string? EscadaSucessoNivelCarreira { get; set; }

    public int? EscadaSucessoTotalNovasConsultoras { get; set; }

    public int? EscadaSucessoTotalNovasConsultorasQualificadas { get; set; }

    public double? EscadaSucessoTotalPrograma { get; set; }

    public int? EscadaSucessoNivelConseguido { get; set; }

    public double? EscadaSucessoPrecisaParaNivelSeguinte { get; set; }

    public string? EscadaSucessoTrimestre { get; set; }

    public DateOnly? EscadaSucessoDataExtracao { get; set; }

    public string? DataInsertDb { get; set; }
}
