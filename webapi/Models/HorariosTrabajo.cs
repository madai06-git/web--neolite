using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class HorariosTrabajo
{
    public int HorarioId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? HoraEntrada { get; set; }

    public TimeSpan? HoraSalida { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
