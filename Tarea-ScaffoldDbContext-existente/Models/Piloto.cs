using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Piloto
{
    public int PilotoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Licencia { get; set; } = null!;

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
