using System;
using System.Collections.Generic;

namespace Vetrinaria.Models;

public partial class Dueño
{
    public int IdDueños { get; set; }

    public string? Nombre { get; set; }

    public int? Telefono { get; set; }

    public int? IdMascotas { get; set; }
}
