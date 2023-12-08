using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class CategoriasServicio
{
    public int CategoriaId { get; set; }

    public string? NombreCategoria { get; set; }

    public string? Descripcion { get; set; }
}
