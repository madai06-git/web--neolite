using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public string? Rol { get; set; }

    public string? Contacto { get; set; }

    public virtual ICollection<HorariosTrabajo> HorariosTrabajos { get; set; } = new List<HorariosTrabajo>();
}
