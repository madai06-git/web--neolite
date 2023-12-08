using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Puesto
{
    public int PuestoId { get; set; }

    public string? Nombre { get; set; }

    public decimal? Comision { get; set; }
}
