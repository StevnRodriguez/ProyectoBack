using System;
using System.Collections.Generic;

namespace Vetrinaria.Models;

public partial class Comida
{
    public int IdComida { get; set; }

    public string? Marca { get; set; }

    public int? Cantidad { get; set; }

    public int? Precio { get; set; }
}
