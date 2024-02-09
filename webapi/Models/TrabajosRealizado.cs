using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class TrabajosRealizado
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }

    public string? TipoRestauracion { get; set; }

    public string? NumeroNota { get; set; }

    public string? Fecha { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
