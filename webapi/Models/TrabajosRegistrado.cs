using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class TrabajosRegistrado
{
    public int TrabajoId { get; set; }

    public int? EmpleadoId { get; set; }

    public string? TipoRestauracion { get; set; }

    public string? NumeroNota { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
