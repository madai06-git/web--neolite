using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string? Nombre { get; set; }

    public string? Contacto { get; set; }

    public virtual ICollection<InventarioMateriale> InventarioMateriales { get; set; } = new List<InventarioMateriale>();
}
