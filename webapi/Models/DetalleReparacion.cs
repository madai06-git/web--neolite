using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class DetalleReparacion
{
    public int DetalleId { get; set; }

    public string? DescripcionProblema { get; set; }

    public string? MaterialesNecesarios { get; set; }

    public decimal? CostoEstimado { get; set; }

    public int? OrdenId { get; set; }

    public virtual ICollection<HistorialReparacione> HistorialReparaciones { get; set; } = new List<HistorialReparacione>();

    public virtual OrdenesTrabajo? Orden { get; set; }
}
