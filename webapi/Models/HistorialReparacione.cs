using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class HistorialReparacione
{
    public int HistorialId { get; set; }

    public DateTime? FechaReparacion { get; set; }

    public int? OrdenId { get; set; }

    public int? DetalleId { get; set; }

    public virtual DetalleReparacion? Detalle { get; set; }

    public virtual OrdenesTrabajo? Orden { get; set; }
}
