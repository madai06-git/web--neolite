using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class OrdenesTrabajo
{
    public int OrdenId { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public DateTime? FechaEntregaEstimada { get; set; }

    public string? Estado { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleReparacion> DetalleReparacions { get; set; } = new List<DetalleReparacion>();

    public virtual ICollection<FacturasPago> FacturasPagos { get; set; } = new List<FacturasPago>();

    public virtual ICollection<HistorialReparacione> HistorialReparaciones { get; set; } = new List<HistorialReparacione>();
}
