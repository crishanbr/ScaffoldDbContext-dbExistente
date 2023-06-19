using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Avione
{
    public int AvionId { get; set; }

    public string Modelo { get; set; } = null!;

    public int Capacidad { get; set; }

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
