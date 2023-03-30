using System;
using System.Collections.Generic;

namespace OrmAlmacen.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descipción { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

}
