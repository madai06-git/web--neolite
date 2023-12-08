using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class InventarioMateriale
{
    public int MaterialId { get; set; }

    public string? NombreMaterial { get; set; }

    public int? CantidadStock { get; set; }

    public decimal? Precio { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Proveedore? Proveedor { get; set; }
}
