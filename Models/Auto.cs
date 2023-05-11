using System;
using System.Collections.Generic;

namespace CRUDAutosv.Models;

public partial class Auto
{
    public int IdAuto { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Patente { get; set; } = null!;

    public short Anio { get; set; }
}
