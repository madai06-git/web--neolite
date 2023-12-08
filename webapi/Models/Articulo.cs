using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Articulo
{
    public int ArticuloId { get; set; }

    public string? TipoArticulo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? OtrosDetalles { get; set; }
}
