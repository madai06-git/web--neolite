using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class FacturasPago
{
    public int FacturaId { get; set; }

    public DateTime? FechaFacturacion { get; set; }

    public decimal? MontoTotal { get; set; }

    public int? OrdenId { get; set; }

    public virtual OrdenesTrabajo? Orden { get; set; }
}
