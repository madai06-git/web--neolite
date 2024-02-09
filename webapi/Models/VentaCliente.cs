using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class VentaCliente
{
    public int VentaId { get; set; }

    public string? Nombre { get; set; }

    public string? Categoria { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Anticipo { get; set; }

    public string? FechaEntrada { get; set; }

    public string? FechaSalida { get; set; }
}
