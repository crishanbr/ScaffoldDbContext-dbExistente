using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Destino
{
    public int DestinoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();
}
