using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public string? Rol { get; set; }

    public string? Contacto { get; set; }

    public decimal? Comision { get; set; }

    public virtual ICollection<TrabajosRealizado> TrabajosRealizados { get; set; } = new List<TrabajosRealizado>();

    public virtual ICollection<TrabajosRegistrado> TrabajosRegistrados { get; set; } = new List<TrabajosRegistrado>();
}
