using System;
using System.Collections.Generic;

namespace Vetrinaria.Models;

public partial class Mascota
{
    public int IdMascotas { get; set; }

    public string? Nombre { get; set; }

    public string? Raza { get; set; }

    public int? IdDueño { get; set; }
}
